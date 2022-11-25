using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBusinessApp.Service;
using MyBusinessApp.View;

namespace MyWebApp.Pages.CrUDs;

public class CreatePerson : PageModel
{
    private IPersonService _personService;
    
    public CreatePerson(IPersonService personService)
    {
        _personService = personService;
    }
    
    public void OnGet()
    {
        
    }
    
    [BindProperty]
    public PersonView? Person { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _personService.CreateAsync(Person!);
        
        return RedirectToPage("./Index");
    }
}