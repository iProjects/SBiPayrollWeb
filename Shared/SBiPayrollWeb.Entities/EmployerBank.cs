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
    /// Represents a row of EmployerBank data.
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class EmployerBank
    {
        /// <summary>
        /// Gets or sets a int value for the Id column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a int value for the EmployerId column.
        /// </summary>
        [DataMember]
        public int EmployerId { get; set; }

        /// <summary>
        /// Gets or sets a string value for the BankSortCode column.
        /// </summary>
        [DataMember]
        public string BankSortCode { get; set; }

        /// <summary>
        /// Gets or sets a string value for the AccountName column.
        /// </summary>
        [DataMember]
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets a string value for the AccountNo column.
        /// </summary>
        [DataMember]
        public string AccountNo { get; set; }

        /// <summary>
        /// Gets or sets a string value for the Signatory column.
        /// </summary>
        [DataMember]
        public string Signatory { get; set; }

        /// <summary>
        /// Gets or sets a bool value for the IsDefault column.
        /// </summary>
        [DataMember]
        public bool IsDefault { get; set; }
    }
}
