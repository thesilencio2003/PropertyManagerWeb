using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using PropertyManagerWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace PropertyManagerWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly PropertyManagerContext _context;

        public LoginModel(PropertyManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == Email);

            if (user != null && user.Password == Password)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Email, user.Email)
            };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return RedirectToPage("/Index");
            }


            ModelState.AddModelError(string.Empty, "Correo o contraseña incorrectos.");
            return Page();
        }

    }
}
