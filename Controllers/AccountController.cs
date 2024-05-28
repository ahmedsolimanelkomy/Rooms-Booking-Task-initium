using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rooms_Booking.IRepository;
using Rooms_Booking.Models;
using System.Security.Claims;

namespace Rooms_Booking.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IUnitOfWork unitOfWork;
        public AccountController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveRegister(ApplicationUser NewUser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    UserName = NewUser.UserName,
                    Email = NewUser.Email,
                    PhoneNumber = NewUser.PhoneNumber,
                    Address = NewUser.Address,
                    PasswordHash = NewUser.PasswordHash,
                };
                IdentityResult result = await userManager.CreateAsync(applicationUser, applicationUser.PasswordHash);
                if (result.Succeeded)
                {

                    await userManager.AddToRoleAsync(applicationUser, "User");
                    await signInManager.SignInAsync(applicationUser, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Register", NewUser);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveLogin(ApplicationUser LoggedInUser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userModel =
                    await userManager.FindByNameAsync(LoggedInUser.UserName);
                if (userModel != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userModel, LoggedInUser.PasswordHash);
                    if (found == true)
                    {
                        await signInManager.SignInAsync(userModel, false);
                        //await signInManager.SignInWithClaimsAsync(userModel, false, claims);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Invalid Credentials Please try again");
            }
            return View("Login", LoggedInUser);
        }
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return View();
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> SaveEditAsync(ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                if (applicationUser != null)
                {
                    bool found = await userManager.CheckPasswordAsync(applicationUser, applicationUser.PasswordHash);
                    if (found == true)
                    {
                      var result = await userManager.UpdateAsync(applicationUser);
                      if (result.Succeeded)
                        {
                            return View();
                        }      
                    }
                }
                ModelState.AddModelError("", "Invalid Credentials Please try again");

            }
            return View("Edit", applicationUser);
        }
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
