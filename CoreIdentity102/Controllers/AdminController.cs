using CoreIdentity102.Models;
using CoreIdentity102.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreIdentity102.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;


        public AdminController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View(_userManager.Users.ToList());
        }
        public IActionResult Roles()
        {
            return View(_roleManager.Roles.ToList());
        }
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RoleCreate(RoleViewModel model)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole();
                role.Name = model.Name;
                IdentityResult result = _roleManager.CreateAsync(role).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Roles");
                }
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }
            return View(model);
        }
        public async Task<IActionResult> RolAdd(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            List<AppRole> allRoles = _roleManager.Roles.ToList();
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            List<RoleAssignViewModel> assignRoles = new List<RoleAssignViewModel>();
            allRoles.ForEach(role => assignRoles.Add(new RoleAssignViewModel
            {
                HasAssign = userRoles.Contains(role.Name),
                RoleId = role.Id,
                RoleName = role.Name
            }));

            return View(assignRoles);
        }
        [HttpPost]
        public async Task<IActionResult> RolAdd(List<RoleAssignViewModel> modelList, string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            foreach (RoleAssignViewModel role in modelList)
            {
                if (role.HasAssign)
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                else
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
            }
            return RedirectToAction("Index", "Admin");

            
        }
    }
}
