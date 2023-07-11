//====================================================================================================
// Base code generated with Inertia: BE Gen (Build 2.5.5049.15162)
// Layered Architecture Solution Guidance (http://layerguidance.codeplex.com)
//
// Generated by Administrator at SAPSERVER on 12/31/2014 17:24:16 
//====================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;


namespace SBiPayrollWeb.Entities
{
    /// <summary>
    /// Represents a row of EmployeeTransaction data.
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class EmployeeTransaction
    {
        /// <summary>
        /// Gets or sets a int value for the Id column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a DateTime value for the PostDate column.
        /// </summary>
        [DataMember]
        public DateTime PostDate { get; set; }

        /// <summary>
        /// Gets or sets a string value for the EmpNo column.
        /// </summary>
        [DataMember]
        public string EmpNo { get; set; }

        /// <summary>
        /// Gets or sets a int value for the EmployeeId column.
        /// </summary>
        [DataMember]
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets a bool value for the Enabled column.
        /// </summary>
        [DataMember]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets a bool value for the Recurrent column.
        /// </summary>
        [DataMember]
        public bool Recurrent { get; set; }

        /// <summary>
        /// Gets or sets a string value for the ItemId column.
        /// </summary>
        [DataMember]
        public string ItemId { get; set; }

        /// <summary>
        /// Gets or sets a decimal value for the Amount column.
        /// </summary>
        [DataMember]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets a decimal value for the Balance column.
        /// </summary>
        [DataMember]
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets a decimal value for the InitialAmount column.
        /// </summary>
        [DataMember]
        public decimal InitialAmount { get; set; }

        /// <summary>
        /// Gets or sets a bool value for the Processed column.
        /// </summary>
        [DataMember]
        public bool Processed { get; set; }

        /// <summary>
        /// Gets or sets a bool value for the TrackYTD column.
        /// </summary>
        [DataMember]
        public bool TrackYTD { get; set; }

        /// <summary>
        /// Gets or sets a bool value for the ShowYTDInPayslip column.
        /// </summary>
        [DataMember]
        public bool ShowYTDInPayslip { get; set; }

        /// <summary>
        /// Gets or sets a string value for the CreatedBy column.
        /// </summary>
        [DataMember]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets a string value for the LastChangedBy column.
        /// </summary>
        [DataMember]
        public string LastChangedBy { get; set; }

        /// <summary>
        /// Gets or sets a DateTime value for the LastChangeDate column.
        /// </summary>
        [DataMember]
        public DateTime LastChangeDate { get; set; }

        /// <summary>
        /// Gets or sets a string value for the AuthorizedBy column.
        /// </summary>
        [DataMember]
        public string AuthorizedBy { get; set; }

        /// <summary>
        /// Gets or sets a DateTime value for the AuthorizeDate column.
        /// </summary>
        [DataMember]
        public DateTime AuthorizeDate { get; set; }

        /// <summary>
        /// Gets or sets a string value for the LoanType column.
        /// </summary>
        [DataMember]
        public string LoanType { get; set; }

        /// <summary>
        /// Gets or sets a decimal value for the AccumulativePayment column.
        /// </summary>
        [DataMember]
        public decimal AccumulativePayment { get; set; }
    }
}
