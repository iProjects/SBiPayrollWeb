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
    public class BenefitsController : Controller
    {
        #region "Benefits"
        //[Authorize]
        public ActionResult GetAllBenefits()
        {
            BenefitsComponent bc = new BenefitsComponent();
            List<Benefit> Benefits = bc.GetAllBenefits();

            return View("BenefitsListView", Benefits);

        }
        //[Authorize]
        public ActionResult CreateBenefit()
        {

            Benefit model = new Benefit();

            return View("CreateBenefitView", model);

        }
        [HttpPost]
        public ActionResult CreateBenefit([Bind] Benefit model)
        {
            if (ModelState.IsValid)
            {

                BenefitsComponent pc = new BenefitsComponent();

                Benefit Benefit = new Benefit();

                pc.CreateBenefit(Benefit);

                return RedirectToAction("GetAllBenefits");

            }
            else
            {
                string[] errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray();
                foreach (var err in errors)
                {
                    ModelState.AddModelError(err, err);
                }
                return View("CreateBenefitView", model);
            }
        }
        //[Authorize]
        public ActionResult BenefitDetails(int id)
        {
            BenefitsComponent pc = new BenefitsComponent();

            Benefit model = pc.GetBenefitById(id);

            return View("BenefitDetailsView", model);
        }
        //[Authorize]
        public ActionResult EditBenefit(int id)
        {

            BenefitsComponent pc = new BenefitsComponent();
            Benefit model = pc.GetBenefitById(id);
            return View("EditBenefitView", model);

        }
        [HttpPost]
        public ActionResult EditBenefit([Bind] Benefit model)
        {
            BenefitsComponent pc = new BenefitsComponent();

            Benefit Benefit = pc.GetBenefitById(model.Id);

            pc.UpdateBenefit(Benefit);

            return RedirectToAction("GetAllBenefits");

        }
        //[Authorize]
        public ActionResult DeleteBenefit(int id, string description)
        {
            ConfirmDeleteModel model = new ConfirmDeleteModel();
            BenefitsComponent pc = new BenefitsComponent();

            var _benefitsquery = from ur in pc.GetAllBenefits()
                                 where ur.Id == id
                                 select ur;
            List<Benefit> _benefits = _benefitsquery.ToList();
            if (_benefits.Count > 0)
            {
                ErrorHandlerModel errormodel = new ErrorHandlerModel();
                errormodel.ExceptionMessage = "There is an Employee associated with this Benefit. Delete the Employee first !";
                return View("ErrorHandlerView", errormodel);
            }

            model.Id = id;
            model.Description = description;

            return View("ConfirmDeleteBenefitView", model);

        }
        [HttpPost]
        public ActionResult DeleteBenefit([Bind] ConfirmDeleteModel model)
        {
            BenefitsComponent pc = new BenefitsComponent();

            Benefit Benefit = pc.GetBenefitById(model.Id);
            pc.DeleteBenefitById(Benefit.Id);

            return RedirectToAction("GetAllBenefits");

        }
        #endregion "Benefits"



    }
}