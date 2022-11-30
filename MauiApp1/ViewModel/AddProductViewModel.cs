using MauiApp1.Models;
using MauiApp1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Maui.Storage;
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

        PickOptions pickOptions;

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
            ProductService = prodService;
            pickOptions = new PickOptions();
            pickOptions.PickerTitle = "Select an image";
            AddProductCommand = new Command(async () => await AddProduct());
            GetFileCommand = new Command(async () => await GetFile(pickOptions));
        }

        public async Task GetFile(PickOptions options)
        {
            ImageData imgData = await ProductsService.GetFileData(options);
            _ImagePath = imgData.ImageName;
            _File = imgData.ImageFile;
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
