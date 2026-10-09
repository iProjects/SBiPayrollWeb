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
        /// Inserts a new row in the spAllowedRoleMenus table.
        /// </summary>
        /// <param name="spAllowedRoleMenus">A spAllowedRoleMenus object.</param>
        /// <returns>An updated spAllowedRoleMenus object.</returns>
        public spAllowedRoleMenus Create(spAllowedRoleMenus spAllowedRoleMenus)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [spAllowedRoleMenus] ([RoleId], [MenuItemId], [Allowed]) " +
                "VALUES(@RoleId, @MenuItemId, @Allowed); SELECT last_insert_rowid();";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, spAllowedRoleMenus.RoleId);
                db.AddInParameter(cmd, "@MenuItemId", DbType.Int32, spAllowedRoleMenus.MenuItemId);
                db.AddInParameter(cmd, "@Allowed", DbType.Boolean, spAllowedRoleMenus.Allowed);

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
                "UPDATE [spAllowedRoleMenus] " +
                "SET " +
                    "[RoleId]=@RoleId, " +
                    "[MenuItemId]=@MenuItemId, " +
                    "[Allowed]=@Allowed " +
                "WHERE [Id]=@Id;";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
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
            const string SQL_STATEMENT = "DELETE FROM [spAllowedRoleMenus] WHERE [Id]=@Id;";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
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
                "FROM [spAllowedRoleMenus] " +
                "WHERE [Id]=@Id;";

            spAllowedRoleMenus spAllowedRoleMenus = null;

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        spAllowedRoleMenus = new spAllowedRoleMenus();

                        spAllowedRoleMenus.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
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
            const string SQL_STATEMENT =
                "SELECT [Id], [RoleId], [MenuItemId], [Allowed] " +
                "FROM [spAllowedRoleMenus];";

            List<spAllowedRoleMenus> result = new List<spAllowedRoleMenus>();

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        spAllowedRoleMenus spAllowedRoleMenus = new spAllowedRoleMenus();

                        spAllowedRoleMenus.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        spAllowedRoleMenus.RoleId = base.GetDataValue<int>(dr, "RoleId");
                        spAllowedRoleMenus.MenuItemId = base.GetDataValue<int>(dr, "MenuItemId");
                        spAllowedRoleMenus.Allowed = base.GetDataValue<bool>(dr, "Allowed");

                        result.Add(spAllowedRoleMenus);
                    }
                }
            }

            return result;
        }
    }
}
