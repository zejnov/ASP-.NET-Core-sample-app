using MyDataApp.Model;

namespace MyBusinessApp.View;

public class EmailView
{
    public EmailView()
    {
    }
    public EmailView(Email email)
    {
        Id = email.Id;
        Address = email.Address;
        PersonId = email.PersonId;
    }

    public int Id { get; set; }
    public string Address { get; set; }
    public int PersonId { get; set; }
}