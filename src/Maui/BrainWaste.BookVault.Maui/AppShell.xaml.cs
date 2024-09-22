using BrainWaste.BookVault.Maui.Pages;

namespace BrainWaste.BookVault.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(BooksPage), typeof(BooksPage));
        }
    }
}