using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SBiPayrollWeb.Entities;

namespace SBiPayrollWeb.Data
{
    /// <summary>
    /// TechParams data access component. Manages CRUD operations for the TechParams table.
    /// </summary>
    public partial class TechParamDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the TechParams table.
        /// </summary>
        /// <param name="techParam">A TechParam object.</param>
        /// <returns>An updated TechParam object.</returns>
        public TechParam Create(TechParam techParam)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [TechParams] ([strtdt], [edc]) " +
                "VALUES(@strtdt, @edc); SELECT last_insert_rowid();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@strtdt", DbType.Date, techParam.strtdt);
                db.AddInParameter(cmd, "@edc", DbType.Int32, techParam.edc);

                // Get the primary key value.
                techParam.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return techParam;
        }

        /// <summary>
        /// Updates an existing row in the TechParams table.
        /// </summary>
        /// <param name="techParam">A TechParam entity object.</param>
        public void UpdateById(TechParam techParam)
        {
            const string SQL_STATEMENT =
                "UPDATE [TechParams] " +
                "SET " +
                    "[strtdt]=@strtdt, " +
                    "[edc]=@edc " +
                "WHERE [Id]=@Id ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@strtdt", DbType.Date, techParam.strtdt);
                db.AddInParameter(cmd, "@edc", DbType.Int32, techParam.edc);
                db.AddInParameter(cmd, "@Id", DbType.Int32, techParam.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the TechParams table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE FROM [TechParams] " +
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
        /// Returns a row from the TechParams table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A TechParam object with data populated from the database.</returns>
        public TechParam SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [strtdt], [edc] " +
                "FROM [TechParams] " +
                "WHERE [Id]=@Id ";

            TechParam techParam = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new TechParam
                        techParam = new TechParam();

                        // Read values.
                        techParam.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        techParam.strtdt = base.GetDataValue<DateTime>(dr, "strtdt");
                        techParam.edc = base.GetDataValue<int>(dr, "edc");
                    }
                }
            }

            return techParam;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the TechParams table.
        /// </summary>
        /// <returns>A collection of TechParam objects.</returns>		
        public List<TechParam> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [strtdt], [edc] " +
                "FROM [TechParams] ";

            List<TechParam> result = new List<TechParam>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new TechParam
                        TechParam techParam = new TechParam();

                        // Read values.
                        techParam.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        techParam.strtdt = base.GetDataValue<DateTime>(dr, "strtdt");
                        techParam.edc = base.GetDataValue<int>(dr, "edc");

                        // Add to List.
                        result.Add(techParam);
                    }
                }
            }

            return result;
        }
    }
}