using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NimbusPlayer.Model;

namespace NimbusPlayer.Model
{
    public class SongFile
    {
        public SongFile(List<Song> inputSongs, List<Artist> inputArtists, List<Album> inputAlbums)
        {
            Songs = inputSongs;
            Artists = inputArtists;
            Albums = inputAlbums;
        }

        public List<Song> Songs { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Album> Albums { get; set; }
    }
}
