using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingMenegment.Models.Data;
using ShoppingMenegment.Models.Entity;

namespace ShoppingMenegment.Areas.Admin.Controllers
{

    [Authorize(Roles = "Operator")]
    [Area("Admin")]
   
    public class ProductCategoryController : Controller
    {
        private readonly ShoppingMenegmentContext db;


        public ProductCategoryController(ShoppingMenegmentContext ProductCtgy)
        {
            db = ProductCtgy;
        }
        public IActionResult Index()
        {
            List<ProductCategory> productCategories = db.ProductCategories.ToList();
            return View(productCategories);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || db.ProductCategories == null)
            {
                return NotFound();
            }

            var productctg = await db.ProductCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productctg == null)
            {
                return NotFound();
            }

            return View(productctg);
        }

        public IActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }

        [HttpPost]
        public IActionResult Create(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategories.Add(productCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.Clear();
            return View(productCategory);
        }

        public IActionResult Delete(int? id)
        {
            ProductCategory productCategory = db.ProductCategories.Where(p => p.Id == id).FirstOrDefault();
            db.ProductCategories.Remove(productCategory);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            ProductCategory productCategory = db.ProductCategories.Where(p => p.Id == id).FirstOrDefault();
            return View(productCategory);

        }
        [HttpPost]

        public IActionResult Edit([Bind("Id,Name,Description")] ProductCategory productCategory)
        {
            productCategory.UpdatedDate = DateTime.Now;
            db.ProductCategories.Update(productCategory);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
