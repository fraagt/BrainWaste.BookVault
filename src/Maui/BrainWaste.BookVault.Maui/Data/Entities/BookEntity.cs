using System.ComponentModel;
using SQLite;

namespace BrainWaste.BookVault.Maui.Data.Entities;

[Table("Books")]
public class BookEntity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Title { get; set; }
    [DefaultValue("NaN")]
    public string Authors { get; set; }
}