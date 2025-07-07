using LojaDeTenis.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                ViewBag.Erro = "Email e senha são obrigatórios.";
                return View();
            }

            // Gera o hash da senha digitada
            var senhaHash = GerarHash(senha);

            // Busca o usuário com o email
            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(u => u.Email == email);

            // Verifica se usuário existe e a senha bate
            if (usuario == null || usuario.SenhaHash != senha)
            {
                ViewBag.Erro = "Usuário ou senha inválidos";
                return View();
            }

            // Criação do cookie de autenticação
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim("IsAdmin", usuario.IsAdmin.ToString())
            };

            var identidade = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identidade);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal);

            return RedirectToAction("Index", "Home");
        }

        // ✅ Método de logout seguro via POST com token antifalsificação
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sair()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        // 🔐 Gera hash SHA256 (simples)
        private string GerarHash(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(senha);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}