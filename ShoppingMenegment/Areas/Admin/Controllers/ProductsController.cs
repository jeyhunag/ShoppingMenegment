using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingMenegment.Models.Data;
using ShoppingMenegment.Models.Entity;

namespace ShoppingMenegment.Areas.Admin.Controllers
{

    [Authorize(Roles = "Operator")]
    [Area("Admin")]

    public class ProductsController : Controller
    {
        private readonly ShoppingMenegmentContext _context;

        Microsoft.AspNetCore.Hosting.IHostingEnvironment env;
        public ProductsController(ShoppingMenegmentContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        public async Task<IActionResult> Index()
        {
            var shoppingMenegmentContext = _context.Products.Include(p => p.ProductCategory);
            return View(await shoppingMenegmentContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            var filePath = "";

            if (product.file != null && product.file.Length > 0)
            {
                var imagePath = @"\ImgProduct\";
                var uploadPath = env.WebRootPath + imagePath;

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);

                }

                var unicFileName = Guid.NewGuid().ToString();

                var fileName = Path.GetFileName(unicFileName + "." + product.file.FileName.Split(".")[1].ToLower());

                string fullPath = uploadPath + fileName;

                filePath = Path.Combine(uploadPath, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    product.file.CopyTo(fileStream);
                }
                product.Img = fileName;



                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }

            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "Id", "Name", product.ProductCategoryId);
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "Id", "Name", product.ProductCategoryId);
            return View(product);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormFile file, Product product)
        {
            var filePath = "";
            if (product.file != null && product.file.Length > 0)
            {
                var imagePath = @"\ImgProduct\";
                var uploadPath = env.WebRootPath + imagePath;

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);

                }

                var unicFileName = Guid.NewGuid().ToString();

                var fileName = Path.GetFileName(unicFileName + "." + product.file.FileName.Split(".")[1].ToLower());

                string fullPath = uploadPath + fileName;

                filePath = Path.Combine(uploadPath, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    product.file.CopyTo(fileStream);
                }
                product.Img = fileName;



                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }
            product.UpdatedDate = DateTime.Now;

            if (ModelState.IsValid)
            {

                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "Id", "Name", product.ProductCategoryId);
            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ShoppingMenegmentContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.DeletedDate = DateTime.Now;
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
