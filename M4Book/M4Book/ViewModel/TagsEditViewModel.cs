using M4Book.Model;
using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Formats.Tar;

namespace M4Book.ViewModel
{
    public class TagsEditViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        /*Audiobook curent = new Audiobook() { FileName = "В.Чиркова - Личный секретарь для младшего принца.m4b" };*/
        Audiobook curent = new Audiobook()
        {
            FileName = "Житие мое.m4b"
        };

        TagLib.File bookFile;

        StreamImageSource picture;

        List<Tag> listOF;


        public TagsEditViewModel()
        {
            /*bookFile = TagLib.File.Create(FileSystem.Current.AppDataDirectory + "\\" + curent.FileName);*/
            bookFile = TagLib.File.Create("C:\\MyPCNew\\Code\\M4Book\\M4Book\\M4Book\\Resources\\Raw\\" + curent.FileName);
            var ttt = bookFile.Tag.GetType().GetFields(BindingFlags.NonPublic).ToList();
            curent.FileName = bookFile.Tag.Title;
            curent.Duration = bookFile.Properties.Duration;
            

            MemoryStream memoryStream = new MemoryStream(bookFile.Tag.Pictures[0].Data.Data);
            // Image = memoryStream as ImageSource;

            /* TODO: добавить изменения с учетом массивов, возращать текст через свойства класса и не текстовое поле*/
            var tttt1 = new List<Tag>() {
                new Tag("Album", bookFile.Tag.Album),
                new Tag("FirstAlbumArtist", bookFile.Tag.FirstAlbumArtist),
                new Tag("AlbumSort", bookFile.Tag.AlbumSort),
                new Tag("AmazonId", bookFile.Tag.AmazonId),
                new Tag("Comment", bookFile.Tag.Comment),
                new Tag("Conductor", bookFile.Tag.Conductor),
                new Tag("Copyright", bookFile.Tag.Copyright),
                new Tag("Description", bookFile.Tag.Description),
                new Tag("FirstAlbumArtistSort", bookFile.Tag.FirstAlbumArtistSort),
                new Tag("FirstComposer", bookFile.Tag.FirstComposer),
                new Tag("FirstComposerSort", bookFile.Tag.FirstComposerSort),
                new Tag("FirstGenre", bookFile.Tag.FirstGenre),
                new Tag("FirstPerformer", bookFile.Tag.FirstPerformer),
                new Tag("FirstPerformerSort", bookFile.Tag.FirstPerformerSort),
                new Tag("Grouping", bookFile.Tag.Grouping),
                new Tag("InitialKey", bookFile.Tag.InitialKey),
                new Tag("ISRC", bookFile.Tag.ISRC),
                new Tag("JoinedAlbumArtists", bookFile.Tag.JoinedAlbumArtists),
                new Tag("JoinedComposers", bookFile.Tag.JoinedComposers),
                new Tag("JoinedGenres", bookFile.Tag.JoinedGenres),
                new Tag("JoinedPerformers", bookFile.Tag.JoinedPerformers),
                new Tag("JoinedPerformersSort", bookFile.Tag.JoinedPerformersSort),
                new Tag("Length", bookFile.Tag.Length),
                new Tag("Lyrics", bookFile.Tag.Lyrics),
                new Tag("MusicBrainzArtistId", bookFile.Tag.MusicBrainzArtistId),
                new Tag("MusicBrainzDiscId", bookFile.Tag.MusicBrainzDiscId),
                new Tag("MusicBrainzReleaseArtistId", bookFile.Tag.MusicBrainzReleaseArtistId),
                new Tag("MusicBrainzReleaseCountry", bookFile.Tag.MusicBrainzReleaseCountry),
                new Tag("MusicBrainzReleaseGroupId", bookFile.Tag.MusicBrainzReleaseGroupId),
                new Tag("MusicIpId", bookFile.Tag.MusicIpId),
                new Tag("Publisher", bookFile.Tag.Publisher),
                new Tag("RemixedBy", bookFile.Tag.RemixedBy),
                new Tag("Subtitle", bookFile.Tag.Subtitle),
                new Tag("Title", bookFile.Tag.Title),
                new Tag("TitleSor", bookFile.Tag.TitleSort ),
                     
                new Tag("AlbumArtists", string.Join("", bookFile.Tag.AlbumArtists)),
                new Tag("AlbumArtistsSort", string.Join("", bookFile.Tag.AlbumArtistsSort)),
                new Tag("Artists", string.Join("", bookFile.Tag.Artists)),
                new Tag("Composers", string.Join("", bookFile.Tag.Composers)),
                new Tag("ComposersSort", string.Join("", bookFile.Tag.ComposersSort)),
                new Tag("Performers", string.Join("", bookFile.Tag.Performers)),
                new Tag("PerformersRole", string.Join("", bookFile.Tag.PerformersRole)),
                new Tag("PerformersSort", string.Join("", bookFile.Tag.PerformersSort)),
                     
                new Tag("Disc", bookFile.Tag.Disc.ToString()), 
                new Tag("DiscCount", bookFile.Tag.DiscCount.ToString()),
                new Tag("Track", bookFile.Tag.Track.ToString()) ,
                new Tag("TrackCount", bookFile.Tag.TrackCount.ToString()) ,
                new Tag("Year", bookFile.Tag.Year.ToString()),

                new Tag( "DateTagged", bookFile.Tag.DateTagged.ToString() ) 
            };
            listOF = tttt1;
        } 

        public string Name
        {
            get => curent.FileName;
            set
            {
                if(curent.FileName != value) { 
                    curent.FileName = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<Tag> ListOF
        {
            get => listOF;
            set { if (listOF != value) { listOF = value; OnPropertyChanged(); } }
        }

        public StreamImageSource Image
        {
            get => picture;
            set { if (picture != value) { picture = value; OnPropertyChanged(); } }
        }

        public void OnPropertyChanged([CallerMemberName] string prop="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

