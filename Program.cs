using Microsoft.EntityFrameworkCore;
using WebTatIntek.Entity;

using WebTatIntek.Models;

var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(); //�������� �����������

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
    pattern: "{controller=Home}/{action=Index}/{id?}"); //��� ����������� ������� ��������

app.UseSession();

app.Run();
