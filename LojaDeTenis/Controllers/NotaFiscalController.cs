using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LojaDeTenis.Data;
using LojaDeTenis.Models;

namespace LojaDeTenis.Controllers
{
    public class NotaFiscalController : Controller
    {
        private readonly LojaDeTenisContext _context;

        public NotaFiscalController(LojaDeTenisContext context)
        {
            _context = context;
        }

        // Fix for CS1061: Ensure the correct property type is used for _context.NotaFiscal
        public async Task<IActionResult> Index()
        {
            var lojaDeTenisContext = _context.NotaFiscal as DbSet<NotaFiscal>;
            if (lojaDeTenisContext == null)
            {
                return Problem("Entity set 'LojaDeTenisContext.NotaFiscal' is not properly configured.");
            }

            var notaFiscalList = lojaDeTenisContext.Include(n => n.Cliente).Include(n => n.Pedido);
            return View(await notaFiscalList.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NotaFiscal == null)
            {
                return NotFound();
            }

            var lojaDeTenisContext = _context.NotaFiscal as DbSet<NotaFiscal>;
            if (lojaDeTenisContext == null)
            {
                return Problem("Entity set 'LojaDeTenisContext.NotaFiscal' is not properly configured.");
            }

            var notaFiscal = await lojaDeTenisContext
                .Include(n => n.Cliente)
                .Include(n => n.Pedido)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (notaFiscal == null)
            {
                return NotFound();
            }

            return View(notaFiscal);
        }
    }
}
