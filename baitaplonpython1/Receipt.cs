using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitaplonpython1
{
    internal class Receipt
    {
        public Vehicle Vehicle { get; set; }
        public Ticket Ticket { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public bool isLossTicket { get; set; }
        public double Total { get; set; }

        public Receipt(Vehicle vehicle, Ticket ticket) 
        {
            Vehicle = vehicle;
            TimeIn = DateTime.Now;
            ticket.TimeIn = TimeIn;
            Ticket = ticket;
        }

        public bool Equals(Receipt other)
        {
            if(this.Vehicle.Equals(other.Vehicle) && this.Ticket.Equals(other.Ticket) && DateTime.Compare(this.TimeIn, other.TimeIn) == 0 && DateTime.Compare(this.TimeOut, other.TimeOut) == 0 && this.isLossTicket == other.isLossTicket && this.Total == other.Total) 
                return true;
            else
                return false;
        }
    }
}
