using Microsoft.AspNetCore.Components.WebView.Maui;
using SharedLibrary;

namespace BlazorHybridHost
{
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
				});

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSharedStuff();

			return builder.Build();
		}
	}
}