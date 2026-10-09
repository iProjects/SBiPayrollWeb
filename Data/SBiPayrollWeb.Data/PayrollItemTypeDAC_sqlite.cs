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
    /// PayrollItemType data access component. Manages CRUD operations for the PayrollItemType table.
    /// </summary>
    public partial class PayrollItemTypeDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the PayrollItemType table.
        /// </summary>
        /// <param name="payrollItemType">A PayrollItemType object.</param>
        /// <returns>An updated PayrollItemType object.</returns>
        public PayrollItemType Create(PayrollItemType payrollItemType)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [PayrollItemType] ([Id], [Parent], [Description]) " +
                "VALUES(@Id, @Parent, @Description);";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@Id", DbType.String, payrollItemType.Id);
                db.AddInParameter(cmd, "@Parent", DbType.String, payrollItemType.Parent);
                db.AddInParameter(cmd, "@Description", DbType.String, payrollItemType.Description);

                db.ExecuteNonQuery(cmd);
            }

            return payrollItemType;
        }

        /// <summary>
        /// Updates an existing row in the PayrollItemType table.
        /// </summary>
        /// <param name="payrollItemType">A PayrollItemType entity object.</param>
        public void UpdateById(PayrollItemType payrollItemType)
        {
            const string SQL_STATEMENT =
                "UPDATE [PayrollItemType] " +
                "SET " +
                    "[Parent]=@Parent, " +
                    "[Description]=@Description " +
                "WHERE [Id]=@Id;";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@Parent", DbType.String, payrollItemType.Parent);
                db.AddInParameter(cmd, "@Description", DbType.String, payrollItemType.Description);
                db.AddInParameter(cmd, "@Id", DbType.String, payrollItemType.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the PayrollItemType table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(string id)
        {
            const string SQL_STATEMENT = "DELETE FROM [PayrollItemType] " +
                                         "WHERE [Id]=@Id;";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@Id", DbType.String, id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Returns a row from the PayrollItemType table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A PayrollItemType object with data populated from the database.</returns>
        public PayrollItemType SelectById(string id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Parent], [Description] " +
                "FROM [PayrollItemType] " +
                "WHERE [Id]=@Id;";

            PayrollItemType payrollItemType = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.String, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new PayrollItemType
                        payrollItemType = new PayrollItemType();

                        // Read values.
                        payrollItemType.Id = base.GetDataValue<string>(dr, "Id");
                        payrollItemType.Parent = base.GetDataValue<string>(dr, "Parent");
                        payrollItemType.Description = base.GetDataValue<string>(dr, "Description");
                    }
                }
            }

            return payrollItemType;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the PayrollItemType table.
        /// </summary>
        /// <returns>A collection of PayrollItemType objects.</returns>		
        public List<PayrollItemType> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Parent], [Description] " +
                "FROM [PayrollItemType];";

            List<PayrollItemType> result = new List<PayrollItemType>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new PayrollItemType
                        PayrollItemType payrollItemType = new PayrollItemType();

                        // Read values.
                        payrollItemType.Id = base.GetDataValue<string>(dr, "Id");
                        payrollItemType.Parent = base.GetDataValue<string>(dr, "Parent");
                        payrollItemType.Description = base.GetDataValue<string>(dr, "Description");

                        // Add to List.
                        result.Add(payrollItemType);
                    }
                }
            }

            return result;
        }
    }
}
