using JamesTranproject.Interface;
using JamesTranproject.Models;
using JamesTranproject.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Net.NetworkInformation;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<ReactContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DataContext")));

builder.Services.AddTransient<INewsService, NewService>();
builder.Services.AddScoped<IAnouncementService, AnouncementService>();
builder.Services.AddScoped<IEvents, EventsService>();
builder.Services.AddScoped<IHowDoI, HowDoIService>();
builder.Services.AddScoped<IImgGallery, ImgGalleryService>();
builder.Services.AddScoped<IQuickLink, QuicklinkService>();
builder.Services.AddScoped<IVideoGallery, VideoGalleryService>();

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles( new StaticFileOptions
{
    FileProvider= new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Photo")),
    RequestPath="/Photo"
});
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
