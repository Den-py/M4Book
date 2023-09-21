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
    class MainViewModel: INotifyPropertyChanged
    {
        ObservableCollection<AudiobookViewModel> readingList = new ObservableCollection<AudiobookViewModel>();
        ObservableCollection<AudiobookViewModel> library = new ObservableCollection<AudiobookViewModel>();

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel() {
            var books = Library.GetReadingList().ToList();
            foreach (var book in books)
            {
                ReadingList.Add(new AudiobookViewModel(book));
            }
        } 
        public ObservableCollection<AudiobookViewModel> ReadingList
        {
            get => readingList;
            set
            {
                if (readingList != value)
                {
                    readingList = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<AudiobookViewModel> AppLibrary
        {
            get => library;
            set
            {
                if (library != value)
                {
                    library = value;
                    OnPropertyChanged();
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
