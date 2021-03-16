using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class BioController : Controller
    {
        private readonly AppDbContext _context;
        public BioController(AppDbContext context)
        {
            _context = context;
        }
        // GET: BioController
        public ActionResult Index()
        {
            Bio bio = _context.Bios.FirstOrDefault();
            return View(bio);
        }

        // GET: BioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
