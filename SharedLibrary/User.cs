using Microsoft.EntityFrameworkCore;
using SharedLibrary;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace SharedLibrary;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

