using MyDataApp.Model;

namespace MyBusinessApp.Database;

//that should be MSSQL LocalDB
public static class DummyData
{
    public static List<Person?> Persons() => new List<Person?>()
    {
        new Person
        {
            Id = 1,
            FirstName = "Just",
            LastName = "Done",
            Description = "just first desc",
            Emails = new List<Email>
            {
                new Email
                {
                    Id = 1,
                    Address = "just@done.com",
                    PersonId = 1,
                },
                new Email
                {
                    Id = 2,
                    Address = "justmakeit@done.com",
                    PersonId = 1,
                }
            }
        },
        new Person
        {
            Id = 2,
            FirstName = "John",
            LastName = "Second",
            Description = "just second",
            Emails = new List<Email>
            {
                new Email
                {
                    Id = 3,
                    Address = "john@second.com",
                    PersonId = 1,
                }
            }
        },
    };
}