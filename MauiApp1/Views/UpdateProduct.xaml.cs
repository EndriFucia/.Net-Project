using MauiApp1.ViewModel;
namespace MauiApp1;

public partial class UpdateProduct : ContentPage
{
	public UpdateProduct()
	{
		InitializeComponent();
		BindingContext = new EditProductViewModel();
	}
}