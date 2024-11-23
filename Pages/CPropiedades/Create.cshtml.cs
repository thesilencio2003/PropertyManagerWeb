using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PropertyManagerWeb.Data;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Pages.CPropiedades
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
        public
         Propiedades Propiedades
        { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Propiedades == null || Propiedades == null)
            {
                return Page();

            }

            _context.Propiedades.Add(Propiedades);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");

        }
    }
}
