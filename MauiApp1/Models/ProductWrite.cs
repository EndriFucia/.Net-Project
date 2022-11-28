using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class ProductWrite
    {
        private String _name;
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private String _description;
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private double _price;
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private String _image;
        public String Image
        {
            get { return _image; }
            set { _image = value; }
        }

        private byte[] _file;
        public byte[] File
        {
            get { return _file; }
            set { _file = value; }
        }

        public ProductWrite(String name, String description, int price, String image, byte[] file)
        {
            Name = name;
            Description = description;
            Price = price;
            Image = image;
            File = file;
        }

        new public String ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
