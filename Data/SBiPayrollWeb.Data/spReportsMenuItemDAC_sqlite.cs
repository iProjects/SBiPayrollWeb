using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SBiPayrollWeb.Entities;

namespace SBiPayrollWeb.Data
{
    /// <summary>
    /// spReportsMenuItems data access component. Manages CRUD operations for the spReportsMenuItems table.
    /// </summary>
    public partial class spReportsMenuItemDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the spReportsMenuItems table.
        /// </summary>
        /// <param name="spReportsMenuItem">A spReportsMenuItem object.</param>
        /// <returns>An updated spReportsMenuItem object.</returns>
        public spReportsMenuItem Create(spReportsMenuItem spReportsMenuItem)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [spReportsMenuItems] ([mnuName], [Description]) " +
                "VALUES(@mnuName, @Description); SELECT last_insert_rowid();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@mnuName", DbType.String, spReportsMenuItem.mnuName);
                db.AddInParameter(cmd, "@Description", DbType.String, spReportsMenuItem.Description);

                // Get the primary key value.
                spReportsMenuItem.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return spReportsMenuItem;
        }

        /// <summary>
        /// Updates an existing row in the spReportsMenuItems table.
        /// </summary>
        /// <param name="spReportsMenuItem">A spReportsMenuItem entity object.</param>
        public void UpdateById(spReportsMenuItem spReportsMenuItem)
        {
            const string SQL_STATEMENT =
                "UPDATE [spReportsMenuItems] " +
                "SET " +
                    "[mnuName]=@mnuName, " +
                    "[Description]=@Description " +
                "WHERE [Id]=@Id ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@mnuName", DbType.String, spReportsMenuItem.mnuName);
                db.AddInParameter(cmd, "@Description", DbType.String, spReportsMenuItem.Description);
                db.AddInParameter(cmd, "@Id", DbType.Int32, spReportsMenuItem.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the spReportsMenuItems table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE FROM [spReportsMenuItems] " +
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
        /// Returns a row from the spReportsMenuItems table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A spReportsMenuItem object with data populated from the database.</returns>
        public spReportsMenuItem SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [mnuName], [Description] " +
                "FROM [spReportsMenuItems] " +
                "WHERE [Id]=@Id ";

            spReportsMenuItem spReportsMenuItem = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new spReportsMenuItem
                        spReportsMenuItem = new spReportsMenuItem();

                        // Read values.
                        spReportsMenuItem.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        spReportsMenuItem.mnuName = base.GetDataValue<string>(dr, "mnuName");
                        spReportsMenuItem.Description = base.GetDataValue<string>(dr, "Description");
                    }
                }
            }

            return spReportsMenuItem;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the spReportsMenuItems table.
        /// </summary>
        /// <returns>A collection of spReportsMenuItem objects.</returns>		
        public List<spReportsMenuItem> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [mnuName], [Description] " +
                "FROM [spReportsMenuItems] ";

            List<spReportsMenuItem> result = new List<spReportsMenuItem>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new spReportsMenuItem
                        spReportsMenuItem spReportsMenuItem = new spReportsMenuItem();

                        // Read values.
                        spReportsMenuItem.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        spReportsMenuItem.mnuName = base.GetDataValue<string>(dr, "mnuName");
                        spReportsMenuItem.Description = base.GetDataValue<string>(dr, "Description");

                        // Add to List.
                        result.Add(spReportsMenuItem);
                    }
                }
            }

            return result;
        }
    }
}