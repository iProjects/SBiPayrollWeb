//====================================================================================================
// Base code generated with Momentum: DAC Gen (Build 2.5.5049.15162)
// Layered Architecture Solution Guidance (http://layerguidance.codeplex.com)
//
// Generated by Administrator at SAPSERVER on 12/31/2014 17:33:56 
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
    /// spAllowedRoleMenus data access component. Manages CRUD operations for the spAllowedRoleMenus table.
    /// </summary>
    public partial class spAllowedRoleMenusDAC : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the spAllowedRoleMenus table.
        /// </summary>
        /// <param name="spAllowedRoleMenus">A spAllowedRoleMenus object.</param>
        /// <returns>An updated spAllowedRoleMenus object.</returns>
        public spAllowedRoleMenus Create(spAllowedRoleMenus spAllowedRoleMenus)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.spAllowedRoleMenus ([RoleId], [MenuItemId], [Allowed]) " +
                "VALUES(@RoleId, @MenuItemId, @Allowed); SELECT SCOPE_IDENTITY();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, spAllowedRoleMenus.RoleId);
                db.AddInParameter(cmd, "@MenuItemId", DbType.Int32, spAllowedRoleMenus.MenuItemId);
                db.AddInParameter(cmd, "@Allowed", DbType.Boolean, spAllowedRoleMenus.Allowed);

                // Get the primary key value.
                spAllowedRoleMenus.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return spAllowedRoleMenus;
        }

        /// <summary>
        /// Updates an existing row in the spAllowedRoleMenus table.
        /// </summary>
        /// <param name="spAllowedRoleMenus">A spAllowedRoleMenus entity object.</param>
        public void UpdateById(spAllowedRoleMenus spAllowedRoleMenus)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.spAllowedRoleMenus " +
                "SET " +
                    "[RoleId]=@RoleId, " +
                    "[MenuItemId]=@MenuItemId, " +
                    "[Allowed]=@Allowed " +
                "WHERE [Id]=@Id ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, spAllowedRoleMenus.RoleId);
                db.AddInParameter(cmd, "@MenuItemId", DbType.Int32, spAllowedRoleMenus.MenuItemId);
                db.AddInParameter(cmd, "@Allowed", DbType.Boolean, spAllowedRoleMenus.Allowed);
                db.AddInParameter(cmd, "@Id", DbType.Int32, spAllowedRoleMenus.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the spAllowedRoleMenus table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.spAllowedRoleMenus " +
                                         "WHERE [Id]=@Id ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);


                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Returns a row from the spAllowedRoleMenus table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A spAllowedRoleMenus object with data populated from the database.</returns>
        public spAllowedRoleMenus SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [RoleId], [MenuItemId], [Allowed] " +
                "FROM dbo.spAllowedRoleMenus  " +
                "WHERE [Id]=@Id ";

            spAllowedRoleMenus spAllowedRoleMenus = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new spAllowedRoleMenus
                        spAllowedRoleMenus = new spAllowedRoleMenus();

                        // Read values.
                        spAllowedRoleMenus.Id = base.GetDataValue<int>(dr, "Id");
                        spAllowedRoleMenus.RoleId = base.GetDataValue<int>(dr, "RoleId");
                        spAllowedRoleMenus.MenuItemId = base.GetDataValue<int>(dr, "MenuItemId");
                        spAllowedRoleMenus.Allowed = base.GetDataValue<bool>(dr, "Allowed");
                    }
                }
            }

            return spAllowedRoleMenus;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the spAllowedRoleMenus table.
        /// </summary>
        /// <returns>A collection of spAllowedRoleMenus objects.</returns>		
        public List<spAllowedRoleMenus> Select()
        {
            // WARNING! The following SQL query does not contain a WHERE condition.
            // You are advised to include a WHERE condition to prevent any performance
            // issues when querying large resultsets.
            const string SQL_STATEMENT =
                "SELECT [Id], [RoleId], [MenuItemId], [Allowed] " +
                "FROM dbo.spAllowedRoleMenus ";

            List<spAllowedRoleMenus> result = new List<spAllowedRoleMenus>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new spAllowedRoleMenus
                        spAllowedRoleMenus spAllowedRoleMenus = new spAllowedRoleMenus();

                        // Read values.
                        spAllowedRoleMenus.Id = base.GetDataValue<int>(dr, "Id");
                        spAllowedRoleMenus.RoleId = base.GetDataValue<int>(dr, "RoleId");
                        spAllowedRoleMenus.MenuItemId = base.GetDataValue<int>(dr, "MenuItemId");
                        spAllowedRoleMenus.Allowed = base.GetDataValue<bool>(dr, "Allowed");

                        // Add to List.
                        result.Add(spAllowedRoleMenus);
                    }
                }
            }

            return result;
        }
    }
}
