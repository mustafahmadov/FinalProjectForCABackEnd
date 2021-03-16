using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;
using ZodiacWatchStore.ViewModels;

namespace ZodiacWatchStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin,SaleModerator")]

    public class SaleController : Controller
    {
        private readonly AppDbContext _context;
        public SaleController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            SaleForStatusVM model = new SaleForStatusVM
            {
                RejectedSales = _context.Sales.Where(s => s.SaleStatus == 0).Include(s=>s.PaymentType)
                                .Include(s => s.AppUser).Include(s=>s.SaleProducts).ThenInclude(s=>s.Product).ToList(),
                WaitingSales = _context.Sales.Where(s => (int)s.SaleStatus == 1).Include(s => s.PaymentType)
                                .Include(s => s.AppUser).Include(s => s.SaleProducts).ThenInclude(s => s.Product).ToList(),
                SendingSales = _context.Sales.Where(s => (int)s.SaleStatus == 2).Include(s => s.PaymentType)
                                .Include(s => s.AppUser).Include(s => s.SaleProducts).ThenInclude(s => s.Product).ToList(),
                FinishedSales = _context.Sales.Where(s => (int)s.SaleStatus == 3).Include(s => s.PaymentType)
                                .Include(s => s.AppUser).Include(s => s.SaleProducts).ThenInclude(s => s.Product).ToList(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeSaleStatus(int? id,SaleStatus status)
        {
            if (id == null) return NotFound();
            Sale sale = await _context.Sales.FindAsync(id);
            if (sale == null) return NotFound();
            sale.SaleStatus = status;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
