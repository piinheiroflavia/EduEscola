using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduEscola.Context;
using EduEscola.Models;
using System.Xml.Linq;

namespace EduEscola.Controllers
{
    public class AlunosController : Controller
    {
        private readonly TabEduEscola _context;

        public AlunosController(TabEduEscola context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index(string Pesquisar)
        {
            int quantidade = _context.Aluno.Count();
            ViewBag.Quantidade = quantidade;

            ViewData["CurrentFilter"] = Pesquisar;
            var tabEduEscola = _context.Aluno.Include(a => a.Turmas).Include(m => m.Turmas.Unidades);
            var alunos = from b in _context.Aluno.Include(c => c.Turmas.Unidades)
                         select b;

            if (!String.IsNullOrEmpty(Pesquisar))
            {
                alunos = alunos.Where(c => c.NomeCompleto.Contains(Pesquisar));
                alunos = alunos.OrderBy(c => c.NomeCompleto);

                return View(await alunos.ToListAsync());

            }

            return View(await tabEduEscola.ToListAsync());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .Include(a => a.Turmas)
                .Include(m => m.Turmas.Unidades)
                .FirstOrDefaultAsync(m => m.IdAluno == id);
            if (aluno == null)
            {
                return NotFound();
            }
            //PartialView
            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            //ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "TurmaId");

            Aluno model = new Aluno();
            
            model.Turmass = _context.Turmas.ToList();
            return View(model);
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAluno,NomeCompleto,Cpf, Genero_Aluno,DataNascimento,MatriculaAluno,Status_Matricula,TurmaId ")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                aluno.Status_Matricula = Request.Form["Status_Matricula"];
                aluno.Genero_Aluno = Request.Form["Genero_Aluno"];
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "TurmaId", aluno.TurmaId);
            //ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "TurmaId", aluno.TurmaId);
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            Aluno model = new Aluno();
            model.Turmass = _context.Turmas.ToList();

            ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "TurmaId", aluno.TurmaId);
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAluno,NomeCompleto, Genero_Aluno,Cpf,DataNascimento,MatriculaAluno,TurmaId, Status_Matricula")] Aluno aluno)
        {
            if (id != aluno.IdAluno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.IdAluno))
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
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "TurmaId", aluno.TurmaId);
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .Include(a => a.Turmas)
                .FirstOrDefaultAsync(m => m.IdAluno == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.Aluno.Any(e => e.IdAluno == id);
        }
    }
}
