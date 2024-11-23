using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyManagerWeb.Data;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Pages.CInquilinos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly PropertyManagerContext _context;

        public IndexModel(PropertyManagerContext context)
        {
            _context = context;
        }

        public IList<Inquilinos> Inquilinos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Inquilinos != null)
            {
                Inquilinos = await _context.Inquilinos.ToListAsync();

            }
        }
    }
}
