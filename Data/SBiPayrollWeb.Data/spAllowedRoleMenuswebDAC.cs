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
    /// spAllowedRoleMenusweb data access component. Manages CRUD operations for the spAllowedRoleMenusweb table.
    /// </summary>
    public partial class spAllowedRoleMenuswebDAC : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the spAllowedRoleMenusweb table.
        /// </summary>
        /// <param name="spAllowedRoleMenusweb">A spAllowedRoleMenusweb object.</param>
        /// <returns>An updated spAllowedRoleMenusweb object.</returns>
        public spAllowedRoleMenusweb Create(spAllowedRoleMenusweb spAllowedRoleMenusweb)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.spAllowedRoleMenusweb ([RoleId], [MenuItemId], [Allowed]) " +
                "VALUES(@RoleId, @MenuItemId, @Allowed); SELECT SCOPE_IDENTITY();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, spAllowedRoleMenusweb.RoleId);
                db.AddInParameter(cmd, "@MenuItemId", DbType.Int32, spAllowedRoleMenusweb.MenuItemId);
                db.AddInParameter(cmd, "@Allowed", DbType.Boolean, spAllowedRoleMenusweb.Allowed);

                // Get the primary key value.
                spAllowedRoleMenusweb.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return spAllowedRoleMenusweb;
        }

        /// <summary>
        /// Updates an existing row in the spAllowedRoleMenusweb table.
        /// </summary>
        /// <param name="spAllowedRoleMenusweb">A spAllowedRoleMenusweb entity object.</param>
        public void UpdateById(spAllowedRoleMenusweb spAllowedRoleMenusweb)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.spAllowedRoleMenusweb " +
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
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, spAllowedRoleMenusweb.RoleId);
                db.AddInParameter(cmd, "@MenuItemId", DbType.Int32, spAllowedRoleMenusweb.MenuItemId);
                db.AddInParameter(cmd, "@Allowed", DbType.Boolean, spAllowedRoleMenusweb.Allowed);
                db.AddInParameter(cmd, "@Id", DbType.Int32, spAllowedRoleMenusweb.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the spAllowedRoleMenusweb table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.spAllowedRoleMenusweb " +
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
        /// Returns a row from the spAllowedRoleMenusweb table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A spAllowedRoleMenusweb object with data populated from the database.</returns>
        public spAllowedRoleMenusweb SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [RoleId], [MenuItemId], [Allowed] " +
                "FROM dbo.spAllowedRoleMenusweb  " +
                "WHERE [Id]=@Id ";

            spAllowedRoleMenusweb spAllowedRoleMenusweb = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new spAllowedRoleMenusweb
                        spAllowedRoleMenusweb = new spAllowedRoleMenusweb();

                        // Read values.
                        spAllowedRoleMenusweb.Id = base.GetDataValue<int>(dr, "Id");
                        spAllowedRoleMenusweb.RoleId = base.GetDataValue<int>(dr, "RoleId");
                        spAllowedRoleMenusweb.MenuItemId = base.GetDataValue<int>(dr, "MenuItemId");
                        spAllowedRoleMenusweb.Allowed = base.GetDataValue<bool>(dr, "Allowed");
                    }
                }
            }

            return spAllowedRoleMenusweb;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the spAllowedRoleMenusweb table.
        /// </summary>
        /// <returns>A collection of spAllowedRoleMenusweb objects.</returns>		
        public List<spAllowedRoleMenusweb> Select()
        {
            // WARNING! The following SQL query does not contain a WHERE condition.
            // You are advised to include a WHERE condition to prevent any performance
            // issues when querying large resultsets.
            const string SQL_STATEMENT =
                "SELECT [Id], [RoleId], [MenuItemId], [Allowed] " +
                "FROM dbo.spAllowedRoleMenusweb ";

            List<spAllowedRoleMenusweb> result = new List<spAllowedRoleMenusweb>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new spAllowedRoleMenusweb
                        spAllowedRoleMenusweb spAllowedRoleMenusweb = new spAllowedRoleMenusweb();

                        // Read values.
                        spAllowedRoleMenusweb.Id = base.GetDataValue<int>(dr, "Id");
                        spAllowedRoleMenusweb.RoleId = base.GetDataValue<int>(dr, "RoleId");
                        spAllowedRoleMenusweb.MenuItemId = base.GetDataValue<int>(dr, "MenuItemId");
                        spAllowedRoleMenusweb.Allowed = base.GetDataValue<bool>(dr, "Allowed");

                        // Add to List.
                        result.Add(spAllowedRoleMenusweb);
                    }
                }
            }

            return result;
        }
    }
}

