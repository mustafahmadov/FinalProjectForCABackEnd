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
        public IActionResult IncProductCountOne(int? id)
        {
            double productTotal = 0;
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
            
            productTotal = Math.Abs(product.Count) * product.Price;
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));

            return Json(productTotal);
        }
        public IActionResult DecProductCountOne(int? id)
        {
            double productTotal = 0;
            if (id == null) return NotFound();
            List<BasketVM> basket = new List<BasketVM>();
            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            BasketVM product = basket.FirstOrDefault(p => p.Id == id);
            
            if (product != null )
            {
                product.Count--;
                
            }
            if (product.Count == 0)
            {
                basket.Remove(product);
            }



            productTotal = Math.Abs(product.Count) * product.Price;
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));

            return PartialView("_ProductCardPartial",basket);
        }
        public IActionResult GetBasketTotal()
        {
            double Total = 0;
            List<BasketVM> basket = new List<BasketVM>();
            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            foreach (BasketVM item in basket)
            {
                Total += item.Price * item.Count;
            }
            return Json(Total);
        }

        public IActionResult GetProductCount(int? id)
        {
            List<BasketVM> basket = new List<BasketVM>();
            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            BasketVM product = basket.FirstOrDefault(p => p.Id == id);
            if (product.Count == 0) return NotFound();
            return Json(product.Count);
        }

        public IActionResult DeleteFromCard(int? id)
        {
            if (id == null) return NotFound();
            ViewBag.Total = 0;
            List<BasketVM> oldProducts = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            if (oldProducts == null)
            {
                return NotFound();
            }
            BasketVM deletedProduct = oldProducts.FirstOrDefault(p => p.Id == id);
            if (deletedProduct == null) return NotFound();
            oldProducts.Remove(deletedProduct);

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(oldProducts));

            return PartialView("_ProductCardPartial", oldProducts);
        }

        public IActionResult CheckOut()
        {
            List<BasketVM> basket = new List<BasketVM>();
            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            return View(basket);
        }

    }
}
