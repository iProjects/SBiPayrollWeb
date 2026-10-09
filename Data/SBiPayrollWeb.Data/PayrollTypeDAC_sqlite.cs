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
    /// PayrollTypes data access component. Manages CRUD operations for the PayrollTypes table.
    /// </summary>
    public partial class PayrollTypeDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the PayrollTypes table.
        /// </summary>
        /// <param name="payrollType">A PayrollType object.</param>
        /// <returns>An updated PayrollType object.</returns>
        public PayrollType Create(PayrollType payrollType)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [PayrollTypes] ([Description], [Remarks]) " +
                "VALUES(@Description, @Remarks); SELECT last_insert_rowid();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@Description", DbType.String, payrollType.Description);
                db.AddInParameter(cmd, "@Remarks", DbType.String, payrollType.Remarks);

                // Get the primary key value.
                payrollType.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return payrollType;
        }

        /// <summary>
        /// Updates an existing row in the PayrollTypes table.
        /// </summary>
        /// <param name="payrollType">A PayrollType entity object.</param>
        public void UpdateById(PayrollType payrollType)
        {
            const string SQL_STATEMENT =
                "UPDATE [PayrollTypes] " +
                "SET " +
                    "[Description]=@Description, " +
                    "[Remarks]=@Remarks " +
                "WHERE [Id]=@Id;";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@Description", DbType.String, payrollType.Description);
                db.AddInParameter(cmd, "@Remarks", DbType.String, payrollType.Remarks);
                db.AddInParameter(cmd, "@Id", DbType.Int32, payrollType.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the PayrollTypes table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE FROM [PayrollTypes] " +
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
        /// Returns a row from the PayrollTypes table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A PayrollType object with data populated from the database.</returns>
        public PayrollType SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Description], [Remarks] " +
                "FROM [PayrollTypes] " +
                "WHERE [Id]=@Id;";

            PayrollType payrollType = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new PayrollType
                        payrollType = new PayrollType();

                        // Read values.
                        payrollType.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        payrollType.Description = base.GetDataValue<string>(dr, "Description");
                        payrollType.Remarks = base.GetDataValue<string>(dr, "Remarks");
                    }
                }
            }

            return payrollType;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the PayrollTypes table.
        /// </summary>
        /// <returns>A collection of PayrollType objects.</returns>		
        public List<PayrollType> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Description], [Remarks] " +
                "FROM [PayrollTypes];";

            List<PayrollType> result = new List<PayrollType>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new PayrollType
                        PayrollType payrollType = new PayrollType();

                        // Read values.
                        payrollType.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        payrollType.Description = base.GetDataValue<string>(dr, "Description");
                        payrollType.Remarks = base.GetDataValue<string>(dr, "Remarks");

                        // Add to List.
                        result.Add(payrollType);
                    }
                }
            }

            return result;
        }
    }
}