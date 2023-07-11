using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBiPayrollWeb.UI.MVC.Models
{
    public class ErrorHandlerModel
    {
        public string ExceptionMessage { get; set; }

        public List<string> ExceptionMessages { get; set; }
    }

    public class DialogModel
    {
        public object _object { get; set; }

        public List<object> _objects { get; set; }
    }


}