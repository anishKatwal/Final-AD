using IncomeExpenseTracker.Data;
using Microsoft.Extensions.Logging;

namespace IncomeExpenseTracker
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

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "AppData.db");
            builder.Services.AddSingleton(new DatabaseHelper(dbPath));
            return builder.Build();
        }
    }
}
