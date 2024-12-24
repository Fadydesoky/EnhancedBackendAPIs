using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SharedLibrary;
using Microsoft.EntityFrameworkCore.Sqlite;



namespace SharedLibrary;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApiDbContext>
{
    public ApiDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();
        optionsBuilder.UseSqlite("Data Source=../shared.db");

        return new ApiDbContext(optionsBuilder.Options);
    }
}

