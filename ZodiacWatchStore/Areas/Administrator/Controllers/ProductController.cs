using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FrontToUp.Extentions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(AppDbContext context,
                               IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            List<Product> Products = _context.Products.Where(c => c.HasDeleted == false).ToList();
            return View(Products);
        }

        #region ProductDetail
        public async Task<ActionResult> Detail(int? id)
        {
            if (id == null)
            {
                NotFound();
            }
            Product product = await _context.Products.Include(p => p.ProductImages).Include(p => p.Brand)
                  .Include(p => p.Mechanism).Include(p => p.WaterProtection)
                    .Include(p => p.GlassType).Include(p => p.CaseThick)
                      .Include(p => p.BandType).Include(p => p.ProductCategories).ThenInclude(p => p.Category)
                        .Where(p => p.HasDeleted == false && p.Id == id).FirstOrDefaultAsync();
            return View(product);
        }
        #endregion

        #region ProductCreate
        public IActionResult Create()
        {
            ViewBag.Mechanisms = _context.Mechanisms.Where(m => m.HasDeleted == false).ToList();
            ViewBag.CaseThicks = _context.CaseThicks.Where(m => m.HasDeleted == false).ToList();
            ViewBag.GlassTypes = _context.GlassTypes.Where(m => m.HasDeleted == false).ToList();
            ViewBag.BandTypes = _context.BandTypes.Where(m => m.HasDeleted == false).ToList();
            ViewBag.WaterProtection = _context.WaterProtections.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Brands = _context.Brands.Where(b => b.HasDeleted == false).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product Product, List<int> CategoryId, int? BrandId,
                     int? MechanismId, int? WaterProtectionId, int? BandTypeId, int? CaseThickId, int? GlassTypeId)
        {
            ViewBag.Mechanisms = _context.Mechanisms.Where(m => m.HasDeleted == false).ToList();
            ViewBag.CaseThicks = _context.CaseThicks.Where(m => m.HasDeleted == false).ToList();
            ViewBag.GlassTypes = _context.GlassTypes.Where(m => m.HasDeleted == false).ToList();
            ViewBag.BandTypes = _context.BandTypes.Where(m => m.HasDeleted == false).ToList();
            ViewBag.WaterProtection = _context.WaterProtections.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Brands = _context.Brands.Where(b => b.HasDeleted == false).ToList();
            Product newProduct = new Product();
            if (Product.MainPhoto == null)
            {
                ModelState.AddModelError("Photo", "Shekil bolmesi bosh qala bilmez!");
                return View();
            }

            if (!Product.MainPhoto.IsImage())
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                return View();
            }

            if (Product.MainPhoto.MaxLength(600))
            {
                ModelState.AddModelError("Photo", "Sheklin maksimum olcusu 200 kb ola biler");
                return View();
            }

            string folder = Path.Combine("assets", "images");
            string fileName = await Product.MainPhoto.SaveImgAsync(_env.WebRootPath, folder);

            List<ProductImage> images = new List<ProductImage>();
            foreach (IFormFile photo in Product.Photos)
            {
                if (photo == null)
                {
                    ModelState.AddModelError("Photos", "Shekil bolmesi bosh qala bilmez!");
                    return View();
                }

                if (!photo.IsImage())
                {
                    ModelState.AddModelError("Photos", "Zehmet olmasa shekil formati sechin");
                    return View();
                }

                if (photo.MaxLength(600))
                {
                    ModelState.AddModelError("Photos", "Sheklin maksimum olcusu 600 kb ola biler");
                    return View();
                }

                string imagesFolder = Path.Combine("assets", "images");
                string productFileName = await photo.SaveImgAsync(_env.WebRootPath, imagesFolder);
                ProductImage productImage = new ProductImage { Image = productFileName, ProductId = Product.Id, HasDeleted = false };
                images.Add(productImage);

            }
            Product.ProductImages = images;

            List<ProductCategory> CategoryProducts = new List<ProductCategory>();

            if (CategoryId.Count == 0)
            {
                ModelState.AddModelError("", "Kateqoriya bosh ola bilmez");
                return View();
            }

            foreach (int id in CategoryId)
            {
                ProductCategory categoryProduct = new ProductCategory()
                {
                    ProductId = newProduct.Id,
                    CategoryId = id,
                    Product = newProduct
                };
                CategoryProducts.Add(categoryProduct);
                await _context.ProductCategories.AddAsync(categoryProduct);
            }

            if (BrandId == null)
            {
                ModelState.AddModelError("BrandId", "Xahis edirik brandi secin!");
                ViewBag.SelectError = "Please select author";
                return View();
            }
            if (MechanismId == null)
            {
                ModelState.AddModelError("MechanismId", "Xahis edirik mexanizmi secin!");
                ViewBag.SelectError = "Please select mechanism";
                return View();
            }
            if (BandTypeId == null)
            {
                ModelState.AddModelError("BandTypeId", "Xahis edirik qolbaq tipini secin!");
                ViewBag.SelectError = "Please select band type";
                return View();
            }
            if (GlassTypeId == null)
            {
                ModelState.AddModelError("GlassTypeId", "Xahis edirik shushe tipini secin!");
                ViewBag.SelectError = "Please select glasstype";
                return View();
            }
            if (WaterProtectionId == null)
            {
                ModelState.AddModelError("WaterProtectionId", "Xahis edirik brandi secin!");
                ViewBag.SelectError = "Please select WaterProtection";
                return View();
            }
            if (CaseThickId == null)
            {
                ModelState.AddModelError("CaseThickId", "Xahis edirik brandi secin!");
                ViewBag.SelectError = "Please select CaseThick";
                return View();
            }
            newProduct.BrandId = (int)BrandId;
            newProduct.Image = fileName;
            newProduct.WaterProtectionId = (int)WaterProtectionId;
            newProduct.GlassTypeId = (int)GlassTypeId;
            newProduct.MechanismId = (int)MechanismId;
            newProduct.BandTypeId = (int)BandTypeId;
            newProduct.CaseThickId = (int)CaseThickId;
            newProduct.BrandId = (int)BrandId;
            newProduct.Count = Product.Count;
            newProduct.WatchCode = Product.WatchCode;
            newProduct.Price = Product.Price;
            newProduct.Model = Product.Model;
            newProduct.Discount = 0;
            newProduct.SaleCount = 0;
            newProduct.ViewCount = 0;
            newProduct.ProductImages = Product.ProductImages;

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        // GET: ProductController/Edit/5
        //        public IActionResult Update(int? id)
        //        {
        //            ViewBag.Authors = _context.Authors.ToList();
        //            Product Product = _context.Products.Where(cr => cr.HasDeleted == false)
        //                .Include(cr => cr.ProductDetail).FirstOrDefault(cr => cr.Id == id);
        //            return View(Product);
        //        }
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> Update(int? id, Product Product, int? AuthorId)
        //        {
        //            ViewBag.Authors = _context.Authors.ToList();
        //            if (id == null) return NotFound();

        //            Product oldProduct = await _context.Products.Include(c => c.ProductDetail)
        //                 .Include(b => b.Author).FirstOrDefaultAsync(c => c.Id == id);

        //            Product isExist = await _context.Products.Where(cr => cr.HasDeleted == false).FirstOrDefaultAsync(cr => cr.Id == id);

        //            if (isExist != null)
        //            {
        //                if (isExist.Id != oldProduct.Id)
        //                {
        //                    ModelState.AddModelError("", "Bele bir kurs artiq movcuddur .");
        //                    return View();
        //                }
        //            }

        //            if (Product == null) return NotFound();
        //            if (Product.Photo != null)
        //            {
        //                if (!Product.Photo.IsImage())
        //                {
        //                    ModelState.AddModelError("Photos", $"{Product.Photo.FileName} - shekil tipi deyil");
        //                    return View(oldProduct);
        //                }

        //                string folder = Path.Combine("assets", "img", "Product");
        //                string fileName = await Product.Photo.SaveImgAsync(_env.WebRootPath, folder);
        //                if (fileName == null)
        //                {
        //                    return NotFound();
        //                }

        //                Helper.DeleteImage(_env.WebRootPath, folder, oldProduct.Image);
        //                oldProduct.Image = fileName;
        //            }
        //            oldProduct.AuthorId = (int)AuthorId;
        //            oldProduct.Description = Product.Description;
        //            oldProduct.ProductDetail.FirstContent = Product.ProductDetail.FirstContent;
        //            oldProduct.ProductDetail.SecondContent = Product.ProductDetail.SecondContent;
        //            oldProduct.ProductDetail.ThirdContent = Product.ProductDetail.ThirdContent;
        //            oldProduct.ProductDetail.FourthContent = Product.ProductDetail.FourthContent;


        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Product Product = await _context.Products.FindAsync(id);
            if (Product == null) return NotFound();
            return View(Product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null) return NotFound();
            Product Product = _context.Products.FirstOrDefault(c => c.Id == id);
            if (Product == null) return NotFound();

            if (!Product.HasDeleted)
            {
                Product.HasDeleted = true;
                Product.DeletedTime = DateTime.Now;
            }
            else
            {
                Product.HasDeleted = false;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}

