using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FrontToUp.Extentions;
using FrontToUp.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]

    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext context,
                                IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        // GET: SliderController
        public ActionResult Index()
        {
            return View(_context.Sliders.Where(s => s.HasDeleted == false).ToList());
        }

        // GET: SliderController/Details/5
        public ActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = _context.Sliders.FirstOrDefault(s => s.Id == id);
            if (slider == null) return NotFound();

            return View(slider);
        }

        // GET: SliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Slider slider)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!slider.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil formatı seçin");
                return View();
            }

            if (slider.Photo.MaxLength(600))
            {
                ModelState.AddModelError("Photo", "Şəkilin maksimum ölçüsü 600kb ola bilər");
                return View();
            }

            if (_context.Sliders.Where(s=>s.HasDeleted==false).Count() >= 7)
            {
                return RedirectToAction(nameof(Index));
            }
            string folder = Path.Combine("assets", "images", "banner");
            string fileName = await slider.Photo.SaveImgAsync(_env.WebRootPath, folder);

            slider.Image = fileName;
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();

            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSlider(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            string folder = Path.Combine("assets", "images", "banner");
            Helper.DeleteImage(_env.WebRootPath, folder, slider.Image);

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        // GET: SliderController/Edit/5
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();

            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Slider slider)
        {
            if (id == null) return NotFound();

            if (slider.Photo != null)
            {
                if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    return View();
                }

                if (!slider.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil formatı seçin");
                    return View();
                }

                if (slider.Photo.MaxLength(600))
                {
                    ModelState.AddModelError("Photo", "Şəkilin maksimum ölçüsü 600kb ola bilər");
                    return View();
                }

                Slider dbslider = await _context.Sliders.FindAsync(id);
                if (dbslider == null) return NotFound();

                string folder = Path.Combine("assets", "images", "banner");
                Helper.DeleteImage(_env.WebRootPath, folder, dbslider.Image);

                string fileName = await slider.Photo.SaveImgAsync(_env.WebRootPath, folder);

                dbslider.Image = fileName;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
