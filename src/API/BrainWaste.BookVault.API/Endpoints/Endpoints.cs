using BrainWaste.BookVault.Api.Models.DTOs;
using BrainWaste.BookVault.Api.Repositories;

namespace BrainWaste.BookVault.Api.Endpoints;

public static class Endpoints
{
    public static void ConfigureEndpoints(this WebApplication webApplication)
    {
        webApplication.MapGet("/books/get", GetBooks)
            .Produces<IEnumerable<BookReadDto>>()
            .WithName(nameof(GetBooks))
            .WithOpenApi();

        webApplication.MapGet("/books/get/{id:int}", GetBookById)
            .Produces<BookReadDto>()
            .WithName(nameof(GetBookById))
            .WithOpenApi();

        webApplication.MapPost("/books/add", AddBook)
            .Produces<BookReadDto>()
            .Produces(StatusCodes.Status404NotFound)
            .WithName(nameof(AddBook))
            .WithOpenApi();
    }

    private static async Task<IResult> GetBooks(BookRepository bookRepository)
    {
        var books = await bookRepository.GetAllAsync();
        return Results.Ok(books.Select(BookReadDto.ToReadDto));
    }

    private static async Task<IResult> AddBook(BookRepository bookRepository, BookCreateDto newBook)
    {
        var book = newBook.ToBook();
        await bookRepository.AddAsync(book);
        return Results.Created($"/books/{book.Id}", BookReadDto.ToReadDto(book));
    }

    private static async Task<IResult> GetBookById(BookRepository bookRepository, int id)
    {
        var book = await bookRepository.GetByIdAsync(id);
        return book == null ? Results.NotFound() : Results.Ok(BookReadDto.ToReadDto(book));
    }
}