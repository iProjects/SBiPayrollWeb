using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using DotNetOpenAuth.AspNet;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.ExtraInformation;
using Microsoft.Practices.EnterpriseLibrary.Logging.Filters;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Web.WebPages.OAuth;
using SBiPayrollWeb.UI.MVC.Filters;
using SBiPayrollWeb.UI.MVC.Models;
using WebMatrix.WebData;
using SBiPayrollWeb.Business;
using SBiPayrollWeb.Entities;

namespace SBiPayrollWeb.UI.MVC.Controllers
{
    [HandleError]
    [Authorize]
    public class DepartmentsController : Controller
    {
        #region "Departments"
        //[Authorize]
        public ActionResult GetAllDepartments()
        {
            DepartmentsComponent dc = new DepartmentsComponent();
            List<Department> Departments = dc.GetAllDepartments();

            return View("DepartmentsListView", Departments);

        }
        //[Authorize]
        public ActionResult CreateDepartment()
        {

            Department model = new Department();

            return View("CreateDepartmentView", model);

        }
        [HttpPost]
        public ActionResult CreateDepartment([Bind] Department model)
        {
            if (ModelState.IsValid)
            {
                DepartmentsComponent pc = new DepartmentsComponent();

                Department Department = new Department();

                pc.CreateDepartment(Department);

                return RedirectToAction("GetAllDepartments");

            }
            else
            {
                string[] errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray();
                foreach (var err in errors)
                {
                    ModelState.AddModelError(err, err);
                }
                return View("CreateDepartmentView", model);
            }
        }
        //[Authorize]
        public ActionResult DepartmentDetails(int id)
        {
            DepartmentsComponent pc = new DepartmentsComponent();

            Department model = pc.GetDepartmentById(id);

            return View("DepartmentDetailsView", model);

        }
        //[Authorize]
        public ActionResult EditDepartment(int id)
        {

            DepartmentsComponent pc = new DepartmentsComponent();
            Department model = pc.GetDepartmentById(id);
            return View("EditDepartmentView", model);

        }
        [HttpPost]
        public ActionResult EditDepartment([Bind] Department model)
        {

            DepartmentsComponent pc = new DepartmentsComponent();

            Department Department = pc.GetDepartmentById(model.Id);

            pc.UpdateDepartment(Department);

            return RedirectToAction("GetAllDepartments");

        }
        //[Authorize]
        public ActionResult DeleteDepartment(int id, string description)
        {

            ConfirmDeleteModel model = new ConfirmDeleteModel();
            DepartmentsComponent pc = new DepartmentsComponent();

            var _departmentsquery = from ur in pc.GetAllDepartments()
                                    where ur.Id == id
                                    select ur;
            List<Department> _departments = _departmentsquery.ToList();
            if (_departments.Count > 0)
            {
                ErrorHandlerModel errormodel = new ErrorHandlerModel();
                errormodel.ExceptionMessage = "There is an Employee associated with this Department. Delete the Employee first !";
                return View("ErrorHandlerView", errormodel);
            }

            model.Id = id;
            model.Description = description;

            return View("ConfirmDeleteDepartmentView", model);

        }
        [HttpPost]
        public ActionResult DeleteDepartment([Bind] ConfirmDeleteModel model)
        {

            DepartmentsComponent pc = new DepartmentsComponent();

            Department Department = pc.GetDepartmentById(model.Id);
            pc.DeleteDepartmentById(Department.Id);

            return RedirectToAction("GetAllDepartments");

        }
        #endregion "Departments"



    }
}