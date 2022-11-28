using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public interface IData
    {
        // To be defined...
        public Task<List<Product>> GetAllProducts();
        public Task<Boolean> AddProduct(ProductWrite p);
    }
}
