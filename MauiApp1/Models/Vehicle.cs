using System;
using System.ComponentModel;

namespace MauiApp1.Models
{
    #region enums
    public enum MAKE
    {
        Audi,
        BMW,
        MercedesBenz,
        Volkswagen,
        Lambourghini,
        Ferrari,
        AstonMartin,
        Bently,
        RollsRoyce,
        Tesla,
        Ford,
        Opel,
        Citroen,
        Renault
    }
    public enum BODY_TYPE
    {
        Compact,
        Sedan,
        Convertible,
        Coupe,
        SUV
    }
    //public enum MODEL { }
    public enum FUEL_TYPE
    {
        Gasoline,
        Diesel,
        Electric,
        ElectricGasoline,
        ElectricDisel,
        LPG
    }
    public enum TRANSMISSION
    {
        Manual,
        Automaic,
        SemiAutomatic
    }
    #endregion
    public class Vehicle
    {
        #region properties
        string _vin;
        public string VIN
        {
            get { return _vin; }
            set
            {
                _vin = value;
            }
        }

        MAKE _make;
        public MAKE Make
        {
            get { return _make; }
            set
            {
                _make = value;
            }
        }

        BODY_TYPE _bType;
        public BODY_TYPE BodyType
        {
            get { return _bType; }
            set
            {
                _bType = value;
            }
        }

        string _model;
        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
            }
        }

        FUEL_TYPE _fuel;
        public FUEL_TYPE FuelType
        {
            get { return _fuel; }
            set
            {
                _fuel = value;
            }
        }

        DateTime _registration;
        public DateTime RegistrationDate
        {
            get { return _registration; }
            set
            {
                _registration = value;
            }
        }

        int _milage;
        public int Milage
        {
            get { return _milage; }
            set
            {
                _milage = value;
            }
        }

        double _engineSize;
        public double EngineSize
        {
            get { return _engineSize; }
            set
            {
                _engineSize = value;
            }
        }

        int _power;
        public int Power
        {
            get { return _power; }
            set
            {
                _power = value;
            }
        }

        TRANSMISSION _transmission;
        public TRANSMISSION Transmission
        {
            get { return _transmission; }
            set
            {
                _transmission = value;
            }
        }

        string _imgUrl;
        public string ImageUrl
        {
            get { return _imgUrl; }
            set
            {
                _imgUrl = value;
            }
        }
        #endregion
        public Vehicle(string vin, MAKE make, BODY_TYPE body, string model, FUEL_TYPE fuel, DateTime registration, int milage, double engineSize, int power, TRANSMISSION transmission, string url)
        {
            VIN = vin;
            Make = make;
            BodyType = body;
            Model = model;
            FuelType = fuel;
            RegistrationDate = registration;
            Milage = milage;
            EngineSize = engineSize;
            Power = power;
            Transmission = transmission;
            ImageUrl = url;
        }
    }
}
