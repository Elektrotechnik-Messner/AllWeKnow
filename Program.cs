using AllWeKnow.App.Database;
using AllWeKnow.App.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AllWeKnow.App.Services;
using AllWeKnow.App.Repository;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();



//Services

builder.Services.AddSingleton<ConfigService>();

Directory.CreateDirectory(PathBuilder.Dir("storage"));

// Database
builder.Services.AddDbContext<DataContext>();

builder.Services.AddScoped(typeof(Repository<>));


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Services.GetRequiredService<ConfigService>();

app.Run();
