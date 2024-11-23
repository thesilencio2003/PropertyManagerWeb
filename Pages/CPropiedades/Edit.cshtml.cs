using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyManagerWeb.Data;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Pages.CPropiedades
{
    public class EditModel : PageModel
    {
        private readonly PropertyManagerContext _context;

        public EditModel(PropertyManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Propiedades Propiedades { get; set; } = default!;

        public async
         Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Propiedades == null)
            {
                return NotFound();
            }

            var propiedades = await _context.Propiedades.FirstOrDefaultAsync(m => m.Id == id);

            if (propiedades == null)
            {
                return NotFound();
            }

            Propiedades = propiedades;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Propiedades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)

            {
                if (!CategoryExists(Propiedades.Id))
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
            return (_context.Propiedades?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
