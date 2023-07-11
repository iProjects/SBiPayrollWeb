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
    public class PayrollItemsController : Controller
    {
        #region "PayrollItems"
        //[Authorize]
        public ActionResult GetAllPayrollItems()
        {
            PayrollItemsComponent pc = new PayrollItemsComponent();
            List<PayrollItem> payrollitems = pc.GetAllPayrollItems();

            return View("PayrollItemsListView", payrollitems);

        }
        //[Authorize]
        public ActionResult CreatePayrollItem()
        {
            PayrollItem model = new PayrollItem();

            return View("CreatePayrollItemView", model);

        }
        [HttpPost]
        public ActionResult CreatePayrollItem([Bind] PayrollItem model)
        {
            if (ModelState.IsValid)
            {


                PayrollItemsComponent pc = new PayrollItemsComponent();

                PayrollItem PayrollItem = new PayrollItem();

                pc.CreatePayrollItem(PayrollItem);

                return RedirectToAction("GetAllPayrollItems");

            }
            else
            {
                string[] errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray();
                foreach (var err in errors)
                {
                    ModelState.AddModelError(err, err);
                }
                return View("CreatePayrollItemView", model);
            }
        }
        //[Authorize]
        public ActionResult PayrollItemDetails(string id)
        {

            PayrollItemsComponent pc = new PayrollItemsComponent();

            PayrollItem model = pc.GetPayrollItemById(id);

            return View("PayrollItemDetailsView", model);

        }
        //[Authorize]
        public ActionResult EditPayrollItem(string id)
        {

            PayrollItemsComponent pc = new PayrollItemsComponent();
            PayrollItem model = pc.GetPayrollItemById(id);
            return View("EditPayrollItemView", model);

        }
        [HttpPost]
        public ActionResult EditPayrollItem([Bind] PayrollItem model)
        {

            PayrollItemsComponent pc = new PayrollItemsComponent();

            PayrollItem PayrollItem = pc.GetPayrollItemById(model.Id);

            pc.UpdatePayrollItem(PayrollItem);

            return RedirectToAction("GetAllPayrollItems");

        }
        //[Authorize]
        public ActionResult DeletePayrollItem(string key, string description)
        {
            ConfirmDeleteModel model = new ConfirmDeleteModel();
            PayrollItemsComponent pc = new PayrollItemsComponent();

            var _payrollitemsquery = from ur in pc.GetAllPayrollItems()
                                     where ur.Id == key
                                     select ur;
            List<PayrollItem> _payrollitems = _payrollitemsquery.ToList();
            if (_payrollitems.Count > 0)
            {
                ErrorHandlerModel errormodel = new ErrorHandlerModel();
                errormodel.ExceptionMessage = "There is a Payroll associated with this PayrollItem. Delete the Payroll first !";
                return View("ErrorHandlerView", errormodel);
            }

            model.Key = key;
            model.Description = description;

            return View("ConfirmDeletePayrollItemView", model);

        }
        [HttpPost]
        public ActionResult DeletePayrollItem([Bind] ConfirmDeleteModel model)
        {

            PayrollItemsComponent pc = new PayrollItemsComponent();

            PayrollItem PayrollItem = pc.GetPayrollItemById(model.Key);
            pc.DeletePayrollItemById(PayrollItem.Id);

            return RedirectToAction("GetAllPayrollItems");

        }
        #endregion "PayrollItems"



    }
}