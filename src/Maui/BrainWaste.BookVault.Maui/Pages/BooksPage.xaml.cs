using BrainWaste.BookVault.Maui.PageModels;

namespace BrainWaste.BookVault.Maui.Pages;

public partial class BooksPage : ContentPage
{
	public BooksPage(BooksPageModel pageModel)
	{
		InitializeComponent();

		BindingContext = pageModel;
	}
}