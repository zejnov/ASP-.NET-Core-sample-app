using Microsoft.EntityFrameworkCore;
using MyBusinessApp.Exception;
using MyBusinessApp.View;
using MyDataApp.Model;

namespace MyBusinessApp.Service.Impl;

public class PersonService : IPersonService
{
    private MyDbContext _dbContext { get; set; }

    public PersonService(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Person> GetAll()
    {
        return _dbContext.Persons
            .Include(p => p.Emails)
            .ToList();
    }

    public Person GetById(int personId, bool withIncludes = false)
    {
        var personsQuery = _dbContext.Persons;

        if (withIncludes)
            personsQuery.Include(p => p.Emails);

        return personsQuery.FirstOrDefault(p => p.Id == personId) ??
               throw new ObjectNotFoundException();
    }

    public async Task<Person> CreateAsync(PersonView personView)
    {
        var person = new Person()
        {
            FirstName = personView.FirstName,
            LastName = personView.LastName,
            Description = personView.Description,
        };
        _dbContext.Add(person);
        await _dbContext.SaveChangesAsync();
        return person;
    }

    public Person Update(int personId, Person updatedPerson)
    {
        var dbPerson = GetById(personId);
        dbPerson.FirstName = updatedPerson.FirstName;
        dbPerson.LastName = updatedPerson.LastName;
        dbPerson.Description = updatedPerson.Description;
        _dbContext.SaveChanges();
        return dbPerson;
    }

    public void Delete(int personId)
    {
        _dbContext.Persons.Remove(GetById(personId));
    }
}