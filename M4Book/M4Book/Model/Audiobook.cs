
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ATL;

namespace M4Book.Model
{
    public class Chapter
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan StartPosition { get; set; }
    }


    
    public class Audiobook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Series { get; set; }
        public int SeriesPart { get; set; }
        public string Author { get; set; }
        public string Reader { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public ObservableCollection<Chapter> Chapters { get; set; }
        public byte[] Cover { get; set; }
        public string FilePath { get; set; }
        

        public double DurationToDouble()
        {
            return (Duration.Hours + Duration.Minutes / 100.0 + Duration.Seconds / 10000.0) * (Duration > TimeSpan.Zero ? 1 : -1);
        }

        public Audiobook()
        {

        }

        public Audiobook(string path)
        {
            FilePath = path;
            Track theTrack = new Track(path);
            Title = theTrack.Title;
            Series = theTrack.SeriesTitle;
            // SeriesPart = Int32.Parse(theTrack.SeriesPart);
            if (theTrack.Composer is "")
            {
                Author = theTrack.Artist;
            }
            else
            {
                Reader = theTrack.Artist;
                Author = theTrack.Composer;
            }
            Description = theTrack.Description;
            Duration = TimeSpan.FromSeconds(theTrack.Duration);

            Chapters = new ObservableCollection<Chapter>();

            foreach (var chapter in theTrack.Chapters)
            {
                Chapters.Add(new Chapter()
                {
                    Title = chapter.Title,
                    StartPosition = TimeSpan.FromMicroseconds(chapter.StartTime),
                    Duration = TimeSpan.FromMicroseconds(chapter.EndTime - chapter.StartTime)
                });
            }

            Cover = theTrack.EmbeddedPictures[0].PictureData;
        }
    }
}
