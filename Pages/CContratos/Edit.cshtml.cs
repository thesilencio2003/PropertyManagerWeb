using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyManagerWeb.Data;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Pages.CContratos
{
    public class EditModel : PageModel
    {
        private readonly PropertyManagerContext _context;
        public EditModel(PropertyManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contratos Contratos { get; set; } = default!;
        public async
         Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contratos == null)
            {
                return NotFound();
            }

            var contratos = await _context.Contratos.FirstOrDefaultAsync(m => m.Id == id);

            if (contratos == null)
            {
                return NotFound();
            }

            Contratos = contratos;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Contratos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)

            {
                if (!CategoryExists(Contratos.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CategoryExists(int id)
        {
            return (_context.Inquilinos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
