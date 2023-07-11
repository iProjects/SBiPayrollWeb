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
    /// Represents a row of spUsersInRole data.
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class spUsersInRole
    {
        /// <summary>
        /// Gets or sets a int value for the UserId column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets a int value for the RoleId column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public int RoleId { get; set; }
    }
}