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
        public double Turnovermotorbike;
        public double Turnoverbike;

        public ManageVehicles(int vehicleamount) 
        {
            ListVehicles = new List<Vehicle>();
            ListTicket = new List<Ticket>();
            ListReceipt = new List<Receipt>();
            Turnovermotorbike = 0.0;
            Turnoverbike = 0.0;

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

        public Vehicle? VehicleOut(Vehicle vehicle, Ticket ticket, string? vehicleinfo) 
        {
            if(ListVehicles.Contains(vehicle))
            {
                if (ticket == null)
                {
                    int save = ListTicket.Count;

                    for(int i = ListReceipt.Count - 1; i >= 0; i--)
                    {
                        if (ListReceipt[i].Vehicle.LicensePlate == vehicleinfo)
                        {
                            save = i;

                            break;
                        }
                    }

                    if(save < ListReceipt.Count)
                    {
                        int passday = DateTime.Now.Day - ListReceipt[save].TimeIn.Day;

                        if (vehicle.Type == "motorbike")
                        {
                            if (DateTime.Now.Hour < 18 && DateTime.Now.Hour > 8)
                            {
                                ListReceipt[save].Total = 3000 + passday * 35000 + 60000;

                                Turnovermotorbike += ListReceipt[save].Total;

                                ListReceipt[save].TimeOut = DateTime.Now;
                                ListReceipt[save].isLossTicket = true;

                                ListVehicles.Remove(vehicle);
                                ListTicket.Add(ticket);

                                return vehicle;
                            }
                            else if (DateTime.Now.Hour < 22 && DateTime.Now.Hour >= 18)
                            {
                                ListReceipt[save].Total = 6000 + passday * 35000 + 60000;

                                Turnovermotorbike += ListReceipt[save].Total;

                                ListReceipt[save].TimeOut = DateTime.Now;
                                ListReceipt[save].isLossTicket = true;

                                ListVehicles.Remove(vehicle);
                                ListTicket.Add(ticket);

                                return vehicle;
                            }
                            else
                            {
                                return null;
                            }

                        }
                        else
                        {
                            if (DateTime.Now.Hour < 18 && DateTime.Now.Hour > 8)
                            {
                                ListReceipt[save].Total = 2000 + passday * 15000 + 30000;

                                Turnoverbike += ListReceipt[save].Total;

                                ListReceipt[save].TimeOut = DateTime.Now;
                                ListReceipt[save].isLossTicket = true;

                                ListVehicles.Remove(vehicle);
                                ListTicket.Add(ticket);

                                return vehicle;
                            }
                            else if (DateTime.Now.Hour < 22 && DateTime.Now.Hour >= 18)
                            {
                                ListReceipt[save].Total = 4000 + passday * 15000 + 30000;

                                Turnoverbike += ListReceipt[save].Total;

                                ListReceipt[save].TimeOut = DateTime.Now;
                                ListReceipt[save].isLossTicket = true;

                                ListVehicles.Remove(vehicle);
                                ListTicket.Add(ticket);

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
                else
                {
                    DateTime save = ticket.TimeIn;
                    int shape = ListReceipt.Count;

                    Receipt receipt = new Receipt(vehicle, ticket);
                    ticket.TimeIn = save;
                    receipt.TimeIn = ticket.TimeIn;

                    for (int i = ListReceipt.Count - 1; i >= 0; i--)
                    {
                        if (ListReceipt[i].Equals(receipt))
                        {
                            shape = i;

                            break;
                        }
                    }

                    if (shape < ListReceipt.Count)
                    {
                        ListReceipt.RemoveAt(shape);

                        ticket.TimeOut = DateTime.Now;

                        int passday = ticket.TimeOut.Day - receipt.TimeIn.Day;

                        if (vehicle.Type == "motorbike")
                        {
                            if (receipt.TimeOut.Hour < 18 && receipt.TimeOut.Hour > 8)
                            {
                                receipt.Total = 3000 + passday * 35000;

                                Turnovermotorbike += receipt.Total;

                                receipt.TimeOut = DateTime.Now;

                                ListReceipt.Add(receipt);

                                ListVehicles.Remove(vehicle);
                                ListTicket.Add(ticket);

                                return vehicle;
                            }
                            else if (receipt.TimeOut.Hour < 22 && receipt.TimeOut.Hour >= 18)
                            {
                                receipt.Total = 6000 + passday * 35000;

                                Turnovermotorbike += receipt.Total;

                                receipt.TimeOut = DateTime.Now;

                                ListReceipt.Add(receipt);

                                ListVehicles.Remove(vehicle);
                                ListTicket.Add(ticket);

                                return vehicle;
                            }
                            else
                            {
                                ListReceipt.Add(receipt);

                                return null;
                            }

                        }
                        else
                        {
                            if (receipt.TimeOut.Hour < 18 && receipt.TimeOut.Hour > 8)
                            {
                                receipt.Total = 2000 + passday * 15000;

                                Turnoverbike += receipt.Total;

                                receipt.TimeOut = DateTime.Now;

                                ListReceipt.Add(receipt);

                                ListVehicles.Remove(vehicle);
                                ListTicket.Add(ticket);

                                return vehicle;
                            }
                            else if (receipt.TimeOut.Hour < 22 && receipt.TimeOut.Hour >= 18)
                            {
                                receipt.Total = 4000 + passday * 15000;

                                Turnoverbike += receipt.Total;

                                receipt.TimeOut = DateTime.Now;

                                ListReceipt.Add(receipt);

                                ListVehicles.Remove(vehicle);
                                ListTicket.Add(ticket);

                                return vehicle;
                            }
                            else
                            {
                                ListReceipt.Add(receipt);

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

        public int getAmountVehicle()
        {
            return ListVehicles.Count;
        }

        public double getTurnoverMotorbike()
        {
            return Turnovermotorbike;
        }

        public double getTurnoverBike()
        {
            return Turnoverbike;
        }

        public double getTurnover()
        {
            return Turnovermotorbike + Turnoverbike;
        }

        public List<Vehicle> listVehiclelostTicket()
        {
            List<Vehicle> listvehiclelostticket = new List<Vehicle>();

            foreach(Receipt receipt in ListReceipt)
            {
                if(receipt.isLossTicket)
                {
                    listvehiclelostticket.Add(receipt.Vehicle);
                }
            }

            return listvehiclelostticket;
        }
    }
}
