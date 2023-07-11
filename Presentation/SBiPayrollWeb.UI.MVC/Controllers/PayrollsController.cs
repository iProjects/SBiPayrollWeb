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
using SBiPayrollWeb.Business;
using SBiPayrollWeb.Entities;
using SBiPayrollWeb.UI.MVC.Filters;
using SBiPayrollWeb.UI.MVC.Models;
using WebMatrix.WebData;

namespace SBiPayrollWeb.UI.MVC.Controllers
{
    [HandleError]
    [Authorize]
    public class PayrollsController : Controller
    {
        //[Authorize]
        public ActionResult GetAllPayrolls()
        {
            PayrollsComponent pc = new PayrollsComponent();
            List<Payroll> payrolls = pc.GetAllPayrolls();

            return View("PayrollListView", payrolls);
        }
        //[Authorize]
        public ActionResult CreatePayroll()
        {
            Payroll model = new Payroll();

            return View("CreatePayrollView", model);
        }
        //[Authorize]
        public ActionResult ProcessPayroll()
        {
            PayrollsComponent pc = new PayrollsComponent();
            List<Payroll> payrolls = pc.GetAllPayrolls();

            return View("ProcessPayrollView", payrolls);
        }
        [HttpPost]
        public ActionResult ProcessPayroll(int Year, int Period)
        {
            PayrollsComponent pc = new PayrollsComponent();
            List<Payroll> payrolls = pc.GetAllPayrolls();

            InitProcessPayroll(Year, Period);

            return View("ProcessPayrollView", payrolls);
        }
        public void InitProcessPayroll(int Year, int Period)
        {

            Payroll pay = new Payroll();

            // see if the payslip_master_temp has records and they are for this payroll
            //if not, decline processing
            //set up
            int periodWc = 0;
            int yearWc = 0;
            //if (!WorkingCopyNotClosed(ref periodWc, ref yearWc))
            //{
            bool simulateRun = false;
            ProcessPayrollNow(pay.Period, pay.Year, simulateRun);

            //    pay.DateRun = DateTime.Now.Date;

            //    UpdatePayrollDateRun(pay);
            //}
            //else if (periodWc == pay.Period && yearWc == pay.Year)
            //{
            //    if (DialogResult.Yes == MessageBox.Show("Payroll already processed! \nDo you wish to overwrite?", "Confirm Overwrite", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            //    {
            //bool simulateRun = true;
            ProcessPayrollNow(pay.Period, pay.Year, simulateRun);

            pay.DateRun = DateTime.Now.Date;

            //        rep.UpdatePayrollDateRun(pay);
            //    }
            //}
            //else
            //{
            //    //MessageBox.Show("You must close the previously Processed payroll before proceeding", "SB Payroll");
            //}

        }
        public void ProcessPayrollNow(int period, int year, bool simulateRun)
        {

            CPayroll cp = new CPayroll();
            //subscribe to the events 
            string sError = string.Empty;
            cp.RunPayroll(simulateRun, period, year, ref sError);
            //cp.MarkPayrollAsProcessed(period, year);


        }





    }
}