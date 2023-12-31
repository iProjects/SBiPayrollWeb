//====================================================================================================
// Base code generated with Momentum: DAC Gen (Build 2.5.5049.15162)
// Layered Architecture Solution Guidance (http://layerguidance.codeplex.com)
//
// Generated by Administrator at SAPSERVER on 12/31/2014 06:25:02 
//====================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SBiPayrollWeb.Entities;

namespace SBiPayrollWeb.Data
{
    /// <summary>
    /// spUsersInRoles data access component. Manages CRUD operations for the spUsersInRoles table.
    /// </summary>
    public partial class spUsersInRoleDAC 
    { 
        /// <summary>
        /// Returns a row from the spUsersInRoles table.
        /// </summary>
        /// <param name="userId">A UserId value.</param>
        /// <param name="roleId">A RoleId value.</param>
        /// <returns>A spUsersInRole object with data populated from the database.</returns>
        public spUsersInRole SelectById(int userId, int roleId)
        {
            const string SQL_STATEMENT =
                "SELECT [UserId], [RoleId] " +
                "FROM dbo.spUsersInRoles  " +
                "WHERE [UserId]=@UserId " +
                      "AND [RoleId]=@RoleId ";

            spUsersInRole spUsersInRole = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@UserId", DbType.Int32, userId);
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, roleId);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new spUsersInRole
                        spUsersInRole = new spUsersInRole();

                        // Read values.
                        spUsersInRole.UserId = base.GetDataValue<int>(dr, "UserId");
                        spUsersInRole.RoleId = base.GetDataValue<int>(dr, "RoleId");
                    }
                }
            }

            return spUsersInRole;
        }
         
    }
}

