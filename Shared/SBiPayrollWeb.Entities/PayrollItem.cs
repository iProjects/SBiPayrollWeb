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
    /// Represents a row of PayrollItem data.
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class PayrollItem
    {
        /// <summary>
        /// Gets or sets a string value for the Id column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a string value for the Description column.
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a string value for the ItemTypeId column.
        /// </summary>
        [DataMember]
        public string ItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets a string value for the TaxTrackingId column.
        /// </summary>
        [DataMember]
        public string TaxTrackingId { get; set; }

        /// <summary>
        /// Gets or sets a string value for the PayableTo column.
        /// </summary>
        [DataMember]
        public string PayableTo { get; set; }

        /// <summary>
        /// Gets or sets a string value for the GLAccount column.
        /// </summary>
        [DataMember]
        public string GLAccount { get; set; }

        /// <summary>
        /// Gets or sets a int value for the ReFField column.
        /// </summary>
        [DataMember]
        public int ReFField { get; set; }

        /// <summary>
        /// Gets or sets a bool value for the DefaultItem column.
        /// </summary>
        [DataMember]
        public bool DefaultItem { get; set; }

        /// <summary>
        /// Gets or sets a bool value for the AddToPension column.
        /// </summary>
        [DataMember]
        public bool AddToPension { get; set; }

        /// <summary>
        /// Gets or sets a bool value for the Active column.
        /// </summary>
        [DataMember]
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a bool value for the Enable column.
        /// </summary>
        [DataMember]
        public bool Enable { get; set; }

        /// <summary>
        /// Gets or sets a bool value for the IsDeleted column.
        /// </summary>
        [DataMember]
        public bool IsDeleted { get; set; }
    }
}
