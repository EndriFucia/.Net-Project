using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
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

        private ImageSource _image;
        public ImageSource Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public Product(int id, String name, String description, int price, string image)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Image = ImageSource.FromUri(new Uri(image));
        }
    }
}
