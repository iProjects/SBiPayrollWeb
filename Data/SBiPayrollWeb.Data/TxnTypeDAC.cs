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
    /// TxnType data access component. Manages CRUD operations for the TxnType table.
    /// </summary>
    public partial class TxnTypeDAC : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the TxnType table.
        /// </summary>
        /// <param name="txnType">A TxnType object.</param>
        /// <returns>An updated TxnType object.</returns>
        public TxnType Create(TxnType txnType)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.TxnType ([Description]) " +
                "VALUES(@Description); SELECT SCOPE_IDENTITY();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@Description", DbType.String, txnType.Description);

                // Get the primary key value.
                txnType.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return txnType;
        }

        /// <summary>
        /// Updates an existing row in the TxnType table.
        /// </summary>
        /// <param name="txnType">A TxnType entity object.</param>
        public void UpdateById(TxnType txnType)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.TxnType " +
                "SET " +
                    "[Description]=@Description " +
                "WHERE [Id]=@Id ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@Description", DbType.String, txnType.Description);
                db.AddInParameter(cmd, "@Id", DbType.Int32, txnType.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the TxnType table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.TxnType " +
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
        /// Returns a row from the TxnType table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A TxnType object with data populated from the database.</returns>
        public TxnType SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Description] " +
                "FROM dbo.TxnType  " +
                "WHERE [Id]=@Id ";

            TxnType txnType = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new TxnType
                        txnType = new TxnType();

                        // Read values.
                        txnType.Id = base.GetDataValue<int>(dr, "Id");
                        txnType.Description = base.GetDataValue<string>(dr, "Description");
                    }
                }
            }

            return txnType;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the TxnType table.
        /// </summary>
        /// <returns>A collection of TxnType objects.</returns>		
        public List<TxnType> Select()
        {
            // WARNING! The following SQL query does not contain a WHERE condition.
            // You are advised to include a WHERE condition to prevent any performance
            // issues when querying large resultsets.
            const string SQL_STATEMENT =
                "SELECT [Id], [Description] " +
                "FROM dbo.TxnType ";

            List<TxnType> result = new List<TxnType>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new TxnType
                        TxnType txnType = new TxnType();

                        // Read values.
                        txnType.Id = base.GetDataValue<int>(dr, "Id");
                        txnType.Description = base.GetDataValue<string>(dr, "Description");

                        // Add to List.
                        result.Add(txnType);
                    }
                }
            }

            return result;
        }
    }
}

