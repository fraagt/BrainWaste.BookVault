namespace BrainWaste.BookVault.Console.App.Models;

public class Book(int id)
{
    public int Id { get; } = id;
    public string Title { get; set; }
    public string Authors { get; set; }

    public override string ToString()
    {
        return $"{Id} - {Title} by {Authors}";
    }
}