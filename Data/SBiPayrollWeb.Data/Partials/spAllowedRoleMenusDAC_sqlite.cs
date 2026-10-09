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
    /// spAllowedRoleMenus data access component. Manages CRUD operations for the spAllowedRoleMenus table.
    /// </summary>
    public partial class spAllowedRoleMenusDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Returns a row from the spAllowedRoleMenus table.
        /// </summary>
        /// <param name="RoleId">A RoleId value.</param>
        /// <param name="MenuItemId">A MenuItemId value.</param>
        /// <returns>A spAllowedRoleMenus object with data populated from the database.</returns>
        public spAllowedRoleMenus SelectRight(int RoleId, int MenuItemId)
        {
            const string SQL_STATEMENT =
                "SELECT * " +
                "FROM [spAllowedRoleMenus] " +
                "WHERE [RoleId] = @RoleId " +
                      "AND [MenuItemId] = @MenuItemId;";

            spAllowedRoleMenus spAllowedRoleMenus = null;

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
                        // Create a new spAllowedRoleMenus
                        spAllowedRoleMenus = new spAllowedRoleMenus();

                        // Read values.
                        spAllowedRoleMenus.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        spAllowedRoleMenus.RoleId = base.GetDataValue<int>(dr, "RoleId");
                        spAllowedRoleMenus.MenuItemId = base.GetDataValue<int>(dr, "MenuItemId");
                        spAllowedRoleMenus.Allowed = base.GetDataValue<bool>(dr, "Allowed");
                    }
                }
            }

            return spAllowedRoleMenus;
        }
    }
}