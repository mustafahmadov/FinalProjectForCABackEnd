using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;
using ZodiacWatchStore.ViewModels;

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
            List<BasketVM> products = new List<BasketVM>();
            if (Request.Cookies["basket"] != null)
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }

            return View(await Task.FromResult(products));
        }
    }
}
