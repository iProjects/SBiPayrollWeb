using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SBiPayrollWeb.Entities;

namespace SBiPayrollWeb.Data
{
    /// <summary>
    /// NHIFRates data access component. Manages CRUD operations for the NHIFRates table.
    /// </summary>
    public partial class NHIFRateDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the NHIFRates table.
        /// </summary>
        /// <param name="nHIFRate">A NHIFRate object.</param>
        /// <returns>An updated NHIFRate object.</returns>
        public NHIFRate Create(NHIFRate nHIFRate)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [NHIFRates] ([FromAmt], [ToAmt], [Rate]) " +
                "VALUES(@FromAmt, @ToAmt, @Rate); SELECT last_insert_rowid();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@FromAmt", DbType.Decimal, nHIFRate.FromAmt);
                db.AddInParameter(cmd, "@ToAmt", DbType.Decimal, nHIFRate.ToAmt);
                db.AddInParameter(cmd, "@Rate", DbType.Decimal, nHIFRate.Rate);

                // Get the primary key value.
                nHIFRate.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return nHIFRate;
        }

        /// <summary>
        /// Updates an existing row in the NHIFRates table.
        /// </summary>
        /// <param name="nHIFRate">A NHIFRate entity object.</param>
        public void UpdateById(NHIFRate nHIFRate)
        {
            const string SQL_STATEMENT =
                "UPDATE [NHIFRates] " +
                "SET " +
                    "[FromAmt]=@FromAmt, " +
                    "[ToAmt]=@ToAmt, " +
                    "[Rate]=@Rate " +
                "WHERE [Id]=@Id;";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@FromAmt", DbType.Decimal, nHIFRate.FromAmt);
                db.AddInParameter(cmd, "@ToAmt", DbType.Decimal, nHIFRate.ToAmt);
                db.AddInParameter(cmd, "@Rate", DbType.Decimal, nHIFRate.Rate);
                db.AddInParameter(cmd, "@Id", DbType.Int32, nHIFRate.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the NHIFRates table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE FROM [NHIFRates] " +
                                         "WHERE [Id]=@Id;";

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
        /// Returns a row from the NHIFRates table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A NHIFRate object with data populated from the database.</returns>
        public NHIFRate SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [FromAmt], [ToAmt], [Rate] " +
                "FROM [NHIFRates] " +
                "WHERE [Id]=@Id;";

            NHIFRate nHIFRate = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new NHIFRate
                        nHIFRate = new NHIFRate();

                        // Read values.
                        nHIFRate.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        nHIFRate.FromAmt = base.GetDataValue<decimal>(dr, "FromAmt");
                        nHIFRate.ToAmt = base.GetDataValue<decimal>(dr, "ToAmt");
                        nHIFRate.Rate = base.GetDataValue<decimal>(dr, "Rate");
                    }
                }
            }

            return nHIFRate;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the NHIFRates table.
        /// </summary>
        /// <returns>A collection of NHIFRate objects.</returns>		
        public List<NHIFRate> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [FromAmt], [ToAmt], [Rate] " +
                "FROM [NHIFRates];";

            List<NHIFRate> result = new List<NHIFRate>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new NHIFRate
                        NHIFRate nHIFRate = new NHIFRate();

                        // Read values.
                        nHIFRate.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        nHIFRate.FromAmt = base.GetDataValue<decimal>(dr, "FromAmt");
                        nHIFRate.ToAmt = base.GetDataValue<decimal>(dr, "ToAmt");
                        nHIFRate.Rate = base.GetDataValue<decimal>(dr, "Rate");

                        // Add to List.
                        result.Add(nHIFRate);
                    }
                }
            }

            return result;
        }
    }
}
