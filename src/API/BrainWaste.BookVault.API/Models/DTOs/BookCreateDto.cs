namespace BrainWaste.BookVault.Api.Models.DTOs;

public class BookCreateDto
{
    public string Title { get; set; } = string.Empty;

    public Book ToBook()
    {
        return new Book
        {
            Title = Title
        };
    }
}