using MyBusinessApp.Exception;
using MyDataApp.Model;

namespace MyBusinessApp.Service.Impl;

public class EmailService : IEmailService
{
    private MyDbContext _dbContext { get; set; }

    public EmailService(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Email Create(Email email)
    {
        _dbContext.Add(email);
        _dbContext.SaveChanges();
        return email;
    }

    public Email Update(int emailId, Email updatedEmail)
    {
        Email dbEmail = GetById(emailId);
        dbEmail.Address = updatedEmail.Address;
        _dbContext.SaveChanges();
        return dbEmail;
    }
    
    public void Delete (int emailId)
    {
        _dbContext.Remove(GetById(emailId));
        _dbContext.SaveChanges();
    }

    private Email GetById(int emailId) =>
        _dbContext.Emails.FirstOrDefault(e => e.Id == emailId) ??
        throw new ObjectNotFoundException();
}