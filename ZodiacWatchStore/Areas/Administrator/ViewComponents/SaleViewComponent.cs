using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.Areas.Administrator.ViewComponents
{
    public class SaleViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public SaleViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string filterFor)
        {
            List<Sale> sales = new List<Sale>(); 
            if(filterFor == "waiting")
            {
                sales = _context.Sales.Where(s=>(int)s.SaleStatus==0).Include(s => s.AppUser).ToList();
            }
            else if (filterFor == "sending")
            {
                sales = _context.Sales.Where(s => (int)s.SaleStatus == 1).Include(s => s.AppUser).ToList();
            }
            else
            {
                sales = _context.Sales.Where(s => (int)s.SaleStatus == 2).Include(s => s.AppUser).ToList();
            }
            return View(await Task.FromResult(sales));
        }
    }
}
