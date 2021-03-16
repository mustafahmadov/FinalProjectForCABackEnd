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

    public class MechanismController : Controller
    {
        private readonly AppDbContext _context;

        public MechanismController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Mechanism
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mechanisms.ToListAsync());
        }

        // GET: Mechanism/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mechanism = await _context.Mechanisms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mechanism == null)
            {
                return NotFound();
            }

            return View(mechanism);
        }

        // GET: Mechanism/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mechanism/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,HasDeleted,DeletedTime")] Mechanism mechanism)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mechanism);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mechanism);
        }

        // GET: Mechanism/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mechanism = await _context.Mechanisms.FindAsync(id);
            if (mechanism == null)
            {
                return NotFound();
            }
            return View(mechanism);
        }

        // POST: Mechanism/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,HasDeleted,DeletedTime")] Mechanism mechanism)
        {
            if (id != mechanism.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mechanism);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MechanismExists(mechanism.Id))
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
            return View(mechanism);
        }

        // GET: Mechanism/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mechanism = await _context.Mechanisms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mechanism == null)
            {
                return NotFound();
            }

            return View(mechanism);
        }

        // POST: Mechanism/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mechanism = await _context.Mechanisms.FindAsync(id);
            _context.Mechanisms.Remove(mechanism);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MechanismExists(int id)
        {
            return _context.Mechanisms.Any(e => e.Id == id);
        }
    }
}
