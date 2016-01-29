using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NimbusPlayer;
using NimbusPlayer.Model;
using NimbusPlayer.DataAccess;
using NimbusPlayer.DataAccess.Implementation;


namespace NimbusPlayerTests
{
    [TestClass]
    public class IFileAccessTests
    {
        private IFileAccess _iFileAccess;

        [TestInitialize]
        public void IFileAccessIntitialize()
        {
            //_iFileAccess = new SongFilesRepository();
        }

        [TestCleanup]
        public void IFileAccessCleanup()
        {
            _iFileAccess = null;
        }

        [TestMethod]
        public void GetAllAlbums_Test_Positive()
        {
            Assert.IsNotNull(_iFileAccess);

            var albums = _iFileAccess.GetAllAlbums();
            Assert.IsNotNull(albums);
            Assert.IsTrue(albums.Count > 0);
        }

        [TestMethod]
        public void GetAllArtists_Test_Positive()
        {
            Assert.IsNotNull(_iFileAccess);

            var artists = _iFileAccess.GetAllArtists();
            Assert.IsNotNull(artists);
            Assert.IsTrue(artists.Count > 0);
        }

        [TestMethod]
        public void GetAllSongs_Test_Positive()
        {
            Assert.IsNotNull(_iFileAccess);

            var songs = _iFileAccess.GetAllSongs();
            Assert.IsNotNull(songs);
            Assert.IsTrue(songs.Count > 0);
        }

        
    }
}
