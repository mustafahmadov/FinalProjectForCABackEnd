using EduHomeASPNET.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;
using ZodiacWatchStore.ViewModels;

namespace ZodiacWatchStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<AppUser> userManager,
                                SignInManager<AppUser> signInManager,
                                RoleManager<IdentityRole> roleManager,
                                AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }
        public IActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Logout", "Account");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Password or email is incorrect!!");
                return View();
            }
            if (user.HasDeleted)
            {
                ModelState.AddModelError("", "This user has been blocked!!");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult =
                       await _signInManager.PasswordSignInAsync(user, login.Password, true, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Please try few minutes later");
                return View();
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Password or email is incorrect!!");
                return View();
            }
            return RedirectToAction("UserCabinet", "Account");
        }
        public IActionResult Register()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Logout", "Account");
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (register.PrivacyAggrement)
            {
                if (!ModelState.IsValid) return NotFound();
                AppUser user = new AppUser()
                {
                    UserName = register.UserName,
                    Email = register.Email,
                    HasDeleted = false,
                };

                IdentityResult identityResult = await _userManager.CreateAsync(user, register.Password);
                if (!identityResult.Succeeded)
                {
                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(register);
                }

                await _userManager.AddToRoleAsync(user, "SaleModerator");
                await _signInManager.SignInAsync(user, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Şərtlər və qaydalarımızı qəbul etməlisiniz");
                //return RedirectToAction("Register", "Account", new RegisterVM {Name=register.Name,
                // Surname=register.Surname});
                return View(register);
            }
                
                
                
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Subscribe()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Subscribe(SubscribedEmail subscribedEmail)
        {
            if (ModelState.IsValid)
            {
                SubscribedEmail subscribed = new SubscribedEmail();
                subscribed.Email = subscribedEmail.Email.Trim().ToLower();
                bool isExist = _context.SubscribedEmails
                      .Any(e => e.Email.Trim().ToLower() == subscribedEmail.Email.Trim().ToLower());
                if (isExist)
                {
                    ModelState.AddModelError("", "This email already subscribed");
                }
                else
                {
                    await _context.SubscribedEmails.AddAsync(subscribed);
                    await _context.SaveChangesAsync();
                }

            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> UserCabinet()
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                List<WishlListVM> wishlist = new List<WishlListVM>();
                if (Request.Cookies["wishlist"] != null)
                {
                    wishlist = JsonConvert.DeserializeObject<List<WishlListVM>>(Request.Cookies["wishlist"]);
                }
                List<WishlListVM> userWishlist = wishlist.Where(wl => wl.UserName == User.Identity.Name).ToList();
                
                List<Sale> sales = _context.Sales.Where(s=>s.AppUserId==user.Id)
                        .Include(s=>s.PaymentType).Include(s => s.SaleProducts)
                              .ThenInclude(s=>s.Product).ToList();
                
                UserCabinetVM userCabinetVM = new UserCabinetVM
                {
                    User = user,
                    Name = user.Name,
                    Surname = user.Surname,
                    FatherName = user.FatherName,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    Password = user.PasswordHash,
                    CheckPassword = user.PasswordHash,
                    City = user.ShippingCity,
                    District = user.ShippingDistrict,
                    DetalizedAddress = user.DetalizedShippingAddress,
                    Information = user.Information,
                    UserName = user.UserName,
                    FIN = user.FIN,
                    PassportID = user.PassportID,
                    UserWishlist = userWishlist,
                    UserSales = sales

                };

                return View(userCabinetVM);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserCabinet(UserCabinetVM model)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (!ModelState.IsValid) return View(model);

            user.UserName = model.UserName;
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.FatherName = model.FatherName;
            user.Email = model.Email;
            user.PhoneNumber = model.Phone;
            user.ShippingCity = model.City;
            user.ShippingDistrict = model.District;
            user.DetalizedShippingAddress = model.DetalizedAddress;
            user.Information = model.Information;
            user.UserName = model.UserName;
            user.FIN = model.FIN;
            user.PassportID = model.PassportID;

            if (model.Password !=null)
            {
                string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, model.Password);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Xəta baş verdi");
                }
            }
            

            IdentityResult identityResult = await _userManager.UpdateAsync(user);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
            await _signInManager.RefreshSignInAsync(user);
            return RedirectToAction("Index","Home");
        }
        public async Task CreateRole()
        {
            if (!(await _roleManager.RoleExistsAsync("Admin")))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }
            if (!(await _roleManager.RoleExistsAsync("Member")))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
            }
            if (!(await _roleManager.RoleExistsAsync("SaleModerator")))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "SaleModerator" });
            }
        }
    }
}
