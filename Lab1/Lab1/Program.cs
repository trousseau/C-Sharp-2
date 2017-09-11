using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IMedia> mediaLibrary = new List<IMedia>();
            ConsoleUI.InputTypes selection;

            Console.SetWindowSize(100, 35);

            do
            {
                selection = ConsoleUI.DrawUI();

                switch (selection)
                {
                    case ConsoleUI.InputTypes.AddAlbum:
                        ConsoleUI.AddAlbumUI(mediaLibrary);
                        break;
                    case ConsoleUI.InputTypes.AddBook:
                        ConsoleUI.AddBookUI(mediaLibrary);
                        break;
                    case ConsoleUI.InputTypes.AddMovie:
                        ConsoleUI.AddMovieUI(mediaLibrary);
                        break;
                    default:
                        break;
                }

                ConsoleUI.PrintList(mediaLibrary);
            } while (selection != ConsoleUI.InputTypes.Quit);


            Console.Write("Press <ENTER> to quit...");
            Console.ReadLine();
        }
    }
}
