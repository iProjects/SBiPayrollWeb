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
        /// Inserts a new row in the spAllowedRoleMenusweb table.
        /// </summary>
        /// <param name="spAllowedRoleMenusweb">A spAllowedRoleMenusweb object.</param>
        /// <returns>An updated spAllowedRoleMenusweb object.</returns>
        public spAllowedRoleMenusweb Create(spAllowedRoleMenusweb spAllowedRoleMenusweb)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [spAllowedRoleMenusweb] ([RoleId], [MenuItemId], [Allowed]) " +
                "VALUES(@RoleId, @MenuItemId, @Allowed); SELECT last_insert_rowid();";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, spAllowedRoleMenusweb.RoleId);
                db.AddInParameter(cmd, "@MenuItemId", DbType.Int32, spAllowedRoleMenusweb.MenuItemId);
                db.AddInParameter(cmd, "@Allowed", DbType.Boolean, spAllowedRoleMenusweb.Allowed);

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
                "UPDATE [spAllowedRoleMenusweb] " +
                "SET " +
                    "[RoleId]=@RoleId, " +
                    "[MenuItemId]=@MenuItemId, " +
                    "[Allowed]=@Allowed " +
                "WHERE [Id]=@Id;";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
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
            const string SQL_STATEMENT = "DELETE FROM [spAllowedRoleMenusweb] WHERE [Id]=@Id;";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
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
                "FROM [spAllowedRoleMenusweb] " +
                "WHERE [Id]=@Id;";

            spAllowedRoleMenusweb spAllowedRoleMenusweb = null;

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        spAllowedRoleMenusweb = new spAllowedRoleMenusweb();

                        spAllowedRoleMenusweb.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
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
            const string SQL_STATEMENT =
                "SELECT [Id], [RoleId], [MenuItemId], [Allowed] " +
                "FROM [spAllowedRoleMenusweb];";

            List<spAllowedRoleMenusweb> result = new List<spAllowedRoleMenusweb>();

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        spAllowedRoleMenusweb spAllowedRoleMenusweb = new spAllowedRoleMenusweb();

                        spAllowedRoleMenusweb.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        spAllowedRoleMenusweb.RoleId = base.GetDataValue<int>(dr, "RoleId");
                        spAllowedRoleMenusweb.MenuItemId = base.GetDataValue<int>(dr, "MenuItemId");
                        spAllowedRoleMenusweb.Allowed = base.GetDataValue<bool>(dr, "Allowed");

                        result.Add(spAllowedRoleMenusweb);
                    }
                }
            }

            return result;
        }
    }
}