using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
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
using SBiPayrollWeb.Business;
using SBiPayrollWeb.Entities;
using SBiPayrollWeb.UI.MVC.Filters;
using SBiPayrollWeb.UI.MVC.Models;
using WebMatrix.WebData;

namespace SBiPayrollWeb.UI.MVC.Controllers
{
    [HandleError]
    [Authorize]
    public class DataEntryController : Controller
    {
        #region "Employers"
        //[Authorize]
        public ActionResult GetAllEmployers()
        {
            DataEntryComponent dc = new DataEntryComponent();
            List<Employer> Employers = dc.GetAllEmployers();

            return View("EmployersListView", Employers);

        }
        //[Authorize]
        public ActionResult CreateEmployer()
        {
            DataEntryComponent dc = new DataEntryComponent();
            Employer model = new Employer();
            model.IsActive = true;
            model.IsDeleted = false;

            var defaultemployer = (from emp in dc.GetAllEmployers()
                                   where emp.IsDefault == true
                                   select emp);
            if (defaultemployer.Count() > 0)
            {
                ViewBag.IsDefaultchkDisabled = true;
            }
            else if (defaultemployer.Count() == 0)
            {
                ViewBag.IsDefaultchkDisabled = false;
            }

            return View("CreateEmployerView", model);

        }
        [HttpPost]
        public ActionResult CreateEmployer([Bind] Employer model)
        {
            if (ModelState.IsValid)
            {
                DataEntryComponent dc = new DataEntryComponent();

                Employer _Employer = new Employer();
                _Employer.Name = Utils.ConvertFirstLetterToUpper(model.Name);
                _Employer.Email = model.Email.ToLower();
                _Employer.Telephone = Utils.ConvertFirstLetterToUpper(model.Telephone);
                _Employer.Address1 = Utils.ConvertFirstLetterToUpper(model.Address1);
                _Employer.Address2 = Utils.ConvertFirstLetterToUpper(model.Address2);
                _Employer.Slogan = Utils.ConvertFirstLetterToUpper(model.Slogan);
                _Employer.AuthorizedSignatory = Utils.ConvertFirstLetterToUpper(model.AuthorizedSignatory);
                _Employer.PIN = model.PIN;
                _Employer.NHIF = model.NHIF;
                _Employer.NSSF = model.NSSF;
                _Employer.BankBranchSortCode = model.BankBranchSortCode;
                _Employer.AccountName = Utils.ConvertFirstLetterToUpper(model.AccountName);
                _Employer.AccountNo = model.AccountNo;
                _Employer.IsActive = model.IsActive;
                _Employer.IsDefault = model.IsDefault;
                _Employer.IsDeleted = false;

                Employer returnedEmployer = dc.CreateEmployer(_Employer);

                Session["EmployerId"] = null;
                Session["EmployerId"] = returnedEmployer.Id;

                return RedirectToAction("UploadEmployerLogo");

            }
            else
            {
                model.IsActive = true;
                model.IsDeleted = false;

                string[] errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray();
                foreach (var err in errors)
                {
                    ModelState.AddModelError(err, err);
                }
                return View("CreateEmployerView", model);
            }
        }
        //[Authorize]
        public ActionResult UploadEmployerLogo_Edit(int id)
        {
            Session["EmployerId"] = null;
            Session["EmployerId"] = id;

            return RedirectToAction("UploadEmployerLogo");

        }
        //[Authorize]
        public ActionResult UploadEmployerLogo()
        {
            return View();

        }
        [HttpPost]
        public ActionResult UploadEmployerLogo(HttpPostedFileBase HttpPostedLogo)
        {
            DataEntryComponent dc = new DataEntryComponent();

            string fileNameWithPath = null;
            string fileName = null;
            string physicalPath = Server.MapPath("~/Images/");

            //Ensure that the _user has selected a file
            if (HttpPostedLogo != null && HttpPostedLogo.ContentLength > 0)
            {
                fileName = System.IO.Path.GetFileName(HttpPostedLogo.FileName);

                fileNameWithPath = Path.Combine(physicalPath, fileName);

                // save image in folder
                HttpPostedLogo.SaveAs(fileNameWithPath);
            }

            string _Sessionemployerid = Session["EmployerId"].ToString();
            int _employerid = int.Parse(_Sessionemployerid);

            Employer _Employer = dc.GetEmployerbyId(_employerid);
            _Employer.Logo = fileName;
            dc.UploadEmployerLogo(_Employer);

            return RedirectToAction("GetAllEmployers");

        }
        public string GetEmployerLogo()
        {
            DataEntryComponent dc = new DataEntryComponent();
            Employer employer = dc.GetDefaultEmployer();
            if (employer == null)
            {
                return null;
            }
            if (employer.Logo == null)
            {
                return null;
            }
            return employer.Logo;
        }
        //[Authorize]
        public ActionResult EmployerDetails(int id)
        {
            DataEntryComponent dc = new DataEntryComponent();

            Employer model = dc.GetEmployerbyId(id);

            return View("EmployerDetailsView", model);

        }
        //[Authorize]
        public ActionResult EditEmployer(int id)
        {
            DataEntryComponent dc = new DataEntryComponent();
            Employer model = dc.GetEmployerbyId(id);

            var defaultemployer = (from emp in dc.GetAllEmployers()
                                   where emp.IsDefault == true
                                   select emp);
            if (defaultemployer.Count() > 0 && model.IsDefault == true)
            {
                ViewBag.IsDefaultchkDisabled = false;
            }
            else if (defaultemployer.Count() > 0)
            {
                ViewBag.IsDefaultchkDisabled = true;
            }
            else if (defaultemployer.Count() == 0)
            {
                ViewBag.IsDefaultchkDisabled = false;
            }

            return View("EditEmployerView", model);

        }
        [HttpPost]
        public ActionResult EditEmployer([Bind] Employer model)
        {
            DataEntryComponent dc = new DataEntryComponent();

            Employer _Employer = dc.GetEmployerbyId(model.Id);
            _Employer.Name = Utils.ConvertFirstLetterToUpper(model.Name);
            _Employer.Address1 = Utils.ConvertFirstLetterToUpper(model.Address1);
            _Employer.Address2 = Utils.ConvertFirstLetterToUpper(model.Address2);
            _Employer.Telephone = Utils.ConvertFirstLetterToUpper(model.Telephone);
            if (model.Email != null)
            {
                _Employer.Email = model.Email;
            } 
            _Employer.Slogan = Utils.ConvertFirstLetterToUpper(model.Slogan);
            _Employer.AuthorizedSignatory = Utils.ConvertFirstLetterToUpper(model.AuthorizedSignatory);
            _Employer.NHIF = model.NHIF;
            _Employer.NSSF = model.NSSF;
            _Employer.BankBranchSortCode = model.BankBranchSortCode;
            _Employer.AccountName = model.AccountName;
            _Employer.AccountNo = model.AccountNo;
            _Employer.IsActive = model.IsActive;
            _Employer.IsDefault = model.IsDefault; 

            dc.UpdateEmployer(_Employer);

            return RedirectToAction("GetAllEmployers");

        }
        //[Authorize]
        public ActionResult DeleteEmployer(int id, string description)
        {
            DataEntryComponent dc = new DataEntryComponent();

            var _employeesquery = from em in dc.GetAllEmployees()
                                  where em.EmployerId == id
                                  select em;
            List<Employee> _employees = _employeesquery.ToList();
            if (_employees.Count > 0)
            {
                ErrorHandlerModel errormodel = new ErrorHandlerModel();
                errormodel.ExceptionMessage = "There is an Employee associated with this Employer Delete the Employee first!";
                return View("ErrorHandlerView", errormodel);
            }

            ConfirmDeleteModel model = new ConfirmDeleteModel();
            model.Id = id;
            model.Description = description;

            return View("ConfirmDeleteEmployerView", model);

        }
        [HttpPost]
        public ActionResult DeleteEmployer([Bind] ConfirmDeleteModel model)
        {
            DataEntryComponent dc = new DataEntryComponent();

            dc.DeleteEmployerById(model.Id);

            return RedirectToAction("GetAllEmployers");
        }
        #endregion "Employers"
        #region "Employees"
        //[Authorize]
        public ActionResult GetAllEmployees()
        {

            DataEntryComponent dc = new DataEntryComponent();
            List<Employee> Employees = dc.GetAllEmployees();

            return View("EmployeesListView", Employees);

        }
        //[Authorize]
        public ActionResult CreateEmployee()
        {
            DataEntryComponent dc = new DataEntryComponent();
            DepartmentsComponent dpc = new DepartmentsComponent();
            Employee model = new Employee();

            model.IsActive = true;
            model.IsDeleted = false;
            string email = User.Identity.Name;
            model.CreatedBy = email;

            string _EmployeeNo = Utils.NextSeries(NextEmployeeNo());
            model.EmpNo = _EmployeeNo;

            var _employersquery = from ep in dc.GetAllEmployers()
                                  select ep;
            List<Employer> _Employers = _employersquery.ToList();

            model._Employers = _Employers;

            var _Departmentsquery = from dp in dpc.GetAllDepartments()
                                    select dp;
            List<Department> _Departments = _Departmentsquery.ToList();

            model._Departments = _Departments;

            return View("CreateEmployeeView", model);

        }
        private string NextEmployeeNo()
        {

            DataEntryComponent dc = new DataEntryComponent();
            var cn = (from c in dc.GetAllEmployees()
                      orderby c.Id descending
                      select c).FirstOrDefault();
            if (cn == null)
                return "0";
            return cn.EmpNo.ToString().Trim();

        }
        [HttpPost]
        public ActionResult CreateEmployee([Bind] Employee model)
        {
            DataEntryComponent dc = new DataEntryComponent();
            DepartmentsComponent dpc = new DepartmentsComponent();

            if (ModelState.IsValid)
            {

                Employee _Employee = new Employee();
                if (model.Email != null)
                {
                    _Employee.Email = model.Email.ToLower();
                }
                _Employee.Surname = Utils.ConvertFirstLetterToUpper(model.Surname);
                _Employee.OtherNames = Utils.ConvertFirstLetterToUpper(model.OtherNames);
                _Employee.EmpNo = Utils.ConvertFirstLetterToUpper(model.EmpNo);
                _Employee.MaritalStatus = model.MaritalStatus;
                _Employee.Gender = model.Gender;
                _Employee.Photo = model.Photo;
                _Employee.DoB = model.DoB;
                _Employee.DoE = model.DoE;
                _Employee.CreatedOn = model.CreatedOn;
                _Employee.DateLeft = model.DateLeft;
                _Employee.TelephoneNo = Utils.ConvertFirstLetterToUpper(model.TelephoneNo);
                _Employee.DepartmentId = model.DepartmentId;
                _Employee.EmployerId = model.EmployerId;
                _Employee.BasicComputation = model.BasicComputation;
                _Employee.BasicPay = model.BasicPay;
                _Employee.LeaveBalance = model.LeaveBalance;
                _Employee.PersonalRelief = model.PersonalRelief;
                _Employee.MortgageRelief = model.MortgageRelief;
                _Employee.InsuranceRelief = model.InsuranceRelief;
                _Employee.NSSFNo = model.NSSFNo;
                _Employee.NHIFNo = model.NHIFNo;
                _Employee.IDNo = model.IDNo;
                _Employee.PINNo = model.PINNo;
                _Employee.PayPoint = model.PayPoint;
                _Employee.EmpGroup = model.EmpGroup;
                _Employee.EmpPayroll = model.EmpPayroll;
                _Employee.PaymentMode = model.PaymentMode;
                _Employee.ChequeNo = model.ChequeNo;
                _Employee.BankCode = model.BankCode;
                _Employee.BankAccount = model.BankAccount;
                _Employee.CreatedBy = model.CreatedBy;
                _Employee.PrevEmployer = model.PrevEmployer;
                _Employee.IsActive = model.IsActive;
                _Employee.IsDeleted = false;

                Employee returnedEmployee = dc.CreateEmployee(_Employee);

                Session["EmployeeId"] = null;
                Session["EmployeeId"] = returnedEmployee.Id;

                return RedirectToAction("UploadEmployeePhoto");

            }

            model.IsActive = true;
            model.IsDeleted = false;
            string email = User.Identity.Name;
            model.CreatedBy = email;

            string _EmployeeNo = Utils.NextSeries(NextEmployeeNo());
            model.EmpNo = _EmployeeNo;

            var _employersquery = from ep in dc.GetAllEmployers()
                                  select ep;
            List<Employer> _Employers = _employersquery.ToList();

            model._Employers = _Employers;

            var _Departmentsquery = from dp in dpc.GetAllDepartments()
                                    select dp;
            List<Department> _Departments = _Departmentsquery.ToList();

            model._Departments = _Departments;

            string[] errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray();
            foreach (var err in errors)
            {
                ModelState.AddModelError(err, err);
            }
            return View("CreateEmployeeView", model);
        }
        public ActionResult UploadEmployeeLogo_Edit(int id)
        {

            Session["EmployeeId"] = null;
            Session["EmployeeId"] = id;

            return RedirectToAction("UploadEmployeePhoto");

        }
        //[Authorize]
        public ActionResult UploadEmployeePhoto()
        {

            return View();

        }
        [HttpPost]
        public ActionResult UploadEmployeePhoto(HttpPostedFileBase HttpPostedLogo)
        {

            DataEntryComponent dc = new DataEntryComponent();

            string fileNameWithPath = null;
            string fileName = null;
            string physicalPath = Server.MapPath("~/Images/");

            //Ensure that the user has selected a file
            if (HttpPostedLogo != null && HttpPostedLogo.ContentLength > 0)
            {
                fileName = System.IO.Path.GetFileName(HttpPostedLogo.FileName);

                fileNameWithPath = Path.Combine(physicalPath, fileName);

                // save image in folder
                HttpPostedLogo.SaveAs(fileNameWithPath);
            }

            string _Sessionemployeeid = Session["EmployeeId"].ToString();
            int _employeeid = int.Parse(_Sessionemployeeid);

            Employee _Employee = dc.GetEmployeebyId(_employeeid);
            _Employee.Photo = fileName;
            dc.UploadEmployeePhoto(_Employee);

            return RedirectToAction("GetAllEmployees");

        }
        //[Authorize]
        public ActionResult EmployeeDetails(int id)
        {

            DataEntryComponent dc = new DataEntryComponent();
            DepartmentsComponent dpc = new DepartmentsComponent();

            Employee model = dc.GetEmployeebyId(id);

            var _employersquery = from ep in dc.GetAllEmployers()
                                  select ep;
            List<Employer> _Employers = _employersquery.ToList();

            model._Employers = _Employers;

            var _Departmentsquery = from dp in dpc.GetAllDepartments()
                                    select dp;
            List<Department> _Departments = _Departmentsquery.ToList();

            model._Departments = _Departments;

            return View("EmployeeDetailsView", model);

        }
        //[Authorize]
        public ActionResult EditEmployee(int id)
        {
            DataEntryComponent dc = new DataEntryComponent();
            DepartmentsComponent dpc = new DepartmentsComponent();

            Employee model = dc.GetEmployeebyId(id);

            var _employersquery = from ep in dc.GetAllEmployers()
                                  select ep;
            List<Employer> _Employers = _employersquery.ToList();

            model._Employers = _Employers;

            var _Departmentsquery = from dp in dpc.GetAllDepartments()
                                    select dp;
            List<Department> _Departments = _Departmentsquery.ToList();

            model._Departments = _Departments;

            return View("EditEmployeeView", model);

        }
        [HttpPost]
        public ActionResult EditEmployee([Bind] Employee model)
        {

            DataEntryComponent dc = new DataEntryComponent();

            Employee _Employee = dc.GetEmployeebyId(model.Id);
            if (model.Email != null)
            {
                _Employee.Email = model.Email.ToLower();
            }
            _Employee.Surname = Utils.ConvertFirstLetterToUpper(model.Surname);
            _Employee.OtherNames = Utils.ConvertFirstLetterToUpper(model.OtherNames);
            _Employee.EmpNo = Utils.ConvertFirstLetterToUpper(model.EmpNo);
            _Employee.MaritalStatus = model.MaritalStatus;
            _Employee.Gender = model.Gender;
            _Employee.Photo = model.Photo;
            _Employee.DoB = model.DoB;
            _Employee.DoE = model.DoE;
            _Employee.CreatedOn = model.CreatedOn;
            _Employee.DateLeft = model.DateLeft;
            _Employee.TelephoneNo = Utils.ConvertFirstLetterToUpper(model.TelephoneNo);
            _Employee.DepartmentId = model.DepartmentId;
            _Employee.EmployerId = model.EmployerId;
            _Employee.BasicComputation = model.BasicComputation;
            _Employee.BasicPay = model.BasicPay;
            _Employee.LeaveBalance = model.LeaveBalance;
            _Employee.PersonalRelief = model.PersonalRelief;
            _Employee.MortgageRelief = model.MortgageRelief;
            _Employee.InsuranceRelief = model.InsuranceRelief;
            _Employee.NSSFNo = model.NSSFNo;
            _Employee.NHIFNo = model.NHIFNo;
            _Employee.IDNo = model.IDNo;
            _Employee.PINNo = model.PINNo;
            _Employee.PayPoint = model.PayPoint;
            _Employee.EmpGroup = model.EmpGroup;
            _Employee.EmpPayroll = model.EmpPayroll;
            _Employee.PaymentMode = model.PaymentMode;
            _Employee.ChequeNo = model.ChequeNo;
            _Employee.BankCode = model.BankCode;
            _Employee.BankAccount = model.BankAccount;
            _Employee.CreatedBy = model.CreatedBy;
            _Employee.PrevEmployer = model.PrevEmployer;
            _Employee.IsActive = model.IsActive;

            dc.UpdateEmployee(_Employee);

            return RedirectToAction("GetAllEmployees");

        }
        //[Authorize]
        public ActionResult DeleteEmployee(int id, string description)
        {

            DataEntryComponent dc = new DataEntryComponent();
            AdministratorComponent ac = new AdministratorComponent();


            ConfirmDeleteModel model = new ConfirmDeleteModel();
            model.Id = id;
            model.Description = description;

            return View("ConfirmDeleteEmployeeView", model);

        }
        [HttpPost]
        public ActionResult DeleteEmployee([Bind] ConfirmDeleteModel model)
        {
            DataEntryComponent dc = new DataEntryComponent();

            dc.DeleteEmployeeById(model.Id);

            return RedirectToAction("GetAllEmployees");
        }
        #endregion "Employees"
        //[Authorize]
        public ActionResult GetAllPayeeRates()
        {
            DataEntryComponent dc = new DataEntryComponent();
            List<PayeeRate> PayeeRates = dc.GetAllPayeeRates();

            return View("PayeeRatesListView", PayeeRates);
        }

        //[Authorize]
        public ActionResult GetAllNhifRates()
        {
            DataEntryComponent dc = new DataEntryComponent();
            List<NHIFRate> NHIFRates = dc.GetAllNhifRates();

            return View("NhifRatesListView", NHIFRates);
        }

        //[Authorize]
        public ActionResult GetAllNewNSSFComputaion()
        {
            DataEntryComponent dc = new DataEntryComponent();
            List<NHIFRate> NHIFRates = dc.GetAllNhifRates();

            return View("NhifRatesListView", NHIFRates);
        }

        //[Authorize]
        public ActionResult GetAllReports()
        {
            DataEntryComponent dc = new DataEntryComponent();
            List<spAllowedReportsRolesMenus> Reports = dc.GetAllReports();

            return View("ReportsListView", Reports);
        }

        //[Authorize]
        public ActionResult GetAllTaxCalculator()
        {
            DataEntryComponent dc = new DataEntryComponent();
            List<TaxTracking> TaxTrackings = dc.GetAllTaxCalculator();

            return View("TaxTrackingsListView", TaxTrackings);
        }




    }
}