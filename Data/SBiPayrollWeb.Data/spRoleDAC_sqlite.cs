using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SBiPayrollWeb.Entities;

namespace SBiPayrollWeb.Data
{
    /// <summary>
    /// spRoles data access component. Manages CRUD operations for the spRoles table.
    /// </summary>
    public partial class spRoleDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the spRoles table.
        /// </summary>
        /// <param name="spRole">A spRole object.</param>
        /// <returns>An updated spRole object.</returns>
        public spRole Create(spRole spRole)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [spRoles] ([ShortCode], [Description], [IsDeleted]) " +
                "VALUES(@ShortCode, @Description, @IsDeleted); SELECT last_insert_rowid();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@ShortCode", DbType.String, spRole.ShortCode);
                db.AddInParameter(cmd, "@Description", DbType.String, spRole.Description);
                db.AddInParameter(cmd, "@IsDeleted", DbType.Boolean, spRole.IsDeleted);

                // Get the primary key value.
                spRole.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return spRole;
        }

        /// <summary>
        /// Updates an existing row in the spRoles table.
        /// </summary>
        /// <param name="spRole">A spRole entity object.</param>
        public void UpdateById(spRole spRole)
        {
            const string SQL_STATEMENT =
                "UPDATE [spRoles] " +
                "SET " +
                    "[ShortCode]=@ShortCode, " +
                    "[Description]=@Description, " +
                    "[IsDeleted]=@IsDeleted " +
                "WHERE [Id]=@Id ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@ShortCode", DbType.String, spRole.ShortCode);
                db.AddInParameter(cmd, "@Description", DbType.String, spRole.Description);
                db.AddInParameter(cmd, "@IsDeleted", DbType.Boolean, spRole.IsDeleted);
                db.AddInParameter(cmd, "@Id", DbType.Int32, spRole.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the spRoles table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE FROM [spRoles] " +
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
        /// Returns a row from the spRoles table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A spRole object with data populated from the database.</returns>
        public spRole SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [ShortCode], [Description], [IsDeleted] " +
                "FROM [spRoles] " +
                "WHERE [Id]=@Id ";

            spRole spRole = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new spRole
                        spRole = new spRole();

                        // Read values.
                        spRole.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        spRole.ShortCode = base.GetDataValue<string>(dr, "ShortCode");
                        spRole.Description = base.GetDataValue<string>(dr, "Description");
                        spRole.IsDeleted = base.GetDataValue<bool>(dr, "IsDeleted");
                    }
                }
            }

            return spRole;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the spRoles table.
        /// </summary>
        /// <returns>A collection of spRole objects.</returns>		
        public List<spRole> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [ShortCode], [Description], [IsDeleted] " +
                "FROM [spRoles] ";

            List<spRole> result = new List<spRole>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new spRole
                        spRole spRole = new spRole();

                        // Read values.
                        spRole.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        spRole.ShortCode = base.GetDataValue<string>(dr, "ShortCode");
                        spRole.Description = base.GetDataValue<string>(dr, "Description");
                        spRole.IsDeleted = base.GetDataValue<bool>(dr, "IsDeleted");

                        // Add to List.
                        result.Add(spRole);
                    }
                }
            }

            return result;
        }
    }
}