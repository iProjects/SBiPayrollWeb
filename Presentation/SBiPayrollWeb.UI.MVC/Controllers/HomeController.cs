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
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "For Payroll Management";

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Soft Books Payroll";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Contacts";

            return View();
        }
        public ActionResult ContactUs()
        {
            ViewBag.Message = "Contact Us";

            return View();
        }
        public ActionResult SiteMap()
        {
            ViewBag.Message = "Site Map";

            return View();
        }
        public ActionResult Help()
        {
            ViewBag.Message = "Help";

            return View();
        }
















    }
}
