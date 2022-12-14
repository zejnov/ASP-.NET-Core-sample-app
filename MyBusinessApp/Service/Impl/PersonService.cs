using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

    public async Task<Person> GetByIdAsync(int personId)
    {
        return await _dbContext.Persons
                   .Include(p => p.Emails)
                   .FirstOrDefaultAsync(p => p.Id == personId) ??
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

    public async Task<Person> UpdateAsync(int personId, PersonView updatedPerson)
    {
        var dbPerson = await GetByIdAsync(personId);
        dbPerson.FirstName = updatedPerson.FirstName;
        dbPerson.LastName = updatedPerson.LastName;
        dbPerson.Description = updatedPerson.Description;
        await _dbContext.SaveChangesAsync();
        return dbPerson;
    }

    public async Task DeleteAsync(int personId)
    {
        _dbContext.Persons.Remove(await GetByIdAsync(personId));
        await _dbContext.SaveChangesAsync();
    }
}