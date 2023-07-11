using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using SBiPayrollWeb.Business;
using SBiPayrollWeb.Entities;
using SBiPayrollWeb.UI.MVC.Filters;
using SBiPayrollWeb.UI.MVC.Models;
using WebMatrix.WebData;

namespace SBiPayrollWeb.UI.MVC.Controllers
{
    [HandleError]
    [Authorize]
    public class AdministratorController : Controller
    {

        #region "Roles"
        //[Authorize]
        public ActionResult GetAllRoles()
        {

            return RedirectToAction("Roles");

        }
        public ActionResult Roles()
        {
            AdministratorComponent ac = new AdministratorComponent();
            List<spRole> model = ac.GetAllRoles();

            return View(model);

        }
        //[Authorize]
        public ActionResult CreateRole()
        {
            return View();

        }
        [HttpPost]
        public ActionResult CreateRole([Bind] spRole model)
        {
            if (ModelState.IsValid)
            {
                AdministratorComponent ac = new AdministratorComponent();

                spRole role = new spRole();
                role.ShortCode = Utils.ConvertFirstLetterToUpper(model.ShortCode);
                role.Description = Utils.ConvertFirstLetterToUpper(model.Description);
                role.IsDeleted = false;

                ac.CreateRole(role);

                return RedirectToAction("Roles");

            }
            else
            {
                string[] errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray();
                foreach (var err in errors)
                {
                    ModelState.AddModelError(err, err);
                }
                return View(model);
            }
        }
        //[Authorize]
        public ActionResult RoleDetails(int id)
        {

            AdministratorComponent ac = new AdministratorComponent();

            spRole model = ac.GetRolebyId(id);

            return View(model);

        }
        //[Authorize]
        public ActionResult EditRole(int id)
        {
            AdministratorComponent ac = new AdministratorComponent();
            spRole model = ac.GetRolebyId(id);
            return View(model);

        }
        [HttpPost]
        public ActionResult EditRole([Bind] spRole model)
        {
            AdministratorComponent ac = new AdministratorComponent();

            spRole role = ac.GetRolebyId(model.Id);
            role.ShortCode = Utils.ConvertFirstLetterToUpper(model.ShortCode);
            role.Description = Utils.ConvertFirstLetterToUpper(model.Description);

            ac.UpdateRole(role);

            return RedirectToAction("Roles");

        }
        //[Authorize]
        public ActionResult DeleteRole(int id, string description)
        {
            ConfirmDeleteModel model = new ConfirmDeleteModel();
            AdministratorComponent ac = new AdministratorComponent();

            var _usersrolesquery = from ur in ac.GetAllUSersRoles()
                                   where ur.RoleId == id
                                   select ur;
            List<spUsersInRole> _usersroles = _usersrolesquery.ToList();
            if (_usersroles.Count > 0)
            {
                ErrorHandlerModel errormodel = new ErrorHandlerModel();
                errormodel.ExceptionMessage = "There is a UserRole associated with this Role. Delete the UserRole first !";
                return View("ErrorHandlerView", errormodel);
            }

            model.Id = id;
            model.Description = description;

            return View("ConfirmDeleteRoleView", model);

        }
        [HttpPost]
        public ActionResult DeleteRole([Bind] ConfirmDeleteModel model)
        {
            AdministratorComponent ac = new AdministratorComponent();

            spRole role = ac.GetRolebyId(model.Id);
            ac.DeleteRoleById(role.Id);

            return RedirectToAction("Roles");

        }
        #endregion "Roles"
        #region "USers"
        //[Authorize]
        public ActionResult GetAllUSers()
        {
            AdministratorComponent ac = new AdministratorComponent();
            DataEntryComponent dc = new DataEntryComponent();

            spUser model = new spUser();

            var _usersquery = from us in ac.GetAllUsers()
                              select new spUser
                              {
                                  Password = us.Password,
                                  IsDeleted = us.IsDeleted,
                                  Status = us.Status,
                                  UserName = us.UserName,
                                  Id = us.Id,
                                  RoleId = us.RoleId
                              };
            List<spUser> _users = _usersquery.ToList();

            return View("UsersListView", _users);

        }
        //[Authorize]
        public ActionResult CreateUSer()
        {
            return View("CreateUserView");

        }
        [HttpPost]
        public ActionResult CreateUSer([Bind] spUser model)
        {
            AdministratorComponent ac = new AdministratorComponent();
            DataEntryComponent dc = new DataEntryComponent();

            if (ModelState.IsValid)
            {
                spUser user = new spUser();
                user.UserName = model.UserName;
                user.Password = model.Password;
                user.Status = model.Status;
                user.IsDeleted = false;
                user.RoleId = model.RoleId;

                var _usersquery = from rl in ac.GetAllUsers()
                                  select rl;
                List<spUser> _users = _usersquery.ToList();

                if (_users.Any(i => i.UserName == user.UserName))
                {
                    ErrorHandlerModel errormodel = new ErrorHandlerModel();
                    errormodel.ExceptionMessage = "User Exists!";
                    return View("ErrorHandlerView", errormodel);
                }
                if (!_users.Any(i => i.UserName == user.UserName))
                {
                    WebSecurity.CreateUserAndAccount(user.UserName, user.Password);

                    spUser returnedUser = ac.CreateUser(user);
                    returnedUser.Id = returnedUser.Id;

                    ac.UpdateUser(returnedUser);
                }

                return RedirectToAction("GetAllUSers");

            }
            else
            {
                string[] errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray();
                foreach (var err in errors)
                {
                    ModelState.AddModelError(err, err);
                }
                return View("CreateUserView", model);
            }
        }
        //[Authorize]
        public ActionResult USerDetails(int id)
        {
            AdministratorComponent ac = new AdministratorComponent();
            DataEntryComponent dc = new DataEntryComponent();

            var _userquery = from us in ac.GetAllUsers()
                             where us.Id == id
                             select new spUser
                             {
                                 IsDeleted = us.IsDeleted,
                                 Status = us.Status,
                                 UserName = us.UserName,
                                 Id = us.Id,
                                 RoleId = us.RoleId
                             };
            spUser model = _userquery.FirstOrDefault();

            return View("UserDetailsView", model);

        }
        //[Authorize]
        public ActionResult EditUSer(int id)
        {
            AdministratorComponent ac = new AdministratorComponent();
            DataEntryComponent dc = new DataEntryComponent();

            var _userquery = from us in ac.GetAllUsers()
                             where us.Id == id
                             select new spUser
                             {
                                 IsDeleted = us.IsDeleted,
                                 Status = us.Status,
                                 UserName = us.UserName,
                                 Id = us.Id,
                                 RoleId = us.RoleId
                             };
            spUser model = _userquery.FirstOrDefault();

            return View("EditUserView", model);

        }
        [HttpPost]
        public ActionResult EditUSer([Bind] spUser model)
        {
            AdministratorComponent ac = new AdministratorComponent();
            spUser user = ac.GetUserById(model.Id);
            user.UserName = model.UserName;
            user.Password = model.Password;
            user.Status = model.Status;
            user.RoleId = model.RoleId;

            ac.UpdateUser(user);

            return RedirectToAction("GetAllUSers");

        }
        public spUser GetUserByEmail(string email)
        {
            AdministratorComponent ac = new AdministratorComponent();
            spUser user = ac.GetUserByEmail(email);
            return user;
        }
        public string GetUserPhoto(string email)
        {
            AdministratorComponent ac = new AdministratorComponent();
            spUser user = ac.GetUserByEmail(email);
            if (user == null)
            {
                return null;
            }
            if (user.Photo == null)
            {
                return null;
            }
            return user.Photo;
        }
        //[Authorize]
        public ActionResult DeleteUSer(int id, string description)
        {
            ConfirmDeleteModel model = new ConfirmDeleteModel();
            AdministratorComponent ac = new AdministratorComponent();

            var _usersrolesquery = from ur in ac.GetAllUSersRoles()
                                   where ur.UserId == id
                                   select ur;
            List<spUsersInRole> _usersroles = _usersrolesquery.ToList();
            if (_usersroles.Count > 0)
            {
                ErrorHandlerModel errormodel = new ErrorHandlerModel();
                errormodel.ExceptionMessage = "There is a UserRole associated with this User. Delete the UserRole first !";
                return View("ErrorHandlerView", errormodel);
            }

            model.Id = id;
            model.Description = description;

            return View("ConfirmDeleteUserView", model);

        }
        [HttpPost]
        public ActionResult DeleteUSer([Bind] ConfirmDeleteModel model)
        {

            AdministratorComponent ac = new AdministratorComponent();
            spUser user = ac.GetUserById(model.Id);

            ac.DeleteUserById(user.Id);

            return RedirectToAction("GetAllUSers");

        }
        #endregion "USers"
        #region "USersRoles"
        //[Authorize]
        public ActionResult GetAllUSersRoles()
        {
            AdministratorComponent ac = new AdministratorComponent();
            DataEntryComponent dc = new DataEntryComponent();

            var _usersrolesquery = from ur in ac.GetAllUSersRoles()
                                   join rl in ac.GetAllRoles() on ur.RoleId equals rl.Id
                                   join us in ac.GetAllUsers() on ur.UserId equals us.Id
                                   select new spUsersInRole
                                   {
                                       RoleId = rl.Id,
                                       RoleName = rl.Description,
                                       UserId = us.Id,
                                       UserName = us.UserName
                                   };
            List<spUsersInRole> _usersroles = _usersrolesquery.ToList();

            return View("UsersRolesListView", _usersroles);

        }
        [HttpPost]
        public ActionResult GetUSerRoles(int userid)
        {
            AdministratorComponent ac = new AdministratorComponent();
            spUsersInRole model = new spUsersInRole();
            model._Roles = new List<spRole>();
            model._UserRoles = new List<string>();
            model._Users = new List<spUser>();

            var _userrolesquery = from us in ac.GetAllRolesforUser(userid)
                                  select us.RoleId;
            List<int> _userroles = _userrolesquery.ToList();

            var _rolesquery = from rl in ac.GetAllRoles()
                              where _userroles.Contains(rl.Id)
                              select rl;
            List<spRole> _roles = _rolesquery.ToList();

            foreach (var role in _roles)
            {
                //model._UserRoles.Add(role.RoleName);
            }

            return View("CreateUserRolesView", model);

        }
        //[HttpPost]
        public ActionResult GetUSerRolesPartial(int userid)
        {
            AdministratorComponent ac = new AdministratorComponent();
            spUsersInRole model = new spUsersInRole();
            model._Roles = new List<spRole>();
            model._UserRoles = new List<string>();
            model._Users = new List<spUser>();

            var _userrolesquery = from us in ac.GetAllRolesforUser(userid)
                                  select us.RoleId;
            List<int> _userroles = _userrolesquery.ToList();

            var _rolesquery = from rl in ac.GetAllRoles()
                              where _userroles.Contains(rl.Id)
                              select rl;
            List<spRole> _roles = _rolesquery.ToList();

            foreach (var role in _roles)
            {
                model._UserRoles.Add(role.Description);
            }

            return PartialView("PartialUserRolesView", model);

        }
        //[Authorize]
        public ActionResult CreateUSerRole()
        {
            AdministratorComponent ac = new AdministratorComponent();
            DataEntryComponent dc = new DataEntryComponent();
            spUsersInRole model = new spUsersInRole();

            var _usersquery = from us in ac.GetAllUsers()
                              select new spUser
                              {
                                  IsDeleted = us.IsDeleted,
                                  Status = us.Status,
                                  UserName = us.UserName,
                                  Id = us.Id
                              };
            List<spUser> _users = _usersquery.ToList();
            model._Users = _users;

            var _rolesquery = from rl in ac.GetAllRoles()
                              select rl;
            List<spRole> _roles = _rolesquery.ToList();
            model._Roles = _roles;

            return View("CreateUserRolesView", model);

        }
        [HttpPost]
        public ActionResult CreateUSerRole([Bind] spUsersInRole model)
        {
            AdministratorComponent ac = new AdministratorComponent();
            DataEntryComponent dc = new DataEntryComponent();

            if (ModelState.IsValid)
            {

                spUsersInRole _UsersRolesModel = new spUsersInRole();
                _UsersRolesModel.UserId = model.UserId;
                _UsersRolesModel.RoleId = model.RoleId;

                var _UsersRolesquery = from rl in ac.GetAllUsersInRole()
                                       select rl;
                List<spUsersInRole> _UsersRoles = _UsersRolesquery.ToList();

                if (_UsersRoles.Any(i => i.UserId == _UsersRolesModel.UserId && i.RoleId == _UsersRolesModel.RoleId))
                {
                    ErrorHandlerModel errormodel = new ErrorHandlerModel();
                    errormodel.ExceptionMessage = "User Role Exists!";
                    return View("ErrorHandlerView", errormodel);
                }

                if (!_UsersRoles.Any(i => i.UserId == _UsersRolesModel.UserId && i.RoleId == _UsersRolesModel.RoleId))
                {
                    spUsersInRole returnedUserRole = ac.CreateUSerRole(_UsersRolesModel);

                    spUser _user = ac.GetUserById(returnedUserRole.UserId);
                    _user.RoleId = returnedUserRole.RoleId;

                    ac.UpdateUser(_user);
                }

                return RedirectToAction("GetAllUSersRoles");

            }
            else
            {
                var _usersquery = from us in ac.GetAllUsers()
                                  select new spUser
                                  {
                                      IsDeleted = us.IsDeleted,
                                      Status = us.Status,
                                      UserName = us.UserName,
                                      Id = us.Id
                                  };
                List<spUser> _users = _usersquery.ToList();
                model._Users = _users;

                var _rolesquery = from rl in ac.GetAllRoles()
                                  select rl;
                List<spRole> _roles = _rolesquery.ToList();
                model._Roles = _roles;

                string[] errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray();
                foreach (var err in errors)
                {
                    ModelState.AddModelError(err, err);
                }
                return View("CreateUserRolesView", model);
            }
        }

        //[Authorize]
        public ActionResult USerRoleDetails(int? UserId, int? RoleId)
        {
            AdministratorComponent ac = new AdministratorComponent();
            DataEntryComponent dc = new DataEntryComponent();

            spUsersInRole model = ac.GetUSerRolebyId(UserId ?? -1, RoleId ?? -1);

            var _usersquery = from us in ac.GetAllUsers()
                              select new spUser
                              {
                                  IsDeleted = us.IsDeleted,
                                  Status = us.Status,
                                  UserName = us.UserName,
                                  Id = us.Id
                              };
            List<spUser> _users = _usersquery.ToList();
            model._Users = _users;

            var _rolesquery = from rl in ac.GetAllRoles()
                              select rl;
            List<spRole> _roles = _rolesquery.ToList();
            model._Roles = _roles;

            return View("UserRolesDetailsView", model);

        }

        //[Authorize]
        public ActionResult EditUSerRole(int userid, int roleid)
        {
            AdministratorComponent ac = new AdministratorComponent();
            DataEntryComponent dc = new DataEntryComponent();
            spUsersInRole model = ac.GetUSerRolebyId(userid, roleid);

            var _usersquery = from us in ac.GetAllUsers()
                              select new spUser
                              {
                                  IsDeleted = us.IsDeleted,
                                  Status = us.Status,
                                  UserName = us.UserName,
                                  Id = us.Id
                              };
            List<spUser> _users = _usersquery.ToList();
            model._Users = _users;

            var _rolesquery = from rl in ac.GetAllRoles()
                              select rl;
            List<spRole> _roles = _rolesquery.ToList();
            model._Roles = _roles;

            return View("EditUserRolesView", model);

        }

        [HttpPost]
        public ActionResult EditUSerRole([Bind] spUsersInRole model)
        {
            AdministratorComponent ac = new AdministratorComponent();

            spUsersInRole _UsersRolesModel = ac.GetUSerRolebyId(model.UserId, model.RoleId);
            _UsersRolesModel.UserId = model.UserId;
            _UsersRolesModel.RoleId = model.RoleId;

            ac.UpdateUSerRole(_UsersRolesModel);

            return RedirectToAction("GetAllUSersRoles");

        }

        //[Authorize]
        public ActionResult DeleteUSerRole(int userid, int roleid, string description)
        {
            ConfirmDeleteModel model = new ConfirmDeleteModel();
            model.Id = userid;
            model.Id2 = roleid;
            model.Description = description;

            return View("ConfirmDeleteUserRoleView", model);

        }
        [HttpPost]
        public ActionResult DeleteUSerRole([Bind] ConfirmDeleteModel model)
        {

            AdministratorComponent ac = new AdministratorComponent();

            spUsersInRole _UsersRolesModel = ac.GetUSerRolebyId(model.Id, model.Id2);
            ac.DeleteUserRoleById(_UsersRolesModel.UserId, _UsersRolesModel.RoleId);

            return RedirectToAction("GetAllUSersRoles");

        }

        #endregion "USersRoles"
        #region "Rights"
        //[Authorize]
        public ActionResult GetAllRights()
        {
            AdministratorComponent ac = new AdministratorComponent();
            DataEntryComponent dc = new DataEntryComponent();

            var _allowedrolemenusquery = from rm in ac.GetAllspAllowedRoleMenus()
                                         join rl in ac.GetAllRoles() on rm.RoleId equals rl.Id
                                         join mn in ac.GetAllspMenus() on rm.MenuItemId equals mn.Id
                                         select new spUsersInRole
                                         {
                                             Allowed = rm.Allowed,
                                             MenuDescription = mn.Description,
                                             MenuName = mn.mnuName,
                                             MenuItemId = mn.Id,
                                             RoleId = rl.Id,
                                             RoleName = rl.Description
                                         };
            List<spUsersInRole> _allowedrolemenus = _allowedrolemenusquery.ToList();

            return View("RightsListView", _allowedrolemenus);

        }
        public bool _IsRoleMenusAllowed(string email, string menuname)
        {
            AdministratorComponent ac = new AdministratorComponent();
            DataEntryComponent dc = new DataEntryComponent();

            var _allowedrolemenusquery = from rm in ac.GetAllspAllowedRoleMenus()
                                         join rl in ac.GetAllRoles() on rm.RoleId equals rl.Id
                                         join mn in ac.GetAllspMenus() on rm.MenuItemId equals mn.Id
                                         join usr in ac.GetAllUSersRoles() on rl.Id equals usr.RoleId
                                         join us in ac.GetAllUsers() on usr.UserId equals us.Id
                                         where us.UserName == email
                                         where mn.mnuName == menuname
                                         select new spUsersInRole
                                         {
                                             Allowed = rm.Allowed,
                                             MenuDescription = mn.Description,
                                             MenuName = mn.mnuName,
                                             MenuItemId = mn.Id,
                                             RoleId = rl.Id,
                                             RoleName = rl.Description
                                         };
            bool _allowedrolemenus = _allowedrolemenusquery.Select(i => i.Allowed).FirstOrDefault();

            return _allowedrolemenus;

        }
        //[Authorize]
        public ActionResult CreateRight()
        {

            AdministratorComponent ac = new AdministratorComponent();
            DataEntryComponent dc = new DataEntryComponent();
            spUsersInRole model = new spUsersInRole();

            var _menusquery = from rl in ac.GetAllspMenus()
                              orderby rl.Description ascending
                              select rl;
            List<spMenus> _spMenus = _menusquery.ToList();
            model._Menus = _spMenus;

            var _rolesquery = from rl in ac.GetAllRoles()
                              select rl;
            List<spRole> _roles = _rolesquery.ToList();
            model._Roles = _roles;

            model.Allowed = true;

            return View("CreateRightView", model);

        }
        [HttpPost]
        public ActionResult CreateRight([Bind] spUsersInRole model)
        {
            AdministratorComponent ac = new AdministratorComponent();
            DataEntryComponent dc = new DataEntryComponent();

            if (ModelState.IsValid)
            {
                spAllowedRoleMenus _right = new spAllowedRoleMenus();
                _right.RoleId = model.RoleId;
                _right.MenuItemId = model.MenuItemId;
                _right.Allowed = model.Allowed;

                var _rightsquery = from rt in ac.GetAllspAllowedRoleMenus()
                                   select new spUsersInRole
                                   {
                                       RightId = rt.Id,
                                       MenuItemId = rt.MenuItemId,
                                       RoleId = rt.RoleId
                                   };
                List<spUsersInRole> _rights = _rightsquery.ToList();

                if (_rights.Any(i => i.RoleId == _right.RoleId && i.MenuItemId == _right.MenuItemId))
                {
                    ErrorHandlerModel errormodel = new ErrorHandlerModel();
                    errormodel.ExceptionMessage = "Right Exists!";
                    return View("ErrorHandlerView", errormodel);
                }

                if (!_rights.Any(i => i.RoleId == _right.RoleId && i.MenuItemId == _right.MenuItemId))
                {
                    ac.CreatespAllowedRoleMenu(_right);
                }

                return RedirectToAction("GetAllRights");

            }
            else
            {
                var _menusquery = from rl in ac.GetAllspMenus()
                                  orderby rl.Description ascending
                                  select rl;
                List<spMenus> _spMenus = _menusquery.ToList();
                model._Menus = _spMenus;

                var _rolesquery = from rl in ac.GetAllRoles()
                                  select rl;
                List<spRole> _roles = _rolesquery.ToList();
                model._Roles = _roles;

                model.Allowed = true;

                string[] errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray();
                foreach (var err in errors)
                {
                    ModelState.AddModelError(err, err);
                }
                return View("CreateRightView", model);
            }
        }

        //[Authorize]
        public ActionResult RightDetails(int id)
        {
            AdministratorComponent ac = new AdministratorComponent();
            DataEntryComponent dc = new DataEntryComponent();

            var _rightquery = from rt in ac.GetAllspAllowedRoleMenus()
                              where rt.Id == id
                              select new spUsersInRole
                              {
                                  RightId = rt.Id,
                                  MenuItemId = rt.MenuItemId,
                                  RoleId = rt.RoleId
                              };
            spUsersInRole model = _rightquery.FirstOrDefault();

            var _menusquery = from rl in ac.GetAllspMenus()
                              select rl;
            List<spMenus> _spMenus = _menusquery.ToList();
            model._Menus = _spMenus;

            var _rolesquery = from rl in ac.GetAllRoles()
                              select rl;
            List<spRole> _roles = _rolesquery.ToList();
            model._Roles = _roles;

            return View("RightDetailsView", model);

        }

        //[Authorize]
        public ActionResult EditRight(int id)
        {
            AdministratorComponent ac = new AdministratorComponent();
            DataEntryComponent dc = new DataEntryComponent();

            var _rightquery = from rt in ac.GetAllspAllowedRoleMenus()
                              where rt.Id == id
                              select new spUsersInRole
                              {
                                  RightId = rt.Id,
                                  MenuItemId = rt.MenuItemId,
                                  RoleId = rt.RoleId
                              };
            spUsersInRole model = _rightquery.FirstOrDefault();

            var _menusquery = from rl in ac.GetAllspMenus()
                              select rl;
            List<spMenus> _spMenus = _menusquery.ToList();
            model._Menus = _spMenus;

            var _rolesquery = from rl in ac.GetAllRoles()
                              select rl;
            List<spRole> _roles = _rolesquery.ToList();
            model._Roles = _roles;

            return View("EditRightView", model);

        }

        [HttpPost]
        public ActionResult EditRight([Bind] spUsersInRole model)
        {
            AdministratorComponent ac = new AdministratorComponent();

            spAllowedRoleMenus _Right = ac.GetspAllowedRoleMenusbyId(model.RightId);
            _Right.RoleId = model.RoleId;
            _Right.MenuItemId = model.MenuItemId;
            _Right.Allowed = model.Allowed;

            ac.UpdatespAllowedRoleMenus(_Right);

            return RedirectToAction("GetAllRights");

        }

        //[Authorize]
        public ActionResult DeleteRight(int roleid, int menuid, string description)
        {
            ConfirmDeleteModel model = new ConfirmDeleteModel();
            model.Id = roleid;
            model.Id2 = menuid;
            model.Description = description;

            return View("ConfirmDeleteRightView", model);

        }
        [HttpPost]
        public ActionResult DeleteRight([Bind] ConfirmDeleteModel model)
        {
            AdministratorComponent ac = new AdministratorComponent();

            spAllowedRoleMenus _Right = ac.GetRight(model.Id, model.Id2);
            ac.DeletespAllowedRoleMenusById(_Right.Id);

            return RedirectToAction("GetAllRights");

        }

        #endregion "Rights"



    }
}