using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitaplonpython1
{
    internal class Vehicle
    {
        public string Type;
        public string LicensePlate;

        public Vehicle(string type, string licenseplate) 
        { 
            Type = type;
            LicensePlate = licenseplate;
        }
    }
}
