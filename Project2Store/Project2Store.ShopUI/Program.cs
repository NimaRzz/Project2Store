var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();

app.UseRouting();


app.UseEndpoints(endpoints =>
    endpoints.MapDefaultControllerRoute()
);

app.Run();
