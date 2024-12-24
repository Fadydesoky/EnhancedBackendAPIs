using Microsoft.EntityFrameworkCore;
using SoapCore;
using SharedLibrary;
using SoapApi.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. إعداد قاعدة البيانات باستخدام SQLite
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. إضافة خدمة SoapCore وتسجيل الخدمات
builder.Services.AddSoapCore();
builder.Services.AddScoped<IUserService, UserService>();

// 3. إضافة CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()  // السماح بأي أصل
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// 4. تفعيل CORS
app.UseCors();

app.UseRouting();

// 5. تطبيق الهجرات على قاعدة البيانات عند بدء التشغيل
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
    try
    {
        dbContext.Database.Migrate(); // تطبيق الهجرات
        Console.WriteLine("Database migration applied successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error applying migrations: {ex.Message}");
    }
}

// 6. تكوين نقطة النهاية لخدمة SOAP
app.UseEndpoints(endpoints =>
{
    _ = endpoints.UseSoapEndpoint<IUserService>(
        "/UserService.asmx", // مسار الخدمة
        new SoapEncoderOptions(), // خيارات الترميز
        SoapSerializer.XmlSerializer // نوع الـ Serializer المستخدم
    );
});

app.Run();
