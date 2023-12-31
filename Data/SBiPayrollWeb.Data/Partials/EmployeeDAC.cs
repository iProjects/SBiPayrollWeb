//====================================================================================================
// Base code generated with Momentum: DAC Gen (Build 2.5.5049.15162)
// Layered Architecture Solution Guidance (http://layerguidance.codeplex.com)
//
// Generated by Administrator at SAPSERVER on 12/31/2014 06:25:02 
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
    /// Employees data access component. Manages CRUD operations for the Employees table.
    /// </summary>
    public partial class EmployeeDAC 
    { 
        /// <summary>
        /// Updates an existing row in the Employees table.
        /// </summary>
        /// <param name="employee">A Employee entity object.</param>
        public void UploadEmployeePhoto(Employee employee)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.Employees " +
                "SET " + 
                    "[Photo]=@Photo " +   
                "WHERE [Id]=@Id ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values. 
                db.AddInParameter(cmd, "@Photo", DbType.String, employee.Photo);   
                db.AddInParameter(cmd, "@Id", DbType.Int32, employee.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Returns a row from the Employees table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A Employee object with data populated from the database.</returns>
        public Employee SelectByEmail(string Email)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [EmpNo], [Surname], [OtherNames], [Email], [DoB], [MaritalStatus], [Gender]" +
                        ", [Photo], [DoE], [BasicComputation], [BasicPay], [PersonalRelief], [MortgageRelief]" +
                        ", [InsuranceRelief], [NSSFNo], [NHIFNo], [IDNo], [PINNo], [DepartmentId], [EmployerId]" +
                        ", [PayPoint], [EmpGroup], [EmpPayroll], [PrevEmployer], [DateLeft], [PaymentMode]" +
                        ", [TelephoneNo], [ChequeNo], [BankCode], [BankAccount], [LeaveBalance], [IsActive]" +
                        ", [CreatedBy], [CreatedOn], [IsDeleted], [SystemId] " +
                "FROM dbo.Employees  " +
                "WHERE [Email]=@Email ";

            Employee employee = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Email", DbType.String, Email);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new Employee
                        employee = new Employee();

                        // Read values.
                        employee.Id = base.GetDataValue<int>(dr, "Id");
                        employee.EmpNo = base.GetDataValue<string>(dr, "EmpNo");
                        employee.Surname = base.GetDataValue<string>(dr, "Surname");
                        employee.OtherNames = base.GetDataValue<string>(dr, "OtherNames");
                        employee.Email = base.GetDataValue<string>(dr, "Email");
                        employee.DoB = base.GetDataValue<DateTime>(dr, "DoB");
                        employee.MaritalStatus = base.GetDataValue<string>(dr, "MaritalStatus");
                        employee.Gender = base.GetDataValue<string>(dr, "Gender");
                        employee.Photo = base.GetDataValue<string>(dr, "Photo");
                        employee.DoE = base.GetDataValue<DateTime>(dr, "DoE");
                        employee.BasicComputation = base.GetDataValue<string>(dr, "BasicComputation");
                        employee.BasicPay = base.GetDataValue<decimal>(dr, "BasicPay");
                        employee.PersonalRelief = base.GetDataValue<decimal>(dr, "PersonalRelief");
                        employee.MortgageRelief = base.GetDataValue<decimal>(dr, "MortgageRelief");
                        employee.InsuranceRelief = base.GetDataValue<decimal>(dr, "InsuranceRelief");
                        employee.NSSFNo = base.GetDataValue<string>(dr, "NSSFNo");
                        employee.NHIFNo = base.GetDataValue<string>(dr, "NHIFNo");
                        employee.IDNo = base.GetDataValue<string>(dr, "IDNo");
                        employee.PINNo = base.GetDataValue<string>(dr, "PINNo");
                        employee.DepartmentId = base.GetDataValue<int>(dr, "DepartmentId");
                        employee.EmployerId = base.GetDataValue<int>(dr, "EmployerId");
                        employee.PayPoint = base.GetDataValue<string>(dr, "PayPoint");
                        employee.EmpGroup = base.GetDataValue<string>(dr, "EmpGroup");
                        employee.EmpPayroll = base.GetDataValue<string>(dr, "EmpPayroll");
                        employee.PrevEmployer = base.GetDataValue<string>(dr, "PrevEmployer");
                        employee.DateLeft = base.GetDataValue<DateTime>(dr, "DateLeft");
                        employee.PaymentMode = base.GetDataValue<string>(dr, "PaymentMode");
                        employee.TelephoneNo = base.GetDataValue<string>(dr, "TelephoneNo");
                        employee.ChequeNo = base.GetDataValue<string>(dr, "ChequeNo");
                        employee.BankCode = base.GetDataValue<string>(dr, "BankCode");
                        employee.BankAccount = base.GetDataValue<string>(dr, "BankAccount");
                        employee.LeaveBalance = base.GetDataValue<string>(dr, "LeaveBalance");
                        employee.IsActive = base.GetDataValue<bool>(dr, "IsActive");
                        employee.CreatedBy = base.GetDataValue<string>(dr, "CreatedBy");
                        employee.CreatedOn = base.GetDataValue<DateTime>(dr, "CreatedOn");
                        employee.IsDeleted = base.GetDataValue<bool>(dr, "IsDeleted");
                        employee.SystemId = base.GetDataValue<string>(dr, "SystemId");
                    }
                }
            }

            return employee;
        }


    }
}

