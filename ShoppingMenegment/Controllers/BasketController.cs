using Microsoft.AspNetCore.Mvc;
using ShoppingMenegment.Models.Data;

namespace ShoppingMenegment.Controllers
{
    public class BasketController : Controller
    {
        readonly ShoppingMenegmentContext db;
        public BasketController(ShoppingMenegmentContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            string cookieValueFromReq = Request.Cookies["Shoppingcookie"];
            var value = Convert.ToInt32(cookieValueFromReq);
            ViewData["User"] = value;


            var count = db.Baskets.Where(p => p.UserId == value).Count();




            ViewBag.Count = count;
            return View();
        }
    }
}
