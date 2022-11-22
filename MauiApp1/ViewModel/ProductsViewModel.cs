using MauiApp1.Models;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public class ProductsViewModel: BaseViewModel
    {
        ProductsService productService;

        public ObservableCollection<Product> productList { get; } = new();
        public Command GetProductsCommand { get; }
        public ProductsViewModel(ProductsService productService)
        {
            this.productService = productService;
            GetProductsCommand = new Command(async () => await GetAllProducts());
        }

        async Task GetAllProducts()
        {
            try
            {
                IsBusy = true;

                List<Product> products = await productService.GetAllProducts();
                if (products.Count > 0)
                {
                    productList.Clear();
                    foreach(Product p in products)
                    {
                        productList.Add(p);
                    }
                }

                IsBusy = false;
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Products couldn`t be retrieved!", ex.Message, "OK");
            }
        }
    }
}
