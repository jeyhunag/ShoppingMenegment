using Microsoft.AspNetCore.Mvc;
using ShoppingMenegment.Models;
using ShoppingMenegment.Models.Data;
using ShoppingMenegment.Models.Entity;
using System.Diagnostics;
using System.Security.Claims;

namespace ShoppingMenegment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShoppingMenegmentContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ShoppingMenegmentContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {

            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(2000);
            cookieOptions.Path = "/";

            Response.Cookies.Append("Shoppingcookie", $"{1}", cookieOptions);

            string cookieValueFromReq = Request.Cookies["Shoppingcookie"];
            var value = Convert.ToInt32(cookieValueFromReq);

            var count = db.Baskets.Where(p => p.UserId == value).Count();




            ViewBag.Count = count;

            return View();
        }

        public IActionResult AddToCart(int? id)
        {

            var basket = new Basket();
            string cookieValueFromReq = Request.Cookies["Shoppingcookie"];
            var value = Convert.ToInt32(cookieValueFromReq);

            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);


            var basketrow = db.Baskets.FirstOrDefault(p => p.ProductId == id && p.UserId == userId);

            if (basketrow != null)
            {
                return Json(new
                {
                    error = true,
                    msg = "Siz bu product-i elave etmisiniz"
                });
            }
            else
            {
                basket.ProductId = (int)id;
                basket.UserId = userId;
                db.Baskets.Add(basket);
                db.SaveChanges();



                return Json(new
                {
                    error = false,
                    msg = "Siz bu product-i elave etdiniz"
                });
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}