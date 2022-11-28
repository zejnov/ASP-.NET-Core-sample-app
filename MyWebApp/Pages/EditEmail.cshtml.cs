using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBusinessApp.Service;
using MyBusinessApp.View;

namespace MyWebApp.Pages;

public class EditEmail : PageModel
{
    private IEmailService _emailService;

    public EditEmail(IEmailService emailService)
    {
        _emailService = emailService;
    }
    
    [BindProperty]
    public EmailView? EmailView { get; set; }
    
    public async Task<IActionResult> OnGetAsync(int? id)
    {
        var email = await _emailService.GetByIdAsync(id.Value);
        EmailView = new EmailView(email);
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync(int? id)
    {
        var email = await _emailService.UpdateAsync(id!.Value, EmailView);
        return RedirectToPage($"./Index");
    }
}