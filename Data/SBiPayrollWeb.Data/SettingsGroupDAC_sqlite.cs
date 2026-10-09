using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SBiPayrollWeb.Entities;

namespace SBiPayrollWeb.Data
{
    /// <summary>
    /// SettingsGroup data access component. Manages CRUD operations for the SettingsGroup table.
    /// </summary>
    public partial class SettingsGroupDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the SettingsGroup table.
        /// </summary>
        /// <param name="settingsGroup">A SettingsGroup object.</param>
        /// <returns>An updated SettingsGroup object.</returns>
        public SettingsGroup Create(SettingsGroup settingsGroup)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [SettingsGroup] ([GroupName], [Parent]) " +
                "VALUES(@GroupName, @Parent); SELECT last_insert_rowid();";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@GroupName", DbType.String, settingsGroup.GroupName);
                db.AddInParameter(cmd, "@Parent", DbType.Int32, settingsGroup.Parent);

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
                "UPDATE [SettingsGroup] " +
                "SET " +
                    "[GroupName]=@GroupName, " +
                    "[Parent]=@Parent " +
                "WHERE [Id]=@Id;";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
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
            const string SQL_STATEMENT = "DELETE FROM [SettingsGroup] WHERE [Id]=@Id;";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
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
                "FROM [SettingsGroup] " +
                "WHERE [Id]=@Id;";

            SettingsGroup settingsGroup = null;

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        settingsGroup = new SettingsGroup();
                        settingsGroup.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
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
            const string SQL_STATEMENT =
                "SELECT [Id], [GroupName], [Parent] " +
                "FROM [SettingsGroup];";

            List<SettingsGroup> result = new List<SettingsGroup>();

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        SettingsGroup settingsGroup = new SettingsGroup();
                        settingsGroup.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        settingsGroup.GroupName = base.GetDataValue<string>(dr, "GroupName");
                        settingsGroup.Parent = base.GetDataValue<int>(dr, "Parent");

                        result.Add(settingsGroup);
                    }
                }
            }

            return result;
        }
    }
}