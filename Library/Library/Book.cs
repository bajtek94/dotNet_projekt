using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library
{
    class Book
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public String TitleAndId {
            get {
                return Title + "(" + Id.ToString() + ")"; 
            }
        }
        public bool isHired { get; set; }
        public User ActualUser { get; set; }

        public Book(String title, String author)
        {
            Random rnd = new Random();
            Id = rnd.Next(1,999999999);
            Thread.Sleep(100);
            Title = title;
            Author = author;
            isHired = false;
            ActualUser = null;
        }

        public void hire(User user, HireHistory hires)
        {
            DateTime actualTime = DateTime.Now;
            DateTime timeForReturn = actualTime;
            timeForReturn.AddMonths(1);
            Hire hire = new Hire(user, actualTime, actualTime.AddMonths(1), this);
            isHired = true;
            hires.addNewHire(hire);
        }

    }
}
