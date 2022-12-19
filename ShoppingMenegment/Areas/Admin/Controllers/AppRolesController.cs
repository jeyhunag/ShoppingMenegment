using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingMenegment.Models.Data;
using ShoppingMenegment.Models.Entity.Identity;

namespace ShoppingMenegment.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin,Manager")]
    [Area("Admin")]
    public class AppRolesController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public AppRolesController(RoleManager<AppRole> roleManager)
        {

            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            List<AppRole> appRoles = await _roleManager.Roles.ToListAsync();
            return View(appRoles);
        }

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

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppRole appRole)
        {
            if (ModelState.IsValid)
            {
                await _roleManager.CreateAsync(appRole);
            
                return RedirectToAction(nameof(Index));
            }
            return View(appRole);
        }

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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AppRole appRole)
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
