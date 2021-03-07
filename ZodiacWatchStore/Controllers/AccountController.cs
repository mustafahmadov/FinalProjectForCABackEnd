using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.DAL;
using ZodiacWatchStore.Models;

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
            TempData["controllerName"] = this.ControllerContext.RouteData.Values["controller"].ToString();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            TempData["controllerName"] = this.ControllerContext.RouteData.Values["controller"].ToString();
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
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            TempData["controllerName"] = this.ControllerContext.RouteData.Values["controller"].ToString();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            TempData["controllerName"] = this.ControllerContext.RouteData.Values["controller"].ToString();
            if (!ModelState.IsValid) return NotFound();
            AppUser user = new AppUser()
            {
                Email = register.Email,
                UserName = register.UserName,
                Fullname = register.FullName
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
            await _userManager.AddToRoleAsync(user, "Member");
            await _signInManager.SignInAsync(user, true);
            return RedirectToAction("Index", "Home");
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
        public IActionResult Reply()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reply(ReplyVM replyVM)
        {
            if (ModelState.IsValid)
            {
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential()
                    {
                        UserName = "mustafaahmadov8@gmail.com",
                        Password = "Araz2006"
                    }
                };
                MailAddress fromEmail = new MailAddress("mustafaahmadov8@gmail.com", replyVM.Name);
                MailAddress toEmail = new MailAddress("mustafa.ehmedov1999@gmail.com", replyVM.Name);
                MailMessage message = new MailMessage()
                {
                    From = fromEmail,
                    Subject = replyVM.Subject,
                    Body = replyVM.Message
                };
                message.To.Add(toEmail);
                client.Send(message);


            }
            return RedirectToAction("Index", "Home");

        }

        //public async Task CreateRole()
        //{
        //    if (!(await _roleManager.RoleExistsAsync("Admin")))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    }
        //    if (!(await _roleManager.RoleExistsAsync("Member")))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
        //    }
        //    if (!(await _roleManager.RoleExistsAsync("CourseModerator")))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "CourseModerator" });
        //    }
        //}
    }
}
