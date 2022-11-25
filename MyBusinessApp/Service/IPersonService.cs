using MyBusinessApp.View;
using MyDataApp.Model;

namespace MyBusinessApp.Service;

public interface IPersonService
{
    List<Person> GetAll();
    Task<Person> GetById(int personId, bool withIncludes = false);
    Task<Person> CreateAsync(PersonView person);
    Task<Person> Update(int personId, Person updatedPerson);
    Task Delete(int personId);
}