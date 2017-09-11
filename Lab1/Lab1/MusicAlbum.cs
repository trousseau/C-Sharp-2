using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public enum Medium { Vinyl,Cassette,CD,MP3 }
    class MusicAlbum : IMedia
    {
        private int _ID;
        private DateTime _PublishDate;
        private int _RunLength;
        private Medium _AlbumMedium;
        private int _SongCount;
        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                if (value > 0 && value < 999999999)
                {
                    _ID = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("ID", "ID must be greater than 0 and less than 999999999");
                }
            }
        }

        public string Title { get; set; }

        public string Publisher { get; set; }

        public string Creator { get; set; }

        public DateTime PublishDate
        {
            get
            {
                return _PublishDate;
            }

            set
            {
                if (value.Year > 1860 && value.Year <= DateTime.Now.Year)
                {
                    _PublishDate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("PublishDate", "PublishDate must be between 1860 and current year");
                }
            }
        }

        public int RunLength
        {
            get
            {
                return _RunLength;
            }

            set
            {
                if (value > 0)
                {
                    _RunLength = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("RunLength", "Runlength must be greater than 0");
                }

            }
        }

        public Medium AlbumMedium
        {
            get
            {
                return _AlbumMedium;
            }
            set
            {
                if (Medium.IsDefined(typeof(Medium),value))
                {
                    _AlbumMedium = value;
                }
                else
                {
                    throw new ArgumentException("AlbumMedium", "AlbumMedium must be defined in the AlbumMedium enum");
                }
            }
        }

        public int SongCount
        {
            get
            {
                return _SongCount;
            }

            set
            {
                if (value > 0)
                {
                    _SongCount = value;
                }

            }
        }


        public int GetAge()
        {
            return DateTime.Now.Year - PublishDate.Year;
        }

        public void Print()
        {
            Console.WriteLine($"Album: {ID,9:000000000} {Title,-12} {Publisher,-12} {Creator,-10} {PublishDate:yyyy-mm-dd} {RunLength,-5} {SongCount,-4} {GetAge(),4} {AlbumMedium,-10}");
        }

        public MusicAlbum()
        {

        }

        public MusicAlbum(int id, string title, string publisher, string creator, DateTime publishDate, int runLength, int songCount, Medium albumMedium)
        {
            ID = id;
            Title = title;
            Publisher = publisher;
            Creator = creator;
            PublishDate = publishDate;
            RunLength = runLength;
            SongCount = songCount;
            AlbumMedium = albumMedium;
        }
    }
}
