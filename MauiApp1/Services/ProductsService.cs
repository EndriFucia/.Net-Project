using MauiApp1.Models;
using MauiApp1.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class ProductsService
    {
        List<Product> productsList = new();
        Product p1 = new Product(1,"Audi", "Very reliable car!", 15700, "audi.jpg");
        Product p2 = new Product(2, "BMW", "Not as good as audi!", 10000, "bmw.jpg");
        HttpClient httpClient;
        public ProductsService() 
        { 
            httpClient = new HttpClient();
            productsList.Add(p1);
            productsList.Add(p2);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var res = await httpClient.GetStringAsync("https://google.com");
            return productsList;
        }
    }
}
