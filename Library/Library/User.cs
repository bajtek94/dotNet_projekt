using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library
{
    class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String FullNameWithId {
            get
            {
                return Name + " " + LastName + "(" + Id + ")";
            }
        }

        public User(String name, String lastName)
        {
            Random rnd = new Random();
            Id = rnd.Next(1, 999999999);
            Thread.Sleep(100);
            Name = name;
            LastName = lastName;
        }



    }
}
