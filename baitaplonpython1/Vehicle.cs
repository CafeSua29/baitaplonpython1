using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitaplonpython1
{
    internal class Vehicle
    {
        public string Type { get; set; }
        public string LicensePlate { get; set; }

        public Vehicle(string type, string licenseplate) 
        { 
            Type = type;
            LicensePlate = licenseplate;
        }

        public bool Equals(Vehicle other)
        {
            if(this.Type == other.Type && this.LicensePlate == other.LicensePlate) 
                return true;
            else
                return false;
        }
    }
}
