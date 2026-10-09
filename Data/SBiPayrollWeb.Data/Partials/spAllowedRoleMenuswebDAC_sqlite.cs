using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SBiPayrollWeb.Entities;

namespace SBiPayrollWeb.Data
{
    /// <summary>
    /// spAllowedRoleMenusweb data access component. Manages CRUD operations for the spAllowedRoleMenusweb table.
    /// </summary>
    public partial class spAllowedRoleMenuswebDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Returns a row from the spAllowedRoleMenusweb table.
        /// </summary>
        /// <param name="RoleId">A RoleId value.</param>
        /// <param name="MenuItemId">A MenuItemId value.</param>
        /// <returns>A spAllowedRoleMenusweb object with data populated from the database.</returns>
        public spAllowedRoleMenusweb SelectRight(int RoleId, int MenuItemId)
        {
            const string SQL_STATEMENT =
                "SELECT * " +
                "FROM [spAllowedRoleMenusweb] " +
                "WHERE [RoleId] = @RoleId " +
                      "AND [MenuItemId] = @MenuItemId;";

            spAllowedRoleMenusweb spAllowedRoleMenusweb = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, RoleId);
                db.AddInParameter(cmd, "@MenuItemId", DbType.Int32, MenuItemId);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new spAllowedRoleMenusweb
                        spAllowedRoleMenusweb = new spAllowedRoleMenusweb();

                        // Read values.
                        spAllowedRoleMenusweb.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        spAllowedRoleMenusweb.RoleId = base.GetDataValue<int>(dr, "RoleId");
                        spAllowedRoleMenusweb.MenuItemId = base.GetDataValue<int>(dr, "MenuItemId");
                        spAllowedRoleMenusweb.Allowed = base.GetDataValue<bool>(dr, "Allowed");
                    }
                }
            }

            return spAllowedRoleMenusweb;
        }
    }
}