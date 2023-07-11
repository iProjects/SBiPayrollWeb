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
    /// Represents a row of Transaction data.
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Transaction
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
        /// Gets or sets a decimal value for the Amount column.
        /// </summary>
        [DataMember]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets a string value for the DRCR column.
        /// </summary>
        [DataMember]
        public string DRCR { get; set; }

        /// <summary>
        /// Gets or sets a string value for the Narrative column.
        /// </summary>
        [DataMember]
        public string Narrative { get; set; }

        /// <summary>
        /// Gets or sets a int value for the TxnType column.
        /// </summary>
        [DataMember]
        public int TxnType { get; set; }
    }
}
