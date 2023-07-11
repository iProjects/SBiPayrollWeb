//====================================================================================================
// Base code generated with Inertia: BE Gen (Build 2.5.5049.15162)
// Layered Architecture Solution Guidance (http://layerguidance.codeplex.com)
//
// Generated by Administrator at SAPSERVER on 06/25/2014 06:53:29 
//====================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SBiPayrollWeb.Entities
{
    /// <summary>
    /// Represents a row of webpages_Role data.
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class RoleModel
    {
        /// <summary>
        /// Gets or sets a int value for the RoleId column.
        /// </summary>
        [DataMember]
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets a string value for the RoleName column.
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Please enter Role Name")]
        [Display(Name = "Role")] 
        public string RoleName { get; set; }
    }
}
