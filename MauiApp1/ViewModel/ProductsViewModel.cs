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

        AddProductViewModel apvm;
        public Product selectedProduct { get; set; }
        public ObservableCollection<Product> productList { get; } = new();
        public Command GetProductsCommand { get; }
        public Command AddProductCommand { get; }
        public Command UpdateProductCommand { get; }
        public ProductsViewModel(ProductsService service)
        {
            apvm = new AddProductViewModel(service);
            productService = service;
            GetProductsCommand = new Command(async () => await GetAllProducts());
            AddProductCommand = new Command(async () => await GoToAddProduct());
            UpdateProductCommand = new Command(async () => await GoToUpateProduct());
            GetAllProducts();
        }

        public async Task GetAllProducts()
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

        public async Task GoToAddProduct()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddProduct(apvm));
        }

        public async Task GoToUpateProduct()
        {
            //await Application.Current.MainPage.DisplayAlert("INFO : ", selectedProduct.Id.ToString(), "OK");
            var navParam = new Dictionary<String, object>
            {
                { "Product" , selectedProduct}
            };
            await Shell.Current.GoToAsync($"UpdateProduct", navParam);
        }
    }
}
