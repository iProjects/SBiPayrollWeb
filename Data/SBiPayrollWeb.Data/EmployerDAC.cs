//====================================================================================================
// Base code generated with Momentum: DAC Gen (Build 2.5.5049.15162)
// Layered Architecture Solution Guidance (http://layerguidance.codeplex.com)
//
// Generated by Administrator at SAPSERVER on 01/13/2015 06:35:39 
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
    /// Employers data access component. Manages CRUD operations for the Employers table.
    /// </summary>
    public partial class EmployerDAC : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the Employers table.
        /// </summary>
        /// <param name="employer">A Employer object.</param>
        /// <returns>An updated Employer object.</returns>
        public Employer Create(Employer employer)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.Employers ([Name], [Email], [Telephone], [Address1], [Address2], [Slogan], [AuthorizedSignatory], [PIN], [NHIF], [NSSF], [BankBranchSortCode], [AccountName], [AccountNo], [Logo], [IsDefault], [IsActive], [IsDeleted]) " +
                "VALUES(@Name, @Email, @Telephone, @Address1, @Address2, @Slogan, @AuthorizedSignatory, @PIN, @NHIF, @NSSF, @BankBranchSortCode, @AccountName, @AccountNo, @Logo, @IsDefault, @IsActive, @IsDeleted); SELECT SCOPE_IDENTITY();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@Name", DbType.String, employer.Name);
                db.AddInParameter(cmd, "@Email", DbType.String, employer.Email);
                db.AddInParameter(cmd, "@Telephone", DbType.String, employer.Telephone);
                db.AddInParameter(cmd, "@Address1", DbType.String, employer.Address1);
                db.AddInParameter(cmd, "@Address2", DbType.String, employer.Address2);
                db.AddInParameter(cmd, "@Slogan", DbType.String, employer.Slogan);
                db.AddInParameter(cmd, "@AuthorizedSignatory", DbType.String, employer.AuthorizedSignatory);
                db.AddInParameter(cmd, "@PIN", DbType.String, employer.PIN);
                db.AddInParameter(cmd, "@NHIF", DbType.String, employer.NHIF);
                db.AddInParameter(cmd, "@NSSF", DbType.String, employer.NSSF);
                db.AddInParameter(cmd, "@BankBranchSortCode", DbType.String, employer.BankBranchSortCode);
                db.AddInParameter(cmd, "@AccountName", DbType.String, employer.AccountName);
                db.AddInParameter(cmd, "@AccountNo", DbType.String, employer.AccountNo);
                db.AddInParameter(cmd, "@Logo", DbType.String, employer.Logo);
                db.AddInParameter(cmd, "@IsDefault", DbType.Boolean, employer.IsDefault);
                db.AddInParameter(cmd, "@IsActive", DbType.Boolean, employer.IsActive);
                db.AddInParameter(cmd, "@IsDeleted", DbType.Boolean, employer.IsDeleted);

                // Get the primary key value.
                employer.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return employer;
        }

        /// <summary>
        /// Updates an existing row in the Employers table.
        /// </summary>
        /// <param name="employer">A Employer entity object.</param>
        public void UpdateById(Employer employer)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.Employers " +
                "SET " +
                    "[Name]=@Name, " +
                    "[Email]=@Email, " +
                    "[Telephone]=@Telephone, " +
                    "[Address1]=@Address1, " +
                    "[Address2]=@Address2, " +
                    "[Slogan]=@Slogan, " +
                    "[AuthorizedSignatory]=@AuthorizedSignatory, " +
                    "[PIN]=@PIN, " +
                    "[NHIF]=@NHIF, " +
                    "[NSSF]=@NSSF, " +
                    "[BankBranchSortCode]=@BankBranchSortCode, " +
                    "[AccountName]=@AccountName, " +
                    "[AccountNo]=@AccountNo, " +
                    "[Logo]=@Logo, " +
                    "[IsDefault]=@IsDefault, " +
                    "[IsActive]=@IsActive, " +
                    "[IsDeleted]=@IsDeleted " +
                "WHERE [Id]=@Id ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@Name", DbType.String, employer.Name);
                db.AddInParameter(cmd, "@Email", DbType.String, employer.Email);
                db.AddInParameter(cmd, "@Telephone", DbType.String, employer.Telephone);
                db.AddInParameter(cmd, "@Address1", DbType.String, employer.Address1);
                db.AddInParameter(cmd, "@Address2", DbType.String, employer.Address2);
                db.AddInParameter(cmd, "@Slogan", DbType.String, employer.Slogan);
                db.AddInParameter(cmd, "@AuthorizedSignatory", DbType.String, employer.AuthorizedSignatory);
                db.AddInParameter(cmd, "@PIN", DbType.String, employer.PIN);
                db.AddInParameter(cmd, "@NHIF", DbType.String, employer.NHIF);
                db.AddInParameter(cmd, "@NSSF", DbType.String, employer.NSSF);
                db.AddInParameter(cmd, "@BankBranchSortCode", DbType.String, employer.BankBranchSortCode);
                db.AddInParameter(cmd, "@AccountName", DbType.String, employer.AccountName);
                db.AddInParameter(cmd, "@AccountNo", DbType.String, employer.AccountNo);
                db.AddInParameter(cmd, "@Logo", DbType.String, employer.Logo);
                db.AddInParameter(cmd, "@IsDefault", DbType.Boolean, employer.IsDefault);
                db.AddInParameter(cmd, "@IsActive", DbType.Boolean, employer.IsActive);
                db.AddInParameter(cmd, "@IsDeleted", DbType.Boolean, employer.IsDeleted);
                db.AddInParameter(cmd, "@Id", DbType.Int32, employer.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the Employers table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.Employers " +
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
        /// Returns a row from the Employers table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A Employer object with data populated from the database.</returns>
        public Employer SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Name], [Email], [Telephone], [Address1], [Address2], [Slogan], [AuthorizedSignatory]" +
                        ", [PIN], [NHIF], [NSSF], [BankBranchSortCode], [AccountName], [AccountNo], [Logo]" +
                        ", [IsDefault], [IsActive], [IsDeleted] " +
                "FROM dbo.Employers  " +
                "WHERE [Id]=@Id ";

            Employer employer = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new Employer
                        employer = new Employer();

                        // Read values.
                        employer.Id = base.GetDataValue<int>(dr, "Id");
                        employer.Name = base.GetDataValue<string>(dr, "Name");
                        employer.Email = base.GetDataValue<string>(dr, "Email");
                        employer.Telephone = base.GetDataValue<string>(dr, "Telephone");
                        employer.Address1 = base.GetDataValue<string>(dr, "Address1");
                        employer.Address2 = base.GetDataValue<string>(dr, "Address2");
                        employer.Slogan = base.GetDataValue<string>(dr, "Slogan");
                        employer.AuthorizedSignatory = base.GetDataValue<string>(dr, "AuthorizedSignatory");
                        employer.PIN = base.GetDataValue<string>(dr, "PIN");
                        employer.NHIF = base.GetDataValue<string>(dr, "NHIF");
                        employer.NSSF = base.GetDataValue<string>(dr, "NSSF");
                        employer.BankBranchSortCode = base.GetDataValue<string>(dr, "BankBranchSortCode");
                        employer.AccountName = base.GetDataValue<string>(dr, "AccountName");
                        employer.AccountNo = base.GetDataValue<string>(dr, "AccountNo");
                        employer.Logo = base.GetDataValue<string>(dr, "Logo");
                        employer.IsDefault = base.GetDataValue<bool>(dr, "IsDefault");
                        employer.IsActive = base.GetDataValue<bool>(dr, "IsActive");
                        employer.IsDeleted = base.GetDataValue<bool>(dr, "IsDeleted");
                    }
                }
            }

            return employer;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the Employers table.
        /// </summary>
        /// <returns>A collection of Employer objects.</returns>		
        public List<Employer> Select()
        {
            // WARNING! The following SQL query does not contain a WHERE condition.
            // You are advised to include a WHERE condition to prevent any performance
            // issues when querying large resultsets.
            const string SQL_STATEMENT =
                "SELECT [Id], [Name], [Email], [Telephone], [Address1], [Address2], [Slogan], [AuthorizedSignatory]" +
                        ", [PIN], [NHIF], [NSSF], [BankBranchSortCode], [AccountName], [AccountNo], [Logo]" +
                        ", [IsDefault], [IsActive], [IsDeleted] " +
                "FROM dbo.Employers ";

            List<Employer> result = new List<Employer>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new Employer
                        Employer employer = new Employer();

                        // Read values.
                        employer.Id = base.GetDataValue<int>(dr, "Id");
                        employer.Name = base.GetDataValue<string>(dr, "Name");
                        employer.Email = base.GetDataValue<string>(dr, "Email");
                        employer.Telephone = base.GetDataValue<string>(dr, "Telephone");
                        employer.Address1 = base.GetDataValue<string>(dr, "Address1");
                        employer.Address2 = base.GetDataValue<string>(dr, "Address2");
                        employer.Slogan = base.GetDataValue<string>(dr, "Slogan");
                        employer.AuthorizedSignatory = base.GetDataValue<string>(dr, "AuthorizedSignatory");
                        employer.PIN = base.GetDataValue<string>(dr, "PIN");
                        employer.NHIF = base.GetDataValue<string>(dr, "NHIF");
                        employer.NSSF = base.GetDataValue<string>(dr, "NSSF");
                        employer.BankBranchSortCode = base.GetDataValue<string>(dr, "BankBranchSortCode");
                        employer.AccountName = base.GetDataValue<string>(dr, "AccountName");
                        employer.AccountNo = base.GetDataValue<string>(dr, "AccountNo");
                        employer.Logo = base.GetDataValue<string>(dr, "Logo");
                        employer.IsDefault = base.GetDataValue<bool>(dr, "IsDefault");
                        employer.IsActive = base.GetDataValue<bool>(dr, "IsActive");
                        employer.IsDeleted = base.GetDataValue<bool>(dr, "IsDeleted");

                        // Add to List.
                        result.Add(employer);
                    }
                }
            }

            return result;
        }
    }
}

