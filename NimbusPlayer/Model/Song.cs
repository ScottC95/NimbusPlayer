using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbusPlayer.Model
{
    public class Song
    {
        public Song(string filePath)
        {
            FilePath = filePath;
            SetupMetadata();
        }

        private bool _isPlaying;

        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string FilePath { get; set; }

        public void SetupMetadata()
        {
            try
            {
                TagLib.File file = TagLib.File.Create(FilePath);
                Title = file.Tag.Title;
                FormatArtist(file.Tag.Performers);
                Album = file.Tag.Album;
            }
            catch (Exception)
            {
                return;
                //TODO: Add way of showing user what is an issue
            }
        }

        public void FormatArtist(string[] peformers)
        {
            if (!peformers.Any()) return;

            if (peformers.Count() == 1)
            {
                Artist = peformers[0];
            }
            else
            {
                for (int i = 0; i < peformers.Length; i++)
                {
                    Artist += peformers[i];
                    if (i < peformers.Length - 1)
                    {
                        Artist += " & ";
                    }
                }
            }
        }

    }
}
