using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyManagerWeb.Data;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Pages.CPropiedades
{
    public class DeleteModel : PageModel
    {
        private readonly PropertyManagerContext _context;

        public DeleteModel(PropertyManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Propiedades Propiedades { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
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
            else
            {
                Propiedades = propiedades;
            }

            return Page();

        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Propiedades == null)
            {
                return NotFound();
            }

            var propiedades = await _context.Propiedades.FindAsync(id);


            if (propiedades != null)
            {
                Propiedades = propiedades;
                _context.Propiedades.Remove(Propiedades);
                await _context.SaveChangesAsync();

            }

            return RedirectToPage("./Index");
        }

    }
}
