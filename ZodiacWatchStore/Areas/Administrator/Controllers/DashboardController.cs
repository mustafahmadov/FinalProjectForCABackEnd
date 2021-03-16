using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.ProductCount = 0;
            ViewBag.UserCount = 0;
            ViewBag.SaleCount = 0;
            ViewBag.TotalEarnings = 0;
            ViewBag.SaleWhichIsWaiting = 0;

            ViewBag.ProductCount = _context.Products.Where(p => p.HasDeleted == false).Count();
            ViewBag.UserCount = _context.Users.Where(p => p.HasDeleted == false).Count();
            
            List<Sale> Sales = _context.Sales.Where(s => s.SaleStatus == Models.SaleStatus.Finished).ToList();

            ViewBag.SaleCount = Sales.Count();
            List<SaleProduct> SaleProducts = _context.SaleProducts
                           .Where(s=>s.Sale.SaleStatus==SaleStatus.Finished).ToList();
            foreach (Sale item in Sales)
            {
                ViewBag.TotalEarnings += item.Total;
            }

            ViewBag.SaleWhichIsWaiting = _context.Sales.Where(s => s.SaleStatus == Models.SaleStatus.Waiting).Count();
            return View();
        }
    }
}
