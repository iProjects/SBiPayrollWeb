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
    /// webpages_UsersInRoles data access component. Manages CRUD operations for the webpages_UsersInRoles table.
    /// </summary>
    public partial class webpages_UsersInRoleDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the webpages_UsersInRoles table.
        /// </summary>
        /// <param name="webpages_UsersInRole">A webpages_UsersInRole object.</param>
        /// <returns>An updated webpages_UsersInRole object.</returns>
        public webpages_UsersInRole Create(webpages_UsersInRole webpages_UsersInRole)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [webpages_UsersInRoles] ([UserId], [RoleId]) " +
                "VALUES (@UserId, @RoleId);";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@UserId", DbType.Int32, webpages_UsersInRole.UserId);
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, webpages_UsersInRole.RoleId);

                db.ExecuteNonQuery(cmd);
            }

            return webpages_UsersInRole;
        }

        /// <summary>
        /// Updates an existing row in the webpages_UsersInRoles table.
        /// </summary>
        /// <param name="webpages_UsersInRole">A webpages_UsersInRole entity object.</param>
        public void UpdateById(webpages_UsersInRole webpages_UsersInRole)
        {
            const string SQL_STATEMENT =
                "UPDATE [webpages_UsersInRoles] " +
                "SET [UserId] = @UserId, [RoleId] = @RoleId " +
                "WHERE [UserId] = @UserId " +
                      "AND [RoleId] = @RoleId;";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@UserId", DbType.Int32, webpages_UsersInRole.UserId);
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, webpages_UsersInRole.RoleId);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the webpages_UsersInRoles table.
        /// </summary>
        /// <param name="userId">A userId value.</param>
        public void DeleteById(int userId)
        {
            const string SQL_STATEMENT = "DELETE FROM [webpages_UsersInRoles] " +
                                         "WHERE [UserId] = @UserId;";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@UserId", DbType.Int32, userId);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Returns a row from the webpages_UsersInRoles table.
        /// </summary>
        /// <param name="userId">A UserId value.</param>
        /// <param name="roleId">A RoleId value.</param>
        /// <returns>A webpages_UsersInRole object with data populated from the database.</returns>
        public webpages_UsersInRole SelectById(int userId, int roleId)
        {
            const string SQL_STATEMENT =
                "SELECT [UserId], [RoleId] " +
                "FROM [webpages_UsersInRoles] " +
                "WHERE [UserId] = @UserId " +
                      "AND [RoleId] = @RoleId;";

            webpages_UsersInRole webpages_UsersInRole = null;

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
                        // Create a new webpages_UsersInRole
                        webpages_UsersInRole = new webpages_UsersInRole();

                        // Read values.
                        webpages_UsersInRole.UserId = base.GetDataValue<int>(dr, "UserId");
                        webpages_UsersInRole.RoleId = base.GetDataValue<int>(dr, "RoleId");
                    }
                }
            }

            return webpages_UsersInRole;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the webpages_UsersInRoles table.
        /// </summary>
        /// <returns>A collection of webpages_UsersInRole objects.</returns>		
        public List<webpages_UsersInRole> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [UserId], [RoleId] " +
                "FROM [webpages_UsersInRoles];";

            List<webpages_UsersInRole> result = new List<webpages_UsersInRole>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new webpages_UsersInRole
                        webpages_UsersInRole webpages_UsersInRole = new webpages_UsersInRole();

                        // Read values.
                        webpages_UsersInRole.UserId = base.GetDataValue<int>(dr, "UserId");
                        webpages_UsersInRole.RoleId = base.GetDataValue<int>(dr, "RoleId");

                        // Add to List.
                        result.Add(webpages_UsersInRole);
                    }
                }
            }

            return result;
        }
    }
}

