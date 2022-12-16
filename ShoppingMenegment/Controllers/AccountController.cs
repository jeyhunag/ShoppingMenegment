using ShoppingMenegment.Models.Entity.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingMenegment.Models.FormModel;
using ShoppingMenegment.Areas.Enums;
using ShoppingMenegment.Models.Entity;
using ShoppingMenegment.Models.Data;

namespace ShoppingMenegment.Controllers
{
    public class AccountController : Controller
    {

        readonly SignInManager<AppUser> signInManager;
        readonly UserManager<AppUser> userManager;
        readonly ShoppingMenegmentContext _context;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userInManager, ShoppingMenegmentContext context)
        {
            this.signInManager = signInManager;
            this.userManager = userInManager;
            _context = context;
        }


        [AllowAnonymous]
        public IActionResult Signin()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        async public Task<IActionResult> Signin(UserFormModel model)
        {
            String UserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            if (ModelState.IsValid)
            {
                var appUser = await userManager.FindByNameAsync(model.Username);
                if (appUser == null)
                {
                    ModelState.AddModelError("", "Username or password is incorrect");
                    goto showSameView;
                }
                var result = await signInManager.PasswordSignInAsync(appUser, model.Password, true, true);

                if (result.Succeeded)
                {

                    string redirect = Request.Query["returnUrl"];
                    if (string.IsNullOrWhiteSpace(redirect))
                        return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Username or password is incorrect");
                    goto showSameView;
                }
            }
        showSameView:
            return View(model);
        }

        [AllowAnonymous]
        async public Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Signin");
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        async public Task<IActionResult> Register(RegisterFormModel model)
        {
            if (ModelState.IsValid)
            {

                Customer customer = new Customer()
                {
                    Address = model.Address,
                    Name = model.Name,
                    Surname = model.Surname,

                };
                _context.Customers.Add(customer);
                _context.SaveChanges();

                var appUser = new AppUser
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    UserType = (int)UserType.CustomerUser,
                    CustomerId = customer.Id
                };
                var result = await userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {

                    return RedirectToAction(nameof(Signin));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View(model);
        }

        public IActionResult Accessdenied()
        {
            return RedirectToAction("Signin");
        }
    }
}
