using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.Areas.Administrator.Controllers
{
    public class GuaranteeController : Controller
    {
        private readonly AppDbContext _context;
        public GuaranteeController(AppDbContext context)
        {
            _context = context;
        }

        //public IActionResult Index()
        //{
        //    List<Guarantee> guarantees = _context.Guarantees.Where(g=>g.)
        //}
    }
}
