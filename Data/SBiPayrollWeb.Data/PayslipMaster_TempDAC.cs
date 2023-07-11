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
    /// PayslipMaster_Temp data access component. Manages CRUD operations for the PayslipMaster_Temp table.
    /// </summary>
    public partial class PayslipMaster_TempDAC : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the PayslipMaster_Temp table.
        /// </summary>
        /// <param name="payslipMaster_Temp">A PayslipMaster_Temp object.</param>
        /// <returns>An updated PayslipMaster_Temp object.</returns>
        public PayslipMaster_Temp Create(PayslipMaster_Temp payslipMaster_Temp)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.PayslipMaster_Temp ([Period], [Year], [EmpNo], [EmployeeId], [PaymentDate], [PrintedBy], [PrintedOn], [EmpName], [PayPoint], [PIN], [NHIFNo], [NSSFNo], [Department], [EmpGroup], [EmpPayroll], [CompName], [CompAddr], [CompTel], [PayeTax], [BasicPay], [Benefits], [Variables], [OtherDeductions], [GrossTaxableEarnings], [NetTaxableEarnings], [MortgageRelief], [InsuranceRelief], [GrossTax], [PersonalRelief], [PensionEmployer], [EmployerNSSF], [PensionEmployee], [BankBranch], [Account], [NSSF], [NHIF], [NetPay]) " +
                "VALUES(@Period, @Year, @EmpNo, @EmployeeId, @PaymentDate, @PrintedBy, @PrintedOn, @EmpName, @PayPoint, @PIN, @NHIFNo, @NSSFNo, @Department, @EmpGroup, @EmpPayroll, @CompName, @CompAddr, @CompTel, @PayeTax, @BasicPay, @Benefits, @Variables, @OtherDeductions, @GrossTaxableEarnings, @NetTaxableEarnings, @MortgageRelief, @InsuranceRelief, @GrossTax, @PersonalRelief, @PensionEmployer, @EmployerNSSF, @PensionEmployee, @BankBranch, @Account, @NSSF, @NHIF, @NetPay);  ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@Period", DbType.Int32, payslipMaster_Temp.Period);
                db.AddInParameter(cmd, "@Year", DbType.Int32, payslipMaster_Temp.Year);
                db.AddInParameter(cmd, "@EmpNo", DbType.String, payslipMaster_Temp.EmpNo);
                db.AddInParameter(cmd, "@EmployeeId", DbType.Int32, payslipMaster_Temp.EmployeeId);
                db.AddInParameter(cmd, "@PaymentDate", DbType.Date, payslipMaster_Temp.PaymentDate);
                db.AddInParameter(cmd, "@PrintedBy", DbType.String, payslipMaster_Temp.PrintedBy);
                db.AddInParameter(cmd, "@PrintedOn", DbType.DateTime, payslipMaster_Temp.PrintedOn);
                db.AddInParameter(cmd, "@EmpName", DbType.String, payslipMaster_Temp.EmpName);
                db.AddInParameter(cmd, "@PayPoint", DbType.String, payslipMaster_Temp.PayPoint);
                db.AddInParameter(cmd, "@PIN", DbType.String, payslipMaster_Temp.PIN);
                db.AddInParameter(cmd, "@NHIFNo", DbType.String, payslipMaster_Temp.NHIFNo);
                db.AddInParameter(cmd, "@NSSFNo", DbType.String, payslipMaster_Temp.NSSFNo);
                db.AddInParameter(cmd, "@Department", DbType.String, payslipMaster_Temp.Department);
                db.AddInParameter(cmd, "@EmpGroup", DbType.String, payslipMaster_Temp.EmpGroup);
                db.AddInParameter(cmd, "@EmpPayroll", DbType.String, payslipMaster_Temp.EmpPayroll);
                db.AddInParameter(cmd, "@CompName", DbType.String, payslipMaster_Temp.CompName);
                db.AddInParameter(cmd, "@CompAddr", DbType.String, payslipMaster_Temp.CompAddr);
                db.AddInParameter(cmd, "@CompTel", DbType.String, payslipMaster_Temp.CompTel);
                db.AddInParameter(cmd, "@PayeTax", DbType.Currency, payslipMaster_Temp.PayeTax);
                db.AddInParameter(cmd, "@BasicPay", DbType.Currency, payslipMaster_Temp.BasicPay);
                db.AddInParameter(cmd, "@Benefits", DbType.Currency, payslipMaster_Temp.Benefits);
                db.AddInParameter(cmd, "@Variables", DbType.Currency, payslipMaster_Temp.Variables);
                db.AddInParameter(cmd, "@OtherDeductions", DbType.Currency, payslipMaster_Temp.OtherDeductions);
                db.AddInParameter(cmd, "@GrossTaxableEarnings", DbType.Currency, payslipMaster_Temp.GrossTaxableEarnings);
                db.AddInParameter(cmd, "@NetTaxableEarnings", DbType.Currency, payslipMaster_Temp.NetTaxableEarnings);
                db.AddInParameter(cmd, "@MortgageRelief", DbType.Currency, payslipMaster_Temp.MortgageRelief);
                db.AddInParameter(cmd, "@InsuranceRelief", DbType.Currency, payslipMaster_Temp.InsuranceRelief);
                db.AddInParameter(cmd, "@GrossTax", DbType.Currency, payslipMaster_Temp.GrossTax);
                db.AddInParameter(cmd, "@PersonalRelief", DbType.Currency, payslipMaster_Temp.PersonalRelief);
                db.AddInParameter(cmd, "@PensionEmployer", DbType.Currency, payslipMaster_Temp.PensionEmployer);
                db.AddInParameter(cmd, "@EmployerNSSF", DbType.Currency, payslipMaster_Temp.EmployerNSSF);
                db.AddInParameter(cmd, "@PensionEmployee", DbType.Currency, payslipMaster_Temp.PensionEmployee);
                db.AddInParameter(cmd, "@BankBranch", DbType.String, payslipMaster_Temp.BankBranch);
                db.AddInParameter(cmd, "@Account", DbType.String, payslipMaster_Temp.Account);
                db.AddInParameter(cmd, "@NSSF", DbType.Currency, payslipMaster_Temp.NSSF);
                db.AddInParameter(cmd, "@NHIF", DbType.Currency, payslipMaster_Temp.NHIF);
                db.AddInParameter(cmd, "@NetPay", DbType.Currency, payslipMaster_Temp.NetPay);

                db.ExecuteNonQuery(cmd);
            }

            return payslipMaster_Temp;
        }

        /// <summary>
        /// Updates an existing row in the PayslipMaster_Temp table.
        /// </summary>
        /// <param name="payslipMaster_Temp">A PayslipMaster_Temp entity object.</param>
        public void UpdateById(PayslipMaster_Temp payslipMaster_Temp)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.PayslipMaster_Temp " +
                "SET " +
                    "[EmployeeId]=@EmployeeId, " +
                    "[PaymentDate]=@PaymentDate, " +
                    "[PrintedBy]=@PrintedBy, " +
                    "[PrintedOn]=@PrintedOn, " +
                    "[EmpName]=@EmpName, " +
                    "[PayPoint]=@PayPoint, " +
                    "[PIN]=@PIN, " +
                    "[NHIFNo]=@NHIFNo, " +
                    "[NSSFNo]=@NSSFNo, " +
                    "[Department]=@Department, " +
                    "[EmpGroup]=@EmpGroup, " +
                    "[EmpPayroll]=@EmpPayroll, " +
                    "[CompName]=@CompName, " +
                    "[CompAddr]=@CompAddr, " +
                    "[CompTel]=@CompTel, " +
                    "[PayeTax]=@PayeTax, " +
                    "[BasicPay]=@BasicPay, " +
                    "[Benefits]=@Benefits, " +
                    "[Variables]=@Variables, " +
                    "[OtherDeductions]=@OtherDeductions, " +
                    "[GrossTaxableEarnings]=@GrossTaxableEarnings, " +
                    "[NetTaxableEarnings]=@NetTaxableEarnings, " +
                    "[MortgageRelief]=@MortgageRelief, " +
                    "[InsuranceRelief]=@InsuranceRelief, " +
                    "[GrossTax]=@GrossTax, " +
                    "[PersonalRelief]=@PersonalRelief, " +
                    "[PensionEmployer]=@PensionEmployer, " +
                    "[EmployerNSSF]=@EmployerNSSF, " +
                    "[PensionEmployee]=@PensionEmployee, " +
                    "[BankBranch]=@BankBranch, " +
                    "[Account]=@Account, " +
                    "[NSSF]=@NSSF, " +
                    "[NHIF]=@NHIF, " +
                    "[NetPay]=@NetPay " +
                "WHERE [Period]=@Period " +
                      "AND [Year]=@Year " +
                      "AND [EmpNo]=@EmpNo ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@EmployeeId", DbType.Int32, payslipMaster_Temp.EmployeeId);
                db.AddInParameter(cmd, "@PaymentDate", DbType.Date, payslipMaster_Temp.PaymentDate);
                db.AddInParameter(cmd, "@PrintedBy", DbType.String, payslipMaster_Temp.PrintedBy);
                db.AddInParameter(cmd, "@PrintedOn", DbType.DateTime, payslipMaster_Temp.PrintedOn);
                db.AddInParameter(cmd, "@EmpName", DbType.String, payslipMaster_Temp.EmpName);
                db.AddInParameter(cmd, "@PayPoint", DbType.String, payslipMaster_Temp.PayPoint);
                db.AddInParameter(cmd, "@PIN", DbType.String, payslipMaster_Temp.PIN);
                db.AddInParameter(cmd, "@NHIFNo", DbType.String, payslipMaster_Temp.NHIFNo);
                db.AddInParameter(cmd, "@NSSFNo", DbType.String, payslipMaster_Temp.NSSFNo);
                db.AddInParameter(cmd, "@Department", DbType.String, payslipMaster_Temp.Department);
                db.AddInParameter(cmd, "@EmpGroup", DbType.String, payslipMaster_Temp.EmpGroup);
                db.AddInParameter(cmd, "@EmpPayroll", DbType.String, payslipMaster_Temp.EmpPayroll);
                db.AddInParameter(cmd, "@CompName", DbType.String, payslipMaster_Temp.CompName);
                db.AddInParameter(cmd, "@CompAddr", DbType.String, payslipMaster_Temp.CompAddr);
                db.AddInParameter(cmd, "@CompTel", DbType.String, payslipMaster_Temp.CompTel);
                db.AddInParameter(cmd, "@PayeTax", DbType.Currency, payslipMaster_Temp.PayeTax);
                db.AddInParameter(cmd, "@BasicPay", DbType.Currency, payslipMaster_Temp.BasicPay);
                db.AddInParameter(cmd, "@Benefits", DbType.Currency, payslipMaster_Temp.Benefits);
                db.AddInParameter(cmd, "@Variables", DbType.Currency, payslipMaster_Temp.Variables);
                db.AddInParameter(cmd, "@OtherDeductions", DbType.Currency, payslipMaster_Temp.OtherDeductions);
                db.AddInParameter(cmd, "@GrossTaxableEarnings", DbType.Currency, payslipMaster_Temp.GrossTaxableEarnings);
                db.AddInParameter(cmd, "@NetTaxableEarnings", DbType.Currency, payslipMaster_Temp.NetTaxableEarnings);
                db.AddInParameter(cmd, "@MortgageRelief", DbType.Currency, payslipMaster_Temp.MortgageRelief);
                db.AddInParameter(cmd, "@InsuranceRelief", DbType.Currency, payslipMaster_Temp.InsuranceRelief);
                db.AddInParameter(cmd, "@GrossTax", DbType.Currency, payslipMaster_Temp.GrossTax);
                db.AddInParameter(cmd, "@PersonalRelief", DbType.Currency, payslipMaster_Temp.PersonalRelief);
                db.AddInParameter(cmd, "@PensionEmployer", DbType.Currency, payslipMaster_Temp.PensionEmployer);
                db.AddInParameter(cmd, "@EmployerNSSF", DbType.Currency, payslipMaster_Temp.EmployerNSSF);
                db.AddInParameter(cmd, "@PensionEmployee", DbType.Currency, payslipMaster_Temp.PensionEmployee);
                db.AddInParameter(cmd, "@BankBranch", DbType.String, payslipMaster_Temp.BankBranch);
                db.AddInParameter(cmd, "@Account", DbType.String, payslipMaster_Temp.Account);
                db.AddInParameter(cmd, "@NSSF", DbType.Currency, payslipMaster_Temp.NSSF);
                db.AddInParameter(cmd, "@NHIF", DbType.Currency, payslipMaster_Temp.NHIF);
                db.AddInParameter(cmd, "@NetPay", DbType.Currency, payslipMaster_Temp.NetPay);
                db.AddInParameter(cmd, "@Period", DbType.Int32, payslipMaster_Temp.Period);
                db.AddInParameter(cmd, "@Year", DbType.Int32, payslipMaster_Temp.Year);
                db.AddInParameter(cmd, "@EmpNo", DbType.String, payslipMaster_Temp.EmpNo);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the PayslipMaster_Temp table.
        /// </summary>
        /// <param name="period">A period value.</param>
        public void DeleteById(int period)
        {
            const string SQL_STATEMENT = "DELETE dbo.PayslipMaster_Temp " +
                                         "WHERE [Period]=@Period ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@Period", DbType.Int32, period);


                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Returns a row from the PayslipMaster_Temp table.
        /// </summary>
        /// <param name="period">A Period value.</param>
        /// <param name="year">A Year value.</param>
        /// <param name="empNo">A EmpNo value.</param>
        /// <returns>A PayslipMaster_Temp object with data populated from the database.</returns>
        public PayslipMaster_Temp SelectById(int period, int year, string empNo)
        {
            const string SQL_STATEMENT =
                "SELECT [Period], [Year], [EmpNo], [EmployeeId], [PaymentDate], [PrintedBy], [PrintedOn]" +
                        ", [EmpName], [PayPoint], [PIN], [NHIFNo], [NSSFNo], [Department], [EmpGroup], [EmpPayroll]" +
                        ", [CompName], [CompAddr], [CompTel], [PayeTax], [BasicPay], [Benefits], [Variables]" +
                        ", [OtherDeductions], [GrossTaxableEarnings], [NetTaxableEarnings], [MortgageRelief]" +
                        ", [InsuranceRelief], [GrossTax], [PersonalRelief], [PensionEmployer], [EmployerNSSF]" +
                        ", [PensionEmployee], [BankBranch], [Account], [NSSF], [NHIF], [NetPay] " +
                "FROM dbo.PayslipMaster_Temp  " +
                "WHERE [Period]=@Period " +
                      "AND [Year]=@Year " +
                      "AND [EmpNo]=@EmpNo ";

            PayslipMaster_Temp payslipMaster_Temp = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Period", DbType.Int32, period);
                db.AddInParameter(cmd, "@Year", DbType.Int32, year);
                db.AddInParameter(cmd, "@EmpNo", DbType.String, empNo);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new PayslipMaster_Temp
                        payslipMaster_Temp = new PayslipMaster_Temp();

                        // Read values.
                        payslipMaster_Temp.Period = base.GetDataValue<int>(dr, "Period");
                        payslipMaster_Temp.Year = base.GetDataValue<int>(dr, "Year");
                        payslipMaster_Temp.EmpNo = base.GetDataValue<string>(dr, "EmpNo");
                        payslipMaster_Temp.EmployeeId = base.GetDataValue<int>(dr, "EmployeeId");
                        payslipMaster_Temp.PaymentDate = base.GetDataValue<DateTime>(dr, "PaymentDate");
                        payslipMaster_Temp.PrintedBy = base.GetDataValue<string>(dr, "PrintedBy");
                        payslipMaster_Temp.PrintedOn = base.GetDataValue<DateTime>(dr, "PrintedOn");
                        payslipMaster_Temp.EmpName = base.GetDataValue<string>(dr, "EmpName");
                        payslipMaster_Temp.PayPoint = base.GetDataValue<string>(dr, "PayPoint");
                        payslipMaster_Temp.PIN = base.GetDataValue<string>(dr, "PIN");
                        payslipMaster_Temp.NHIFNo = base.GetDataValue<string>(dr, "NHIFNo");
                        payslipMaster_Temp.NSSFNo = base.GetDataValue<string>(dr, "NSSFNo");
                        payslipMaster_Temp.Department = base.GetDataValue<string>(dr, "Department");
                        payslipMaster_Temp.EmpGroup = base.GetDataValue<string>(dr, "EmpGroup");
                        payslipMaster_Temp.EmpPayroll = base.GetDataValue<string>(dr, "EmpPayroll");
                        payslipMaster_Temp.CompName = base.GetDataValue<string>(dr, "CompName");
                        payslipMaster_Temp.CompAddr = base.GetDataValue<string>(dr, "CompAddr");
                        payslipMaster_Temp.CompTel = base.GetDataValue<string>(dr, "CompTel");
                        payslipMaster_Temp.PayeTax = base.GetDataValue<decimal>(dr, "PayeTax");
                        payslipMaster_Temp.BasicPay = base.GetDataValue<decimal>(dr, "BasicPay");
                        payslipMaster_Temp.Benefits = base.GetDataValue<decimal>(dr, "Benefits");
                        payslipMaster_Temp.Variables = base.GetDataValue<decimal>(dr, "Variables");
                        payslipMaster_Temp.OtherDeductions = base.GetDataValue<decimal>(dr, "OtherDeductions");
                        payslipMaster_Temp.GrossTaxableEarnings = base.GetDataValue<decimal>(dr, "GrossTaxableEarnings");
                        payslipMaster_Temp.NetTaxableEarnings = base.GetDataValue<decimal>(dr, "NetTaxableEarnings");
                        payslipMaster_Temp.MortgageRelief = base.GetDataValue<decimal>(dr, "MortgageRelief");
                        payslipMaster_Temp.InsuranceRelief = base.GetDataValue<decimal>(dr, "InsuranceRelief");
                        payslipMaster_Temp.GrossTax = base.GetDataValue<decimal>(dr, "GrossTax");
                        payslipMaster_Temp.PersonalRelief = base.GetDataValue<decimal>(dr, "PersonalRelief");
                        payslipMaster_Temp.PensionEmployer = base.GetDataValue<decimal>(dr, "PensionEmployer");
                        payslipMaster_Temp.EmployerNSSF = base.GetDataValue<decimal>(dr, "EmployerNSSF");
                        payslipMaster_Temp.PensionEmployee = base.GetDataValue<decimal>(dr, "PensionEmployee");
                        payslipMaster_Temp.BankBranch = base.GetDataValue<string>(dr, "BankBranch");
                        payslipMaster_Temp.Account = base.GetDataValue<string>(dr, "Account");
                        payslipMaster_Temp.NSSF = base.GetDataValue<decimal>(dr, "NSSF");
                        payslipMaster_Temp.NHIF = base.GetDataValue<decimal>(dr, "NHIF");
                        payslipMaster_Temp.NetPay = base.GetDataValue<decimal>(dr, "NetPay");
                    }
                }
            }

            return payslipMaster_Temp;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the PayslipMaster_Temp table.
        /// </summary>
        /// <returns>A collection of PayslipMaster_Temp objects.</returns>		
        public List<PayslipMaster_Temp> Select()
        {
            // WARNING! The following SQL query does not contain a WHERE condition.
            // You are advised to include a WHERE condition to prevent any performance
            // issues when querying large resultsets.
            const string SQL_STATEMENT =
                "SELECT [Period], [Year], [EmpNo], [EmployeeId], [PaymentDate], [PrintedBy], [PrintedOn]" +
                        ", [EmpName], [PayPoint], [PIN], [NHIFNo], [NSSFNo], [Department], [EmpGroup], [EmpPayroll]" +
                        ", [CompName], [CompAddr], [CompTel], [PayeTax], [BasicPay], [Benefits], [Variables]" +
                        ", [OtherDeductions], [GrossTaxableEarnings], [NetTaxableEarnings], [MortgageRelief]" +
                        ", [InsuranceRelief], [GrossTax], [PersonalRelief], [PensionEmployer], [EmployerNSSF]" +
                        ", [PensionEmployee], [BankBranch], [Account], [NSSF], [NHIF], [NetPay] " +
                "FROM dbo.PayslipMaster_Temp ";

            List<PayslipMaster_Temp> result = new List<PayslipMaster_Temp>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new PayslipMaster_Temp
                        PayslipMaster_Temp payslipMaster_Temp = new PayslipMaster_Temp();

                        // Read values.
                        payslipMaster_Temp.Period = base.GetDataValue<int>(dr, "Period");
                        payslipMaster_Temp.Year = base.GetDataValue<int>(dr, "Year");
                        payslipMaster_Temp.EmpNo = base.GetDataValue<string>(dr, "EmpNo");
                        payslipMaster_Temp.EmployeeId = base.GetDataValue<int>(dr, "EmployeeId");
                        payslipMaster_Temp.PaymentDate = base.GetDataValue<DateTime>(dr, "PaymentDate");
                        payslipMaster_Temp.PrintedBy = base.GetDataValue<string>(dr, "PrintedBy");
                        payslipMaster_Temp.PrintedOn = base.GetDataValue<DateTime>(dr, "PrintedOn");
                        payslipMaster_Temp.EmpName = base.GetDataValue<string>(dr, "EmpName");
                        payslipMaster_Temp.PayPoint = base.GetDataValue<string>(dr, "PayPoint");
                        payslipMaster_Temp.PIN = base.GetDataValue<string>(dr, "PIN");
                        payslipMaster_Temp.NHIFNo = base.GetDataValue<string>(dr, "NHIFNo");
                        payslipMaster_Temp.NSSFNo = base.GetDataValue<string>(dr, "NSSFNo");
                        payslipMaster_Temp.Department = base.GetDataValue<string>(dr, "Department");
                        payslipMaster_Temp.EmpGroup = base.GetDataValue<string>(dr, "EmpGroup");
                        payslipMaster_Temp.EmpPayroll = base.GetDataValue<string>(dr, "EmpPayroll");
                        payslipMaster_Temp.CompName = base.GetDataValue<string>(dr, "CompName");
                        payslipMaster_Temp.CompAddr = base.GetDataValue<string>(dr, "CompAddr");
                        payslipMaster_Temp.CompTel = base.GetDataValue<string>(dr, "CompTel");
                        payslipMaster_Temp.PayeTax = base.GetDataValue<decimal>(dr, "PayeTax");
                        payslipMaster_Temp.BasicPay = base.GetDataValue<decimal>(dr, "BasicPay");
                        payslipMaster_Temp.Benefits = base.GetDataValue<decimal>(dr, "Benefits");
                        payslipMaster_Temp.Variables = base.GetDataValue<decimal>(dr, "Variables");
                        payslipMaster_Temp.OtherDeductions = base.GetDataValue<decimal>(dr, "OtherDeductions");
                        payslipMaster_Temp.GrossTaxableEarnings = base.GetDataValue<decimal>(dr, "GrossTaxableEarnings");
                        payslipMaster_Temp.NetTaxableEarnings = base.GetDataValue<decimal>(dr, "NetTaxableEarnings");
                        payslipMaster_Temp.MortgageRelief = base.GetDataValue<decimal>(dr, "MortgageRelief");
                        payslipMaster_Temp.InsuranceRelief = base.GetDataValue<decimal>(dr, "InsuranceRelief");
                        payslipMaster_Temp.GrossTax = base.GetDataValue<decimal>(dr, "GrossTax");
                        payslipMaster_Temp.PersonalRelief = base.GetDataValue<decimal>(dr, "PersonalRelief");
                        payslipMaster_Temp.PensionEmployer = base.GetDataValue<decimal>(dr, "PensionEmployer");
                        payslipMaster_Temp.EmployerNSSF = base.GetDataValue<decimal>(dr, "EmployerNSSF");
                        payslipMaster_Temp.PensionEmployee = base.GetDataValue<decimal>(dr, "PensionEmployee");
                        payslipMaster_Temp.BankBranch = base.GetDataValue<string>(dr, "BankBranch");
                        payslipMaster_Temp.Account = base.GetDataValue<string>(dr, "Account");
                        payslipMaster_Temp.NSSF = base.GetDataValue<decimal>(dr, "NSSF");
                        payslipMaster_Temp.NHIF = base.GetDataValue<decimal>(dr, "NHIF");
                        payslipMaster_Temp.NetPay = base.GetDataValue<decimal>(dr, "NetPay");

                        // Add to List.
                        result.Add(payslipMaster_Temp);
                    }
                }
            }

            return result;
        }
    }
}
