using BrainWaste.BookVault.Console.App;

var bookVault = new BookVault();

Console.WriteLine("Starting BookVault...");

string input;
do
{
    Console.WriteLine("1. Load books");
    Console.WriteLine("2. Show books");
    Console.WriteLine("9. Exit");

    Console.Write("Input: ");
    input = Console.ReadLine() ?? string.Empty;

    switch (input)
    {
        case "1":
            await LoadBooksAsync();
            break;
        case "2":
            ShowBooks();
            break;
        case "9":
            Console.WriteLine("Exiting BookVault...");
            break;
        default:
            Console.WriteLine("Invalid input.");
            break;
    }
} while (input != "9");

Console.WriteLine("BookVault is closed");

return 0;

async Task LoadBooksAsync()
{
    Console.WriteLine("Loading books...");
    var books = await bookVault.GetBooksAsync();
    Console.WriteLine("Books are loaded.");
}

void ShowBooks()
{
    if (bookVault.Books.Count == 0)
    {
        Console.WriteLine("No books.");
        return;
    }

    foreach (var book in bookVault.Books)
    {
        Console.WriteLine(book.ToString());
    }
}