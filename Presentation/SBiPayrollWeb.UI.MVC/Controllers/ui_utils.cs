using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBiPayrollWeb.UI.MVC.Controllers
{
    public class ui_utils
    {
        public ui_utils()
        {

        }

        public string get_base_version()
        {
            var dll_ver = System.Reflection.Assembly.GetAssembly(typeof(AccountController)).GetName().Version.ToString();
            return dll_ver;
        }
    }
}