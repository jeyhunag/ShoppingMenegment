using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingMenegment.Models.Data;
using ShoppingMenegment.Models.Entity.Membership;

namespace ShoppingMenegment.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin, Seller")]
    [Area("Admin")]
    public class RequestController : Controller
    {
        readonly ShoppingMenegmentContext smc;
        public RequestController(ShoppingMenegmentContext smc)
        {
            this.smc = smc;
        }
        public IActionResult Index()
        {
            var request = smc.Users.Where(c => c.Request == true && c.DeletedDate == null).ToList();
            return View(request);
        }
   
        public IActionResult Accept(int id)
        {

            var userRole = new AppUserRole();
            var request = smc.Users.FirstOrDefault(c => c.Id == id);

            userRole.UserId = id;
            userRole.RoleId = 2;

            request.Request = false;

            smc.Users.Update(request);
            smc.UserRoles.Add(userRole);
            smc.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            var request = smc.Users.FirstOrDefault(c => c.Id == id);
            request.DeletedDate = DateTime.Now;
            smc.Users.Update(request);
            smc.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
