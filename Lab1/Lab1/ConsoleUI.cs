using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Lab1
{
    public static class ConsoleUI
    {
        public enum InputTypes { AddMovie,AddAlbum,AddBook,Quit}
        public static InputTypes DrawUI()
        {
            var values = Enum.GetValues(typeof(InputTypes));
            int count = 0;
            int enumLength = Enum.GetNames(typeof(InputTypes)).Length;
            Console.WriteLine("Please select an action:");

            foreach (var value in values)
            {
                Console.WriteLine($"[{count}]-{value}");
                count++;
            }

            int selectionInt = ConsoleHelpers.ReadInt("Enter selection: ", 0, enumLength-1);
            InputTypes selection = (InputTypes)selectionInt;

            return selection;
        }

        public static void AddMovieUI(List<IMedia> mediaLibrary)
        {
            DateTime datevalue;
            DateTime.TryParse("1/1/1878", out datevalue);

            Console.WriteLine("<< New Movie >>");
            int id = ConsoleHelpers.ReadInt("Enter movie ID: ", 1, 999999999);
            string title = ConsoleHelpers.ReadString("Enter movie title: ", 1, 0);
            string publisher = ConsoleHelpers.ReadString("Enter movie producer/publisher: ", 1, 0);
            string creator = ConsoleHelpers.ReadString("Enter movie screenwriter: ", 1, 0);
            DateTime publishDate = ConsoleHelpers.ReadDate("Enter release date: ",datevalue,DateTime.Now);
            int runLength = ConsoleHelpers.ReadInt("Enter runtime: ", 1, 43200);

            var values = Enum.GetValues(typeof(Ratings));
            int count = 0;
            int ratingsEnumLength = Enum.GetNames(typeof(Ratings)).Length;

            foreach (var var in values)
            {
                Console.WriteLine($"[{count}]-{var}");
                count++;
            }

            int ratingInt = ConsoleHelpers.ReadInt("Enter value: ", 0, ratingsEnumLength);
            Ratings rating = (Ratings)ratingInt;

            try
            {
                Movie movieObj = new Movie(id, title, publisher, creator, publishDate, runLength, rating);
                mediaLibrary.Add(movieObj);
            }
            catch (Exception e)
            {

                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public static void AddAlbumUI(List<IMedia> mediaLibrary)
        {
            DateTime datevalue;
            DateTime.TryParse("1/1/1860", out datevalue);

            Console.WriteLine("<< New Album >>");
            int id = ConsoleHelpers.ReadInt("Enter album ID: ", 1, 999999999);
            string title = ConsoleHelpers.ReadString("Enter album title: ", 1, 0);
            string publisher = ConsoleHelpers.ReadString("Enter album producer/publisher: ", 1, 0);
            string creator = ConsoleHelpers.ReadString("Enter album artist: ", 1, 0);
            DateTime publishDate = ConsoleHelpers.ReadDate("Enter release date: ", datevalue, DateTime.Now);
            int runLength = ConsoleHelpers.ReadInt("Enter runtime: ", 1, 43200);
            int songCount = ConsoleHelpers.ReadInt("Enter song count: ", 1, 1000);

            var values = Enum.GetValues(typeof(Medium));
            int count = 0;
            int mediumEnumLength = Enum.GetNames(typeof(Medium)).Length;

            foreach (var var in values)
            {
                Console.WriteLine($"[{count}]-{var}");
                count++;
            }

            int mediumInt = ConsoleHelpers.ReadInt("Enter value: ", 0, mediumEnumLength);
            Medium albumMedium = (Medium)mediumInt;

            try
            {
                MusicAlbum albumObj = new MusicAlbum(id, title, publisher, creator, publishDate, runLength, songCount,albumMedium);
                mediaLibrary.Add(albumObj);
            }
            catch (Exception e)
            {

                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public static void AddBookUI(List<IMedia> mediaLibrary)
        {
            Console.WriteLine("<< New Book >>");
            int id = ConsoleHelpers.ReadInt("Enter book ID: ", 1, 999999999);
            string title = ConsoleHelpers.ReadString("Enter book title: ", 1, 0);
            string publisher = ConsoleHelpers.ReadString("Enter book publisher: ", 1, 0);
            string creator = ConsoleHelpers.ReadString("Enter book author: ", 1, 0);
            DateTime publishDate = ConsoleHelpers.ReadDate("Enter publishing date: ", DateTime.MinValue, DateTime.Now);
            int pageCount = ConsoleHelpers.ReadInt("Enter page count: ", 1, 10000);

            var values = Enum.GetValues(typeof(BookFormat));
            int count = 0;
            int formatEnumLength = Enum.GetNames(typeof(BookFormat)).Length;

            foreach (var var in values)
            {
                Console.WriteLine($"[{count}]-{var}");
                count++;
            }

            int formatInt = ConsoleHelpers.ReadInt("Enter value: ", 0, formatEnumLength);
            BookFormat albumMedium = (BookFormat)formatInt;

            try
            {
                Book bookObj = new Book(id, title, publisher, creator, publishDate, pageCount, albumMedium);
                mediaLibrary.Add(bookObj);
            }
            catch (Exception e)
            {

                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public static void PrintList(List<IMedia> mediaLibrary)
        {
            foreach (var item in mediaLibrary)
            {
                item.Print();
            }
        }
    }
}
