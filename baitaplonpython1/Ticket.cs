using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitaplonpython1
{
    internal class Ticket
    {
        public int ID { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }

        public Ticket(int id) 
        {
            ID = id;
        }

        public bool Equals(Ticket other)
        {
            if(this.ID == other.ID && DateTime.Compare(this.TimeIn, other.TimeIn) == 0 && DateTime.Compare(this.TimeOut, other.TimeOut) == 0) 
                return true;
            else
                return false;
        }
    }
}
