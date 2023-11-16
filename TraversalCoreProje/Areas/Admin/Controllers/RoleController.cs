using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2021.Excel.RichDataWebImage;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Attributes;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Role")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var data = _roleManager.Roles.ToList();
            return View(data);
        }

        [HttpGet]
        [Route("CreateRole")]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            AppRole appRole = new AppRole()
            {
                Name = model.RoleName
            };
            var result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [Route("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var data = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(data);
            return RedirectToAction("Index");
        }

        [Route("UpdateRole/{id}")]
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var data = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel()
            {
                RoleID = data.Id,
                RoleName = data.Name,
            };
            return View(updateRoleViewModel);
        }
        [Route("UpdateRole/{id}")]
        [HttpPost]
        public async Task<IActionResult >UpdateRole(UpdateRoleViewModel updateRoleViewModel)
        {
            var data = _roleManager.Roles.FirstOrDefault(x => x.Id == updateRoleViewModel.RoleID);
            data.Name = updateRoleViewModel.RoleName;
            await _roleManager.UpdateAsync(data);
            return RedirectToAction("Index");
        }


        [Route("ListUser")]
        public IActionResult ListUser()
        {
            var data = _userManager.Users.ToList();
            return View(data);
        }


        [Route("AssignRole/{id}")]
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["userId"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> list = new List<RoleAssignViewModel>();
            foreach (var role in roles)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleID = role.Id;
                model.RoleName= role.Name;
                model.RoleExist = userRoles.Contains(role.Name);
                list.Add(model);
            }
            return View(list);
        }


		[Route("AssignRole/{id}")]
		[HttpPost]
		public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> list)
        {
            var userID= (int)TempData["userId"];
            var userData = _userManager.Users.FirstOrDefault(x => x.Id == userID);
            foreach (var item in list)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(userData, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(userData, item.RoleName);
				}
            }
            return RedirectToAction("ListUser");
        }

	}
}