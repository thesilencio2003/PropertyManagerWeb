using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PropertyManagerWeb.Data;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Pages.CPagos
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
        public Pagos Pagos { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Pagos == null || Pagos == null)
            {
                return Page();
            }
            _context.Pagos.Add(Pagos);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
