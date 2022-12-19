using System;
using System.Collections.Generic;
using System.Data;
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
    [Authorize(Roles = "SuperAdmin,Operator,Manager")]
    [Area("Admin")]
    public class OrderitemsController : Controller
    {
        private readonly ShoppingMenegmentContext _context;

        public OrderitemsController(ShoppingMenegmentContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var shoppingMenegmentContext = _context.Orderitems.Include(o => o.Order).Include(o => o.Product);
            return View(await shoppingMenegmentContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orderitems == null)
            {
                return NotFound();
            }

            var orderitem = await _context.Orderitems
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderitem == null)
            {
                return NotFound();
            }

            return View(orderitem);
        }

        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Name");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Orderitem orderitem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderitem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Name", orderitem.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", orderitem.ProductId);
            return View(orderitem);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orderitems == null)
            {
                return NotFound();
            }

            var orderitem = await _context.Orderitems.FindAsync(id);
            if (orderitem == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Name", orderitem.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", orderitem.ProductId);
            return View(orderitem);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Orderitem orderitem)
        {
            if (id != orderitem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    orderitem.UpdatedDate = DateTime.Now;
                    _context.Update(orderitem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderitemExists(orderitem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Name", orderitem.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", orderitem.ProductId);
            return View(orderitem);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orderitems == null)
            {
                return NotFound();
            }

            var orderitem = await _context.Orderitems
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderitem == null)
            {
                return NotFound();
            }

            return View(orderitem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orderitems == null)
            {
                return Problem("Entity set 'ShoppingMenegmentContext.Orderitems'  is null.");
            }
            var orderitem = await _context.Orderitems.FindAsync(id);
            if (orderitem != null)
            {
                orderitem.DeletedDate = DateTime.Now;
                _context.Orderitems.Remove(orderitem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderitemExists(int id)
        {
            return _context.Orderitems.Any(e => e.Id == id);
        }
    }
}
