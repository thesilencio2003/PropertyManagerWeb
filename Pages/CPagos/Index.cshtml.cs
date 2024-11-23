using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyManagerWeb.Data;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Pages.CPagos
{
    public class IndexModel : PageModel
    {
     

			private readonly PropertyManagerContext _context;

		public IndexModel(PropertyManagerContext context)
		{
			_context = context;
		}

		public IList<Pagos> Pagos { get; set; } = default!;

		public async Task OnGetAsync()
		{
			if (_context.Pagos != null)
			{

				Pagos = await _context.Pagos.ToListAsync();

			}
		}
	}
}

