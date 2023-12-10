using AllWeKnow.App.Database;
using AllWeKnow.App.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AllWeKnow.App.Services;
using AllWeKnow.App.Repository;
using AllWeKnow.App.Services.Partials;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Services

builder.Services.AddSingleton<ConfigService>();

Directory.CreateDirectory(PathBuilder.Dir("storage"));

// Database
builder.Services.AddDbContext<DataContext>();

// TODO: Add Auto Update Migrations

builder.Services.AddScoped(typeof(Repository<>));

// Users
builder.Services.AddScoped<UserService>();
// Articles
builder.Services.AddScoped<ArticleService>();  
// Subjects
builder.Services.AddScoped<SubjectService>();
// Settings
builder.Services.AddScoped<SettingsService>();
// Jokes
builder.Services.AddScoped<JokeService>();

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
