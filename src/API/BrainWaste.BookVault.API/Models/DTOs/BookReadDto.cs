namespace BrainWaste.BookVault.Api.Models.DTOs;

public class BookReadDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public static BookReadDto ToReadDto(Book book)
    {
        return new BookReadDto
        {
            Id = book.Id,
            Title = book.Title
        };
    }
}