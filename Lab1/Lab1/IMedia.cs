using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public interface IMedia
    {
        int ID { get; set; }
        string Title { get; set; }
        string Publisher { get; set; }
        string Creator { get; set; }
        DateTime PublishDate { get; set; }
        int GetAge();
        void Print();
    }
}
