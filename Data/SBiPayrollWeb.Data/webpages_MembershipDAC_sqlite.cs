using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SBiPayrollWeb.Entities;

namespace SBiPayrollWeb.Data
{
    /// <summary>
    /// webpages_Membership data access component. Manages CRUD operations for the webpages_Membership table.
    /// </summary>
    public partial class webpages_MembershipDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the webpages_Membership table.
        /// </summary>
        /// <param name="webpages_Membership">A webpages_Membership object.</param>
        /// <returns>An updated webpages_Membership object.</returns>
        public webpages_Membership Create(webpages_Membership webpages_Membership)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) " +
                "VALUES(@UserId, @CreateDate, @ConfirmationToken, @IsConfirmed, @LastPasswordFailureDate, @PasswordFailuresSinceLastSuccess, @Password, @PasswordChangedDate, @PasswordSalt, @PasswordVerificationToken, @PasswordVerificationTokenExpirationDate);";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@UserId", DbType.Int32, webpages_Membership.UserId);
                db.AddInParameter(cmd, "@CreateDate", DbType.DateTime, webpages_Membership.CreateDate);
                db.AddInParameter(cmd, "@ConfirmationToken", DbType.String, webpages_Membership.ConfirmationToken);
                db.AddInParameter(cmd, "@IsConfirmed", DbType.Boolean, webpages_Membership.IsConfirmed);
                db.AddInParameter(cmd, "@LastPasswordFailureDate", DbType.DateTime, webpages_Membership.LastPasswordFailureDate);
                db.AddInParameter(cmd, "@PasswordFailuresSinceLastSuccess", DbType.Int32, webpages_Membership.PasswordFailuresSinceLastSuccess);
                db.AddInParameter(cmd, "@Password", DbType.String, webpages_Membership.Password);
                db.AddInParameter(cmd, "@PasswordChangedDate", DbType.DateTime, webpages_Membership.PasswordChangedDate);
                db.AddInParameter(cmd, "@PasswordSalt", DbType.String, webpages_Membership.PasswordSalt);
                db.AddInParameter(cmd, "@PasswordVerificationToken", DbType.String, webpages_Membership.PasswordVerificationToken);
                db.AddInParameter(cmd, "@PasswordVerificationTokenExpirationDate", DbType.DateTime, webpages_Membership.PasswordVerificationTokenExpirationDate);

                db.ExecuteNonQuery(cmd);
            }

            return webpages_Membership;
        }

        /// <summary>
        /// Updates an existing row in the webpages_Membership table.
        /// </summary>
        /// <param name="webpages_Membership">A webpages_Membership entity object.</param>
        public void UpdateById(webpages_Membership webpages_Membership)
        {
            const string SQL_STATEMENT =
                "UPDATE [webpages_Membership] " +
                "SET " +
                    "[CreateDate]=@CreateDate, " +
                    "[ConfirmationToken]=@ConfirmationToken, " +
                    "[IsConfirmed]=@IsConfirmed, " +
                    "[LastPasswordFailureDate]=@LastPasswordFailureDate, " +
                    "[PasswordFailuresSinceLastSuccess]=@PasswordFailuresSinceLastSuccess, " +
                    "[Password]=@Password, " +
                    "[PasswordChangedDate]=@PasswordChangedDate, " +
                    "[PasswordSalt]=@PasswordSalt, " +
                    "[PasswordVerificationToken]=@PasswordVerificationToken, " +
                    "[PasswordVerificationTokenExpirationDate]=@PasswordVerificationTokenExpirationDate " +
                "WHERE [UserId]=@UserId ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@CreateDate", DbType.DateTime, webpages_Membership.CreateDate);
                db.AddInParameter(cmd, "@ConfirmationToken", DbType.String, webpages_Membership.ConfirmationToken);
                db.AddInParameter(cmd, "@IsConfirmed", DbType.Boolean, webpages_Membership.IsConfirmed);
                db.AddInParameter(cmd, "@LastPasswordFailureDate", DbType.DateTime, webpages_Membership.LastPasswordFailureDate);
                db.AddInParameter(cmd, "@PasswordFailuresSinceLastSuccess", DbType.Int32, webpages_Membership.PasswordFailuresSinceLastSuccess);
                db.AddInParameter(cmd, "@Password", DbType.String, webpages_Membership.Password);
                db.AddInParameter(cmd, "@PasswordChangedDate", DbType.DateTime, webpages_Membership.PasswordChangedDate);
                db.AddInParameter(cmd, "@PasswordSalt", DbType.String, webpages_Membership.PasswordSalt);
                db.AddInParameter(cmd, "@PasswordVerificationToken", DbType.String, webpages_Membership.PasswordVerificationToken);
                db.AddInParameter(cmd, "@PasswordVerificationTokenExpirationDate", DbType.DateTime, webpages_Membership.PasswordVerificationTokenExpirationDate);
                db.AddInParameter(cmd, "@UserId", DbType.Int32, webpages_Membership.UserId);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the webpages_Membership table.
        /// </summary>
        /// <param name="userId">A userId value.</param>
        public void DeleteById(int userId)
        {
            const string SQL_STATEMENT = "DELETE FROM [webpages_Membership] " +
                                         "WHERE [UserId]=@UserId ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@UserId", DbType.Int32, userId);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Returns a row from the webpages_Membership table.
        /// </summary>
        /// <param name="userId">A UserId value.</param>
        /// <returns>A webpages_Membership object with data populated from the database.</returns>
        public webpages_Membership SelectById(int userId)
        {
            const string SQL_STATEMENT =
                "SELECT [UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate]" +
                        ", [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt]" +
                        ", [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate] " +
                "FROM [webpages_Membership] " +
                "WHERE [UserId]=@UserId ";

            webpages_Membership webpages_Membership = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@UserId", DbType.Int32, userId);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new webpages_Membership
                        webpages_Membership = new webpages_Membership();

                        // Read values.
                        webpages_Membership.UserId = base.GetDataValue<int>(dr, "UserId");
                        webpages_Membership.CreateDate = base.GetDataValue<DateTime>(dr, "CreateDate");
                        webpages_Membership.ConfirmationToken = base.GetDataValue<string>(dr, "ConfirmationToken");
                        webpages_Membership.IsConfirmed = base.GetDataValue<bool>(dr, "IsConfirmed");
                        webpages_Membership.LastPasswordFailureDate = base.GetDataValue<DateTime>(dr, "LastPasswordFailureDate");
                        webpages_Membership.PasswordFailuresSinceLastSuccess = base.GetDataValue<int>(dr, "PasswordFailuresSinceLastSuccess");
                        webpages_Membership.Password = base.GetDataValue<string>(dr, "Password");
                        webpages_Membership.PasswordChangedDate = base.GetDataValue<DateTime>(dr, "PasswordChangedDate");
                        webpages_Membership.PasswordSalt = base.GetDataValue<string>(dr, "PasswordSalt");
                        webpages_Membership.PasswordVerificationToken = base.GetDataValue<string>(dr, "PasswordVerificationToken");
                        webpages_Membership.PasswordVerificationTokenExpirationDate = base.GetDataValue<DateTime>(dr, "PasswordVerificationTokenExpirationDate");
                    }
                }
            }

            return webpages_Membership;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the webpages_Membership table.
        /// </summary>
        /// <returns>A collection of webpages_Membership objects.</returns>		
        public List<webpages_Membership> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate]" +
                        ", [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt]" +
                        ", [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate] " +
                "FROM [webpages_Membership] ";

            List<webpages_Membership> result = new List<webpages_Membership>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new webpages_Membership
                        webpages_Membership webpages_Membership = new webpages_Membership();

                        // Read values.
                        webpages_Membership.UserId = base.GetDataValue<int>(dr, "UserId");
                        webpages_Membership.CreateDate = base.GetDataValue<DateTime>(dr, "CreateDate");
                        webpages_Membership.ConfirmationToken = base.GetDataValue<string>(dr, "ConfirmationToken");
                        webpages_Membership.IsConfirmed = base.GetDataValue<bool>(dr, "IsConfirmed");
                        webpages_Membership.LastPasswordFailureDate = base.GetDataValue<DateTime>(dr, "LastPasswordFailureDate");
                        webpages_Membership.PasswordFailuresSinceLastSuccess = base.GetDataValue<int>(dr, "PasswordFailuresSinceLastSuccess");
                        webpages_Membership.Password = base.GetDataValue<string>(dr, "Password");
                        webpages_Membership.PasswordChangedDate = base.GetDataValue<DateTime>(dr, "PasswordChangedDate");
                        webpages_Membership.PasswordSalt = base.GetDataValue<string>(dr, "PasswordSalt");
                        webpages_Membership.PasswordVerificationToken = base.GetDataValue<string>(dr, "PasswordVerificationToken");
                        webpages_Membership.PasswordVerificationTokenExpirationDate = base.GetDataValue<DateTime>(dr, "PasswordVerificationTokenExpirationDate");

                        // Add to List.
                        result.Add(webpages_Membership);
                    }
                }
            }

            return result;
        }
    }
}

