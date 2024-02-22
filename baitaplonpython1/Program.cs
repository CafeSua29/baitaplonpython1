using baitaplonpython1;
using System.Net.Sockets;

ManageVehicles managevehicles = new ManageVehicles(100);

Vehicle vehicle1 = new Vehicle("motorbike", "111");
Vehicle vehicle2 = new Vehicle("bike", "222");
Vehicle vehicle3 = new Vehicle("motorbike", "333");

Console.WriteLine(managevehicles.getAmountVehicle());

Ticket ticket1 = managevehicles.VehicleIn(vehicle1);

DateTime save = ticket1.TimeIn;

Receipt receipt = new Receipt(vehicle1, ticket1);
ticket1.TimeIn = save;
receipt.TimeIn = ticket1.TimeIn;

//Console.WriteLine(managevehicles.ListReceipt[0].Vehicle.LicensePlate);
//Console.WriteLine(receipt.Vehicle.LicensePlate);

Console.WriteLine(managevehicles.getAmountVehicle());

Ticket ticket2 = managevehicles.VehicleIn(vehicle2);

Console.WriteLine(managevehicles.getAmountVehicle());

Vehicle vehicle11 = managevehicles.VehicleOut(vehicle1, ticket2, null);

Console.WriteLine(managevehicles.getAmountVehicle());

vehicle11 = managevehicles.VehicleOut(vehicle1, ticket1, null);

Console.WriteLine(vehicle11.LicensePlate);

Console.WriteLine(managevehicles.getAmountVehicle());

Console.WriteLine(managevehicles.getTurnover());