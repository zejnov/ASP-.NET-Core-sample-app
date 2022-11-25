using MyDataApp.Model;

namespace MyBusinessApp.Service;

public interface IEmailService
{
    Email Create(Email email);
    Email Update(int emailId, Email updatedEmail);
    void Delete(int emailId);
}