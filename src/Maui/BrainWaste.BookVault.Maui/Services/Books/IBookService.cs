using BrainWaste.BookVault.Maui.Models;

namespace BrainWaste.BookVault.Maui.Services.Books
{
    public interface IBookService
    {
        Task<Book?> GetAsync(int id);
        Task<List<Book>> GetAllAsync();
    }
}