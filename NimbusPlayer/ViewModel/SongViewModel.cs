using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NimbusPlayer.Model;

namespace NimbusPlayer.ViewModel
{
    class SongViewModel : ViewModelBase
    {
        private Song _song;
        private string _title, _artist, _album;
        private bool _isPlaying;
        private SongViewModel song;

        //relay command

        public string Title
        {
            get { return _title; }
            set { SetAndNotify(ref _title, value); }
        }

        public string Artist
        {
            get { return _artist; }
            set { SetAndNotify(ref _artist, value); }
        }

        public string Album
        {
            get { return _album; }
            set { SetAndNotify(ref _album, value); }
        }

        public string FilePath
        {
            get { return _song.FilePath; }
        }

        public bool IsPlaying
        {
            get { return _isPlaying; }
            set { SetAndNotify(ref _isPlaying, value); }
        }

        public SongViewModel(Song song)
        {
            _song = song;
            _title = _song.Title;
            _artist = _song.Artist;
            _album = _song.Album;
        }

        public SongViewModel(SongViewModel songViewModel)
        {
            _song = songViewModel._song;
            _title = songViewModel.Title;
            _artist = songViewModel.Artist;
            _album = songViewModel.Album;
        }
    }
}
