using MauiApp1.Services;
using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace MauiApp1.ViewModel
{
    public class EditProductViewModel : BaseViewModel,IQueryAttributable
    {
        private readonly ProductsService productsService;

        PickOptions pickOptions;

        private Product _product;
        public Product SelectedProduct 
        { 
            get => _product; 
            set
            {
                _product = value;
                OnPropertyChanged();
            }
        }
        public Command GetFileCommand { get; }
        public Command UpdateProductCommand { get; }
        public Command DeleteProductCommand { get; }

        private String _imgName;
        public String ImageName
        {
            get => _imgName;
            set
            {
                _imgName = value;
                OnPropertyChanged();
            }
        }

        byte[] _file;
        public byte[] File
        {
            get => _file;
            set
            {
                _file = value;
            }
        }

        public EditProductViewModel()
        {
            productsService = new ProductsService();
            pickOptions = new PickOptions();
            pickOptions.PickerTitle = "Select an image";
            GetFileCommand = new Command(async () => await GetFile(pickOptions));
            UpdateProductCommand = new Command(async () => await UpdateProduct());
            DeleteProductCommand = new Command(async () => await DeleteProduct());
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            SelectedProduct = query["Product"] as Product;
            ImageName = SelectedProduct.ImageName.Split("http://10.0.2.2:5067/Images/")[1];
        }

        public async Task UpdateProduct()
        {
            try
            {
                //check if image is still the same
                if(ImageName == SelectedProduct.ImageName.Split("http://10.0.2.2:5067/Images/")[1])
                {
                    var wc = new WebClient();
                    File = wc.DownloadData(new Uri(SelectedProduct.ImageName));
                }

                //Update the 
                if (File != null)
                {
                    var prod = new ProductWrite(SelectedProduct.Name, SelectedProduct.Description, SelectedProduct.Price, ImageName, File);
                    if (await productsService.UpdateProduct(prod, SelectedProduct.Id))
                    {
                        await Application.Current.MainPage.DisplayAlert("Info :", "Product updated sucessfully!", "OK");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Info :", "Product couldn`t be updated!", "OK");
                    }
                }
            }
            catch(Exception ex) 
            {
                await Application.Current.MainPage.DisplayAlert("Products couldn`t be updated!", ex.Message, "OK");
            }
        }

        public async Task DeleteProduct()
        {
            try
            {
                if (await productsService.DeleteProduct(SelectedProduct.Id))
                {
                    await Application.Current.MainPage.DisplayAlert("Info :", "Product deleted sucessfully!", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Info :", "Product couldn`t be deleted!", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Products couldn`t be deleted!", ex.Message, "OK");
            }
        }

        public async Task GetFile(PickOptions options)
        {
            ImageData imgData = await ProductsService.GetFileData(options);
            ImageName = imgData.ImageName;
            File = imgData.ImageFile;
        }
    }
}
