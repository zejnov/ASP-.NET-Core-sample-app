using MyBusinessApp.View;
using MyDataApp.Model;

namespace MyBusinessApp.Service;

public interface IEmailService
{
    Task<Email> GetByIdAsync(int emailId);
    Task<Email> CreateAsync(EmailView? emailView);
    Task<Email> UpdateAsync(int emailId, EmailView? updatedEmail);
    Task DeleteAsync(int emailId);
}