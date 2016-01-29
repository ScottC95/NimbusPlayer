using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace NimbusPlayer.Model
{
    public class Album
    {
        public Album(string albumName, string albumArtDir)
        {
            this.AlbumName = albumName;
            this.AlbumArtDir = albumArtDir;
        }

        public string AlbumName { get; set; }
        public string AlbumArtDir { get; set; }
    }
}
