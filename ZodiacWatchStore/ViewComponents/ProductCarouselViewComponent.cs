using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.ViewComponents
{
    public class ProductCarouselViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public ProductCarouselViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string filterFor)
        {
            List<Product> products = new List<Product>();
            if (filterFor == "bestsellers")
            {
                products = _context.Products.Where(p => p.HasDeleted == false)
                                                  .OrderByDescending(p => p.SaleCount).Take(8).ToList();
            }
            else if (filterFor == "newproducts")
            {
                products = _context.Products.Where(p => p.HasDeleted == false)
                                                            .Take(8).ToList();
            }
            else if(filterFor == "discountproducts")
            {
                products = _context.Products.Where(p => p.HasDeleted == false && p.Discount>0)
                                                            .Take(8).ToList();
            }
            return View(await Task.FromResult(products));
        }
        
    }
}
