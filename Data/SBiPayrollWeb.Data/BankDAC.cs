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
    /// Banks data access component. Manages CRUD operations for the Banks table.
    /// </summary>
    public partial class BankDAC : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the Banks table.
        /// </summary>
        /// <param name="bank">A Bank object.</param>
        /// <returns>An updated Bank object.</returns>
        public Bank Create(Bank bank)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.Banks ([BankCode], [BankName]) " +
                "VALUES(@BankCode, @BankName);  ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@BankCode", DbType.String, bank.BankCode);
                db.AddInParameter(cmd, "@BankName", DbType.String, bank.BankName);

                db.ExecuteNonQuery(cmd);
            }

            return bank;
        }

        /// <summary>
        /// Updates an existing row in the Banks table.
        /// </summary>
        /// <param name="bank">A Bank entity object.</param>
        public void UpdateById(Bank bank)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.Banks " +
                "SET " +
                    "[BankName]=@BankName " +
                "WHERE [BankCode]=@BankCode ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@BankName", DbType.String, bank.BankName);
                db.AddInParameter(cmd, "@BankCode", DbType.String, bank.BankCode);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the Banks table.
        /// </summary>
        /// <param name="bankCode">A bankCode value.</param>
        public void DeleteById(string bankCode)
        {
            const string SQL_STATEMENT = "DELETE dbo.Banks " +
                                         "WHERE [BankCode]=@BankCode ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@BankCode", DbType.String, bankCode);


                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Returns a row from the Banks table.
        /// </summary>
        /// <param name="bankCode">A BankCode value.</param>
        /// <returns>A Bank object with data populated from the database.</returns>
        public Bank SelectById(string bankCode)
        {
            const string SQL_STATEMENT =
                "SELECT [BankCode], [BankName] " +
                "FROM dbo.Banks  " +
                "WHERE [BankCode]=@BankCode ";

            Bank bank = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@BankCode", DbType.String, bankCode);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new Bank
                        bank = new Bank();

                        // Read values.
                        bank.BankCode = base.GetDataValue<string>(dr, "BankCode");
                        bank.BankName = base.GetDataValue<string>(dr, "BankName");
                    }
                }
            }

            return bank;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the Banks table.
        /// </summary>
        /// <returns>A collection of Bank objects.</returns>		
        public List<Bank> Select()
        {
            // WARNING! The following SQL query does not contain a WHERE condition.
            // You are advised to include a WHERE condition to prevent any performance
            // issues when querying large resultsets.
            const string SQL_STATEMENT =
                "SELECT [BankCode], [BankName] " +
                "FROM dbo.Banks ";

            List<Bank> result = new List<Bank>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new Bank
                        Bank bank = new Bank();

                        // Read values.
                        bank.BankCode = base.GetDataValue<string>(dr, "BankCode");
                        bank.BankName = base.GetDataValue<string>(dr, "BankName");

                        // Add to List.
                        result.Add(bank);
                    }
                }
            }

            return result;
        }
    }
}

