using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public enum Ratings{G,PG,PG13,R,NC17,Unrated}
    public class Movie : IMedia
    {
        private int _ID;
        private DateTime _PublishDate;
        private Ratings _Rating;
        private int _RunLength;
        public int ID
        {
            //TODO: stack overflow happening here
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
                if (value.Year > 1878 && value.Year <= DateTime.Now.Year )
                {
                    _PublishDate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("PublishDate", "PublishDate must be between 1878 and current year");
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

        internal Ratings Rating
        {
            get
            {
                return _Rating;
            }

            set
            {
                if (Ratings.IsDefined(typeof(Ratings),value))
                {
                    _Rating = value;
                }
                else
                {
                    throw new ArgumentException("Rating", "Rating must be defined in Ratings enum");
                }

            }
        }

        public int GetAge()
        {
            return DateTime.Now.Year - PublishDate.Year;
        }

        public void Print()
        {
            Console.WriteLine($"Movie: {ID,9:000000000} {Title,-12} {Publisher,-12} {Creator,-10} {PublishDate:yyyy-mm-dd} {RunLength,-5} {GetAge(),4} {Rating,-10}");
        }

        public Movie()
        {

        }

        public Movie(int id, string title, string publisher, string creator, DateTime publishDate, int runLength, Ratings rating)
        {
            ID = id;
            Title = title;
            Publisher = publisher;
            Creator = creator;
            PublishDate = publishDate;
            RunLength = runLength;
            Rating = rating;
        }
    }
}
