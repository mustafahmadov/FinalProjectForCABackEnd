using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Bio bio = _context.Bios.FirstOrDefault();
            return View(bio);
        }
    }
}
