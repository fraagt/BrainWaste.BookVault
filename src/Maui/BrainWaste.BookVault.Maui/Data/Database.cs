using BrainWaste.BookVault.Maui.Data.Entities;
using SQLite;

namespace BrainWaste.BookVault.Maui.Data;

public class Database
{
    private readonly SQLiteAsyncConnection _connection;

    public ISQLiteAsyncConnection AsyncConnection => _connection;

    public Database(string dbPath)
    {
        _connection = new SQLiteAsyncConnection(dbPath);
        _connection.CreateTableAsync<BookEntity>().Wait();
    }
}