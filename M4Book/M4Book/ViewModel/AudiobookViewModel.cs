using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using M4Book.Model;

namespace M4Book.ViewModel
{
    public class AudiobookViewModel: INotifyPropertyChanged 
    {
        Audiobook audiobook;
        ImageSource coverSource;

        public event PropertyChangedEventHandler? PropertyChanged;


        public AudiobookViewModel()
        {

        }

        public AudiobookViewModel(string path, string fileFormat)
        {
            audiobook = new Audiobook(path, fileFormat);
            coverSource = ImageSource.FromStream(() => new MemoryStream(audiobook.Cover));
        }

        public AudiobookViewModel(Audiobook book)
        {
            audiobook = book;
            coverSource = ImageSource.FromStream(() => new MemoryStream(audiobook.Cover));
        }


        public int Id { get => audiobook.Id; set { if (audiobook.Id != value) { audiobook.Id = value; OnPropertyChanged(); } } }
        public string Title { get => audiobook.Title; set { if (audiobook.Title != value) { audiobook.Title = value; OnPropertyChanged(); } } }
        public string Series { get => audiobook.Series; set { if (audiobook.Series != value) { audiobook.Series = value; OnPropertyChanged(); } } }
        public int SeriesPart { get => audiobook.SeriesPart; set { if (audiobook.SeriesPart != value) { audiobook.SeriesPart = value; OnPropertyChanged(); } } }
        public string Author { get => audiobook.Author; set { if (audiobook.Author != value) { audiobook.Author = value; OnPropertyChanged(); } } }
        public string Reader { get => audiobook.Reader; set { if (audiobook.Reader != value) { audiobook.Reader = value; OnPropertyChanged(); } } }
        public string Description { get => audiobook.Description; set { if (audiobook.Description != value) { audiobook.Description = value; OnPropertyChanged(); } } }
        public TimeSpan Duration { get => audiobook.Duration; set { if (audiobook.Duration != value) { audiobook.Duration = value; OnPropertyChanged(); } } }
        public ObservableCollection<Chapter> Chapters { get => audiobook.Chapters; set { if (audiobook.Chapters != value) { audiobook.Chapters = value; OnPropertyChanged(); } } }
        public ImageSource Cover { get => coverSource; set { if (coverSource != value) { coverSource = value; OnPropertyChanged(); } } }
        public string FilePath { get => audiobook.FilePath; set { if (audiobook.FilePath != value) { audiobook.FilePath = value; OnPropertyChanged(); } } }

        public TimeSpan CurentDuration { get => Duration; set { if (Duration != value) {  Duration = value; OnPropertyChanged(); } } }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
