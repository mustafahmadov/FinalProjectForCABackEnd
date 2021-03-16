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
    [Authorize(Roles ="Admin")]

    public class BandTypesController : Controller
    {
        private readonly AppDbContext _context;

        public BandTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BandTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.BandTypes.ToListAsync());
        }

        // GET: BandTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandType = await _context.BandTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bandType == null)
            {
                return NotFound();
            }

            return View(bandType);
        }

        // GET: BandTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BandTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,HasDeleted,DeletedTime")] BandType bandType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bandType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bandType);
        }

        // GET: BandTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandType = await _context.BandTypes.FindAsync(id);
            if (bandType == null)
            {
                return NotFound();
            }
            return View(bandType);
        }

        // POST: BandTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,HasDeleted,DeletedTime")] BandType bandType)
        {
            if (id != bandType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bandType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BandTypeExists(bandType.Id))
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
            return View(bandType);
        }

        // GET: BandTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandType = await _context.BandTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bandType == null)
            {
                return NotFound();
            }

            return View(bandType);
        }

        // POST: BandTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bandType = await _context.BandTypes.FindAsync(id);
            _context.BandTypes.Remove(bandType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BandTypeExists(int id)
        {
            return _context.BandTypes.Any(e => e.Id == id);
        }
    }
}
