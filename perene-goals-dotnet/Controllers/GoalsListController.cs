using System;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using perene_goals_dotnet.Data;
using perene_goals_dotnet.Models;

namespace perene_goals_dotnet.Controllers
{
    public class GoalsListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoalsListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GoalsList
        public async Task<IActionResult> Index()
        {
            return View(await _context.GoalsLists.ToListAsync());
        }

        // GET: GoalsList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goalsList = await _context.GoalsLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goalsList == null)
            {
                return NotFound();
            }

            return View(goalsList);
        }

        // GET: GoalsList/Create
        public IActionResult Create()
        {
            if (User.Identity != null && !User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }


            return View();
        }

        // POST: GoalsList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,IsPublic")] GoalsList goalsList)
        {
            if (ModelState.IsValid)
            {
                goalsList.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                 Console.WriteLine($"UserId: {goalsList.UserId}, Title: {goalsList.Title}, IsPublic: {goalsList.IsPublic}");

                _context.Add(goalsList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return View(goalsList);
        }

        // GET: GoalsList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goalsList = await _context.GoalsLists.FindAsync(id);
            if (goalsList == null)
            {
                return NotFound();
            }
            return View(goalsList);
        }

        // POST: GoalsList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,IsPublic,UserId")] GoalsList goalsList)
        {
            if (id != goalsList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goalsList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoalsListExists(goalsList.Id))
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
            return View(goalsList);
        }

        // GET: GoalsList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goalsList = await _context.GoalsLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goalsList == null)
            {
                return NotFound();
            }

            return View(goalsList);
        }

        // POST: GoalsList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goalsList = await _context.GoalsLists.FindAsync(id);

            if(goalsList == null) {
                 return NotFound();
            }

            _context.GoalsLists.Remove(goalsList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoalsListExists(int id)
        {
            return _context.GoalsLists.Any(e => e.Id == id);
        }
    }
}
