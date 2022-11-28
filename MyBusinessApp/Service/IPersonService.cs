using MyBusinessApp.View;
using MyDataApp.Model;

namespace MyBusinessApp.Service;

public interface IPersonService
{
    List<Person> GetAll();
    Task<Person> GetByIdAsync(int personId);
    Task<Person> CreateAsync(PersonView person);
    Task<Person> UpdateAsync(int personId, PersonView updatedPerson);
    Task DeleteAsync(int personId);
}