using MauiApp1.Models;
using MauiApp1.ViewModel;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http.Internal;

namespace MauiApp1.Services
{
    public class ProductsService : IData
    {
        HttpClient httpClient;
        private readonly String URL = "http://10.0.2.2:5067/api/products";
        public ProductsService() 
        { 
            httpClient = new HttpClient();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var response = await httpClient.GetStringAsync(URL);
            return JsonConvert.DeserializeObject<List<Product>>(response);
        }

        public async Task<Boolean> AddProduct(ProductWrite p)
        {
            HttpContent content = new StringContent(p.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(URL, content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
