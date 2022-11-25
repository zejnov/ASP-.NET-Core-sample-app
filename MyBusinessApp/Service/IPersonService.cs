﻿using MyBusinessApp.View;
using MyDataApp.Model;

namespace MyBusinessApp.Service;

public interface IPersonService
{
    List<Person> GetAll();
    Person GetById(int personId, bool withIncludes = false);
    Task<Person> CreateAsync(PersonView person);
    Person Update(int personId, Person updatedPerson);
    void Delete(int personId);
}