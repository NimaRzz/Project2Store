using Microsoft.EntityFrameworkCore;
using Project2Store.ShopUI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var cnnString = builder.Configuration.GetConnectionString("StoreCnn");
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(cnnString));
builder.Services.AddScoped<IProductRepository, EfProductRepository>();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();

app.UseRouting();


app.UseEndpoints(endpoints =>
        {
        endpoints.MapControllerRoute(
            name: "pagination",
            pattern: "/{controller=Home}/{action=index}/Page{pageNumber}");
        endpoints.MapDefaultControllerRoute();
        }
    );

app.Run();
