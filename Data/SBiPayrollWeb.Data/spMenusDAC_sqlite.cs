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
    /// spMenus data access component. Manages CRUD operations for the spMenus table.
    /// </summary>
    public partial class spMenusDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the spMenus table.
        /// </summary>
        /// <param name="spMenus">A spMenus object.</param>
        /// <returns>An updated spMenus object.</returns>
        public spMenus Create(spMenus spMenus)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [spMenus] ([mnuName], [Description]) " +
                "VALUES(@mnuName, @Description); SELECT last_insert_rowid();";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@mnuName", DbType.String, spMenus.mnuName);
                db.AddInParameter(cmd, "@Description", DbType.String, spMenus.Description);

                spMenus.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return spMenus;
        }

        /// <summary>
        /// Updates an existing row in the spMenus table.
        /// </summary>
        /// <param name="spMenus">A spMenus entity object.</param>
        public void UpdateById(spMenus spMenus)
        {
            const string SQL_STATEMENT =
                "UPDATE [spMenus] " +
                "SET " +
                    "[mnuName]=@mnuName, " +
                    "[Description]=@Description " +
                "WHERE [Id]=@Id;";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@mnuName", DbType.String, spMenus.mnuName);
                db.AddInParameter(cmd, "@Description", DbType.String, spMenus.Description);
                db.AddInParameter(cmd, "@Id", DbType.Int32, spMenus.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the spMenus table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE FROM [spMenus] WHERE [Id]=@Id;";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Returns a row from the spMenus table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A spMenus object with data populated from the database.</returns>
        public spMenus SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [mnuName], [Description] " +
                "FROM [spMenus] " +
                "WHERE [Id]=@Id;";

            spMenus spMenus = null;

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        spMenus = new spMenus();

                        spMenus.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        spMenus.mnuName = base.GetDataValue<string>(dr, "mnuName");
                        spMenus.Description = base.GetDataValue<string>(dr, "Description");
                    }
                }
            }

            return spMenus;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the spMenus table.
        /// </summary>
        /// <returns>A collection of spMenus objects.</returns>		
        public List<spMenus> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [mnuName], [Description] " +
                "FROM [spMenus];";

            List<spMenus> result = new List<spMenus>();

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        spMenus spMenus = new spMenus();

                        spMenus.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        spMenus.mnuName = base.GetDataValue<string>(dr, "mnuName");
                        spMenus.Description = base.GetDataValue<string>(dr, "Description");

                        result.Add(spMenus);
                    }
                }
            }

            return result;
        }
    }
}
