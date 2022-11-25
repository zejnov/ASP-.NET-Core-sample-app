using Microsoft.EntityFrameworkCore;

namespace MyDataApp.Model;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Server=localhost;Database=mywebapp;user id=user;Password=password"); //TODO get conn string from config file
        base.OnConfiguring(optionsBuilder);
    }
    
    public DbSet<Person> Persons { get; set; }
    public DbSet<Email> Emails { get; set; }
}