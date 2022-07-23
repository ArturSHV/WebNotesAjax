using Microsoft.EntityFrameworkCore;
using WebTatIntek.Entity;

using WebTatIntek.Models;

var builder = WebApplication.CreateBuilder(args);

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(); //добавить авторизацию

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".MyApp.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(3600);
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews(); 

var app = builder.Build();

app.UseStaticFiles(); 

app.UseAuthorization(); 

app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //для подключения главной страницы

app.UseSession();

app.Run();
