namespace BrainWaste.BookVault.Maui.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddPage<TPage, TPageModel>(this IServiceCollection serviceCollection)
        where TPage : class
        where TPageModel : class
    {
        serviceCollection.AddSingleton<TPageModel>();
        serviceCollection.AddSingleton<TPage>();
    }
}