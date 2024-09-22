using BrainWaste.BookVault.Api.Models;
using BrainWaste.BookVault.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BrainWaste.BookVault.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options, ITimeService timeService) : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .Property(b => b.CreatedAtMs)
            .HasValueGenerator(CreateCreatedAtMsValueGenerator);
    }

    private ValueGenerator CreateCreatedAtMsValueGenerator(IProperty property, ITypeBase typeBase)
    {
        return new CreatedAtMsValueGenerator(timeService);
    }
}