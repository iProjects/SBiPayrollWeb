//====================================================================================================
// Base code generated with Momentum: DAC Gen (Build 2.5.5049.15162)
// Layered Architecture Solution Guidance (http://layerguidance.codeplex.com)
// Modified for SQLite and .NET 4.0 Compatibility
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
    /// Accounts data access component. Manages CRUD operations for the Accounts table.
    /// </summary>
    public partial class AccountDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the Accounts table.
        /// </summary>
        /// <param name="account">A Account object.</param>
        /// <returns>An updated Account object.</returns>
        public Account Create(Account account)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [Accounts] ([Id], [EmpNo], [AccountType], [BookBalance]) " +
                "VALUES(@Id, @EmpNo, @AccountType, @BookBalance);";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@Id", DbType.Int32, account.Id);
                db.AddInParameter(cmd, "@EmpNo", DbType.String, account.EmpNo);
                db.AddInParameter(cmd, "@AccountType", DbType.String, account.AccountType);
                db.AddInParameter(cmd, "@BookBalance", DbType.Decimal, account.BookBalance);

                db.ExecuteNonQuery(cmd);
            }

            return account;
        }

        /// <summary>
        /// Updates an existing row in the Accounts table.
        /// </summary>
        /// <param name="account">A Account entity object.</param>
        public void UpdateById(Account account)
        {
            const string SQL_STATEMENT =
                "UPDATE [Accounts] " +
                "SET " +
                    "[EmpNo]=@EmpNo, " +
                    "[AccountType]=@AccountType, " +
                    "[BookBalance]=@BookBalance " +
                "WHERE [Id]=@Id;";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@EmpNo", DbType.String, account.EmpNo);
                db.AddInParameter(cmd, "@AccountType", DbType.String, account.AccountType);
                db.AddInParameter(cmd, "@BookBalance", DbType.Decimal, account.BookBalance);
                db.AddInParameter(cmd, "@Id", DbType.Int32, account.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the Accounts table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE FROM [Accounts] " +
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
        /// Returns a row from the Accounts table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A Account object with data populated from the database.</returns>
        public Account SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [EmpNo], [AccountType], [BookBalance] " +
                "FROM [Accounts] " +
                "WHERE [Id]=@Id;";

            Account account = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new Account
                        account = new Account();

                        // Read values.
                        account.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        account.EmpNo = base.GetDataValue<string>(dr, "EmpNo");
                        account.AccountType = base.GetDataValue<string>(dr, "AccountType");
                        account.BookBalance = base.GetDataValue<decimal>(dr, "BookBalance");
                    }
                }
            }

            return account;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the Accounts table.
        /// </summary>
        /// <returns>A collection of Account objects.</returns>		
        public List<Account> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [EmpNo], [AccountType], [BookBalance] " +
                "FROM [Accounts];";

            List<Account> result = new List<Account>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new Account
                        Account account = new Account();

                        // Read values.
                        account.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        account.EmpNo = base.GetDataValue<string>(dr, "EmpNo");
                        account.AccountType = base.GetDataValue<string>(dr, "AccountType");
                        account.BookBalance = base.GetDataValue<decimal>(dr, "BookBalance");

                        // Add to List.
                        result.Add(account);
                    }
                }
            }

            return result;
        }
    }
}
