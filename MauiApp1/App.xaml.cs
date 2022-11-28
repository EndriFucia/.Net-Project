using MauiApp1.Services;
using MauiApp1.ViewModel;

namespace MauiApp1;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new AppShell();
	}
}
