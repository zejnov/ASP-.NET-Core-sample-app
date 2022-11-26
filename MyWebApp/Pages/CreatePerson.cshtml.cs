using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBusinessApp.Service;
using MyBusinessApp.View;

namespace MyWebApp.Pages;

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
    public PersonView? PersonView { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _personService.CreateAsync(PersonView!);
        
        return RedirectToPage("./Index");
    }
}