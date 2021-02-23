using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.ViewComponents
{
    public class ProductSimpleViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public ProductSimpleViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string filterFor)
        {
            List<Product> products = new List<Product>();
            if (filterFor == "mostviewed")
            {
                products = _context.Products.Where(p => p.HasDeleted == false)
                                                  .OrderByDescending(p => p.ViewCount).Take(3).ToList();
            }
            else if (filterFor == "countdes")
            {
                products = _context.Products.Where(p => p.HasDeleted == false)
                                                  .OrderBy(p=>p.Count).Take(3).ToList();
            }
            else if (filterFor == "discountproducts")
            {
                products = _context.Products.Where(p => p.HasDeleted == false && p.Discount > 0)
                                                            .Take(3).ToList();
            }
            return View(await Task.FromResult(products));
        }
    }
}
