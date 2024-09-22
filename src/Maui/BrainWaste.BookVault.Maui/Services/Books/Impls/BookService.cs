using BrainWaste.BookVault.Maui.Data;
using BrainWaste.BookVault.Maui.Data.Entities;
using BrainWaste.BookVault.Maui.Models;

namespace BrainWaste.BookVault.Maui.Services.Books.Impls
{
    public class BookService(Database database) : IBookService
    {
        public async Task<List<Book>> GetAllAsync()
        {
            var bookEntities = await database.AsyncConnection.Table<BookEntity>().ToListAsync();

            return bookEntities.Select(ToModel).ToList();
        }

        public async Task<Book?> GetAsync(int id)
        {
            var bookEntity = await database.AsyncConnection.Table<BookEntity>()
                .FirstOrDefaultAsync(entry => entry.Id == id);

            return bookEntity != null
                ? ToModel(bookEntity)
                : null;
        }

        private static Book ToModel(BookEntity bookEntity)
        {
            return new Book
            {
                Id = bookEntity.Id,
                Title = bookEntity.Title
            };
        }
    }
}