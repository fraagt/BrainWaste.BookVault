using System.Diagnostics;
using BrainWaste.BookVault.Console.App.Models;
using BrainWaste.BookVault.Console.App.Models.DTOs;
using Newtonsoft.Json;

namespace BrainWaste.BookVault.Console.App;

public class BookVault
{
    private readonly string _baseUrl = "https://localhost:44385/";
    private readonly HttpClient _httpClient = new();

    public List<Book> Books { get; private set; } = [];

    public async Task<List<Book>> GetBooksAsync()
    {
        var response = await _httpClient.GetAsync(_baseUrl + Endpoints.GetBooks);

        if (!response.IsSuccessStatusCode)
            return [];

        var contentJson = await response.Content.ReadAsStringAsync();
        var wrappedJson = $"{{{nameof(BooksDto.Books)}:{contentJson}}}";
        var booksDto = JsonConvert.DeserializeObject<BooksDto>(wrappedJson);

        if (booksDto == null)
        {
            Debug.Fail("BooksDto is null");
            return [];
        }

        Books = booksDto.Books.Select(bookDto => new Book(bookDto.Id)
            { Title = bookDto.Title, Authors = bookDto.Authors }).ToList();
        return Books;
    }
}