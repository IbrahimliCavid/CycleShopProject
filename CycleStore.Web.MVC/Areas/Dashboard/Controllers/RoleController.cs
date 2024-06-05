using Entities.Concrete.MemberShip;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationRole role)
        {
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);  
                }
                return View(role);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public  async Task<IActionResult> Edit(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationRole role)
        {
            var existingRole = await _roleManager.FindByIdAsync(role.Id.ToString());

            existingRole.Name = role.Name;
            existingRole.NormalizedName = role.NormalizedName;

            var result = await _roleManager.UpdateAsync(existingRole);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(role);
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            var result =await _roleManager.DeleteAsync(role);
            if (result.Succeeded) RedirectToAction("Index");
            return View(result);
        }

    }
}
