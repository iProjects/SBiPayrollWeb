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
    /// Employee_Ext data access component. Manages CRUD operations for the Employee_Ext table.
    /// </summary>
    public partial class Employee_ExtDAC : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the Employee_Ext table.
        /// </summary>
        /// <param name="employee_Ext">A Employee_Ext object.</param>
        /// <returns>An updated Employee_Ext object.</returns>
        public Employee_Ext Create(Employee_Ext employee_Ext)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.Employee_Ext ([EmpNo], [ExFieldName], [ExFieldStr], [ExFieldInt], [ExFieldDate], [ExFieldDecimal]) " +
                "VALUES(@EmpNo, @ExFieldName, @ExFieldStr, @ExFieldInt, @ExFieldDate, @ExFieldDecimal);  ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@EmpNo", DbType.StringFixedLength, employee_Ext.EmpNo);
                db.AddInParameter(cmd, "@ExFieldName", DbType.Int32, employee_Ext.ExFieldName);
                db.AddInParameter(cmd, "@ExFieldStr", DbType.AnsiString, employee_Ext.ExFieldStr);
                db.AddInParameter(cmd, "@ExFieldInt", DbType.Int32, employee_Ext.ExFieldInt);
                db.AddInParameter(cmd, "@ExFieldDate", DbType.DateTime, employee_Ext.ExFieldDate);
                db.AddInParameter(cmd, "@ExFieldDecimal", DbType.Decimal, employee_Ext.ExFieldDecimal);

                db.ExecuteNonQuery(cmd);
            }

            return employee_Ext;
        }

        /// <summary>
        /// Updates an existing row in the Employee_Ext table.
        /// </summary>
        /// <param name="employee_Ext">A Employee_Ext entity object.</param>
        public void UpdateById(Employee_Ext employee_Ext)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.Employee_Ext " +
                "SET " +
                    "[ExFieldStr]=@ExFieldStr, " +
                    "[ExFieldInt]=@ExFieldInt, " +
                    "[ExFieldDate]=@ExFieldDate, " +
                    "[ExFieldDecimal]=@ExFieldDecimal " +
                "WHERE [EmpNo]=@EmpNo " +
                      "AND [ExFieldName]=@ExFieldName ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@ExFieldStr", DbType.AnsiString, employee_Ext.ExFieldStr);
                db.AddInParameter(cmd, "@ExFieldInt", DbType.Int32, employee_Ext.ExFieldInt);
                db.AddInParameter(cmd, "@ExFieldDate", DbType.DateTime, employee_Ext.ExFieldDate);
                db.AddInParameter(cmd, "@ExFieldDecimal", DbType.Decimal, employee_Ext.ExFieldDecimal);
                db.AddInParameter(cmd, "@EmpNo", DbType.StringFixedLength, employee_Ext.EmpNo);
                db.AddInParameter(cmd, "@ExFieldName", DbType.Int32, employee_Ext.ExFieldName);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the Employee_Ext table.
        /// </summary>
        /// <param name="empNo">A empNo value.</param>
        public void DeleteById(string empNo)
        {
            const string SQL_STATEMENT = "DELETE dbo.Employee_Ext " +
                                         "WHERE [EmpNo]=@EmpNo ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@EmpNo", DbType.StringFixedLength, empNo);


                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Returns a row from the Employee_Ext table.
        /// </summary>
        /// <param name="empNo">A EmpNo value.</param>
        /// <param name="exFieldName">A ExFieldName value.</param>
        /// <returns>A Employee_Ext object with data populated from the database.</returns>
        public Employee_Ext SelectById(string empNo, int exFieldName)
        {
            const string SQL_STATEMENT =
                "SELECT [EmpNo], [ExFieldName], [ExFieldStr], [ExFieldInt], [ExFieldDate], [ExFieldDecimal]" +
                        " " +
                "FROM dbo.Employee_Ext  " +
                "WHERE [EmpNo]=@EmpNo " +
                      "AND [ExFieldName]=@ExFieldName ";

            Employee_Ext employee_Ext = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@EmpNo", DbType.StringFixedLength, empNo);
                db.AddInParameter(cmd, "@ExFieldName", DbType.Int32, exFieldName);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new Employee_Ext
                        employee_Ext = new Employee_Ext();

                        // Read values.
                        employee_Ext.EmpNo = base.GetDataValue<string>(dr, "EmpNo");
                        employee_Ext.ExFieldName = base.GetDataValue<int>(dr, "ExFieldName");
                        employee_Ext.ExFieldStr = base.GetDataValue<string>(dr, "ExFieldStr");
                        employee_Ext.ExFieldInt = base.GetDataValue<int>(dr, "ExFieldInt");
                        employee_Ext.ExFieldDate = base.GetDataValue<DateTime>(dr, "ExFieldDate");
                        employee_Ext.ExFieldDecimal = base.GetDataValue<decimal>(dr, "ExFieldDecimal");
                    }
                }
            }

            return employee_Ext;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the Employee_Ext table.
        /// </summary>
        /// <returns>A collection of Employee_Ext objects.</returns>		
        public List<Employee_Ext> Select()
        {
            // WARNING! The following SQL query does not contain a WHERE condition.
            // You are advised to include a WHERE condition to prevent any performance
            // issues when querying large resultsets.
            const string SQL_STATEMENT =
                "SELECT [EmpNo], [ExFieldName], [ExFieldStr], [ExFieldInt], [ExFieldDate], [ExFieldDecimal]" +
                        " " +
                "FROM dbo.Employee_Ext ";

            List<Employee_Ext> result = new List<Employee_Ext>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new Employee_Ext
                        Employee_Ext employee_Ext = new Employee_Ext();

                        // Read values.
                        employee_Ext.EmpNo = base.GetDataValue<string>(dr, "EmpNo");
                        employee_Ext.ExFieldName = base.GetDataValue<int>(dr, "ExFieldName");
                        employee_Ext.ExFieldStr = base.GetDataValue<string>(dr, "ExFieldStr");
                        employee_Ext.ExFieldInt = base.GetDataValue<int>(dr, "ExFieldInt");
                        employee_Ext.ExFieldDate = base.GetDataValue<DateTime>(dr, "ExFieldDate");
                        employee_Ext.ExFieldDecimal = base.GetDataValue<decimal>(dr, "ExFieldDecimal");

                        // Add to List.
                        result.Add(employee_Ext);
                    }
                }
            }

            return result;
        }
    }
}

