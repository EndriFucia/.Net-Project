namespace MauiApp1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(AddProduct), typeof(AddProduct));
        Routing.RegisterRoute(nameof(UpdateProduct), typeof(UpdateProduct));
    }
}
