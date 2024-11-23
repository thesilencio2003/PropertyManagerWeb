using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyManagerWeb.Data;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Pages.CContratos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly PropertyManagerContext _context;

        public IndexModel(PropertyManagerContext context)
        {
            _context = context;
        }

        public IList<Contratos> Contratos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Contratos != null)
            {

                Contratos = await _context.Contratos.ToListAsync();

            }
        }
    }
}
