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
    public class MateriasController : Controller
    {
        private readonly TabEduEscola _context;

        public MateriasController(TabEduEscola context)
        {
            _context = context;
        }

        // GET: Materias
        public async Task<IActionResult> Index(string Pesquisar)
        {
            int quantidade = _context.Materias.Count();
            ViewBag.Quantidade = quantidade;

            ViewData["CurrentFilter"] = Pesquisar;
            
            var tabEduEscola = _context.Materias.Include(m => m.Professors).Include(m => m.Turmas).Include(m => m.Turmas.Unidades);
            var materias = from b in _context.Materias.Include(c => c.Turmas.Unidades).Include(m => m.Professors)
                           select b;

            if (!String.IsNullOrEmpty(Pesquisar))
            {
                materias = materias.Where(c => c.Nome_Materia.Contains(Pesquisar));

                materias = materias.OrderBy(c => c.Nome_Materia);

                return View(await materias.ToListAsync());

            }

            return View(await tabEduEscola.ToListAsync());
        }

        // GET: Materias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias
                .Include(m => m.Professors)
                .Include(m => m.Turmas)
                .Include(m => m.Turmas.Unidades)
                .FirstOrDefaultAsync(m => m.MateriaId == id);

            if (materia == null)
            {
                return NotFound();
            }

            return View(materia); ;
        }

        // GET: Materias/Create
        public IActionResult Create()
        {
            //ViewData["ProfessorId"] = new SelectList(_context.Professors, "ProfessorId", "ProfessorId");
            //ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "TurmaId");

            Materia model= new Materia();
            model.Professorss= _context.Professors.ToList();
            model.Turmass = _context.Turmas.ToList();
           
            return View(model);

        }

        // POST: Materias/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MateriaId,ProfessorId,TurmaId,Nome_Materia")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfessorId"] = new SelectList(_context.Professors, "ProfessorId", "ProfessorId", materia.ProfessorId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "TurmaId", materia.TurmaId);
            return View(materia);
        }


        // GET: Materias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //Materia model = new Materia();
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }

            ViewData["ProfessorId"] = new SelectList(_context.Professors, "ProfessorId", "ProfessorId", materia.Professors);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "TurmaId", materia.Turmas);
            //model.Professors = _context.Professors.ToList();
            //model.Turmas = _context.Turmas.ToList();
            return View(materia);           
            
        }

        // POST: Materias/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MateriaId,ProfessorId,TurmaId,Nome_Materia")] Materia materia)
        {
            if (id != materia.MateriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaExists(materia.MateriaId))
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
            ViewData["ProfessorId"] = new SelectList(_context.Professors, "ProfessorId", "ProfessorId", materia.ProfessorId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "TurmaId", materia.TurmaId);
            return View(materia);
        }

        // GET: Materias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias
                .Include(m => m.Professors)
                .Include(m => m.Turmas)
                .FirstOrDefaultAsync(m => m.MateriaId == id);

            Materia model = new Materia();
            model.Professorss = _context.Professors.ToList();
            model.Turmass = _context.Turmas.ToList();

            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaExists(int id)
        {
            return _context.Materias.Any(e => e.MateriaId == id);
        }
    }
}
