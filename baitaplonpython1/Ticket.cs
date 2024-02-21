using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitaplonpython1
{
    internal class Ticket
    {
        public int ID;
        public DateTime TimeIn;
        public DateTime TimeOut;

        public Ticket(int id) 
        {
            ID = id;
        }
    }
}
