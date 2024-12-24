using GrpcApi.Services;
using Microsoft.EntityFrameworkCore;
using SharedLibrary;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Apply migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
    dbContext.Database.Migrate();
}

app.MapGrpcService<UserService>();
app.MapGrpcReflectionService();

app.Run();