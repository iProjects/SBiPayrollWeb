using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SBiPayrollWeb.Entities;

namespace SBiPayrollWeb.Data
{
    /// <summary>
    /// spUsers data access component. Manages CRUD operations for the spUsers table.
    /// </summary>
    public partial class spUserDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the spUsers table.
        /// </summary>
        /// <param name="spUser">A spUser object.</param>
        /// <returns>An updated spUser object.</returns>
        public spUser Create(spUser spUser)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [spUsers] ([RoleId], [UserName], [Password], [Status], [Locked], [IsDeleted], [SystemId], [Surname], [OtherNames], [DateOfBirth], [Gender], [Telephone], [Email], [DateJoined], [InformBy], [Photo], [NationalID], [password_hash], [password_salt]) " +
                "VALUES(@RoleId, @UserName, @Password, @Status, @Locked, @IsDeleted, @SystemId, @Surname, @OtherNames, @DateOfBirth, @Gender, @Telephone, @Email, @DateJoined, @InformBy, @Photo, @NationalID, @password_hash, @password_salt); SELECT last_insert_rowid();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, spUser.RoleId);
                db.AddInParameter(cmd, "@UserName", DbType.String, spUser.UserName);
                db.AddInParameter(cmd, "@Password", DbType.String, spUser.Password);
                db.AddInParameter(cmd, "@Status", DbType.String, spUser.Status);
                db.AddInParameter(cmd, "@Locked", DbType.Boolean, spUser.Locked);
                db.AddInParameter(cmd, "@IsDeleted", DbType.Boolean, spUser.IsDeleted);
                db.AddInParameter(cmd, "@SystemId", DbType.String, spUser.SystemId);
                db.AddInParameter(cmd, "@Surname", DbType.String, spUser.Surname);
                db.AddInParameter(cmd, "@OtherNames", DbType.String, spUser.OtherNames);
                db.AddInParameter(cmd, "@DateOfBirth", DbType.Date, spUser.DateOfBirth);
                db.AddInParameter(cmd, "@Gender", DbType.String, spUser.Gender);
                db.AddInParameter(cmd, "@Telephone", DbType.String, spUser.Telephone);
                db.AddInParameter(cmd, "@Email", DbType.String, spUser.Email);
                db.AddInParameter(cmd, "@DateJoined", DbType.Date, spUser.DateJoined);
                db.AddInParameter(cmd, "@InformBy", DbType.String, spUser.InformBy);
                db.AddInParameter(cmd, "@Photo", DbType.String, spUser.Photo);
                db.AddInParameter(cmd, "@NationalID", DbType.String, spUser.NationalID);
                db.AddInParameter(cmd, "@password_hash", DbType.String, spUser.password_hash);
                db.AddInParameter(cmd, "@password_salt", DbType.String, spUser.password_salt);

                // Get the primary key value.
                spUser.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return spUser;
        }

        /// <summary>
        /// Updates an existing row in the spUsers table.
        /// </summary>
        /// <param name="spUser">A spUser entity object.</param>
        public void UpdateById(spUser spUser)
        {
            const string SQL_STATEMENT =
                "UPDATE [spUsers] " +
                "SET " +
                    "[RoleId]=@RoleId, " +
                    "[UserName]=@UserName, " +
                    "[Password]=@Password, " +
                    "[Status]=@Status, " +
                    "[Locked]=@Locked, " +
                    "[IsDeleted]=@IsDeleted, " +
                    "[SystemId]=@SystemId, " +
                    "[Surname]=@Surname, " +
                    "[OtherNames]=@OtherNames, " +
                    "[DateOfBirth]=@DateOfBirth, " +
                    "[Gender]=@Gender, " +
                    "[Telephone]=@Telephone, " +
                    "[Email]=@Email, " +
                    "[DateJoined]=@DateJoined, " +
                    "[InformBy]=@InformBy, " +
                    "[Photo]=@Photo, " +
                    "[NationalID]=@NationalID " +
                "WHERE [Id]=@Id ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, spUser.RoleId);
                db.AddInParameter(cmd, "@UserName", DbType.String, spUser.UserName);
                db.AddInParameter(cmd, "@Password", DbType.String, spUser.Password);
                db.AddInParameter(cmd, "@Status", DbType.String, spUser.Status);
                db.AddInParameter(cmd, "@Locked", DbType.Boolean, spUser.Locked);
                db.AddInParameter(cmd, "@IsDeleted", DbType.Boolean, spUser.IsDeleted);
                db.AddInParameter(cmd, "@SystemId", DbType.String, spUser.SystemId);
                db.AddInParameter(cmd, "@Surname", DbType.String, spUser.Surname);
                db.AddInParameter(cmd, "@OtherNames", DbType.String, spUser.OtherNames);
                db.AddInParameter(cmd, "@DateOfBirth", DbType.Date, spUser.DateOfBirth);
                db.AddInParameter(cmd, "@Gender", DbType.String, spUser.Gender);
                db.AddInParameter(cmd, "@Telephone", DbType.String, spUser.Telephone);
                db.AddInParameter(cmd, "@Email", DbType.String, spUser.Email);
                db.AddInParameter(cmd, "@DateJoined", DbType.Date, spUser.DateJoined);
                db.AddInParameter(cmd, "@InformBy", DbType.String, spUser.InformBy);
                db.AddInParameter(cmd, "@Photo", DbType.String, spUser.Photo);
                db.AddInParameter(cmd, "@NationalID", DbType.String, spUser.NationalID);
                db.AddInParameter(cmd, "@Id", DbType.Int32, spUser.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the spUsers table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE FROM [spUsers] " +
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
        /// Returns a row from the spUsers table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A spUser object with data populated from the database.</returns>
        public spUser SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [RoleId], [UserName], [Password], [Status], [Locked], [IsDeleted], [SystemId]" +
                        ", [Surname], [OtherNames], [DateOfBirth], [Gender], [Telephone], [Email], [DateJoined]" +
                        ", [InformBy], [Photo], [NationalID] " +
                "FROM [spUsers] " +
                "WHERE [Id]=@Id ";

            spUser spUser = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new spUser
                        spUser = new spUser();

                        // Read values.
                        spUser.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        spUser.RoleId = base.GetDataValue<int>(dr, "RoleId");
                        spUser.UserName = base.GetDataValue<string>(dr, "UserName");
                        spUser.Password = base.GetDataValue<string>(dr, "Password");
                        spUser.Status = base.GetDataValue<string>(dr, "Status");
                        spUser.Locked = base.GetDataValue<bool>(dr, "Locked");
                        spUser.IsDeleted = base.GetDataValue<bool>(dr, "IsDeleted");
                        spUser.SystemId = base.GetDataValue<string>(dr, "SystemId");
                        spUser.Surname = base.GetDataValue<string>(dr, "Surname");
                        spUser.OtherNames = base.GetDataValue<string>(dr, "OtherNames");
                        spUser.DateOfBirth = Convert.ToDateTime(base.GetDataValue<string>(dr, "DateOfBirth"));
                        spUser.Gender = base.GetDataValue<string>(dr, "Gender");
                        spUser.Telephone = base.GetDataValue<string>(dr, "Telephone");
                        spUser.Email = base.GetDataValue<string>(dr, "Email");
                        spUser.DateJoined = Convert.ToDateTime(base.GetDataValue<string>(dr, "DateJoined"));
                        spUser.InformBy = base.GetDataValue<string>(dr, "InformBy");
                        spUser.Photo = base.GetDataValue<string>(dr, "Photo");
                        spUser.NationalID = base.GetDataValue<string>(dr, "NationalID");
                    }
                }
            }

            return spUser;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the spUsers table.
        /// </summary>
        /// <returns>A collection of spUser objects.</returns>		
        public List<spUser> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [RoleId], [UserName], [Password], [Status], [Locked], [IsDeleted], [SystemId]" +
                        ", [Surname], [OtherNames], [DateOfBirth], [Gender], [Telephone], [Email], [DateJoined]" +
                        ", [InformBy], [Photo], [NationalID] " +
                "FROM [spUsers] ";

            List<spUser> result = new List<spUser>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new spUser
                        spUser spUser = new spUser();

                        // Read values.
                        spUser.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        spUser.RoleId = base.GetDataValue<int>(dr, "RoleId");
                        spUser.UserName = base.GetDataValue<string>(dr, "UserName");
                        spUser.Password = base.GetDataValue<string>(dr, "Password");
                        spUser.Status = base.GetDataValue<string>(dr, "Status");
                        spUser.Locked = base.GetDataValue<Boolean>(dr, "Locked");
                        spUser.IsDeleted = base.GetDataValue<Boolean>(dr, "IsDeleted");
                        spUser.SystemId = base.GetDataValue<string>(dr, "SystemId");
                        spUser.Surname = base.GetDataValue<string>(dr, "Surname");
                        spUser.OtherNames = base.GetDataValue<string>(dr, "OtherNames");
                        spUser.DateOfBirth = Convert.ToDateTime(base.GetDataValue<string>(dr, "DateOfBirth"));
                        spUser.Gender = base.GetDataValue<string>(dr, "Gender");
                        spUser.Telephone = base.GetDataValue<string>(dr, "Telephone");
                        spUser.Email = base.GetDataValue<string>(dr, "Email");
                        spUser.DateJoined = Convert.ToDateTime(base.GetDataValue<string>(dr, "DateJoined"));
                        spUser.InformBy = base.GetDataValue<string>(dr, "InformBy");
                        spUser.Photo = base.GetDataValue<string>(dr, "Photo");
                        spUser.NationalID = base.GetDataValue<string>(dr, "NationalID");

                        // Add to List.
                        result.Add(spUser);
                    }
                }
            }

            return result;
        }

        public spUser SelectByUserName(string userName)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [RoleId], [UserName], [Password], [Status], [Locked], [IsDeleted], [SystemId]" +
                ", [Surname], [OtherNames], [DateOfBirth], [Gender], [Telephone], [Email], [DateJoined]" +
                ", [InformBy], [Photo], [NationalID], [password_hash], [password_salt] " +
                "FROM [spUsers] " +
                "WHERE [UserName]=@UserName AND [IsDeleted]=0";

            spUser user = null;
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@UserName", DbType.String, userName);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        user = new spUser
                        {
                            Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id")),
                            RoleId = base.GetDataValue<int>(dr, "RoleId"),
                            UserName = base.GetDataValue<string>(dr, "UserName"),
                            Password = base.GetDataValue<string>(dr, "Password"),
                            Status = base.GetDataValue<string>(dr, "Status"),
                            Locked = base.GetDataValue<bool>(dr, "Locked"),
                            IsDeleted = base.GetDataValue<bool>(dr, "IsDeleted"),
                            SystemId = base.GetDataValue<string>(dr, "SystemId"),
                            Surname = base.GetDataValue<string>(dr, "Surname"),
                            OtherNames = base.GetDataValue<string>(dr, "OtherNames"),
                            DateOfBirth = Convert.ToDateTime(base.GetDataValue<string>(dr, "DateOfBirth")),
                            Gender = base.GetDataValue<string>(dr, "Gender"),
                            Telephone = base.GetDataValue<string>(dr, "Telephone"),
                            Email = base.GetDataValue<string>(dr, "Email"),
                            DateJoined = Convert.ToDateTime(base.GetDataValue<string>(dr, "DateJoined")),
                            InformBy = base.GetDataValue<string>(dr, "InformBy"),
                            Photo = base.GetDataValue<string>(dr, "Photo"),
                            NationalID = base.GetDataValue<string>(dr, "NationalID"),
                            password_hash = base.GetDataValue<string>(dr, "password_hash"),
                            password_salt = base.GetDataValue<string>(dr, "password_salt")
                        };
                    }
                }
            }
            return user;
        }






    }
}