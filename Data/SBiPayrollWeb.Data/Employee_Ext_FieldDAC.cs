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
    /// Employee_Ext_Fields data access component. Manages CRUD operations for the Employee_Ext_Fields table.
    /// </summary>
    public partial class Employee_Ext_FieldDAC : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the Employee_Ext_Fields table.
        /// </summary>
        /// <param name="employee_Ext_Field">A Employee_Ext_Field object.</param>
        /// <returns>An updated Employee_Ext_Field object.</returns>
        public Employee_Ext_Field Create(Employee_Ext_Field employee_Ext_Field)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.Employee_Ext_Fields ([Description], [FType]) " +
                "VALUES(@Description, @FType); SELECT SCOPE_IDENTITY();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@Description", DbType.String, employee_Ext_Field.Description);
                db.AddInParameter(cmd, "@FType", DbType.String, employee_Ext_Field.FType);

                // Get the primary key value.
                employee_Ext_Field.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return employee_Ext_Field;
        }

        /// <summary>
        /// Updates an existing row in the Employee_Ext_Fields table.
        /// </summary>
        /// <param name="employee_Ext_Field">A Employee_Ext_Field entity object.</param>
        public void UpdateById(Employee_Ext_Field employee_Ext_Field)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.Employee_Ext_Fields " +
                "SET " +
                    "[Description]=@Description, " +
                    "[FType]=@FType " +
                "WHERE [Id]=@Id ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@Description", DbType.String, employee_Ext_Field.Description);
                db.AddInParameter(cmd, "@FType", DbType.String, employee_Ext_Field.FType);
                db.AddInParameter(cmd, "@Id", DbType.Int32, employee_Ext_Field.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the Employee_Ext_Fields table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.Employee_Ext_Fields " +
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
        /// Returns a row from the Employee_Ext_Fields table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A Employee_Ext_Field object with data populated from the database.</returns>
        public Employee_Ext_Field SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Description], [FType] " +
                "FROM dbo.Employee_Ext_Fields  " +
                "WHERE [Id]=@Id ";

            Employee_Ext_Field employee_Ext_Field = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new Employee_Ext_Field
                        employee_Ext_Field = new Employee_Ext_Field();

                        // Read values.
                        employee_Ext_Field.Id = base.GetDataValue<int>(dr, "Id");
                        employee_Ext_Field.Description = base.GetDataValue<string>(dr, "Description");
                        employee_Ext_Field.FType = base.GetDataValue<string>(dr, "FType");
                    }
                }
            }

            return employee_Ext_Field;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the Employee_Ext_Fields table.
        /// </summary>
        /// <returns>A collection of Employee_Ext_Field objects.</returns>		
        public List<Employee_Ext_Field> Select()
        {
            // WARNING! The following SQL query does not contain a WHERE condition.
            // You are advised to include a WHERE condition to prevent any performance
            // issues when querying large resultsets.
            const string SQL_STATEMENT =
                "SELECT [Id], [Description], [FType] " +
                "FROM dbo.Employee_Ext_Fields ";

            List<Employee_Ext_Field> result = new List<Employee_Ext_Field>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new Employee_Ext_Field
                        Employee_Ext_Field employee_Ext_Field = new Employee_Ext_Field();

                        // Read values.
                        employee_Ext_Field.Id = base.GetDataValue<int>(dr, "Id");
                        employee_Ext_Field.Description = base.GetDataValue<string>(dr, "Description");
                        employee_Ext_Field.FType = base.GetDataValue<string>(dr, "FType");

                        // Add to List.
                        result.Add(employee_Ext_Field);
                    }
                }
            }

            return result;
        }
    }
}

