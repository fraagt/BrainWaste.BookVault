using BrainWaste.BookVault.Maui.Pages;
using CommunityToolkit.Mvvm.Input;

namespace BrainWaste.BookVault.Maui.PageModels
{
    public partial class MainPageModel : BasePageModel
    {
        public MainPageModel()
        {
            Title = "Main Page";
        }

        [RelayCommand]
        private async Task LoadBooksAsync()
        {
            if (IsBusy)
                return;

            await Shell.Current.GoToAsync(nameof(BooksPage));

            IsBusy = false;
        }
    }
}