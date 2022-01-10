using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data;
using StudentApp.Models;
using StudentApp.Models.StudViewModels;

namespace StudentApp.Controllers
{
    [Authorize(Policy = "OnlyAdmin")]
    public class SpecializariController : Controller
    {
        private readonly StudentContext _context;

        public SpecializariController(StudentContext context)
        {
            _context = context;
        }

        // GET: Specializari
        public async Task<IActionResult> Index(int? id, int? studentID)
        {
            var viewModel = new SpecializareIndexData();
            viewModel.Specilizari = await _context.Specializari
                .Include(i => i.SpecializareStudenti)
                 .ThenInclude(i => i.Student)
                 .ThenInclude(i => i.Cursuri)
                 .ThenInclude(i => i.Profesor)
                 .AsNoTracking()
                 .OrderBy(i => i.DenumireSpecializare)
                 .ToListAsync();
            if (id != null)
            {
                ViewData["SpecializareID"] = id.Value;
                Specializare publisher = viewModel.Specilizari.Where(
                i => i.ID == id.Value).Single();
                viewModel.Studenti = publisher.SpecializareStudenti.Select(s => s.Student);
            }
            if (studentID != null)
            {
                ViewData["StudentID"] = studentID.Value;
                viewModel.Cursuri = viewModel.Studenti.Where(
                x => x.ID == studentID).Single().Cursuri;
            }
            return View(viewModel);
        }

        // GET: Specializari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specializare = await _context.Specializari
                .FirstOrDefaultAsync(m => m.ID == id);
            if (specializare == null)
            {
                return NotFound();
            }

            return View(specializare);
        }

        // GET: Specializari/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Specializari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DenumireSpecializare,Domeniu")] Specializare specializare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specializare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specializare);
        }

        // GET: Specializari/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specializare = await _context.Specializari.FindAsync(id);
            if (specializare == null)
            {
                return NotFound();
            }
            return View(specializare);
        }

        // POST: Specializari/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DenumireSpecializare,Domeniu")] Specializare specializare)
        {
            if (id != specializare.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specializare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecializareExists(specializare.ID))
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
            return View(specializare);
        }

        // GET: Specializari/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specializare = await _context.Specializari
                .FirstOrDefaultAsync(m => m.ID == id);
            if (specializare == null)
            {
                return NotFound();
            }

            return View(specializare);
        }

        // POST: Specializari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specializare = await _context.Specializari.FindAsync(id);
            _context.Specializari.Remove(specializare);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecializareExists(int id)
        {
            return _context.Specializari.Any(e => e.ID == id);
        }
    }
}
