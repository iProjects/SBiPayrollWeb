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
    public class BanksController : Controller
    {
        #region "Banks"
        //[Authorize]
        public ActionResult GetAllBanks()
        {
            BanksComponent pc = new BanksComponent();
            List<Bank> Banks = pc.GetAllBanks();

            return View("BanksListView", Banks);

        }
        //[Authorize]
        public ActionResult CreateBank()
        {
            Bank model = new Bank();

            return View("CreateBankView", model);

        }
        [HttpPost]
        public ActionResult CreateBank([Bind] Bank model)
        {
            if (ModelState.IsValid)
            {
                BanksComponent pc = new BanksComponent();

                Bank Bank = new Bank();

                pc.CreateBank(Bank);

                return RedirectToAction("GetAllBanks");
            }
            else
            {
                string[] errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray();
                foreach (var err in errors)
                {
                    ModelState.AddModelError(err, err);
                }
                return View("CreateBankView", model);
            }
        }
        //[Authorize]
        public ActionResult BankDetails(string key)
        {
            BanksComponent pc = new BanksComponent();

            Bank model = pc.GetBankById(key);

            return View("BankDetailsView", model);

        }
        //[Authorize]
        public ActionResult EditBank(string key)
        {
            BanksComponent pc = new BanksComponent();
            Bank model = pc.GetBankById(key);
            return View("EditBankView", model);

        }
        [HttpPost]
        public ActionResult EditBank([Bind] Bank model)
        {

            BanksComponent pc = new BanksComponent();

            Bank Bank = pc.GetBankById(model.BankCode);

            pc.UpdateBank(Bank);

            return RedirectToAction("GetAllBanks");

        }
        //[Authorize]
        public ActionResult DeleteBank(string key, string description)
        {
            ConfirmDeleteModel model = new ConfirmDeleteModel();
            BanksComponent pc = new BanksComponent();

            var _benefitsquery = from ur in pc.GetAllBanks()
                                 where ur.BankCode == key
                                 select ur;
            List<Bank> _benefits = _benefitsquery.ToList();
            if (_benefits.Count > 0)
            {
                ErrorHandlerModel errormodel = new ErrorHandlerModel();
                errormodel.ExceptionMessage = "There is a Branch associated with this Bank. Delete the Branch first !";
                return View("ErrorHandlerView", errormodel);
            }

            model.Key = key;
            model.Description = description;

            return View("ConfirmDeleteBankView", model);

        }
        [HttpPost]
        public ActionResult DeleteBank([Bind] ConfirmDeleteModel model)
        {
            BanksComponent pc = new BanksComponent();

            Bank Bank = pc.GetBankById(model.Key);
            pc.DeleteBankById(Bank.BankCode);

            return RedirectToAction("GetAllBanks");

        }
        #endregion "Banks"



    }
}