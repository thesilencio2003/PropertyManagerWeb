using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyManagerWeb.Data;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Pages.CPagos
{
    public class DeleteModel : PageModel
    {
        private readonly PropertyManagerContext _context;
        public DeleteModel(PropertyManagerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Pagos Pagos { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
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
            else
            {
                Pagos = pagos;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Pagos == null)
            {
                return NotFound();
            }
            var pagos = await _context.Pagos.FindAsync(id);
            if (pagos != null)
            {
                Pagos = pagos;
                _context.Pagos.Remove(Pagos);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");

        }
    }
}