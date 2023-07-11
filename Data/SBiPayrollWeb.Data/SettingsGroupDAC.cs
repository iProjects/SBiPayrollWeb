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
    /// SettingsGroup data access component. Manages CRUD operations for the SettingsGroup table.
    /// </summary>
    public partial class SettingsGroupDAC : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the SettingsGroup table.
        /// </summary>
        /// <param name="settingsGroup">A SettingsGroup object.</param>
        /// <returns>An updated SettingsGroup object.</returns>
        public SettingsGroup Create(SettingsGroup settingsGroup)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.SettingsGroup ([GroupName], [Parent]) " +
                "VALUES(@GroupName, @Parent); SELECT SCOPE_IDENTITY();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@GroupName", DbType.String, settingsGroup.GroupName);
                db.AddInParameter(cmd, "@Parent", DbType.Int32, settingsGroup.Parent);

                // Get the primary key value.
                settingsGroup.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return settingsGroup;
        }

        /// <summary>
        /// Updates an existing row in the SettingsGroup table.
        /// </summary>
        /// <param name="settingsGroup">A SettingsGroup entity object.</param>
        public void UpdateById(SettingsGroup settingsGroup)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.SettingsGroup " +
                "SET " +
                    "[GroupName]=@GroupName, " +
                    "[Parent]=@Parent " +
                "WHERE [Id]=@Id ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@GroupName", DbType.String, settingsGroup.GroupName);
                db.AddInParameter(cmd, "@Parent", DbType.Int32, settingsGroup.Parent);
                db.AddInParameter(cmd, "@Id", DbType.Int32, settingsGroup.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the SettingsGroup table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.SettingsGroup " +
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
        /// Returns a row from the SettingsGroup table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A SettingsGroup object with data populated from the database.</returns>
        public SettingsGroup SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [GroupName], [Parent] " +
                "FROM dbo.SettingsGroup  " +
                "WHERE [Id]=@Id ";

            SettingsGroup settingsGroup = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new SettingsGroup
                        settingsGroup = new SettingsGroup();

                        // Read values.
                        settingsGroup.Id = base.GetDataValue<int>(dr, "Id");
                        settingsGroup.GroupName = base.GetDataValue<string>(dr, "GroupName");
                        settingsGroup.Parent = base.GetDataValue<int>(dr, "Parent");
                    }
                }
            }

            return settingsGroup;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the SettingsGroup table.
        /// </summary>
        /// <returns>A collection of SettingsGroup objects.</returns>		
        public List<SettingsGroup> Select()
        {
            // WARNING! The following SQL query does not contain a WHERE condition.
            // You are advised to include a WHERE condition to prevent any performance
            // issues when querying large resultsets.
            const string SQL_STATEMENT =
                "SELECT [Id], [GroupName], [Parent] " +
                "FROM dbo.SettingsGroup ";

            List<SettingsGroup> result = new List<SettingsGroup>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new SettingsGroup
                        SettingsGroup settingsGroup = new SettingsGroup();

                        // Read values.
                        settingsGroup.Id = base.GetDataValue<int>(dr, "Id");
                        settingsGroup.GroupName = base.GetDataValue<string>(dr, "GroupName");
                        settingsGroup.Parent = base.GetDataValue<int>(dr, "Parent");

                        // Add to List.
                        result.Add(settingsGroup);
                    }
                }
            }

            return result;
        }
    }
}

