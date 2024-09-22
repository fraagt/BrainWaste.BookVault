using BrainWaste.BookVault.Maui.PageModels;

namespace BrainWaste.BookVault.Maui.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageModel pageModel)
    {
        InitializeComponent();

        BindingContext = pageModel;
    }
}