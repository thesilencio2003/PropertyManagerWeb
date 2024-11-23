using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyManagerWeb.Data;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Pages.CContratos
{
    public class DeleteModel : PageModel
    {
        private readonly PropertyManagerContext _context;
        public DeleteModel(PropertyManagerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Contratos Contratos { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
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
            else
            {
                Contratos = contratos;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Contratos == null)
            {
                return NotFound();
            }
            var contratos = await _context.Contratos.FindAsync(id);
            if (contratos != null)
            {
                Contratos = contratos;
                _context.Contratos.Remove(Contratos);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");

        }
    }
}
