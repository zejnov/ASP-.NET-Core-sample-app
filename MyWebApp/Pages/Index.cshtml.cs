using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBusinessApp.Service;
using MyDataApp.Model;

namespace MyWebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IPersonService  _personService;

    public IndexModel(ILogger<IndexModel> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    public List<Person> People { get; set; }

    public void OnGet()
    {
        People = _personService.GetAll();
    }
    
    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await _personService.DeleteAsync(id);
        return RedirectToPage();
    }
}