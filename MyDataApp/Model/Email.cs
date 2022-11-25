using System.ComponentModel.DataAnnotations;

namespace MyDataApp.Model;

public class Email
{
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string Address { get; set; }
    
    public int PersonId { get; set; }
    public Person Person { get; set; }
}