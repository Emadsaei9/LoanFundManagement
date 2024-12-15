using LoanFundManagement.Models; // فضای نامی که DbContext و مدل‌هایتان در آن قرار دارند.
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// پیکربندی DbContext برای استفاده از SQLite
builder.Services.AddDbContext<LoanFundDbContext>(options =>
    options.UseSqlite("Data Source=LoanFundManagement.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// اطمینان از ایجاد و آماده‌سازی پایگاه داده
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LoanFundDbContext>();
    dbContext.Database.EnsureCreated(); // پایگاه داده را ایجاد می‌کند اگر از قبل وجود نداشته باشد.
}

app.Run();
