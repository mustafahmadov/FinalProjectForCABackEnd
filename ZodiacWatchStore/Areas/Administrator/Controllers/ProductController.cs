using FrontToUp.Extentions;
using FrontToUp.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]

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
            List<Product> products = _context.Products.Where(p => p.HasDeleted == false).ToList();
            return View(products);
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

        #region ProductUpdate
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            ViewBag.Mechanisms = _context.Mechanisms.Where(m => m.HasDeleted == false).ToList();
            ViewBag.CaseThicks = _context.CaseThicks.Where(m => m.HasDeleted == false).ToList();
            ViewBag.GlassTypes = _context.GlassTypes.Where(m => m.HasDeleted == false).ToList();
            ViewBag.BandTypes = _context.BandTypes.Where(m => m.HasDeleted == false).ToList();
            ViewBag.WaterProtection = _context.WaterProtections.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Brands = _context.Brands.Where(b => b.HasDeleted == false).ToList();
            Product product = await _context.Products.Where(p => p.HasDeleted == false)
                .Include(p => p.ProductImages).Include(p => p.Brand)
                  .Include(p => p.Mechanism).Include(p => p.WaterProtection)
                    .Include(p => p.GlassType).Include(p => p.CaseThick)
                      .Include(p => p.BandType).Include(p => p.ProductCategories).ThenInclude(p => p.Category)
                        .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            ViewBag.BrandId = product.Brand.Id;
            ViewBag.MechanismId = product.MechanismId;
            ViewBag.WaterProtectionId = product.WaterProtectionId;
            ViewBag.GlassTypeId = product.GlassTypeId;
            ViewBag.CaseThickId = product.CaseThickId;
            ViewBag.BandTypeId = product.BandTypeId;
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Product Product, int? BrandId, int? MechanismId,
                   int? WaterProtectionId, int? BandTypeId, int? CaseThickId, int? GlassTypeId)
        {
            ViewBag.Mechanisms = _context.Mechanisms.Where(m => m.HasDeleted == false).ToList();
            ViewBag.CaseThicks = _context.CaseThicks.Where(m => m.HasDeleted == false).ToList();
            ViewBag.GlassTypes = _context.GlassTypes.Where(m => m.HasDeleted == false).ToList();
            ViewBag.BandTypes = _context.BandTypes.Where(m => m.HasDeleted == false).ToList();
            ViewBag.WaterProtection = _context.WaterProtections.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Brands = _context.Brands.Where(b => b.HasDeleted == false).ToList();
            Product newProduct = new Product();
            Product dbProduct = await _context.Products.Where(p => p.HasDeleted == false)
                .Include(p => p.ProductImages).Include(p => p.Brand)
                  .Include(p => p.Mechanism).Include(p => p.WaterProtection)
                    .Include(p => p.GlassType).Include(p => p.CaseThick)
                      .Include(p => p.BandType).Include(p => p.ProductCategories).ThenInclude(p => p.Category)
                        .FirstOrDefaultAsync(p => p.Id == id);
            if (dbProduct == null) return NotFound();
            ViewBag.BrandId = dbProduct.Brand.Id;
            ViewBag.MechanismId = dbProduct.MechanismId;
            ViewBag.WaterProtectionId = dbProduct.WaterProtectionId;
            ViewBag.GlassTypeId = dbProduct.GlassTypeId;
            ViewBag.CaseThickId = dbProduct.CaseThickId;
            ViewBag.BandTypeId = dbProduct.BandTypeId;
            if (Product.MainPhoto != null)
            {
                if (ModelState["MainPhoto"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    return View();
                }
                if (!Product.MainPhoto.IsImage())
                {
                    ModelState.AddModelError("MainPhoto", "Zehmet olmasa shekil formati sechin");
                    return View();
                }

                if (Product.MainPhoto.MaxLength(600))
                {
                    ModelState.AddModelError("MainPhoto", "Sheklin maksimum olcusu 200 kb ola biler");
                    return View();
                }

                string folder = Path.Combine("assets", "images");
                Helper.DeleteImage(_env.WebRootPath, folder, dbProduct.Image);

                string fileName = await Product.MainPhoto.SaveImgAsync(_env.WebRootPath, folder);
                dbProduct.Image = fileName;
            }


            if (Product.Photos != null)
            {
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
                    _context.ProductImages.Add(productImage);
                }
            }
            dbProduct.BrandId = (int)BrandId;
            dbProduct.WaterProtectionId = (int)WaterProtectionId;
            dbProduct.GlassTypeId = (int)GlassTypeId;
            dbProduct.MechanismId = (int)MechanismId;
            dbProduct.BandTypeId = (int)BandTypeId;
            dbProduct.CaseThickId = (int)CaseThickId;
            dbProduct.BrandId = (int)BrandId;
            dbProduct.Count = Product.Count;
            dbProduct.WatchCode = Product.WatchCode;
            dbProduct.Price = Product.Price;
            dbProduct.Model = Product.Model;
            dbProduct.Discount = Product.Discount;
            dbProduct.SaleCount = 0;
            dbProduct.ViewCount = 0;


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region ProductDelete
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
            Product product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            string folder = Path.Combine("assets", "images");
            Helper.DeleteImage(_env.WebRootPath, folder, product.Image);

            if (product.Photos != null)
            {
                foreach (ProductImage image in product.ProductImages)
                {
                    Helper.DeleteImage(_env.WebRootPath, folder, image.Image);
                }
            }
            

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region DeleteProductImage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductImage(int? id)
        {
            if (id == null) return NotFound();
            ProductImage image = await _context.ProductImages.FindAsync(id);
            if (image == null) return NotFound();
            string folder = Path.Combine("assets", "images");
            Helper.DeleteImage(_env.WebRootPath, folder, image.Image);
            _context.ProductImages.Remove(image);
            await _context.SaveChangesAsync();

            return RedirectToAction("Update", new { id = image.ProductId });
        }
        #endregion

    }

}

