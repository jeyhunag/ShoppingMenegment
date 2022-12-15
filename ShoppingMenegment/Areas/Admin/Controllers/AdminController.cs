using Microsoft.AspNetCore.Mvc;
using ShoppingMenegment.Models;
using System.Security.Claims;

namespace ShoppingMenegment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            //var product = DBNull.product.where(product => product.deleteddate == null && product.createdbyuserId == Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value).tolist());
            return View();
        }

        public IActionResult Create()
        {
            //product.deletedDat = DateTime.Now;
            //Product.deletedByUserId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            return View();
        }
    }
}