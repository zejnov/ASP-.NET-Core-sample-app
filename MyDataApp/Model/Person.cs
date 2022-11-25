using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MyDataApp.Model;

public class Person
{
    [ValidateNever]
    public int Id { get; set; }
    
    [Required, StringLength(50)]
    public string FirstName { get; set; }
    
    [Required, StringLength(50)]
    public string LastName { get; set; }
    
    public string Description { get; set; }
    
    [ValidateNever]
    public List<Email> Emails { get; set; }
}