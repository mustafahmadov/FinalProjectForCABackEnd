﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;
using ZodiacWatchStore.ViewModels;

namespace ZodiacWatchStore.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            HeaderFooterVM viewModel = new HeaderFooterVM()
            {
                Bio = _context.Bios.FirstOrDefault(),
                Brands = _context.Brands.Where(b => b.HasDeleted == false).ToList()
            };
            return View(await Task.FromResult(viewModel));
        }
    }
}
