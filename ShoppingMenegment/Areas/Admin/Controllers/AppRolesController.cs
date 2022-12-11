using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingMenegment.Models.Data;
using ShoppingMenegment.Models.Entity.Membership;

namespace ShoppingMenegment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppRolesController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public AppRolesController(RoleManager<AppRole> roleManager)
        {

            _roleManager = roleManager;
        }

        // GET: Admin/AppRoles
        public async Task<IActionResult> Index()
        {
            List<AppRole> appRoles = await _roleManager.Roles.ToListAsync();
            return View(appRoles);
        }

        // GET: Admin/AppRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _roleManager.Roles == null)
            {
                return NotFound();
            }

            var appRole = await _roleManager.FindByIdAsync(id.ToString());
            
            if (appRole == null)
            {
                return NotFound();
            }

            return View(appRole);
        }

        // GET: Admin/AppRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AppRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AppRole appRole)
        {
            if (ModelState.IsValid)
            {
                await _roleManager.CreateAsync(appRole);
            
                return RedirectToAction(nameof(Index));
            }
            return View(appRole);
        }

        // GET: Admin/AppRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _roleManager.Roles == null)
            {
                return NotFound();
            }

            var appRole = await _roleManager.FindByIdAsync(id.ToString());
            if (appRole == null)
            {
                return NotFound();
            }
            return View(appRole);
        }

        // POST: Admin/AppRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] AppRole appRole)
        {
            if (id != appRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    AppRole rolDb = await _roleManager.FindByIdAsync(id.ToString());
                    rolDb.Name=appRole.Name;
                    await _roleManager.UpdateAsync(rolDb);
             
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppRoleExists(appRole.Id))
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
            return View(appRole);
        }

        // GET: Admin/AppRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _roleManager.Roles == null)
            {
                return NotFound();
            }

            var appRole = await _roleManager.FindByIdAsync(id.ToString());
            if (appRole == null)
            {
                return NotFound();
            }

            return View(appRole);
        }

        // POST: Admin/AppRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_roleManager.Roles == null)
            {
                return Problem("Entity set 'ShoppingMenegmentContext.Roles'  is null.");
            }
            var appRole = await _roleManager.FindByIdAsync(id.ToString());
            if (appRole != null)
            {
             await  _roleManager.DeleteAsync(appRole);
            }

       
            return RedirectToAction(nameof(Index));
        }

        private bool AppRoleExists(int id)
        {
            return _roleManager.Roles.Any(e => e.Id == id);
        }
    }
}
