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
        public IActionResult Index(int? id,int? page)
        {
            ViewBag.Mechanisms = _context.Mechanisms.Where(m => m.HasDeleted == false).ToList();
            ViewBag.CaseThicks = _context.CaseThicks.Where(m => m.HasDeleted == false).ToList();
            ViewBag.GlassTypes = _context.GlassTypes.Where(m => m.HasDeleted == false).ToList();
            ViewBag.BandTypes = _context.BandTypes.Where(m => m.HasDeleted == false).ToList();
            ViewBag.WaterProtection = _context.WaterProtections.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Brands = _context.Brands.Where(b => b.HasDeleted == false).ToList();
            List<Product> products = new List<Product>();
            if (id != null)
            {
                ViewBag.PageCount = Decimal.Ceiling((decimal)_context.Products
                        .Where(t => t.HasDeleted == false&&t.BrandId==id).Count() / 8);
                ViewBag.Page = page;
                if (page == null)
                {
                    return View(_context.Products.Where(t => t.HasDeleted == false&&t.BrandId == id).Take(8).ToList());
                }
                products = _context.Products.Where(t => t.HasDeleted == false && t.BrandId == id).Skip(((int)page - 1) * 8).Take(8).ToList();
                return View(products);

            }
            List<BasketVM> basketproducts = new List<BasketVM>();
            if (Request.Cookies["basket"] != null)
            {
                basketproducts = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            ViewBag.BasketCount = basketproducts.Count();


            ViewBag.PageCount = Decimal.Ceiling((decimal)_context.Products
                        .Where(t => t.HasDeleted == false).Count() / 8);
            ViewBag.Page = page;
            if (page == null)
            {
                return View(_context.Products.Where(t => t.HasDeleted == false).Take(8).ToList());
            }
            products = _context.Products.Where(t => t.HasDeleted == false).Skip(((int)page - 1) * 8).Take(8).ToList();
            return View(products);
        }

        public IActionResult ProductFilter(int? PriceFrom, int? PriceTo, int? CategoryId,
            int? BrandId, int? MechanismId, int? WaterProtectionId, int? BandTypeId, int? CaseThickId, int? GlassTypeId)
        {
            var result = _context.Products.Where(p => p.HasDeleted == false)
                .Include(p => p.ProductImages).Include(p => p.Brand)
                  .Include(p => p.Mechanism).Include(p => p.WaterProtection)
                    .Include(p => p.GlassType).Include(p => p.CaseThick)
                      .Include(p => p.BandType).Include(p => p.ProductCategories)
                        .ThenInclude(p => p.Category).AsQueryable();
            if (PriceFrom != null)
                result = result.Where(x => x.Price >= PriceFrom);
            if (PriceTo != null)
                result = result.Where(x => x.Price <= PriceTo);
            if (CategoryId != null)
                result = result.Where(x => x.ProductCategories.Select(pc=>pc.CategoryId==CategoryId).FirstOrDefault());
            if (BrandId != null)
                result = result.Where(x => x.BrandId==BrandId);
            if (MechanismId != null)
                result = result.Where(x => x.MechanismId == MechanismId);
            if (WaterProtectionId != null)
                result = result.Where(x => x.WaterProtectionId == WaterProtectionId);
            if (BandTypeId != null)
                result = result.Where(x => x.BandTypeId == BandTypeId);
            if (CaseThickId != null)
                result = result.Where(x => x.CaseThickId == CaseThickId);
            if (GlassTypeId != null)
                result = result.Where(x => x.GlassTypeId == GlassTypeId);

            ProductPartialVM model = new ProductPartialVM();
            //model.Page = page;
            //model.PageCount = Decimal.Ceiling((decimal)result
            //            .Where(t => t.HasDeleted == false).Count() / 8);
            //ViewBag.PageCount = Decimal.Ceiling((decimal)result
            //            .Where(t => t.HasDeleted == false).Count() / 8);
            //ViewBag.Page = page;
            //if (page == null)
            //{

            //    result = result.Where(t => t.HasDeleted == false).Take(8);
            //    model.products = result;
            //    return PartialView("_ProductPartial", model);
            //}
            //result = result.Where(t => t.HasDeleted == false).Skip(((int)page - 1) * 8).Take(8);
            model.products = result.Take(16);
            return PartialView("_ProductPartial", model);
        }


        public IActionResult ProductDetails(int? id)
        {
            if (id == null)
            {
                return View();
            }
            Product product = _context.Products.Include(p => p.ProductImages).Include(p => p.Brand)
                  .Include(p => p.Mechanism).Include(p => p.WaterProtection)
                    .Include(p => p.GlassType).Include(p => p.CaseThick)
                      .Include(p => p.BandType).Include(p => p.ProductCategories).ThenInclude(p => p.Category)
                        .Where(p => p.HasDeleted == false && p.Id == id).FirstOrDefault();
            return View(product);
        }
        public async Task<IActionResult> AddToBasket(int? id, int? count)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
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
            if (isExist == null && count == null)
            {
                BasketVM newProduct = new BasketVM()
                {
                    Id = product.Id,
                    Count = 1,
                    Image = product.Image,
                    Model = product.Model,
                    Price = product.Price-product.Price*product.Discount/100,
                    WatchCode = product.WatchCode
                };
                products.Add(newProduct);
            }
            else if (isExist == null && count != null)
            {
                BasketVM newProduct = new BasketVM()
                {
                    Id = product.Id,
                    Count = (int)count,
                    Image = product.Image,
                    Model = product.Model,
                    Price = product.Price,
                    WatchCode = product.WatchCode
                };
                products.Add(newProduct);
            }
            else if (isExist != null && count != null)
            {

                isExist.Count += (int)count;
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
            List<BasketVM> basket = new List<BasketVM>();
            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            return Content(basket.Count.ToString());
        }

        public IActionResult GetBasketTotal()
        {
            int basketTotal = 0;
            List<BasketVM> basket = new List<BasketVM>();
            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            foreach (BasketVM item in basket)
            {
                basketTotal += (int)item.Price * item.Count;
            }
            return Json(basketTotal);
        }


        public IActionResult DeleteFromBasket(int? id)
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

            return PartialView("_BasketPartial", oldProducts);
        }

        public async Task<IActionResult> AddToWishList(int? id)
        {

            if (User.Identity.IsAuthenticated)
            {
                if (id == null) return NotFound();
                Product product = await _context.Products.FindAsync(id);
                if (product == null) return NotFound();
                List<WishlListVM> viewModel = new List<WishlListVM>();

                if (Request.Cookies["wishlist"] == null)
                    viewModel = new List<WishlListVM>();
                else
                    viewModel = JsonConvert.DeserializeObject<List<WishlListVM>>(Request.Cookies["wishlist"]);

                WishlListVM isExist = viewModel.FirstOrDefault(wp => wp.Id == id && wp.UserName == User.Identity.Name);
                if (isExist == null)
                {
                    WishlListVM wl = new WishlListVM()
                    {
                        Id = product.Id,
                        Price = product.Price,
                        Image = product.Image,
                        ProductCode = product.WatchCode,
                        Model = product.Model,
                        StatusCount = product.Count,
                        UserName = User.Identity.Name,
                    };
                    viewModel.Add(wl);
                }
                Response.Cookies.Append("wishlist", JsonConvert.SerializeObject(viewModel));
                return Json(new { icon = "success", message = "Istək siyahısına Əlavə Olundu!" });
            }
            else
            {
                return Json(new { icon = "error", message = "Yalnız sayt istifadəçiləri bu prosesdən istifadə edə bilər..." });
            }
        }


        public IActionResult RemoveFromWishList(int? id)
        {
            if (id == null) return NotFound();
            List<WishlListVM> wishlist = new List<WishlListVM>();
            if (Request.Cookies["wishlist"] != null)
            {
                wishlist = JsonConvert.DeserializeObject<List<WishlListVM>>(Request.Cookies["wishlist"]);
            }
            WishlListVM deletedProduct = wishlist.FirstOrDefault(p => p.Id == id);
            if (deletedProduct == null) return NotFound();

            wishlist.Remove(deletedProduct);
            Response.Cookies.Append("wishlist", JsonConvert.SerializeObject(wishlist));
            return PartialView("_WishListPartial", wishlist);
        }
        public IActionResult WishListCount()
        {

            List<WishlListVM> wishlist = new List<WishlListVM>();
            if (Request.Cookies["wishlist"] != null)
            {
                wishlist = JsonConvert.DeserializeObject<List<WishlListVM>>(Request.Cookies["wishlist"]);
            }
            return Content(wishlist.Where(wl => wl.UserName == User.Identity.Name).Count().ToString());
        }

        public IActionResult WishList()
        {
            List<WishlListVM> wishlist = new List<WishlListVM>();
            if (Request.Cookies["wishlist"] != null)
            {
                wishlist = JsonConvert.DeserializeObject<List<WishlListVM>>(Request.Cookies["wishlist"]);
            }
            List<WishlListVM> userWishlist = wishlist.Where(wl => wl.UserName == User.Identity.Name).ToList();
            return View(userWishlist);

        }

        public IActionResult Search(string search)
        {
            IEnumerable<Product> model = _context.Products.Where(p => p.WatchCode.Contains(search)&& p.HasDeleted==false).OrderByDescending(p => p.Id).Take(5);
            return PartialView("_SearchProductPartial", model);
        }
    }

}
