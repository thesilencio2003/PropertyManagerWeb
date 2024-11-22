using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyManagerWeb.Data;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Pages.CInquilinos
{
    public class DeleteModel : PageModel
    {
        private readonly PropertyManagerContext _context;
        public DeleteModel(PropertyManagerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Inquilinos Inquilinos { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
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
            else
            {
                Inquilinos = inquilinos;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Inquilinos == null)
            {
                return NotFound();
            }
            var inquilinos = await _context.Inquilinos.FindAsync(id);
            if (inquilinos != null)
            {
                Inquilinos = inquilinos;
                _context.Inquilinos.Remove(Inquilinos);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}

