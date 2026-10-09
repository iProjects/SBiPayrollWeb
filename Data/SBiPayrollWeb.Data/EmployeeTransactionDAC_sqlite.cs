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
    /// EmployeeTransactions data access component. Manages CRUD operations for the EmployeeTransactions table.
    /// </summary>
    public partial class EmployeeTransactionDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the EmployeeTransactions table.
        /// </summary>
        /// <param name="employeeTransaction">A EmployeeTransaction object.</param>
        /// <returns>An updated EmployeeTransaction object.</returns>
        public EmployeeTransaction Create(EmployeeTransaction employeeTransaction)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [EmployeeTransactions] ([PostDate], [EmpNo], [EmployeeId], [Enabled], [Recurrent], [ItemId], [Amount], [Balance], [InitialAmount], [Processed], [TrackYTD], [ShowYTDInPayslip], [CreatedBy], [LastChangedBy], [LastChangeDate], [AuthorizedBy], [AuthorizeDate], [LoanType], [AccumulativePayment]) " +
                "VALUES(@PostDate, @EmpNo, @EmployeeId, @Enabled, @Recurrent, @ItemId, @Amount, @Balance, @InitialAmount, @Processed, @TrackYTD, @ShowYTDInPayslip, @CreatedBy, @LastChangedBy, @LastChangeDate, @AuthorizedBy, @AuthorizeDate, @LoanType, @AccumulativePayment); SELECT last_insert_rowid();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@PostDate", DbType.DateTime, employeeTransaction.PostDate);
                db.AddInParameter(cmd, "@EmpNo", DbType.String, employeeTransaction.EmpNo);
                db.AddInParameter(cmd, "@EmployeeId", DbType.Int32, employeeTransaction.EmployeeId);
                db.AddInParameter(cmd, "@Enabled", DbType.Boolean, employeeTransaction.Enabled);
                db.AddInParameter(cmd, "@Recurrent", DbType.Boolean, employeeTransaction.Recurrent);
                db.AddInParameter(cmd, "@ItemId", DbType.String, employeeTransaction.ItemId);
                db.AddInParameter(cmd, "@Amount", DbType.Decimal, employeeTransaction.Amount);
                db.AddInParameter(cmd, "@Balance", DbType.Decimal, employeeTransaction.Balance);
                db.AddInParameter(cmd, "@InitialAmount", DbType.Decimal, employeeTransaction.InitialAmount);
                db.AddInParameter(cmd, "@Processed", DbType.Boolean, employeeTransaction.Processed);
                db.AddInParameter(cmd, "@TrackYTD", DbType.Boolean, employeeTransaction.TrackYTD);
                db.AddInParameter(cmd, "@ShowYTDInPayslip", DbType.Boolean, employeeTransaction.ShowYTDInPayslip);
                db.AddInParameter(cmd, "@CreatedBy", DbType.String, employeeTransaction.CreatedBy);
                db.AddInParameter(cmd, "@LastChangedBy", DbType.String, employeeTransaction.LastChangedBy);
                db.AddInParameter(cmd, "@LastChangeDate", DbType.DateTime, employeeTransaction.LastChangeDate);
                db.AddInParameter(cmd, "@AuthorizedBy", DbType.String, employeeTransaction.AuthorizedBy);
                db.AddInParameter(cmd, "@AuthorizeDate", DbType.DateTime, employeeTransaction.AuthorizeDate);
                db.AddInParameter(cmd, "@LoanType", DbType.String, employeeTransaction.LoanType);
                db.AddInParameter(cmd, "@AccumulativePayment", DbType.Decimal, employeeTransaction.AccumulativePayment);

                // Get the primary key value.
                employeeTransaction.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return employeeTransaction;
        }

        /// <summary>
        /// Updates an existing row in the EmployeeTransactions table.
        /// </summary>
        /// <param name="employeeTransaction">A EmployeeTransaction entity object.</param>
        public void UpdateById(EmployeeTransaction employeeTransaction)
        {
            const string SQL_STATEMENT =
                "UPDATE [EmployeeTransactions] " +
                "SET " +
                    "[PostDate]=@PostDate, " +
                    "[EmpNo]=@EmpNo, " +
                    "[EmployeeId]=@EmployeeId, " +
                    "[Enabled]=@Enabled, " +
                    "[Recurrent]=@Recurrent, " +
                    "[ItemId]=@ItemId, " +
                    "[Amount]=@Amount, " +
                    "[Balance]=@Balance, " +
                    "[InitialAmount]=@InitialAmount, " +
                    "[Processed]=@Processed, " +
                    "[TrackYTD]=@TrackYTD, " +
                    "[ShowYTDInPayslip]=@ShowYTDInPayslip, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[LastChangedBy]=@LastChangedBy, " +
                    "[LastChangeDate]=@LastChangeDate, " +
                    "[AuthorizedBy]=@AuthorizedBy, " +
                    "[AuthorizeDate]=@AuthorizeDate, " +
                    "[LoanType]=@LoanType, " +
                    "[AccumulativePayment]=@AccumulativePayment " +
                "WHERE [Id]=@Id ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@PostDate", DbType.DateTime, employeeTransaction.PostDate);
                db.AddInParameter(cmd, "@EmpNo", DbType.String, employeeTransaction.EmpNo);
                db.AddInParameter(cmd, "@EmployeeId", DbType.Int32, employeeTransaction.EmployeeId);
                db.AddInParameter(cmd, "@Enabled", DbType.Boolean, employeeTransaction.Enabled);
                db.AddInParameter(cmd, "@Recurrent", DbType.Boolean, employeeTransaction.Recurrent);
                db.AddInParameter(cmd, "@ItemId", DbType.String, employeeTransaction.ItemId);
                db.AddInParameter(cmd, "@Amount", DbType.Decimal, employeeTransaction.Amount);
                db.AddInParameter(cmd, "@Balance", DbType.Decimal, employeeTransaction.Balance);
                db.AddInParameter(cmd, "@InitialAmount", DbType.Decimal, employeeTransaction.InitialAmount);
                db.AddInParameter(cmd, "@Processed", DbType.Boolean, employeeTransaction.Processed);
                db.AddInParameter(cmd, "@TrackYTD", DbType.Boolean, employeeTransaction.TrackYTD);
                db.AddInParameter(cmd, "@ShowYTDInPayslip", DbType.Boolean, employeeTransaction.ShowYTDInPayslip);
                db.AddInParameter(cmd, "@CreatedBy", DbType.String, employeeTransaction.CreatedBy);
                db.AddInParameter(cmd, "@LastChangedBy", DbType.String, employeeTransaction.LastChangedBy);
                db.AddInParameter(cmd, "@LastChangeDate", DbType.DateTime, employeeTransaction.LastChangeDate);
                db.AddInParameter(cmd, "@AuthorizedBy", DbType.String, employeeTransaction.AuthorizedBy);
                db.AddInParameter(cmd, "@AuthorizeDate", DbType.DateTime, employeeTransaction.AuthorizeDate);
                db.AddInParameter(cmd, "@LoanType", DbType.String, employeeTransaction.LoanType);
                db.AddInParameter(cmd, "@AccumulativePayment", DbType.Decimal, employeeTransaction.AccumulativePayment);
                db.AddInParameter(cmd, "@Id", DbType.Int32, employeeTransaction.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the EmployeeTransactions table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE FROM [EmployeeTransactions] " +
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
        /// Returns a row from the EmployeeTransactions table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A EmployeeTransaction object with data populated from the database.</returns>
        public EmployeeTransaction SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [PostDate], [EmpNo], [EmployeeId], [Enabled], [Recurrent], [ItemId], [Amount]" +
                        ", [Balance], [InitialAmount], [Processed], [TrackYTD], [ShowYTDInPayslip], [CreatedBy]" +
                        ", [LastChangedBy], [LastChangeDate], [AuthorizedBy], [AuthorizeDate], [LoanType], [AccumulativePayment] " +
                "FROM [EmployeeTransactions] " +
                "WHERE [Id]=@Id ";

            EmployeeTransaction employeeTransaction = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new EmployeeTransaction
                        employeeTransaction = new EmployeeTransaction();

                        // Read values.
                        employeeTransaction.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        employeeTransaction.PostDate = base.GetDataValue<DateTime>(dr, "PostDate");
                        employeeTransaction.EmpNo = base.GetDataValue<string>(dr, "EmpNo");
                        employeeTransaction.EmployeeId = base.GetDataValue<int>(dr, "EmployeeId");
                        employeeTransaction.Enabled = base.GetDataValue<bool>(dr, "Enabled");
                        employeeTransaction.Recurrent = base.GetDataValue<bool>(dr, "Recurrent");
                        employeeTransaction.ItemId = base.GetDataValue<string>(dr, "ItemId");
                        employeeTransaction.Amount = base.GetDataValue<decimal>(dr, "Amount");
                        employeeTransaction.Balance = base.GetDataValue<decimal>(dr, "Balance");
                        employeeTransaction.InitialAmount = base.GetDataValue<decimal>(dr, "InitialAmount");
                        employeeTransaction.Processed = base.GetDataValue<bool>(dr, "Processed");
                        employeeTransaction.TrackYTD = base.GetDataValue<bool>(dr, "TrackYTD");
                        employeeTransaction.ShowYTDInPayslip = base.GetDataValue<bool>(dr, "ShowYTDInPayslip");
                        employeeTransaction.CreatedBy = base.GetDataValue<string>(dr, "CreatedBy");
                        employeeTransaction.LastChangedBy = base.GetDataValue<string>(dr, "LastChangedBy");
                        employeeTransaction.LastChangeDate = base.GetDataValue<DateTime>(dr, "LastChangeDate");
                        employeeTransaction.AuthorizedBy = base.GetDataValue<string>(dr, "AuthorizedBy");
                        employeeTransaction.AuthorizeDate = base.GetDataValue<DateTime>(dr, "AuthorizeDate");
                        employeeTransaction.LoanType = base.GetDataValue<string>(dr, "LoanType");
                        employeeTransaction.AccumulativePayment = base.GetDataValue<decimal>(dr, "AccumulativePayment");
                    }
                }
            }

            return employeeTransaction;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the EmployeeTransactions table.
        /// </summary>
        /// <returns>A collection of EmployeeTransaction objects.</returns>		
        public List<EmployeeTransaction> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [PostDate], [EmpNo], [EmployeeId], [Enabled], [Recurrent], [ItemId], [Amount]" +
                        ", [Balance], [InitialAmount], [Processed], [TrackYTD], [ShowYTDInPayslip], [CreatedBy]" +
                        ", [LastChangedBy], [LastChangeDate], [AuthorizedBy], [AuthorizeDate], [LoanType], [AccumulativePayment] " +
                "FROM [EmployeeTransactions] ";

            List<EmployeeTransaction> result = new List<EmployeeTransaction>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new EmployeeTransaction
                        EmployeeTransaction employeeTransaction = new EmployeeTransaction();

                        // Read values.
                        employeeTransaction.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        employeeTransaction.PostDate = base.GetDataValue<DateTime>(dr, "PostDate");
                        employeeTransaction.EmpNo = base.GetDataValue<string>(dr, "EmpNo");
                        employeeTransaction.EmployeeId = base.GetDataValue<int>(dr, "EmployeeId");
                        employeeTransaction.Enabled = base.GetDataValue<bool>(dr, "Enabled");
                        employeeTransaction.Recurrent = base.GetDataValue<bool>(dr, "Recurrent");
                        employeeTransaction.ItemId = base.GetDataValue<string>(dr, "ItemId");
                        employeeTransaction.Amount = base.GetDataValue<decimal>(dr, "Amount");
                        employeeTransaction.Balance = base.GetDataValue<decimal>(dr, "Balance");
                        employeeTransaction.InitialAmount = base.GetDataValue<decimal>(dr, "InitialAmount");
                        employeeTransaction.Processed = base.GetDataValue<bool>(dr, "Processed");
                        employeeTransaction.TrackYTD = base.GetDataValue<bool>(dr, "TrackYTD");
                        employeeTransaction.ShowYTDInPayslip = base.GetDataValue<bool>(dr, "ShowYTDInPayslip");
                        employeeTransaction.CreatedBy = base.GetDataValue<string>(dr, "CreatedBy");
                        employeeTransaction.LastChangedBy = base.GetDataValue<string>(dr, "LastChangedBy");
                        employeeTransaction.LastChangeDate = base.GetDataValue<DateTime>(dr, "LastChangeDate");
                        employeeTransaction.AuthorizedBy = base.GetDataValue<string>(dr, "AuthorizedBy");
                        employeeTransaction.AuthorizeDate = base.GetDataValue<DateTime>(dr, "AuthorizeDate");
                        employeeTransaction.LoanType = base.GetDataValue<string>(dr, "LoanType");
                        employeeTransaction.AccumulativePayment = base.GetDataValue<decimal>(dr, "AccumulativePayment");

                        // Add to List.
                        result.Add(employeeTransaction);
                    }
                }
            }

            return result;
        }
    }
}