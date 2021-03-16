using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class GuaranteesController : Controller
    {
        private readonly AppDbContext _context;

        public GuaranteesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Guarantees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Guarantees.ToListAsync());
        }

        // GET: Guarantees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guarantee = await _context.Guarantees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guarantee == null)
            {
                return NotFound();
            }

            return View(guarantee);
        }

        // GET: Guarantees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guarantees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Icon,Title,HasDeleted,DeletedTime")] Guarantee guarantee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guarantee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guarantee);
        }

        // GET: Guarantees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guarantee = await _context.Guarantees.FindAsync(id);
            if (guarantee == null)
            {
                return NotFound();
            }
            return View(guarantee);
        }

        // POST: Guarantees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Icon,Title,HasDeleted,DeletedTime")] Guarantee guarantee)
        {
            if (id != guarantee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guarantee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuaranteeExists(guarantee.Id))
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
            return View(guarantee);
        }

        // GET: Guarantees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guarantee = await _context.Guarantees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guarantee == null)
            {
                return NotFound();
            }

            return View(guarantee);
        }

        // POST: Guarantees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guarantee = await _context.Guarantees.FindAsync(id);
            _context.Guarantees.Remove(guarantee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuaranteeExists(int id)
        {
            return _context.Guarantees.Any(e => e.Id == id);
        }
    }
}
