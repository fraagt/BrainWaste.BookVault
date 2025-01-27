﻿using System.ComponentModel.DataAnnotations;

namespace BrainWaste.BookVault.Api.Models;

public class Author
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
}