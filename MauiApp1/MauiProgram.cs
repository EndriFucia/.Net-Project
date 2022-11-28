using MauiApp1.Services;
using MauiApp1.ViewModel;
using MauiApp1.Models;
namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<ProductsService>();

		builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<ProductsViewModel>();

		builder.Services.AddSingleton<AddProduct>();
        builder.Services.AddTransient<AddProductViewModel>();
        return builder.Build();
	}
}
