using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBusinessApp.Service;
using MyBusinessApp.View;

namespace MyWebApp.Pages;

public class EditPerson : PageModel
{
    private IPersonService _personService;

    public EditPerson(IPersonService personService)
    {
        _personService = personService;
    }

    [BindProperty] public PersonView? PersonView { get; set; }

    public List<EmailView> Emails { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        var person = await _personService.GetByIdAsync(id.Value);
        PersonView = new PersonView(person);
        Emails = person.Emails.Any()
            ? person.Emails.Select(e => new EmailView(e)).ToList()
            : new List<EmailView>();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        var _ = await _personService.UpdateAsync(id!.Value, PersonView);

        return RedirectToPage("./Index");
    }
}