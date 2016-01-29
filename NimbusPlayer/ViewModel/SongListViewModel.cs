using System;
using System.Collections.ObjectModel;
using NimbusPlayer.DataAccess;
using System.Windows.Input;
using System.Windows.Media;
using NimbusPlayer.DataAccess.Implementation;
using NimbusPlayer.Model;
using System.Collections.Generic;
using System.Linq;

namespace NimbusPlayer.ViewModel
{
    //public class SongListViewModel : ViewModelBase
    //{
    //    readonly IFileAccess _songFilesRepository;

    //    public SongFile AllFiles
    //    {
    //        get;
    //        private set;
    //    }

    //    public ObservableCollection<Model.Song> AllSongs
    //    {
    //        get;
    //        private set;
    //    }

    //    public ObservableCollection<Model.Album> AllAlbums
    //    {
    //        get;
    //        private set;
    //    }

    //    public ObservableCollection<Model.Artist> AllArtists
    //    {
    //        get;
    //        private set;
    //    }

    //    public SongListViewModel(SongFilesRepository songFilesRepository)
    //    {
    //        if (songFilesRepository == null)
    //        {
    //            throw new ArgumentNullException("songRepository");
    //        }
    //        _songFilesRepository = songFilesRepository;
    //        this.AllFiles = _songFilesRepository.ParseAllSongs();
    //        this.AllSongs = new ObservableCollection<Song>(_songFilesRepository.GetAllSongs());
    //        this.AllAlbums = new ObservableCollection<Album>(_songFilesRepository.GetAllAlbums());
    //        this.AllArtists = new ObservableCollection<Artist>(_songFilesRepository.GetAllArtists());
    //        List<Song> Songs = this.AllSongs.ToList();
    //        FormatArtists(ref Songs);
    //        this.AllSongs = new ObservableCollection<Song>(Songs);
    //    }

    //    private List<Song> FormatArtists(ref List<Song> songList)
    //    {
    //        string[] FormattedArray = new string[] { "" };
    //        foreach (Song song in songList)
    //        {
    //            for (int i = 0; i < song.Artists.Length; i++)
    //            {
    //                FormattedArray[0] += song.Artists[i].ToString();
    //                if (i != song.Artists.Length - 1)
    //                    FormattedArray[0] += " & ";
    //            }
    //            song.Artists = FormattedArray;
    //            FormattedArray = new string[] { "" };
    //        }
    //        return songList;
    //    }
    //    protected override void OnDispose()
    //    {
    //        AllFiles = new SongFile(new List<Song>(), new List<Artist>(), new List<Album>());
    //        this.AllSongs.Clear();
    //        this.AllAlbums.Clear();
    //        this.AllArtists.Clear();
    //    }
    //}
}
