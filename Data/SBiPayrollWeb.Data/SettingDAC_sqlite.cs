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
    /// Settings data access component. Manages CRUD operations for the Settings table.
    /// </summary>
    public partial class SettingDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the Settings table.
        /// </summary>
        /// <param name="setting">A Setting object.</param>
        /// <returns>An updated Setting object.</returns>
        public Setting Create(Setting setting)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) " +
                "VALUES(@SSKey, @SSValue, @SSValueType, @Description, @SGroup, @SSSystem);";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@SSKey", DbType.String, setting.SSKey);
                db.AddInParameter(cmd, "@SSValue", DbType.String, setting.SSValue);
                db.AddInParameter(cmd, "@SSValueType", DbType.String, setting.SSValueType);
                db.AddInParameter(cmd, "@Description", DbType.String, setting.Description);
                db.AddInParameter(cmd, "@SGroup", DbType.Int32, setting.SGroup);
                db.AddInParameter(cmd, "@SSSystem", DbType.Boolean, setting.SSSystem);

                db.ExecuteNonQuery(cmd);
            }

            return setting;
        }

        /// <summary>
        /// Updates an existing row in the Settings table.
        /// </summary>
        /// <param name="setting">A Setting entity object.</param>
        public void UpdateById(Setting setting)
        {
            const string SQL_STATEMENT =
                "UPDATE [Settings] " +
                "SET " +
                    "[SSValue]=@SSValue, " +
                    "[SSValueType]=@SSValueType, " +
                    "[Description]=@Description, " +
                    "[SGroup]=@SGroup, " +
                    "[SSSystem]=@SSSystem " +
                "WHERE [SSKey]=@SSKey;";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@SSValue", DbType.String, setting.SSValue);
                db.AddInParameter(cmd, "@SSValueType", DbType.String, setting.SSValueType);
                db.AddInParameter(cmd, "@Description", DbType.String, setting.Description);
                db.AddInParameter(cmd, "@SGroup", DbType.Int32, setting.SGroup);
                db.AddInParameter(cmd, "@SSSystem", DbType.Boolean, setting.SSSystem);
                db.AddInParameter(cmd, "@SSKey", DbType.String, setting.SSKey);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the Settings table.
        /// </summary>
        /// <param name="sSKey">A sSKey value.</param>
        public void DeleteById(string sSKey)
        {
            const string SQL_STATEMENT = "DELETE FROM [Settings] WHERE [SSKey]=@SSKey;";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@SSKey", DbType.String, sSKey);
                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Returns a row from the Settings table.
        /// </summary>
        /// <param name="sSKey">A SSKey value.</param>
        /// <returns>A Setting object with data populated from the database.</returns>
        public Setting SelectById(string sSKey)
        {
            const string SQL_STATEMENT =
                "SELECT [SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem] " +
                "FROM [Settings] " +
                "WHERE [SSKey]=@SSKey;";

            Setting setting = null;

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@SSKey", DbType.String, sSKey);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        setting = new Setting();
                        setting.SSKey = base.GetDataValue<string>(dr, "SSKey");
                        setting.SSValue = base.GetDataValue<string>(dr, "SSValue");
                        setting.SSValueType = base.GetDataValue<string>(dr, "SSValueType");
                        setting.Description = base.GetDataValue<string>(dr, "Description");
                        setting.SGroup = base.GetDataValue<int>(dr, "SGroup");
                        setting.SSSystem = base.GetDataValue<bool>(dr, "SSSystem");
                    }
                }
            }

            return setting;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the Settings table.
        /// </summary>
        /// <returns>A collection of Setting objects.</returns>		
        public List<Setting> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem] " +
                "FROM [Settings];";

            List<Setting> result = new List<Setting>();

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Setting setting = new Setting();
                        setting.SSKey = base.GetDataValue<string>(dr, "SSKey");
                        setting.SSValue = base.GetDataValue<string>(dr, "SSValue");
                        setting.SSValueType = base.GetDataValue<string>(dr, "SSValueType");
                        setting.Description = base.GetDataValue<string>(dr, "Description");
                        setting.SGroup = base.GetDataValue<int>(dr, "SGroup");
                        setting.SSSystem = base.GetDataValue<bool>(dr, "SSSystem");

                        result.Add(setting);
                    }
                }
            }

            return result;
        }
    }
}
