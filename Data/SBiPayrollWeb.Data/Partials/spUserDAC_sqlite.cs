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
    /// spUsers data access component. Manages CRUD operations for the spUsers table.
    /// </summary>
    public partial class spUserDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Updates an existing row in the spUsers table.
        /// </summary>
        /// <param name="spUser">A spUser entity object.</param>
        public void UploadUserPhoto(spUser spUser)
        {
            const string SQL_STATEMENT =
                "UPDATE [spUsers] " +
                "SET " +
                    "[Photo] = @Photo " +
                "WHERE [Id] = @Id;";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values. 
                db.AddInParameter(cmd, "@Photo", DbType.String, spUser.Photo);
                db.AddInParameter(cmd, "@Id", DbType.Int32, spUser.Id);

                db.ExecuteNonQuery(cmd);
            }
        }
    }
}