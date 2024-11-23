using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyManagerWeb.Data;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Pages.CPagos
{
    public class EditModel : PageModel
    {
        private readonly PropertyManagerContext _context;

        public EditModel(PropertyManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pagos Pagos { get; set; } = default!;

        public async
         Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pagos == null)
            {
                return NotFound();
            }

            var pagos = await _context.Pagos.FirstOrDefaultAsync(m => m.Id == id);

            if (pagos == null)
            {
                return NotFound();
            }

            Pagos = pagos;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pagos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)

            {
                if (!CategoryExists(Pagos.Id))
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
