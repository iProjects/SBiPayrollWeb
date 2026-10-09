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
    /// spMenuItems data access component. Manages CRUD operations for the spMenuItems table.
    /// </summary>
    public partial class spMenuItemDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the spMenuItems table.
        /// </summary>
        /// <param name="spMenuItem">A spMenuItem object.</param>
        /// <returns>An updated spMenuItem object.</returns>
        public spMenuItem Create(spMenuItem spMenuItem)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [spMenuItems] ([mnuName], [Description]) " +
                "VALUES(@mnuName, @Description); SELECT last_insert_rowid();";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@mnuName", DbType.String, spMenuItem.mnuName);
                db.AddInParameter(cmd, "@Description", DbType.String, spMenuItem.Description);

                spMenuItem.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return spMenuItem;
        }

        /// <summary>
        /// Updates an existing row in the spMenuItems table.
        /// </summary>
        /// <param name="spMenuItem">A spMenuItem entity object.</param>
        public void UpdateById(spMenuItem spMenuItem)
        {
            const string SQL_STATEMENT =
                "UPDATE [spMenuItems] " +
                "SET " +
                    "[mnuName]=@mnuName, " +
                    "[Description]=@Description " +
                "WHERE [Id]=@Id;";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@mnuName", DbType.String, spMenuItem.mnuName);
                db.AddInParameter(cmd, "@Description", DbType.String, spMenuItem.Description);
                db.AddInParameter(cmd, "@Id", DbType.Int32, spMenuItem.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the spMenuItems table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE FROM [spMenuItems] WHERE [Id]=@Id;";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Returns a row from the spMenuItems table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A spMenuItem object with data populated from the database.</returns>
        public spMenuItem SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [mnuName], [Description] " +
                "FROM [spMenuItems] " +
                "WHERE [Id]=@Id;";

            spMenuItem spMenuItem = null;

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        spMenuItem = new spMenuItem();

                        spMenuItem.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        spMenuItem.mnuName = base.GetDataValue<string>(dr, "mnuName");
                        spMenuItem.Description = base.GetDataValue<string>(dr, "Description");
                    }
                }
            }

            return spMenuItem;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the spMenuItems table.
        /// </summary>
        /// <returns>A collection of spMenuItem objects.</returns>		
        public List<spMenuItem> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [mnuName], [Description] " +
                "FROM [spMenuItems];";

            List<spMenuItem> result = new List<spMenuItem>();

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        spMenuItem spMenuItem = new spMenuItem();

                        spMenuItem.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        spMenuItem.mnuName = base.GetDataValue<string>(dr, "mnuName");
                        spMenuItem.Description = base.GetDataValue<string>(dr, "Description");

                        result.Add(spMenuItem);
                    }
                }
            }

            return result;
        }
    }
}