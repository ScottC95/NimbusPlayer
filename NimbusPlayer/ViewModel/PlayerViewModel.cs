using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.IO;
using NimbusPlayer.Model;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Imaging;
using NimbusPlayer.Properties;

namespace NimbusPlayer.ViewModel
{
    class PlayerViewModel : ViewModelBase
    {
        private ObservableCollection<SongViewModel> _songCollection;
        private ObservableCollection<SongViewModel> _playlist;
        private ObservableCollection<Album> _albums;
        private MediaPlayer _currentPlayer;
        private int _currentSongID;
        private SongViewModel _currentSong;
        private Timer _songTimer;
        private bool _isPlaying;
        private double _volume;
        private List<int> indexList;
        private RelayCommand _playCommand, _pauseCommand, _skipForwardCommand, _skipBackwardCommand;

        public bool IsSeeking;

        public ObservableCollection<SongViewModel> SongCollection
        {
            get
            {
                return _songCollection;
            }
        }

        public ObservableCollection<SongViewModel> Playlist
        {
            get
            {
                return _playlist;
            }
        }

        public ObservableCollection<Album> Albums
        {
            get
            {
                if (_songCollection != null)
                {
                    return new ObservableCollection<Album>(GetAlbumDetails(_songCollection));
                }
                return _albums;
            }
        }

        public Uri AlbumArt
        {
            get
            {
                if (Albums.Any() && _currentPlayer != null)
                {
                    //Consolidate this down to just saving to list as BitmapImage
                    var path = Albums.Where(x => x.AlbumName == CurrentSong.Album).Select(x => x.AlbumArtDir).First();
                    return new Uri(path); 
                }
                return null;
            }
        }

        public double ProgressValue
        {
            get
            {
                if (_currentPlayer != null)
                {
                    return _currentPlayer.Position.TotalSeconds;
                }
                return 0;
            }
            set
            {
                if (_currentPlayer != null)
                {
                    _currentPlayer.Position = TimeSpan.FromSeconds(value);
                    //OnPropertyChanged(); May not work
                    OnPropertyChanged("ProgressTextValue");
                }
            }
        }

        public double TotalDuration
        {
            get
            {
                if (_currentPlayer != null && _currentPlayer.NaturalDuration.HasTimeSpan)
                {
                    return _currentPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                }
                return 0.1;
            }
        }

        public PlayerViewModel()
        {
            _songCollection = new ObservableCollection<SongViewModel>();
            _playlist = new ObservableCollection<SongViewModel>();
            string filepath = Settings.Default["MusicFilePath"].ToString();
            OpenDirectory(filepath);
        }

        public RelayCommand PlayCommand
        {
            get { return _playCommand ?? (_playCommand = new RelayCommand(PlaySong)); }
        }

        public RelayCommand PauseCommand
        {
            get { return _pauseCommand ?? (_pauseCommand = new RelayCommand(PauseSong)); }
        }

        public RelayCommand SkipForwardCommand
        {
            get { return _skipForwardCommand ?? (_skipForwardCommand = new RelayCommand(NextSong)); }
        }

        public RelayCommand SkipBackwardCommand
        {
            get { return _skipBackwardCommand ?? (_skipBackwardCommand = new RelayCommand(PreviousSong)); }
        }

        private void OpenDirectory(string path)
        {

            if (!Directory.Exists(path))
                return;

            foreach (string dir in Directory.GetDirectories(path).ToList())
            {
                try
                {
                    foreach (var file in Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories).Where(file => file.ToLower().EndsWith("mp3") ||
                                                                      file.ToLower().EndsWith("flac")).ToList())
                    {
                        AddToCollection(file);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    //Do Nothing
                }
            }
        }

        private void AddToCollection(string filePath)
        {
            if (ValidateFile(filePath))
            {
                SongCollection.Add(new SongViewModel(new Song(filePath)));
            }
        }

        private bool ValidateFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return true;
            }
            return false;
        }

        public MediaPlayer CurrentPlayer
        {
            get { return _currentPlayer; }
        }

        public SongViewModel CurrentSong
        {
            get { return _currentSong; }
            set { SetAndNotify(ref _currentSong, value); }
        }

        public bool HasSongs
        {
            get { return _playlist.Any(); }
        }

        public double Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                if (_currentPlayer != null)
                {
                    _currentPlayer.Volume = value;
                    SetAndNotify(ref _volume, value);
                    OnPropertyChanged("VolumeTextValue");
                }
            }
        }
        
        public string VolumeTextValue
        {
            get { return Volume.ToString("P0"); }
        }

        public string ProgressTextValue
        {
            get { return TimeSpan.FromSeconds(ProgressValue).ToString(@"hh\:mm\:ss"); }
        }

        public string TotalDurationTextValue
        {
            get { return TimeSpan.FromSeconds(TotalDuration).ToString(@"hh\:mm\:ss"); }
        }

        public bool IsPlaying
        {
            get { return _isPlaying; }
            set { SetAndNotify(ref _isPlaying, value); }
        }

        public void AddToPlaylist(Album album)
        {
            List<SongViewModel> songs = SongCollection.Where(s => s.Album == album.AlbumName).ToList();
            foreach (SongViewModel song in songs)
            {
                Playlist.Add(new SongViewModel(song));
            }
        }

        public void GetSelectedSong(SongViewModel s)
        {
            if (_currentPlayer != null)
            {
                if (IsPlaying)
                {
                    CurrentSong.IsPlaying = false;
                    _currentPlayer.Stop();
                }
            }

            _currentPlayer = null;
            var songID = _playlist.IndexOf(s);
            _currentSongID = songID;
            PlaySong(null);
        }

        private void PlaySong(object o)
        {
            if (!HasSongs)
                return;
            if (_currentPlayer == null)
            {
                BuildPlayer();
            }
            _currentPlayer.Play();
            CurrentSong.IsPlaying = true;
            IsPlaying = true;
        }

        private void PauseSong(object o)
        {
            if (!HasSongs || !IsPlaying || _currentPlayer == null)
                return;
            _currentPlayer.Pause();
            IsPlaying = false;
        }

        private ObservableCollection<Album> GetAlbumDetails(ObservableCollection<SongViewModel> songs)
        {
            var tracks = songs.GroupBy(s => s.Album).Select(t => t.First()).ToList();
            ObservableCollection<Album> albums = new ObservableCollection<Album>();
            foreach (SongViewModel song in tracks)
            {
                string upDir = Directory.GetParent(song.FilePath).FullName;
                if (File.Exists(upDir + "\\cover.jpg"))
                {
                    albums.Add(new Album(song.Album, upDir + "\\cover.jpg"));
                }
                else if(File.Exists(Directory.GetParent(upDir).FullName.ToString() + "\\cover.jpg"))
                {
                    albums.Add(new Album(song.Album, upDir + "\\cover.jpg"));
                }
            }
            return albums;
        }
        
        private void NextSong(object o)
        {
            if (!HasSongs)
                return;

            if (IsPlaying)
            {
                CurrentSong.IsPlaying = false;
                _currentPlayer.Stop();
            }

            if (indexList == null)
            {
                if (_currentSongID < _playlist.Count - 1)
                {
                    _currentSongID++;
                }
            }
            else
            {
                _currentSongID = indexList.IndexOf(_currentSongID++);
            }
            BuildPlayer();
            PlaySong(o);
        }

        private void PreviousSong(object o)
        {
            if (!HasSongs)
                return;
            if (IsPlaying)
            {
                CurrentSong.IsPlaying = false;
                _currentPlayer.Stop();
            }

            if (indexList == null)
            {
                if (_currentSongID > 0)
                {
                    _currentSongID--;
                }
            }
            else
            {
                _currentSongID = indexList.IndexOf(_currentSongID--);
            }
            BuildPlayer();
            PlaySong(o);
        }

        private void BuildPlayer()
        {
            if (_currentPlayer != null)
            {
                _currentPlayer.Stop();
                _currentPlayer = null;
            }

            if (HasSongs)
            {
                var currentTrack = _playlist[_currentSongID];
                CurrentSong = currentTrack;
                _currentPlayer = new MediaPlayer();
                _currentPlayer.Open(new Uri(Path.GetFullPath(currentTrack.FilePath)));
                if (_songTimer != null)
                {
                    _songTimer.Stop();
                    _songTimer.Tick -= TimerTick;
                }
                _songTimer = new Timer();
                _songTimer.Tick += TimerTick;
                _songTimer.Start();

                if (Volume.Equals(0.0))
                    Volume = _currentPlayer.Volume;
                else
                    _currentPlayer.Volume = Volume;
                OnPropertyChanged("VolumeTextValue");
                OnPropertyChanged("AlbumArt");
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (_currentPlayer != null && IsPlaying && _currentPlayer.NaturalDuration.HasTimeSpan && !IsSeeking)
            {
                OnPropertyChanged("ProgressValue");
                OnPropertyChanged("ProgressTextValue");
                OnPropertyChanged("TotalDuration");
                OnPropertyChanged("TotalDurationTextValue");
            }

            if (ProgressValue.Equals(TotalDuration))
            {
                NextSong(null);
            }
        }
    }
}
