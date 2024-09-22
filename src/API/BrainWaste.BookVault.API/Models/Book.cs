using System.ComponentModel.DataAnnotations;

// TODO With data available determine the probable max length
// ReSharper disable EntityFramework.ModelValidation.UnlimitedStringLength

namespace BrainWaste.BookVault.Api.Models;

public class Book
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public long CreatedAtMs { get; set; }
}