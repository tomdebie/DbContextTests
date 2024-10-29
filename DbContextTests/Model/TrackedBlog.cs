using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DbContextTests.Model;

public class TrackedBlog : Blog
{
    public string? Source { get; set; }

    public string? Medium { get; set; }

    public string? Campaign { get; set; }
}
