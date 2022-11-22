using System;
using System.Collections.ObjectModel;

namespace MauiApp1.Models
{
    public class MyShop
    {
        public ObservableCollection<Vehicle> vehiclesList { get; set; } = new ObservableCollection<Vehicle>();
        Vehicle v1 = new Vehicle("1WXASCALAKSDA", MAKE.Audi, BODY_TYPE.Sedan, "A4", FUEL_TYPE.Diesel, new DateTime(), 12500, 1999.0, 144, TRANSMISSION.Manual, "audi.jpg");
        Vehicle v2 = new Vehicle("2AFSAWDLAKSDA", MAKE.BMW, BODY_TYPE.Sedan, "A4", FUEL_TYPE.Gasoline, new DateTime(), 12500, 2498.6, 243, TRANSMISSION.Automaic, "bmw.jpg");
        public MyShop()
        {
            vehiclesList.Add(v1);
            vehiclesList.Add(v2);
        }

        void addVehicle(Vehicle vehicle)
        {
            if (!vehiclesList.Contains(vehicle))
            {
                vehiclesList.Add(vehicle);
            }
        }
    }
}
