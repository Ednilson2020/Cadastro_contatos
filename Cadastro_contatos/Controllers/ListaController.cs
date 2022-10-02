using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cadastro_contatos.DataBases;
using Cadastro_contatos.Models;

namespace Cadastro_contatos.Controllers
{
    public class ListaController : Controller
    {
        private readonly Contexto _context;

        public ListaController(Contexto context)
        {
            _context = context;
        }

        // GET: Lista
        public async Task<IActionResult> Index()
        {
              return View(await _context.Contatos.ToListAsync());
        }

        // GET: Lista/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }

            var contatos = await _context.Contatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contatos == null)
            {
                return NotFound();
            }

            return View(contatos);
        }

        // GET: Lista/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lista/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Contato,Email")] Contatos contatos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contatos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contatos);
        }

        // GET: Lista/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }

            var contatos = await _context.Contatos.FindAsync(id);
            if (contatos == null)
            {
                return NotFound();
            }
            return View(contatos);
        }

        // POST: Lista/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Contato,Email")] Contatos contatos)
        {
            if (id != contatos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contatos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatosExists(contatos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contatos);
        }

        // GET: Lista/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }

            var contatos = await _context.Contatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contatos == null)
            {
                return NotFound();
            }

            return View(contatos);
        }

        // POST: Lista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contatos == null)
            {
                return Problem("Entity set 'Contexto.Contatos'  is null.");
            }
            var contatos = await _context.Contatos.FindAsync(id);
            if (contatos != null)
            {
                _context.Contatos.Remove(contatos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatosExists(int id)
        {
          return _context.Contatos.Any(e => e.Id == id);
        }
    }
}
