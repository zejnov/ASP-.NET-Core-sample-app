using Microsoft.EntityFrameworkCore;
using MyBusinessApp.Exception;
using MyBusinessApp.View;
using MyDataApp.Model;

namespace MyBusinessApp.Service.Impl;

public class EmailService : IEmailService
{
    private MyDbContext _dbContext { get; set; }

    public EmailService(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Email> GetByIdAsync(int emailId) =>
        await _dbContext.Emails.FirstOrDefaultAsync(e => e.Id == emailId) ??
        throw new ObjectNotFoundException();

    public async Task<Email> CreateAsync(EmailView? emailView)
    {
        var email = new Email()
        {
            Address = emailView.Address,
            PersonId = emailView.PersonId
        };
        _dbContext.Add(email);
        await _dbContext.SaveChangesAsync();
        return email;
    }

    public async Task<Email> UpdateAsync(int emailId, EmailView? updatedEmail)
    {
        var dbEmail = await GetByIdAsync(emailId);
        dbEmail.Address = updatedEmail.Address;
        await _dbContext.SaveChangesAsync();
        return dbEmail;
    }

    public async Task DeleteAsync(int emailId)
    {
        _dbContext.Remove(GetByIdAsync(emailId));
        await _dbContext.SaveChangesAsync();
    }
}