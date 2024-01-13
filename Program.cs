using AllWeKnow.App.Auth;
using AllWeKnow.App.Database;
using AllWeKnow.App.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AllWeKnow.App.Services;
using AllWeKnow.App.Repository;
using AllWeKnow.App.Configuration;
using AllWeKnow.App.Services.Partials;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Authentication.Cookies;
using Logging.Net;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;



// setup logger
Logger.UseSBLogger();

ConfigHelper configHelper = new();

await configHelper.Perform();

ConfigService configService = new();

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Services



builder.Services.AddSingleton<ConfigService>();

Logger.Info("Successfully initialised the configuration");

// Database

DatabaseCheckup databaseCheckup = new (configService);
await databaseCheckup.Perform();

builder.Services.AddDbContext<DataContext>();


builder.Services.AddScoped(typeof(Repository<>));

// Users

builder.Services.AddScoped<UserService>();
Logger.Info("Successfully initialised the UserService");

// Auth
builder.Services.AddAuthenticationCore();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

// Articles

builder.Services.AddScoped<ArticleService>();  
Logger.Info("Successfully initialised the ArticleService");

builder.Services.AddSignalR(e => {
    e.MaximumReceiveMessageSize = 2 * 1024 * 1024;
});


// Subjects

builder.Services.AddScoped<SubjectService>();
Logger.Info("Successfully initialised the SubjectService");

// Settings
builder.Services.AddScoped<SettingsService>();
Logger.Info("Successfully initialised the SettingsService");

// Jokes
builder.Services.AddScoped<JokeService>();
Logger.Info("Successfully added all Services, building Application now.");


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
