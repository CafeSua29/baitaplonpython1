using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitaplonpython1
{
    internal class ManageVehicles
    {
        public List<Vehicle> ListVehicles;
        public List<Ticket> ListTicket;
        public List<Receipt> ListReceipt;
        public double Turnover;

        public ManageVehicles(int vehicleamount) 
        {
            ListVehicles = new List<Vehicle>();
            ListTicket = new List<Ticket>();
            ListReceipt = new List<Receipt>();
            Turnover = 0.0;

            for (int i = 0; i < vehicleamount; i++) 
            {
                ListTicket.Add(new Ticket(i));
            }
        }

        public Ticket VehicleIn(Vehicle vehicle) 
        {
            ListVehicles.Add(vehicle);

            Ticket ticket = ListTicket[0];

            ListTicket.RemoveAt(0);

            ListReceipt.Add(new Receipt(vehicle, ticket));

            return ticket;
        }

        public Vehicle? VehicleOut(Vehicle vehicle, Ticket ticket) 
        {
            if(ListVehicles.Contains(vehicle))
            {
                if (ticket == null)
                {

                }
                else
                {
                    Receipt receipt = new Receipt(vehicle, ticket);
                    receipt.TimeIn = ticket.TimeIn;

                    if (ListReceipt.Contains(receipt))
                    {
                        ListReceipt.Remove(receipt);

                        receipt.TimeOut = DateTime.Now;

                        if (vehicle.Type == "motorbike")
                        {
                            if (receipt.TimeOut.Hour < 18 && receipt.TimeOut.Hour > 8)
                            {
                                receipt.Total = 3000;

                                Turnover += receipt.Total;

                                ListVehicles.Remove(vehicle);

                                return vehicle;
                            }
                            else if (receipt.TimeOut.Hour < 22 && receipt.TimeOut.Hour >= 18)
                            {
                                receipt.Total = 6000;

                                Turnover += receipt.Total;

                                ListVehicles.Remove(vehicle);

                                return vehicle;
                            }
                            else
                            {
                                return null;
                            }

                        }
                        else
                        {
                            if (receipt.TimeOut.Hour < 18 && receipt.TimeOut.Hour > 8)
                            {
                                receipt.Total = 2000;

                                Turnover += receipt.Total;

                                ListVehicles.Remove(vehicle);

                                return vehicle;
                            }
                            else if (receipt.TimeOut.Hour < 22 && receipt.TimeOut.Hour >= 18)
                            {
                                receipt.Total = 4000;

                                Turnover += receipt.Total;

                                ListVehicles.Remove(vehicle);

                                return vehicle;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }
}
