using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PropertyManagerWeb.Data;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Pages.CInquilinos
{
    public class CreateModel : PageModel
    {
        private readonly PropertyManagerContext _context;
        public CreateModel(PropertyManagerContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Inquilinos Inquilinos { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Inquilinos == null || Inquilinos == null)
            {
                return Page();
            }
            _context.Inquilinos.Add(Inquilinos);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    

    }
}
