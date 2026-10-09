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
    /// PayeeRates data access component. Manages CRUD operations for the PayeeRates table.
    /// </summary>
    public partial class PayeeRateDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the PayeeRates table.
        /// </summary>
        /// <param name="payeeRate">A PayeeRate object.</param>
        /// <returns>An updated PayeeRate object.</returns>
        public PayeeRate Create(PayeeRate payeeRate)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [PayeeRates] ([FromAmt], [ToAmt], [Rate]) " +
                "VALUES(@FromAmt, @ToAmt, @Rate); SELECT last_insert_rowid();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@FromAmt", DbType.Decimal, payeeRate.FromAmt);
                db.AddInParameter(cmd, "@ToAmt", DbType.Decimal, payeeRate.ToAmt);
                db.AddInParameter(cmd, "@Rate", DbType.Decimal, payeeRate.Rate);

                // Get the primary key value.
                payeeRate.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return payeeRate;
        }

        /// <summary>
        /// Updates an existing row in the PayeeRates table.
        /// </summary>
        /// <param name="payeeRate">A PayeeRate entity object.</param>
        public void UpdateById(PayeeRate payeeRate)
        {
            const string SQL_STATEMENT =
                "UPDATE [PayeeRates] " +
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
                db.AddInParameter(cmd, "@FromAmt", DbType.Decimal, payeeRate.FromAmt);
                db.AddInParameter(cmd, "@ToAmt", DbType.Decimal, payeeRate.ToAmt);
                db.AddInParameter(cmd, "@Rate", DbType.Decimal, payeeRate.Rate);
                db.AddInParameter(cmd, "@Id", DbType.Int32, payeeRate.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the PayeeRates table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE FROM [PayeeRates] " +
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
        /// Returns a row from the PayeeRates table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A PayeeRate object with data populated from the database.</returns>
        public PayeeRate SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [FromAmt], [ToAmt], [Rate] " +
                "FROM [PayeeRates] " +
                "WHERE [Id]=@Id;";

            PayeeRate payeeRate = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new PayeeRate
                        payeeRate = new PayeeRate();

                        // Read values.
                        payeeRate.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        payeeRate.FromAmt = base.GetDataValue<decimal>(dr, "FromAmt");
                        payeeRate.ToAmt = base.GetDataValue<decimal>(dr, "ToAmt");
                        payeeRate.Rate = base.GetDataValue<decimal>(dr, "Rate");
                    }
                }
            }

            return payeeRate;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the PayeeRates table.
        /// </summary>
        /// <returns>A collection of PayeeRate objects.</returns>		
        public List<PayeeRate> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [FromAmt], [ToAmt], [Rate] " +
                "FROM [PayeeRates];";

            List<PayeeRate> result = new List<PayeeRate>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new PayeeRate
                        PayeeRate payeeRate = new PayeeRate();

                        // Read values.
                        payeeRate.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        payeeRate.FromAmt = base.GetDataValue<decimal>(dr, "FromAmt");
                        payeeRate.ToAmt = base.GetDataValue<decimal>(dr, "ToAmt");
                        payeeRate.Rate = base.GetDataValue<decimal>(dr, "Rate");

                        // Add to List.
                        result.Add(payeeRate);
                    }
                }
            }

            return result;
        }
    }
}