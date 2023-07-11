using System; 
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SBiPayrollWeb.UI.MVC.Models
{
    public class ConfirmDeleteModel
    {
        public int Id { get; set; }
        public int Id2 { get; set; }
        public string  Description { get; set; }
        public string Key { get; set; } 
    }

    public class SummaryModel
    {
        public int Id { get; set; } 
        public string Description { get; set; }
        [Display(Name = "Total Products Value")]
        public decimal TotalProductsValue { get; set; }
        [Display(Name = "Total Products Count")]
        public int TotalProductsCount { get; set; }
    }
}