using Microsoft.EntityFrameworkCore;
using MyBusinessApp.Service;
using MyBusinessApp.Service.Impl;
using MyDataApp.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IEmailService, EmailService>();

var connectionString = "Server=localhost;Database=mywebapp;user id=user;Password=password";
builder.Services.AddDbContext<MyDbContext>(x => x.UseNpgsql(connectionString));

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();