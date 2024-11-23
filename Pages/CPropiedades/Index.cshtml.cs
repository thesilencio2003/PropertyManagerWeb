using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyManagerWeb.Data;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Pages.CPropiedades
{
    [Authorize]
    public class IndexModel : PageModel
    {
            private readonly PropertyManagerContext _context;

            public IndexModel(PropertyManagerContext context)
            {
                _context = context;
            }

            public IList<Propiedades> Propiedades { get; set; } = default!;

            public async Task OnGetAsync()
            {
                if (_context.Propiedades != null)
                {
                Propiedades = await _context.Propiedades.ToListAsync();

                }
            }
        }
}
