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
    /// PackedTransactions data access component. Manages CRUD operations for the PackedTransactions table.
    /// </summary>
    public partial class PackedTransactionDAC : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the PackedTransactions table.
        /// </summary>
        /// <param name="packedTransaction">A PackedTransaction object.</param>
        /// <returns>An updated PackedTransaction object.</returns>
        public PackedTransaction Create(PackedTransaction packedTransaction)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.PackedTransactions ([PackDate], [EmpNo], [EmployeeId], [TxnCode], [Amount], [CreatedBy], [Authorized]) " +
                "VALUES(@PackDate, @EmpNo, @EmployeeId, @TxnCode, @Amount, @CreatedBy, @Authorized); SELECT SCOPE_IDENTITY();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@PackDate", DbType.DateTime, packedTransaction.PackDate);
                db.AddInParameter(cmd, "@EmpNo", DbType.StringFixedLength, packedTransaction.EmpNo);
                db.AddInParameter(cmd, "@EmployeeId", DbType.Int32, packedTransaction.EmployeeId);
                db.AddInParameter(cmd, "@TxnCode", DbType.StringFixedLength, packedTransaction.TxnCode);
                db.AddInParameter(cmd, "@Amount", DbType.Currency, packedTransaction.Amount);
                db.AddInParameter(cmd, "@CreatedBy", DbType.String, packedTransaction.CreatedBy);
                db.AddInParameter(cmd, "@Authorized", DbType.Boolean, packedTransaction.Authorized);

                // Get the primary key value.
                packedTransaction.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return packedTransaction;
        }

        /// <summary>
        /// Updates an existing row in the PackedTransactions table.
        /// </summary>
        /// <param name="packedTransaction">A PackedTransaction entity object.</param>
        public void UpdateById(PackedTransaction packedTransaction)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.PackedTransactions " +
                "SET " +
                    "[PackDate]=@PackDate, " +
                    "[EmpNo]=@EmpNo, " +
                    "[EmployeeId]=@EmployeeId, " +
                    "[TxnCode]=@TxnCode, " +
                    "[Amount]=@Amount, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[Authorized]=@Authorized " +
                "WHERE [Id]=@Id ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@PackDate", DbType.DateTime, packedTransaction.PackDate);
                db.AddInParameter(cmd, "@EmpNo", DbType.StringFixedLength, packedTransaction.EmpNo);
                db.AddInParameter(cmd, "@EmployeeId", DbType.Int32, packedTransaction.EmployeeId);
                db.AddInParameter(cmd, "@TxnCode", DbType.StringFixedLength, packedTransaction.TxnCode);
                db.AddInParameter(cmd, "@Amount", DbType.Currency, packedTransaction.Amount);
                db.AddInParameter(cmd, "@CreatedBy", DbType.String, packedTransaction.CreatedBy);
                db.AddInParameter(cmd, "@Authorized", DbType.Boolean, packedTransaction.Authorized);
                db.AddInParameter(cmd, "@Id", DbType.Int32, packedTransaction.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the PackedTransactions table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.PackedTransactions " +
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
        /// Returns a row from the PackedTransactions table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A PackedTransaction object with data populated from the database.</returns>
        public PackedTransaction SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [PackDate], [EmpNo], [EmployeeId], [TxnCode], [Amount], [CreatedBy], [Authorized]" +
                        " " +
                "FROM dbo.PackedTransactions  " +
                "WHERE [Id]=@Id ";

            PackedTransaction packedTransaction = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new PackedTransaction
                        packedTransaction = new PackedTransaction();

                        // Read values.
                        packedTransaction.Id = base.GetDataValue<int>(dr, "Id");
                        packedTransaction.PackDate = base.GetDataValue<DateTime>(dr, "PackDate");
                        packedTransaction.EmpNo = base.GetDataValue<string>(dr, "EmpNo");
                        packedTransaction.EmployeeId = base.GetDataValue<int>(dr, "EmployeeId");
                        packedTransaction.TxnCode = base.GetDataValue<string>(dr, "TxnCode");
                        packedTransaction.Amount = base.GetDataValue<decimal>(dr, "Amount");
                        packedTransaction.CreatedBy = base.GetDataValue<string>(dr, "CreatedBy");
                        packedTransaction.Authorized = base.GetDataValue<bool>(dr, "Authorized");
                    }
                }
            }

            return packedTransaction;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the PackedTransactions table.
        /// </summary>
        /// <returns>A collection of PackedTransaction objects.</returns>		
        public List<PackedTransaction> Select()
        {
            // WARNING! The following SQL query does not contain a WHERE condition.
            // You are advised to include a WHERE condition to prevent any performance
            // issues when querying large resultsets.
            const string SQL_STATEMENT =
                "SELECT [Id], [PackDate], [EmpNo], [EmployeeId], [TxnCode], [Amount], [CreatedBy], [Authorized]" +
                        " " +
                "FROM dbo.PackedTransactions ";

            List<PackedTransaction> result = new List<PackedTransaction>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new PackedTransaction
                        PackedTransaction packedTransaction = new PackedTransaction();

                        // Read values.
                        packedTransaction.Id = base.GetDataValue<int>(dr, "Id");
                        packedTransaction.PackDate = base.GetDataValue<DateTime>(dr, "PackDate");
                        packedTransaction.EmpNo = base.GetDataValue<string>(dr, "EmpNo");
                        packedTransaction.EmployeeId = base.GetDataValue<int>(dr, "EmployeeId");
                        packedTransaction.TxnCode = base.GetDataValue<string>(dr, "TxnCode");
                        packedTransaction.Amount = base.GetDataValue<decimal>(dr, "Amount");
                        packedTransaction.CreatedBy = base.GetDataValue<string>(dr, "CreatedBy");
                        packedTransaction.Authorized = base.GetDataValue<bool>(dr, "Authorized");

                        // Add to List.
                        result.Add(packedTransaction);
                    }
                }
            }

            return result;
        }
    }
}

