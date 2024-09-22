using BrainWaste.BookVault.Maui.Data;
using BrainWaste.BookVault.Maui.Extensions;
using BrainWaste.BookVault.Maui.PageModels;
using BrainWaste.BookVault.Maui.Pages;
using BrainWaste.BookVault.Maui.Services.Books;
using BrainWaste.BookVault.Maui.Services.Books.Impls;
using Microsoft.Extensions.Logging;

namespace BrainWaste.BookVault.Maui;

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

        builder.Services.AddServices();
        builder.Services.AddPages();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static void AddServices(this IServiceCollection serviceCollection)
    {
        var dbPath = Path.Combine(FileSystem.Current.AppDataDirectory, "bookvault.db");
        serviceCollection.AddSingleton<Database>(s => new Database(dbPath));
        serviceCollection.AddSingleton<IBookService, BookService>();
    }

    private static void AddPages(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddPage<MainPage, MainPageModel>();
        serviceCollection.AddPage<BooksPage, BooksPageModel>();
    }
}