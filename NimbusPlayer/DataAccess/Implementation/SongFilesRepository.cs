using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NimbusPlayer.Model;
using System.IO;

namespace NimbusPlayer.DataAccess.Implementation
{
    public class SongFilesRepository //: IFileAccess
    {
        //private readonly SongFile _songFiles;

        //public SongFilesRepository()
        //{
        //    //Initialize all the variables
        //    if (_songFiles == null)
        //        _songFiles = new SongFile(new List<Song>(), new List<Artist>(), new List<Album>());
        //}

        //public SongFile ParseAllSongs()
        //{
        //    bool ReplaceAlbum = false, ReplaceArtist = false;
        //    string Title, Genre, AlbumName, filePath;
        //    string[] Artists, AlbumArtists;
        //    List<string> Dirs;
        //    long Duration;
        //    int AlbumIndex = 0, ArtistIndex = 0;

        //    filePath = @"Z:"; //Environment.GetFolderPath(Environment.SpecialFolder.MyMusic); // @"Z:\Ujico\空中都市";
        //    Dirs = Directory.GetDirectories(filePath).ToList();
        //    foreach (string Dir in Dirs)
        //    {
        //        try
        //        {
        //            foreach (var file in Directory.GetFiles(Dir, "*.*", SearchOption.AllDirectories).Where(file => file.ToLower().EndsWith("mp3") ||
        //                                                              file.ToLower().EndsWith("flac")).ToList())
        //            {
        //                TagLib.File f = TagLib.File.Create(file);

        //                string s = f.Mode.ToString();
        //                //Buidling Song Object
        //                Title = f.Tag.Title;
        //                Artists = f.Tag.Performers;
        //                Duration = (long)f.Properties.Duration.TotalSeconds;
        //                Genre = f.Tag.FirstGenre;
        //                Song Song = new Song(Title, Artists, Duration, Genre);
        //                _songFiles.Songs.Add(Song);

        //                //Building Album Object
        //                AlbumName = f.Tag.Album;
        //                AlbumArtists = f.Tag.AlbumArtists;
        //                //Search if it already exists
        //                Album Album = _songFiles.Albums.SingleOrDefault(a => a.Name == AlbumName);

        //                if (Album == null)
        //                {
        //                    Album = new Album();
        //                }
        //                else
        //                {
        //                    ReplaceAlbum = true;
        //                    AlbumIndex = _songFiles.Albums.FindIndex(a => a.Name == AlbumName);
        //                }

        //                Album.Artists = AlbumArtists;
        //                Album.Name = AlbumName;
        //                Album.Songs.Add(Song);

        //                if (ReplaceAlbum)
        //                    _songFiles.Albums[AlbumIndex] = Album;
        //                else
        //                    _songFiles.Albums.Add(Album);

        //                //Buidling Artist Object
        //                //Search for item in Artist list, if none is found create is a new one
        //                foreach (string searchArtist in AlbumArtists)
        //                {
        //                    Artist Artist = _songFiles.Artists.SingleOrDefault(a => a.Name == searchArtist);

        //                    if (Artist == null)
        //                    {
        //                        Artist = new Artist();
        //                    }
        //                    else
        //                    {
        //                        ReplaceArtist = true;
        //                        ArtistIndex = _songFiles.Artists.FindIndex(a => a.Name == searchArtist);
        //                    }
        //                    Artist.Name = searchArtist;
        //                    Artist.Songs.Add(Song);
        //                    if (ReplaceArtist)
        //                        _songFiles.Artists[ArtistIndex] = Artist;
        //                    else
        //                        _songFiles.Artists.Add(Artist);
        //                }

        //                ReplaceAlbum = false;
        //                ReplaceArtist = false;
        //            }

        //        }
        //        catch (UnauthorizedAccessException)
        //        {
        //            //Not allowed to access system files
        //        }
        //    }
        //    return _songFiles;
        //}



        //public List<Album> GetAllAlbums()
        //{
        //    if (_songFiles.Albums.Count == 0)
        //        ParseAllSongs();
        //    return new List<Album>(_songFiles.Albums);
        //}

        //public List<Artist> GetAllArtists()
        //{
        //    if (_songFiles.Artists.Count == 0)
        //        ParseAllSongs();
        //    return new List<Artist>(_songFiles.Artists);
        //}

        //public List<Song> GetAllSongs()
        //{
        //    if (_songFiles.Songs.Count == 0)
        //        ParseAllSongs();
        //    return new List<Song>(_songFiles.Songs);
        //}
    }
}
