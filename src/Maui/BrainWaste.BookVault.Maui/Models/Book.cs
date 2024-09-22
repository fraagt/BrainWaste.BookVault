namespace BrainWaste.BookVault.Maui.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        // New property for formatted display
        public string DisplayText => $"{Id} - {Title}";
    }
}