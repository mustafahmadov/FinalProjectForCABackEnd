using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;
using ZodiacWatchStore.ViewModels;

namespace ZodiacWatchStore.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public BasketController(AppDbContext context,
                                UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            List<BasketVM> basket = new List<BasketVM>();
            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            if (User.Identity.IsAuthenticated)
            {
                return View(basket);
            }
            if (Request.Cookies["basket"] == null)
            {
                return View(basket);
            }
            return RedirectToAction("Login", "Account");
            
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
            List<BasketVM> basketP = new List<BasketVM>();
            if (Request.Cookies["basket"] != null)
            {
                basketP = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            BasketVM product = basketP.FirstOrDefault(p => p.Id == id);
            
            if (product != null )
            {
                product.Count--;
                
            }
            if (product.Count == 0)
            {
                basketP.Remove(product);
            }



            productTotal = Math.Abs(product.Count) * product.Price;
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketP));

            return PartialView("_ProductCardPartial",basketP);
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
            ViewBag.PaymentTypes = _context.PaymentTypes.ToList();
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Total = 0;
                ViewBag.Basket = basket;
                foreach (BasketVM item in basket)
                {
                    ViewBag.Total += item.Count * item.Price;
                }

                ViewBag.PaymentTypes = _context.PaymentTypes.ToList();
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOut(CheckOutVM sale,int? PaymentTypeId)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.PaymentTypes = _context.PaymentTypes.ToList();
                AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
                List<BasketVM> basketProducts = new List<BasketVM>();
                if (Request.Cookies["basket"] != null)
                {
                    basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
                }
                ViewBag.Basket = basketProducts;
                ViewBag.Total = 0;
                foreach (BasketVM item in basketProducts)
                {
                    ViewBag.Total += item.Count * item.Price;
                }
                Sale newSale = new Sale();
                foreach (BasketVM item in basketProducts)
                {
                    var dbPro = await _context.Products.FindAsync(item.Id);
                    if (item.Count > dbPro.Count)
                    {
                        TempData["error"] = $"Anbarda {item.Model} məhsulundan seçdiyiniz sayda yoxdur";
                        return View();
                    }
                }
                List<SaleProduct> saleProducts = new List<SaleProduct>();
                double total = 0;
                ViewBag.Total = 0;
                foreach (BasketVM basketProduct in basketProducts)
                {
                        Product dbProduct = await _context.Products.FindAsync(basketProduct.Id);

                        //await DecreaseProductCount(dbProduct, basketProduct);

                        SaleProduct saleProduct = new SaleProduct
                        {
                            Price = dbProduct.Price,
                            Count = basketProduct.Count,
                            ProductId = basketProduct.Id,
                            Sale = newSale,
                            SaleId = newSale.Id
                        };
                        total += saleProduct.Price * saleProduct.Count;
                        ViewBag.Total = total;
                        saleProducts.Add(saleProduct);
                        await _context.SaleProducts.AddAsync(saleProduct);
                }
                
                if (PaymentTypeId == null)
                {
                    ModelState.AddModelError("PaymentTypeId", "Xahis edirik brandi secin!");
                    ViewBag.SelectError = "Please select PaymentType";
                    return View();
                }
                foreach (BasketVM item in basketProducts)
                {
                    var dbPro = await _context.Products.FindAsync(item.Id);
                    dbPro.SaleCount += item.Count;
                    dbPro.Count -= item.Count;
                }
                newSale.Total = total;
                newSale.CustomerName = sale.Name;
                newSale.CustomerSurname = sale.Surname;
                newSale.CustomerPhone = sale.PhoneNumber;
                newSale.CustomerFatherName = sale.FatherName;
                newSale.AppUserId = appUser.Id;
                newSale.PaymentTypeId = (int)PaymentTypeId;
                newSale.Date = DateTime.Now;
                newSale.ShippingAddress = sale.City+' '+sale.District+' '+sale.DetalizedAddress;
                newSale.SaleStatus = SaleStatus.Waiting;
                newSale.Information = sale.Information;
                

                await _context.Sales.AddAsync(newSale);
                await _context.SaveChangesAsync();

                Response.Cookies.Delete("basket");
                return RedirectToAction("OrderCompleted","Basket");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        //private async Task DecreaseProductCount(Product dbProduct, BasketVM basketProduct)
        //{
        //    dbProduct.Count -= basketProduct.Count;
        //    await _context.SaveChangesAsync();
        //}
        public IActionResult OrderCompleted()
        {
            return View();
        }
    }
}
