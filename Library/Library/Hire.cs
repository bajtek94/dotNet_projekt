using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Hire
    {
        public long Id { get; set; }
        public User WhoHire { get; set; }
        public DateTime TimeOfHire { get; set; }
        public DateTime TimeForReturn { get; set; }
        public DateTime ReturnTime { get; set; }
        public Book BookHired { get; set; }

        public Hire (User user, DateTime timeOfHire, DateTime timeForReturn, Book book)
        {
            Id = DateTime.Now.Millisecond;
            WhoHire = user;
            TimeOfHire = timeOfHire;
            TimeForReturn = timeForReturn;
            BookHired = book;
        }

    }
}
