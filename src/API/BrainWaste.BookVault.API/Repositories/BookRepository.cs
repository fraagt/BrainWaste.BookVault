using BrainWaste.BookVault.Api.Data;
using BrainWaste.BookVault.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BrainWaste.BookVault.Api.Repositories;

public class BookRepository(AppDbContext context)
{
    public async Task<List<Book>> GetAllAsync()
    {
        return await context.Books.ToListAsync();
    }

    public async Task AddAsync(Book book)
    {
        context.Books.Add(book);
        await context.SaveChangesAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await context.Books.FirstOrDefaultAsync(book => book.Id == id);
    }
}