using System.Collections.ObjectModel;
using BrainWaste.BookVault.Maui.Data;
using BrainWaste.BookVault.Maui.Data.Entities;
using BrainWaste.BookVault.Maui.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BrainWaste.BookVault.Maui.PageModels
{
    public partial class BooksPageModel : BasePageModel
    {
        private readonly Database _database;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsBookTitleValid))]
        [NotifyPropertyChangedFor(nameof(IsAddBookButtonEnabled))]
        private string _bookTitle;

        public bool IsBookTitleValid => !string.IsNullOrEmpty(BookTitle);

        public bool IsAddBookButtonEnabled => !IsBusy && IsBookTitleValid;

        public ObservableCollection<Book> Books { get; } = [];

        public BooksPageModel(Database database)
        {
            _database = database;
            Title = "Books page";

            LoadBooks();
        }

        private async Task LoadBooks()
        {
            IsBusy = true;

            var bookEntities = await _database.AsyncConnection.Table<BookEntity>().ToListAsync();

            bookEntities.ForEach(entity => Books.Add(new Book { Id = entity.Id, Title = entity.Title }));

            IsBusy = false;
        }

        [RelayCommand]
        private async Task AddBookAsync()
        {
            IsBusy = false;

            var entity = new BookEntity
            {
                Title = BookTitle
            };
            await _database.AsyncConnection.InsertAsync(entity);

            Books.Add(new Book { Id = entity.Id, Title = entity.Title });

            // Clear the entry field after adding
            BookTitle = string.Empty;

            IsBusy = false;
        }
    }
}