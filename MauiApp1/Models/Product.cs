using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Product
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

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

        private string _imageName;
        public string ImageName
        {
            get { return _imageName; }
            set { _imageName = value; }
        }

        private ImageSource _imageSource;
        public ImageSource ImageSource
        {
            get { return _imageSource; }
            set { _imageSource = value; }
        }

        public Product(int id, String name, String description, int price, String image)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            ImageName = image.Split("http://10.0.2.2:5067/Images/")[1];
            ImageSource = ImageSource.FromUri(new Uri(image));
        }

        new public String ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
