using LojaDeTenis.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SQLitePCL;
using System.Security.Claims;

namespace LojaDeTenis.Controllers
{

    public class LoginController : Controller
    {
       private readonly LojaDeTenisContext _context;
    
       public LoginController(LojaDeTenisContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string senha)
        {
            var usuario = await _context.Usuario
            .FirstOrDefaultAsync(u => u.Email == email && u.SenhaHash == senha);

            if (usuario == null)
            {
                ViewBag.Erro = "Usuário ou senha inválidos";
                return View();
            }

            // Criação do cookie de autenticação
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario.Nome),
            new Claim("IsAdmin", usuario.IsAdmin.ToString())
        };

            var identidade = new ClaimsIdentity(claims, "Login");
            var principal = new ClaimsPrincipal(identidade);
            await HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Sair()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

    }
}
