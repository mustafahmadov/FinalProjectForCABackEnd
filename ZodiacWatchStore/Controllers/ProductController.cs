using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;
using ZodiacWatchStore.ViewModels;

namespace ZodiacWatchStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<BasketVM> products = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            ViewBag.BasketCount = products.Count();
            return View();
        }
        public IActionResult ProductDetails(int? id)
        {
            if (id == null)
            {
                return View();
            }
            Product product = _context.Products.Include(p => p.ProductImages).Include(p=>p.Brand)
                  .Include(p=>p.Mechanism).Include(p=>p.WaterProtection)
                    .Include(p=>p.GlassType).Include(p=>p.CaseThick)
                      .Include(p=>p.BandType).Include(p => p.ProductCategories).ThenInclude(p => p.Category)
                        .Where(p => p.HasDeleted == false && p.Id == id).FirstOrDefault();
            return View(product);
        }
        public async Task<IActionResult> AddToBasket(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            List<BasketVM> products;
            if (Request.Cookies["basket"] == null)
            {
                products = new List<BasketVM>();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            BasketVM isExist = products.FirstOrDefault(p => p.Id == id);
            if (isExist == null)
            {
                BasketVM newProduct = new BasketVM()
                {
                    Id = product.Id,
                    Count = 1,
                    Image = product.Image,
                    Model = product.Model,
                    Price = product.Price,
                 };
                products.Add(newProduct);
            }
            else
            {
                isExist.Count++;
            }
            foreach (BasketVM prod in products)
            {
                ViewBag.BasketTotal += prod.Price * prod.Count;
            }
            ViewBag.BasketCount = products.Count();
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products));
            //products = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            return PartialView("_BasketPartial", products);
        }

        public IActionResult GetBasketCount()
        {
            List<BasketVM> basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            return Content(basket.Count.ToString());
        }

        public IActionResult GetBasketTotal()
        {
            int basketTotal = 0;
            List<BasketVM> basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            foreach (BasketVM item in basket)
            {
                basketTotal += (int)item.Price * item.Count;
            }
            return Json(basketTotal);
        }


        public IActionResult DeleteFromBasket(int? id)
        {
            ViewBag.Total = 0;
            List<BasketVM> oldProducts = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            if(oldProducts == null)
            {
                return NotFound();
            }
            BasketVM deletedProduct = oldProducts.FirstOrDefault(p => p.Id == id);
            if (deletedProduct == null) return NotFound();
            oldProducts.Remove(deletedProduct);
            
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(oldProducts));

            return PartialView("_BasketPartial",oldProducts);
        }
    }
}
