using MauiApp1.Models;
using MauiApp1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public class AddProductViewModel: BaseViewModel
    {
        private readonly ProductsService ProductService;

        private PickOptions pickOptions;

        String _name;
        public String _Name { 
            get => _name;
            set
            {
                _name = value;
            } 
        }
        public String _Description { get; set; } = String.Empty;
        public int _Price { get; set; } = 0;

        String _imgPath;
        public String _ImagePath 
        { 
            get => _imgPath;
            set
            {
                _imgPath = value;
                OnPropertyChanged();
            } 
        }

        byte[] _file;
        public byte[] _File
        {
            get => _file;
            set
            {
                _file = value;
            }
        }

        public Command AddProductCommand { get; }
        public Command GetFileCommand { get; }

        public AddProductViewModel(ProductsService prodService)
        {
            pickOptions= new PickOptions();
            pickOptions.PickerTitle = "Select an image";
            ProductService = prodService;
            AddProductCommand = new Command(async () => await AddProduct());
            GetFileCommand = new Command(async () => await GetFile(pickOptions));
        }

        public async Task GetFile(PickOptions options)
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(options);
                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    var ms = new MemoryStream();
                    stream.CopyTo(ms);
                    _File= ms.ToArray();
                    _ImagePath = result.FileName;
                }            
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Info :", ex.Message, "OK");
            }

        }
        public async Task AddProduct()
        {
            try
            {
                var product = new ProductWrite(_Name, _Description, _Price, _ImagePath, _File);
                if (product != null)
                {
                    if (await ProductService.AddProduct(product))
                    {
                        await Application.Current.MainPage.DisplayAlert("Info :", "Product added succesfully!", "OK");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Info :", "Product could not be added!", "OK");
                    }
                }

                _Name = String.Empty;
                _Description = String.Empty;
                _Price = 0;
                _ImagePath = String.Empty;
                _File = null;
                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Info :", ex.Message, "OK");
            }
        }
    }
}
