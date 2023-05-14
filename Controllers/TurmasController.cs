using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduEscola.Context;
using EduEscola.Models;

namespace EduEscola.Controllers
{
    public class TurmasController : Controller
    {
        private readonly TabEduEscola _context;

        public TurmasController(TabEduEscola context)
        {
            _context = context;
        }

        // GET: Turmas
        public async Task<IActionResult> Index(string Pesquisar)
        {
            int quantidade = _context.Turmas.Count();
            ViewBag.Quantidade = quantidade;

            //int TurmaId = 1;

            //var alunosNaTurma = from aluno in _context.Turmas
            //            where aluno.TurmaId == TurmaId
            //            select aluno;


            var tabEduEscola = _context.Turmas.Include(t => t.Unidades);
            var turmas = from b in _context.Turmas.Include(c => c.Unidades)
                         select b;

            if (!String.IsNullOrEmpty(Pesquisar))
            {
                turmas = turmas.Where(c => c.Unidades.Nome_Unidade.Contains(Pesquisar));
                turmas = turmas.OrderBy(c => c.CodigoTurma);

                return View(await turmas.ToListAsync());

            }

            return View(await tabEduEscola.ToListAsync());
        }

        // GET: Turmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas
                .Include(t => t.Unidades)
                .FirstOrDefaultAsync(m => m.TurmaId == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // GET: Turmas/Create
        public IActionResult Create()
        {
            //ViewData["UnidadeId"] = new SelectList(_context.Unidades, "UnidadeId", "UnidadeId");

            Turma model = new Turma();
            model.Unidadess = _context.Unidades.ToList();

            return View(model);

        }
       
        // POST: Turmas/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TurmaId,CodigoTurma,UnidadeId")] Turma turma)
        {

            if (ModelState.IsValid)
            {
                if (Request.Form["Turno"] == "Manha")
                {
                    turma.Turno = Turno.Manha;
                }
                else if (Request.Form["Turno"] == "Tarde")
                {
                    turma.Turno = Turno.Tarde;
                }
                else if (Request.Form["Turno"] == "Noite")
                {
                    turma.Turno = Turno.Noite;
                }
                string nomeTurno = turma.Turno.ToString();

                _context.Add(turma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_CreateModal", turma);
            //ViewData["UnidadeId"] = new SelectList(_context.Unidades, "UnidadeId", "UnidadeId", turma.UnidadeId);
            //return View(turma);
        }

        // GET: Turmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }
            ViewData["UnidadeId"] = new SelectList(_context.Unidades, "UnidadeId", "UnidadeId", turma.UnidadeId);
            return View(turma);
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TurmaId,CodigoTurma,UnidadeId")] Turma turma)
        {
            if (id != turma.TurmaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaExists(turma.TurmaId))
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
            ViewData["UnidadeId"] = new SelectList(_context.Unidades, "UnidadeId", "UnidadeId", turma.UnidadeId);
            return View(turma);
        }

        // GET: Turmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas
                .Include(t => t.Unidades)
                .FirstOrDefaultAsync(m => m.TurmaId == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);
            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaExists(int id)
        {
            return _context.Turmas.Any(e => e.TurmaId == id);
        }
    }
}
