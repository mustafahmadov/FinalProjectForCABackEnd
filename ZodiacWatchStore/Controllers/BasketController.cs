using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZodiacWatchStore.ViewModels;

namespace ZodiacWatchStore.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            List<BasketVM> basket = new List<BasketVM>();
            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }

            return View(basket);
        }
        public async Task<IActionResult> IncProductCountOne(int? id)
        {
            if (id == null) return NotFound();
            List<BasketVM> basket = new List<BasketVM>();
            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            BasketVM product = basket.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Count++;
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));

            return View();
        }
    }
}
