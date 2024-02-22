using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitaplonpython1
{
    internal class Receipt
    {
        public Vehicle Vehicle;
        public Ticket Ticket;
        public DateTime TimeIn;
        public DateTime TimeOut;
        public bool isLossTicket;
        public double Total;

        public Receipt(Vehicle vehicle, Ticket ticket) 
        {
            Vehicle = vehicle;
            TimeIn = DateTime.Now;
            ticket.TimeIn = TimeIn;
            Ticket = ticket;
        }

    }
}
