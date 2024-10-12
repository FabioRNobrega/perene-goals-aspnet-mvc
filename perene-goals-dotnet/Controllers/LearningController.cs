using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using perene_goals_dotnet.Data;
using perene_goals_dotnet.Models;

namespace perene_goals_dotnet.Controllers
{
    public class LearningController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LearningController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Learning
        public async Task<IActionResult> Index()
        {
            return View(await _context.Learning.ToListAsync());
        }

        // GET: Learning/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learning = await _context.Learning
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learning == null)
            {
                return NotFound();
            }

            return View(learning);
        }

        // GET: Learning/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Learning/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Author,ReferenceLink,ImageLink")] Learning learning)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learning);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(learning);
        }

        // GET: Learning/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learning = await _context.Learning.FindAsync(id);
            if (learning == null)
            {
                return NotFound();
            }
            return View(learning);
        }

        // POST: Learning/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Author,ReferenceLink,ImageLink")] Learning learning)
        {
            if (id != learning.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learning);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearningExists(learning.Id))
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
            return View(learning);
        }

        // GET: Learning/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learning = await _context.Learning
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learning == null)
            {
                return NotFound();
            }

            return View(learning);
        }

        // POST: Learning/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learning = await _context.Learning.FindAsync(id);
            if (learning == null) {
                return NotFound();
            }

            _context.Learning.Remove(learning);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearningExists(int id)
        {
            return _context.Learning.Any(e => e.Id == id);
        }
    }
}
