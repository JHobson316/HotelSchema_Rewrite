using HotelSchema_Rewrite.Data;
using Microsoft.EntityFrameworkCore;
using HotelSchema_Rewrite.Models.Interfaces;
using HotelSchema_Rewrite.Models.Services;
using Microsoft.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TestDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AzureContext")));
builder.Services.AddTransient<IHotel, HotelService>();
builder.Services.AddTransient<IRoom, RoomsService>();
builder.Services.AddTransient<IAmenity, AmenityService>();

builder.Services.AddSwaggerDocument(config =>
{
    config.PostProcess = document =>
    {
        document.Info.Version = "v1";
        document.Info.Title = "Trip-Booker Api";
        document.Info.Description = "A simple AspNet Core Mvc web API";
        document.Info.TermsOfService = "None";
        document.Info.Contact = new NSwag.OpenApiContact
        {
            Name = "Jordan",
            Email = "hobsoncjordan@gmail.com",
            Url = "https://youtube.com"
        };
        document.Info.License = new NSwag.OpenApiLicense
        {
            Name = "Use under MIT",
            Url = "https://opensource.org/licenses/MIT"
        };
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseOpenApi();
app.UseSwaggerUi3();

app.Run();