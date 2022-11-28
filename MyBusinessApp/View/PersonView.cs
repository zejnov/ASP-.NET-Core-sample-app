using MyDataApp.Model;

namespace MyBusinessApp.View;

public class PersonView
{
    public PersonView()
    {
    }
    
    public PersonView(Person person)
    {
        Id = person.Id;
        FirstName = person.FirstName;
        LastName = person.LastName;
        Description = person.Description;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
}