using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Areas.Dashboard.ViewModels;
using HotelManagement.Entities;
using HotelManagement.Services;
using HotelManagement.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace HotelManagement.Areas.Dashboard.Controllers
{
    public class UsersController : Controller
    {
        private HotelManagementSignInManager _signInManager;
        private HotelManagementUserManager _userManager;
        private HotelManagementRolesManager _roleManager;
        
        public HotelManagementSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<HotelManagementSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public HotelManagementUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<HotelManagementUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public HotelManagementRolesManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().GetUserManager<HotelManagementRolesManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        public UsersController()
        {
        }

        public UsersController(HotelManagementUserManager userManager, HotelManagementSignInManager signInManager, HotelManagementRolesManager roleManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }


        readonly AccommodationsService _accommodationsService = new AccommodationsService();
        readonly AccommodationPackagesService _accommodationPackagesService = new AccommodationPackagesService();
        // GET: Dashboard/AccommodationTypes
        public ActionResult Index(string searchTerm, string roleID, int? page)
        {
            int recordSize = 10;
            page = page ?? 1;

            UsersListingModel model = new UsersListingModel();

            model.SearchTerm = searchTerm;
            model.RoleID = roleID;
            model.Roles = RoleManager.Roles.ToList();

            model.Users = SearchUsers(searchTerm, roleID, page.Value, recordSize);

            var totalRecords = SearchUsersCount(searchTerm, roleID);

            model.Pager = new Pager(totalRecords, page, recordSize);

            return View(model);
        }

        public IEnumerable<HotelManagementUser> SearchUsers(string searchTerm, string roleID, int page, int recordSize)
        {
            
            var users = UserManager.Users.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = users.Where(a => a.Email.ToLower().Contains(searchTerm.ToLower()));
            }

            if (!string.IsNullOrEmpty(roleID))
            {
                //users = users.Where(a => a.Email.ToLower().Contains(searchTerm.ToLower()));
            }

            // my pagination:
            var skip = (page - 1) * recordSize;
            // skip = (1-1) = 0*3=0
            // skip = (2-1) = 1*3=3
            // skip = (3-1) = 2*3=6

            return users.OrderBy(x => x.Email).Skip(skip).Take(recordSize).ToList();
        }
        public int SearchUsersCount(string searchTerm, string roleID)
        {
            
            var users = UserManager.Users.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = users.Where(a => a.Email.ToLower().Contains(searchTerm.ToLower()));
            }

            if (!string.IsNullOrEmpty(roleID))
            {
                //users = users.Where(a => a.Email.ToLower().Contains(searchTerm.ToLower()));
            }

            return users.Count();
        }

        [HttpGet]
        public async Task<ActionResult> Action(string ID)
        {
            UserActionModel model = new UserActionModel();

            // trying to edit a record
            if (!string.IsNullOrEmpty(ID))
            {
                var user = await UserManager.FindByIdAsync(ID);

                model.ID = user.Id;
                model.FullName = user.FullName;
                model.Email = user.Email;
                model.Username = user.UserName;
                model.Country = user.Country;
                model.City = user.City;
                model.Address = user.Address;
            }

            return PartialView("_Action", model);
        }

        [HttpPost]
        public async Task<JsonResult> Action(UserActionModel model)
        {
            JsonResult json = new JsonResult();

            IdentityResult result = null;

            // trying to edit a record
            if (!string.IsNullOrEmpty(model.ID))
            {
                var user = await UserManager.FindByIdAsync(model.ID);

                user.FullName = model.FullName;
                user.Email = model.Email;
                user.UserName = model.Username;
                user.Country = model.Country;
                user.City = model.City;
                user.Address = model.Address;

                result = await UserManager.UpdateAsync(user);
            }
            // trying to create a record
            else
            {
                var user = new HotelManagementUser();

                user.FullName = model.FullName;
                user.Email = model.Email;
                user.UserName = model.Username;
                user.Country = model.Country;
                user.City = model.City;
                user.Address = model.Address;

                result = await UserManager.CreateAsync(user);
            }

            json.Data = new { Success = result.Succeeded, Message = string.Join(", ", result.Errors) };

            return json;
        }

        [HttpGet]
        public async Task<ActionResult> Delete(string ID)
        {
            UserActionModel model = new UserActionModel();

            var user = await UserManager.FindByIdAsync(ID);

            model.ID = user.Id;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(UserActionModel model)
        {
            JsonResult json = new JsonResult();

            IdentityResult result = null;

            // trying to delete a record
            if (!string.IsNullOrEmpty(model.ID))
            {
                var user = await UserManager.FindByIdAsync(model.ID);

                result = await UserManager.DeleteAsync(user);

                json.Data = new { Success = result.Succeeded, Message = string.Join(", ", result.Errors) };
            }
            else
            {
                json.Data = new { Success = false, Message = "Invalid user." };
            }

            return json;
        }

        [HttpGet]
        public async Task<ActionResult> UserRoles(string ID)
        {
            UserRolesModel model = new UserRolesModel();

            model.UserID = ID;
            var user = await UserManager.FindByIdAsync(ID);
            var userRoleIDs = user.Roles.Select(x => x.RoleId).ToList();
            
            model.UserRoles = RoleManager.Roles.Where(x => userRoleIDs.Contains(x.Id)).ToList();

            model.Roles = RoleManager.Roles.Where(x => !userRoleIDs.Contains(x.Id)).ToList();

            return PartialView("_UserRoles", model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="opperation">Type of operation to perform e.g. Assing role or Delete role</param>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> UserRoleOperation(string opperation, string userID, string roleID)
        {
            JsonResult json = new JsonResult();

            var user = await UserManager.FindByIdAsync(userID);
            var role = await RoleManager.FindByIdAsync(roleID);

            if (user != null && role != null)
            {
                IdentityResult result = null;

                if (opperation.Equals("assign"))
                {
                    result = await UserManager.AddToRoleAsync(userID, role.Name);
                }
                else if (opperation.Equals("delete"))
                {
                    result = await UserManager.RemoveFromRoleAsync(userID, role.Name);
                }


                json.Data = new {Success = result.Succeeded, Message = string.Join(",", result.Errors)};
            }
            else
            {
                json.Data = new { Success = false, Message = "Invalid operation." };
            }

            return json;
        }
    }
}