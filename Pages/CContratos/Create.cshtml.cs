using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PropertyManagerWeb.Data;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Pages.CContratos
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
        public Contratos Contratos{ get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Contratos == null || Contratos == null)
            {
                return Page();
            }
            _context.Contratos.Add(Contratos);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
