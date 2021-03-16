using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly UserManager<AppUser> _userManager;
        public HeaderViewComponent(AppDbContext context,
                                    UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Brands = _context.Brands.Where(b => b.HasDeleted == false).ToList();
            ViewBag.UserName = "";
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.UserName ="Xoş gəldin," + " " + user.UserName + "!";
            }
            HeaderFooterVM viewModel = new HeaderFooterVM()
            {
                Bio = _context.Bios.FirstOrDefault(),
                Brands = _context.Brands.Where(b => b.HasDeleted == false).ToList()
            };
            return View(await Task.FromResult(viewModel));
        }
    }
}
