using MauiApp1.Services;
using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            pickOptions = new PickOptions();
            pickOptions.PickerTitle = "Select an image";
            GetFileCommand = new Command(async () => await GetFile(pickOptions));
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            SelectedProduct = query["Product"] as Product;
            ImageName = SelectedProduct.ImageName;
        }

        public async Task GetFile(PickOptions options)
        {
            ImageData imgData = await ProductsService.GetFileData(options);
            ImageName = imgData.ImageName;
            File = imgData.ImageFile;
        }
    }
}
