//====================================================================================================
// Base code generated with Momentum: DAC Gen (Build 2.5.5049.15162)
// Layered Architecture Solution Guidance (http://layerguidance.codeplex.com)
//
// Generated by Administrator at SAPSERVER on 12/31/2014 17:33:56 
//====================================================================================================

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
    public partial class PayeeRateDAC : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the PayeeRates table.
        /// </summary>
        /// <param name="payeeRate">A PayeeRate object.</param>
        /// <returns>An updated PayeeRate object.</returns>
        public PayeeRate Create(PayeeRate payeeRate)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.PayeeRates ([FromAmt], [ToAmt], [Rate]) " +
                "VALUES(@FromAmt, @ToAmt, @Rate); SELECT SCOPE_IDENTITY();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@FromAmt", DbType.Currency, payeeRate.FromAmt);
                db.AddInParameter(cmd, "@ToAmt", DbType.Currency, payeeRate.ToAmt);
                db.AddInParameter(cmd, "@Rate", DbType.Currency, payeeRate.Rate);

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
                "UPDATE dbo.PayeeRates " +
                "SET " +
                    "[FromAmt]=@FromAmt, " +
                    "[ToAmt]=@ToAmt, " +
                    "[Rate]=@Rate " +
                "WHERE [Id]=@Id ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@FromAmt", DbType.Currency, payeeRate.FromAmt);
                db.AddInParameter(cmd, "@ToAmt", DbType.Currency, payeeRate.ToAmt);
                db.AddInParameter(cmd, "@Rate", DbType.Currency, payeeRate.Rate);
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
            const string SQL_STATEMENT = "DELETE dbo.PayeeRates " +
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
        /// Returns a row from the PayeeRates table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A PayeeRate object with data populated from the database.</returns>
        public PayeeRate SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [FromAmt], [ToAmt], [Rate] " +
                "FROM dbo.PayeeRates  " +
                "WHERE [Id]=@Id ";

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
                        payeeRate.Id = base.GetDataValue<int>(dr, "Id");
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
            // WARNING! The following SQL query does not contain a WHERE condition.
            // You are advised to include a WHERE condition to prevent any performance
            // issues when querying large resultsets.
            const string SQL_STATEMENT =
                "SELECT [Id], [FromAmt], [ToAmt], [Rate] " +
                "FROM dbo.PayeeRates ";

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
                        payeeRate.Id = base.GetDataValue<int>(dr, "Id");
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
