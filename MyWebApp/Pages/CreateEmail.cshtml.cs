using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBusinessApp.Service;
using MyBusinessApp.View;

namespace MyWebApp.Pages;

public class CreateEmail : PageModel
{
    private IEmailService _emailService;
    private IPersonService _personService;

    public CreateEmail(IEmailService emailService, IPersonService personService)
    {
        _emailService = emailService;
        _personService = personService;
    }
    
    [BindProperty]
    public EmailView? EmailView { get; set; }
    public PersonView? PersonView { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        var person = await _personService.GetByIdAsync(id.Value);
        PersonView = new PersonView(person)
        {
            
            FirstName = person.FirstName,
            LastName = person.LastName,
            Description = person.Description
        };
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        EmailView.PersonId = PersonView.Id;
        await _emailService.CreateAsync(EmailView);
        
        return RedirectToPage($"./EditPerson/{PersonView.Id}");
    }
}