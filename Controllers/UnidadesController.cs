using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduEscola.Context;
using EduEscola.Models;
using System.IO;

namespace EduEscola.Controllers
{
    public class UnidadesController : Controller
    {
        private readonly TabEduEscola _context;

        public UnidadesController(TabEduEscola context)
        {
            _context = context;
        }

        // GET: Unidades
        public ActionResult Index(string Pesquisar = "")
        {
            int quantidadee = _context.Unidades.Count();
            ViewBag.Quantidadee = quantidadee;

            var unidades = _context.Unidades.AsQueryable();
            if (!string.IsNullOrEmpty(Pesquisar))
                unidades = unidades.Where(c => c.Nome_Unidade.Contains(Pesquisar));
                unidades = unidades.OrderBy(c => c.Nome_Unidade);

            //return View(await _context.Alunos.ToListAsync());
            return View(unidades.ToList());
            //return View(await _context.Unidades.ToListAsync());
        }

        // GET: Unidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidade = await _context.Unidades
                .FirstOrDefaultAsync(m => m.UnidadeId == id);
            if (unidade == null)
            {
                return NotFound();
            }

            return View(unidade);
        }

        // GET: Unidades/Create
        public IActionResult CreateCreate()
        {
            return View() ;
        }

        // POST: Unidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnidadeId,Nome_Unidade,Endereco,Nome_Diretor, Genero")] Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                unidade.Genero = Request.Form["Genero"];
                _context.Add(unidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //return PartialView("_CreateModal", unidade);
            return View(unidade);
        }

        // GET: Unidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidade = await _context.Unidades.FindAsync(id);
            if (unidade == null)
            {
                return NotFound();
            }
            return View(unidade);
        }

        // POST: Unidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnidadeId,Nome_Unidade,Endereco,Nome_Diretor, Genero ")] Unidade unidade)
        {
            if (id != unidade.UnidadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadeExists(unidade.UnidadeId))
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
            return View(unidade);
        }

        // GET: Unidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidade = await _context.Unidades
                .FirstOrDefaultAsync(m => m.UnidadeId == id);
            if (unidade == null)
            {
                return NotFound();
            }

            return View(unidade);
        }

        // POST: Unidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidade = await _context.Unidades.FindAsync(id);
            _context.Unidades.Remove(unidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadeExists(int id)
        {
            return _context.Unidades.Any(e => e.UnidadeId == id);
        }
    }
}
