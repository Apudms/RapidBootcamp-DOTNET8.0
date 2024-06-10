using Microsoft.EntityFrameworkCore;
using RapidBootcamp.WebApplication.DAL;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext untuk EF
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"));
});

// Menambahkan Modul MVC
builder.Services.AddControllersWithViews();

// Menambahkan DI
//builder.Services.AddScoped<ICategory, CategoriesDAL>();
builder.Services.AddScoped<ICategory, CategoriesEF>();
//builder.Services.AddScoped<ICustomer, CustomersDAL>();
builder.Services.AddScoped<ICustomer, CustomersEF>();
builder.Services.AddScoped<IProduct, ProductsEF>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
