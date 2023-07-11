//====================================================================================================
// Base code generated with Inertia: BE Gen (Build 2.5.5049.15162)
// Layered Architecture Solution Guidance (http://layerguidance.codeplex.com)
//
// Generated by Administrator at SAPSERVER on 01/13/2015 06:32:02 
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
    /// Represents a row of Employer data.
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Employer
    {
        /// <summary>
        /// Gets or sets a int value for the Id column.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a string value for the Name column.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a string value for the Email column.
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a string value for the Telephone column.
        /// </summary>
        [DataMember]
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets a string value for the Address1 column.
        /// </summary>
        [DataMember]
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or sets a string value for the Address2 column.
        /// </summary>
        [DataMember]
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or sets a string value for the Slogan column.
        /// </summary>
        [DataMember]
        public string Slogan { get; set; }

        /// <summary>
        /// Gets or sets a string value for the AuthorizedSignatory column.
        /// </summary>
        [DataMember]
        public string AuthorizedSignatory { get; set; }

        /// <summary>
        /// Gets or sets a string value for the PIN column.
        /// </summary>
        [DataMember]
        public string PIN { get; set; }

        /// <summary>
        /// Gets or sets a string value for the NHIF column.
        /// </summary>
        [DataMember]
        public string NHIF { get; set; }

        /// <summary>
        /// Gets or sets a string value for the NSSF column.
        /// </summary>
        [DataMember]
        public string NSSF { get; set; }

        /// <summary>
        /// Gets or sets a string value for the BankBranchSortCode column.
        /// </summary>
        [DataMember]
        public string BankBranchSortCode { get; set; }

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
        /// Gets or sets a string value for the Logo column.
        /// </summary>
        [DataMember]
        public string Logo { get; set; }

        /// <summary>
        /// Gets or sets a bool value for the IsDefault column.
        /// </summary>
        [DataMember]
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets a bool value for the IsActive column.
        /// </summary>
        [DataMember]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a bool value for the IsDeleted column.
        /// </summary>
        [DataMember]
        public bool IsDeleted { get; set; }
    }
}
