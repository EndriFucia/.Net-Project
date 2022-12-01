using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public struct ImageData
    {
        public String ImageName { get; set; }
        public byte[] ImageFile { get; set; }

    }
    public interface IData
    {
        // To be defined...
        public Task<List<Product>> GetAllProducts();
        public Task<Boolean> AddProduct(ProductWrite p);
        public Task<Boolean> UpdateProduct(ProductWrite p, int id);
        public Task<Boolean> DeleteProduct(int id);
    }
}
