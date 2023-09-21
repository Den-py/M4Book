using CommunityToolkit.Maui.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace M4Book.Model
{
    static class Library
    {
        public static List<Audiobook> Books = new List<Audiobook>();
        static string libraryDirectory;
        static Library()
        {
            
            libraryDirectory = FileSystem.Current.AppDataDirectory + "\\Books";
            if (!Directory.Exists(libraryDirectory))
            {
                /*Environment.GetFolderPath(Environment.SpecialFolder);*/
                Directory.CreateDirectory(libraryDirectory);
            }
            /*var fileInfo = new FileInfo("C:\\MyPCNew\\Code\\M4Book\\M4Book\\M4Book\\Resources\\Raw\\В.Чиркова - Личный секретарь для младшего принца.m4b");
            fileInfo.CopyTo(libraryDirectory+ "\\В.Чиркова - Личный секретарь для младшего принца.m4b");*/
            LibraryUpdate();
        }

        public static void LibraryUpdate()
        {
            // Только для первого запуска, в противном случае нужна проверка чтобы в бд не повторялась
            foreach (var folder in Directory.GetDirectories(libraryDirectory))
            {
                Books.Add(new Audiobook(folder, "mp3"));
            }
            
            foreach (var file in Directory.GetFiles(libraryDirectory))
            {
                Books.Add(new Audiobook(file, "m4b"));
                var yyy = 0;
            }
            
        }

        public static List<Audiobook> GetReadingList()
        {
            return Books;
        }
    }
}
