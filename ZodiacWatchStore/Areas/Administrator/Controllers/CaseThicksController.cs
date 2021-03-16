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

    public class CaseThicksController : Controller
    {
        private readonly AppDbContext _context;

        public CaseThicksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CaseThicks
        public async Task<IActionResult> Index()
        {
            return View(await _context.CaseThicks.ToListAsync());
        }

        // GET: CaseThicks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseThick = await _context.CaseThicks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseThick == null)
            {
                return NotFound();
            }

            return View(caseThick);
        }

        // GET: CaseThicks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CaseThicks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,HasDeleted,DeletedTime")] CaseThick caseThick)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caseThick);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caseThick);
        }

        // GET: CaseThicks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseThick = await _context.CaseThicks.FindAsync(id);
            if (caseThick == null)
            {
                return NotFound();
            }
            return View(caseThick);
        }

        // POST: CaseThicks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,HasDeleted,DeletedTime")] CaseThick caseThick)
        {
            if (id != caseThick.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caseThick);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseThickExists(caseThick.Id))
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
            return View(caseThick);
        }

        // GET: CaseThicks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseThick = await _context.CaseThicks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseThick == null)
            {
                return NotFound();
            }

            return View(caseThick);
        }

        // POST: CaseThicks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caseThick = await _context.CaseThicks.FindAsync(id);
            _context.CaseThicks.Remove(caseThick);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaseThickExists(int id)
        {
            return _context.CaseThicks.Any(e => e.Id == id);
        }
    }
}
