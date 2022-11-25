using MauiApp1.Models;
using MauiApp1.ViewModel;
using Newtonsoft.Json;
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
        HttpClient httpClient;
        public ProductsService() 
        { 
            httpClient = new HttpClient();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var response = await httpClient.GetStringAsync("http://10.0.2.2:5067/api/products");
            return JsonConvert.DeserializeObject<List<Product>>(response);
        }
    }
}
