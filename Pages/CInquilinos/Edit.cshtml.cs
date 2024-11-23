using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyManagerWeb.Data;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Pages.CInquilinos
{
    public class EditModel : PageModel
    {
        private readonly PropertyManagerContext _context;

        public EditModel(PropertyManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inquilinos Inquilinos { get; set; } = default!;

        public async
         Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inquilinos == null)
            {
                return NotFound();
            }

            var inquilinos = await _context.Inquilinos.FirstOrDefaultAsync(m => m.Id == id);

            if (inquilinos == null)
            {
                return NotFound();
            }

            Inquilinos = inquilinos;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Inquilinos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)

            {
                if (!CategoryExists(Inquilinos.Id))
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
