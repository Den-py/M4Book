
using M4Book.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace M4Book.ViewModel
{
    class PlayerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        Audiobook curent = new Audiobook();

        TagLib.File bookFile;

        byte [] cover;

        public PlayerViewModel()
        {
            bookFile = TagLib.File.Create("C:\\MyPCNew\\Code\\M4Book\\M4Book\\M4Book\\Resources\\Raw\\" + curent.FileName);

            curent.Title = bookFile.Tag.Title;
            curent.Duration = bookFile.Properties.Duration/*bookFile.Tag.Track*/;

            cover = bookFile.Tag.Pictures[0].Data.Data;
            

        }

        public string Title
        {
            get => curent.Title;
            set
            {
                if (curent.Title != value)
                {
                    curent.Title = value;
                    OnPropertyChanged();
                }
            }
        }

        public byte [] Cover
        {
            get => cover;
            set 
            { 
                if (cover != value) 
                {
                    cover = value; 
                    OnPropertyChanged();
                }
            }
        }

        public double CurentDuration
        {
            get => curent.Duration.TotalSeconds;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
