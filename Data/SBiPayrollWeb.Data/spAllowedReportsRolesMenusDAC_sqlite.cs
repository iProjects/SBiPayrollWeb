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
    /// spAllowedReportsRolesMenus data access component. Manages CRUD operations for the spAllowedReportsRolesMenus table.
    /// </summary>
    public partial class spAllowedReportsRolesMenusDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the spAllowedReportsRolesMenus table.
        /// </summary>
        /// <param name="spAllowedReportsRolesMenus">A spAllowedReportsRolesMenus object.</param>
        /// <returns>An updated spAllowedReportsRolesMenus object.</returns>
        public spAllowedReportsRolesMenus Create(spAllowedReportsRolesMenus spAllowedReportsRolesMenus)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [spAllowedReportsRolesMenus] ([RoleId], [MenuItemId], [Allowed]) " +
                "VALUES(@RoleId, @MenuItemId, @Allowed); SELECT last_insert_rowid();";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, spAllowedReportsRolesMenus.RoleId);
                db.AddInParameter(cmd, "@MenuItemId", DbType.Int32, spAllowedReportsRolesMenus.MenuItemId);
                db.AddInParameter(cmd, "@Allowed", DbType.Boolean, spAllowedReportsRolesMenus.Allowed);

                spAllowedReportsRolesMenus.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return spAllowedReportsRolesMenus;
        }

        /// <summary>
        /// Updates an existing row in the spAllowedReportsRolesMenus table.
        /// </summary>
        /// <param name="spAllowedReportsRolesMenus">A spAllowedReportsRolesMenus entity object.</param>
        public void UpdateById(spAllowedReportsRolesMenus spAllowedReportsRolesMenus)
        {
            const string SQL_STATEMENT =
                "UPDATE [spAllowedReportsRolesMenus] " +
                "SET " +
                    "[RoleId]=@RoleId, " +
                    "[MenuItemId]=@MenuItemId, " +
                    "[Allowed]=@Allowed " +
                "WHERE [Id]=@Id;";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, spAllowedReportsRolesMenus.RoleId);
                db.AddInParameter(cmd, "@MenuItemId", DbType.Int32, spAllowedReportsRolesMenus.MenuItemId);
                db.AddInParameter(cmd, "@Allowed", DbType.Boolean, spAllowedReportsRolesMenus.Allowed);
                db.AddInParameter(cmd, "@Id", DbType.Int32, spAllowedReportsRolesMenus.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the spAllowedReportsRolesMenus table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE FROM [spAllowedReportsRolesMenus] WHERE [Id]=@Id;";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Returns a row from the spAllowedReportsRolesMenus table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A spAllowedReportsRolesMenus object with data populated from the database.</returns>
        public spAllowedReportsRolesMenus SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [RoleId], [MenuItemId], [Allowed] " +
                "FROM [spAllowedReportsRolesMenus] " +
                "WHERE [Id]=@Id;";

            spAllowedReportsRolesMenus spAllowedReportsRolesMenus = null;

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        spAllowedReportsRolesMenus = new spAllowedReportsRolesMenus();

                        spAllowedReportsRolesMenus.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        spAllowedReportsRolesMenus.RoleId = base.GetDataValue<int>(dr, "RoleId");
                        spAllowedReportsRolesMenus.MenuItemId = base.GetDataValue<int>(dr, "MenuItemId");
                        spAllowedReportsRolesMenus.Allowed = base.GetDataValue<bool>(dr, "Allowed");
                    }
                }
            }

            return spAllowedReportsRolesMenus;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the spAllowedReportsRolesMenus table.
        /// </summary>
        /// <returns>A collection of spAllowedReportsRolesMenus objects.</returns>		
        public List<spAllowedReportsRolesMenus> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [RoleId], [MenuItemId], [Allowed] " +
                "FROM [spAllowedReportsRolesMenus];";

            List<spAllowedReportsRolesMenus> result = new List<spAllowedReportsRolesMenus>();

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        spAllowedReportsRolesMenus spAllowedReportsRolesMenus = new spAllowedReportsRolesMenus();

                        spAllowedReportsRolesMenus.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        spAllowedReportsRolesMenus.RoleId = base.GetDataValue<int>(dr, "RoleId");
                        spAllowedReportsRolesMenus.MenuItemId = base.GetDataValue<int>(dr, "MenuItemId");
                        spAllowedReportsRolesMenus.Allowed = base.GetDataValue<bool>(dr, "Allowed");

                        result.Add(spAllowedReportsRolesMenus);
                    }
                }
            }

            return result;
        }
    }
}
