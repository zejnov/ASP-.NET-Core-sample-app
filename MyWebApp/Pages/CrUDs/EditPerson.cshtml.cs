using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBusinessApp.Service;
using MyBusinessApp.View;

namespace MyWebApp.Pages.CrUDs;

public class EditPerson : PageModel
{
    private IPersonService _personService;
    
    public EditPerson(IPersonService personService)
    {
        _personService = personService;
    }
    
    public void OnGet()
    {
        
    }

    [BindProperty]
    public PersonView? PersonView { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        var person = await _personService.GetById(id.Value);
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // if (Customer != null)
        // {
        //     _context.Attach(Customer).State = EntityState.Modified;
        //
        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!CustomerExists(Customer.Id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }
        // }

        return RedirectToPage("./Index");
    }

    // private bool CustomerExists(int id)
    // {
    //     return _context.Customer.Any(e => e.Id == id);
    // }
}