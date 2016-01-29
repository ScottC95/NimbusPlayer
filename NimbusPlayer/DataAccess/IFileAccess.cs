using NimbusPlayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbusPlayer.DataAccess
{
    public interface IFileAccess
    {
        /// <summary>
        /// Reads all of the files in the folder for the music. e.g. MyMusic
        /// </summary>
        /// <returns>A SongFile object with all the songs in a folder</returns>
        SongFile ParseAllSongs();

        /// <summary>
        /// Gets all of the songs that are in the SongFile object
        /// </summary>
        /// <returns>A list of all the avaible songs</returns>
        List<Song> GetAllSongs();

        /// <summary>
        /// Gets all of the artists that are in the SongFile object
        /// </summary>
        /// <returns>A list of all the available artists</returns>
        List<Artist> GetAllArtists();

        /// <summary>
        /// Gets all of the albums that are in the Songfile object
        /// </summary>
        /// <returns>A list of all the available albums</returns>
        List<Album> GetAllAlbums();
    }
}
