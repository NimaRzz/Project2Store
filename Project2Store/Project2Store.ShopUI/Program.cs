using Microsoft.EntityFrameworkCore;
using Project2Store.ShopUI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var cnnString = builder.Configuration.GetConnectionString("StoreCnn");
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(cnnString));
builder.Services.AddScoped<IProductRepository, EfProductRepository>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<Basket>(p => SessionBasket.GetBasket(p));

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();


app.UseEndpoints(endpoints =>
        {
        endpoints.MapControllerRoute(
            name: "pagination",
            pattern: "/{controller=Home}/{action=index}/{category}/Page{pageNumber}");
        endpoints.MapControllerRoute(
            name: "pagination",
            pattern: "/{controller=Home}/{action=index}/Page{pageNumber}");
        endpoints.MapControllerRoute(
            name: "pagination",
            pattern: "/{controller=Home}/{action=index}/{category}");
            endpoints.MapDefaultControllerRoute();
        }
    );

app.Run();
