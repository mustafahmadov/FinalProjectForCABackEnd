using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.Controllers
{
    public class BrandController : Controller
    {
        private readonly AppDbContext _context;
        public BrandController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Brand> brands = _context.Brands.Where(b => b.HasDeleted == false).Take(8).ToList();
            return View(brands);

        }
    }
}
