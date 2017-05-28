using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class HireHistory
    {
        List<Hire> hires;
        public HireHistory()
        {
            hires = new List<Hire>();
        }

        public void addNewHire(Hire hire)
        {
            hires.Add(hire);
        }
        public void setAsReturned(int id)
        {
            foreach(Hire h in hires)
            {
                if(h.Id == id)
                {
                    h.BookHired.isHired = false;
                    h.ReturnTime = DateTime.Now;
                }
            }
        }

    }
}
