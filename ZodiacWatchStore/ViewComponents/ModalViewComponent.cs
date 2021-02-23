using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.ViewComponents
{
    public class ModalViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public ModalViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Bio bio = _context.Bios.FirstOrDefault();
            return View(await Task.FromResult(bio));
        }
    }
}
