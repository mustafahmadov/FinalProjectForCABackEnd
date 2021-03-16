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


    public class WaterProtectionsController : Controller
    {
        private readonly AppDbContext _context;

        public WaterProtectionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WaterProtections
        public async Task<IActionResult> Index()
        {
            return View(await _context.WaterProtections.ToListAsync());
        }

        // GET: WaterProtections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterProtection = await _context.WaterProtections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waterProtection == null)
            {
                return NotFound();
            }

            return View(waterProtection);
        }

        // GET: WaterProtections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WaterProtections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] WaterProtection waterProtection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waterProtection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(waterProtection);
        }

        // GET: WaterProtections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterProtection = await _context.WaterProtections.FindAsync(id);
            if (waterProtection == null)
            {
                return NotFound();
            }
            return View(waterProtection);
        }

        // POST: WaterProtections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] WaterProtection waterProtection)
        {
            if (id != waterProtection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waterProtection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaterProtectionExists(waterProtection.Id))
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
            return View(waterProtection);
        }

        // GET: WaterProtections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterProtection = await _context.WaterProtections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waterProtection == null)
            {
                return NotFound();
            }

            return View(waterProtection);
        }

        // POST: WaterProtections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waterProtection = await _context.WaterProtections.FindAsync(id);
            _context.WaterProtections.Remove(waterProtection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaterProtectionExists(int id)
        {
            return _context.WaterProtections.Any(e => e.Id == id);
        }
    }
}
