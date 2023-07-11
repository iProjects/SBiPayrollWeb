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
    /// Represents a row of Account data.
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Account
    {
        /// <summary>
        /// Gets or sets a int value for the Id column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a string value for the EmpNo column.
        /// </summary>
        [DataMember]
        public string EmpNo { get; set; }

        /// <summary>
        /// Gets or sets a string value for the AccountType column.
        /// </summary>
        [DataMember]
        public string AccountType { get; set; }

        /// <summary>
        /// Gets or sets a decimal value for the BookBalance column.
        /// </summary>
        [DataMember]
        public decimal BookBalance { get; set; }
    }
}
