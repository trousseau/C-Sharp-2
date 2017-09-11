using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public enum BookFormat { Softcover,Hardcover,Audio,eBook}
    class Book : IMedia
    {
        private int _ID;
        private DateTime _PublishDate;
        private int _PageCount;
        private BookFormat _BookType;
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
                if (value >= DateTime.MinValue && value <= DateTime.Now)
                {
                    _PublishDate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("PublishDate", "PublishDate must be between 1/1/0001 and current date");
                }
            }
        }

        public int PageCount
        {
            get
            {
                return _PageCount;
            }

            set
            {
                if (value > 0)
                {
                    _PageCount = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("PageCount", "PageCount must be greater than 0");
                }

            }
        }

        public BookFormat BookType
        {
            get
            {
                return _BookType;
            }
            set
            {
                if (BookFormat.IsDefined(typeof(BookFormat), value))
                {
                    _BookType = value;
                }
                else
                {
                    throw new ArgumentException("BookFormat", "BookType must be defined in the BookFormat enum");
                }
            }
        }

        public int GetAge()
        {
            return DateTime.Now.Year - PublishDate.Year;
        }

        public void Print()
        {
            Console.WriteLine($"Book: {ID,9:000000000} {Title,-12} {Publisher,-10} {Creator,-12} {PublishDate:yyyy-mm-dd} {PageCount,-5} {GetAge(),4} {BookType,-10}");
        }

        public Book()
        {

        }

        public Book(int id, string title, string publisher, string creator, DateTime publishDate, int pageCount,BookFormat bookType)
        {
            ID = id;
            Title = title;
            Publisher = publisher;
            Creator = creator;
            PublishDate = publishDate;
            PageCount = pageCount;
            BookType = bookType;
        }
    }
}
