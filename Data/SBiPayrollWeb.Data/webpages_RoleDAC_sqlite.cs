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
    /// webpages_Roles data access component. Manages CRUD operations for the webpages_Roles table.
    /// </summary>
    public partial class webpages_RoleDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the webpages_Roles table.
        /// </summary>
        /// <param name="webpages_Role">A webpages_Role object.</param>
        /// <returns>An updated webpages_Role object.</returns>
        public webpages_Role Create(webpages_Role webpages_Role)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [webpages_Roles] ([RoleName]) " +
                "VALUES (@RoleName); SELECT last_insert_rowid();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@RoleName", DbType.String, webpages_Role.RoleName);

                // Get the primary key value.
                webpages_Role.RoleId = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return webpages_Role;
        }

        /// <summary>
        /// Updates an existing row in the webpages_Roles table.
        /// </summary>
        /// <param name="webpages_Role">A webpages_Role entity object.</param>
        public void UpdateById(webpages_Role webpages_Role)
        {
            const string SQL_STATEMENT =
                "UPDATE [webpages_Roles] " +
                "SET " +
                    "[RoleName] = @RoleName " +
                "WHERE [RoleId] = @RoleId;";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@RoleName", DbType.String, webpages_Role.RoleName);
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, webpages_Role.RoleId);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the webpages_Roles table.
        /// </summary>
        /// <param name="roleId">A roleId value.</param>
        public void DeleteById(int roleId)
        {
            const string SQL_STATEMENT = "DELETE FROM [webpages_Roles] " +
                                         "WHERE [RoleId] = @RoleId;";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, roleId);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Returns a row from the webpages_Roles table.
        /// </summary>
        /// <param name="roleId">A RoleId value.</param>
        /// <returns>A webpages_Role object with data populated from the database.</returns>
        public webpages_Role SelectById(int roleId)
        {
            const string SQL_STATEMENT =
                "SELECT [RoleId], [RoleName] " +
                "FROM [webpages_Roles] " +
                "WHERE [RoleId] = @RoleId;";

            webpages_Role webpages_Role = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, roleId);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new webpages_Role
                        webpages_Role = new webpages_Role();

                        // Read values.
                        webpages_Role.RoleId = base.GetDataValue<int>(dr, "RoleId");
                        webpages_Role.RoleName = base.GetDataValue<string>(dr, "RoleName");
                    }
                }
            }

            return webpages_Role;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the webpages_Roles table.
        /// </summary>
        /// <returns>A collection of webpages_Role objects.</returns>		
        public List<webpages_Role> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [RoleId], [RoleName] " +
                "FROM [webpages_Roles];";

            List<webpages_Role> result = new List<webpages_Role>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new webpages_Role
                        webpages_Role webpages_Role = new webpages_Role();

                        // Read values.
                        webpages_Role.RoleId = base.GetDataValue<int>(dr, "RoleId");
                        webpages_Role.RoleName = base.GetDataValue<string>(dr, "RoleName");

                        // Add to List.
                        result.Add(webpages_Role);
                    }
                }
            }

            return result;
        }
    }
}
