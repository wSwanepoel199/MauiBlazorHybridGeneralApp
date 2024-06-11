using Microsoft.Extensions.Logging;
using MauiBlazorHybrid.Services;

namespace MauiBlazorHybrid
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

            //builder.Services.AddSingleton<DataBaseController.LocalDbService>();
            builder.Services.AddSingleton<ITodoService, TodoService>();
            //builder.Services.AddTransient<MainPage>();
            builder.Services.AddBlazorBootstrap();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
