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
    /// PayslipDet data access component. Manages CRUD operations for the PayslipDet table.
    /// </summary>
    public partial class PayslipDetDAC_sqlite : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the PayslipDet table.
        /// </summary>
        /// <param name="payslipDet">A PayslipDet object.</param>
        /// <returns>An updated PayslipDet object.</returns>
        public PayslipDet Create(PayslipDet payslipDet)
        {
            const string SQL_STATEMENT =
                "INSERT INTO [PayslipDet] ([EmpNo], [EmployeeId], [EmpTxnId], [Period], [Year], [Description], [TaxTracking], [Amount], [DEType], [IsStatutory], [ShowInPayslip], [YTD]) " +
                "VALUES(@EmpNo, @EmployeeId, @EmpTxnId, @Period, @Year, @Description, @TaxTracking, @Amount, @DEType, @IsStatutory, @ShowInPayslip, @YTD); SELECT last_insert_rowid();";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@EmpNo", DbType.String, payslipDet.EmpNo);
                db.AddInParameter(cmd, "@EmployeeId", DbType.Int32, payslipDet.EmployeeId);
                db.AddInParameter(cmd, "@EmpTxnId", DbType.Int32, payslipDet.EmpTxnId);
                db.AddInParameter(cmd, "@Period", DbType.Int32, payslipDet.Period);
                db.AddInParameter(cmd, "@Year", DbType.Int32, payslipDet.Year);
                db.AddInParameter(cmd, "@Description", DbType.String, payslipDet.Description);
                db.AddInParameter(cmd, "@TaxTracking", DbType.String, payslipDet.TaxTracking);
                db.AddInParameter(cmd, "@Amount", DbType.Decimal, payslipDet.Amount);
                db.AddInParameter(cmd, "@DEType", DbType.String, payslipDet.DEType);
                db.AddInParameter(cmd, "@IsStatutory", DbType.Boolean, payslipDet.IsStatutory);
                db.AddInParameter(cmd, "@ShowInPayslip", DbType.Boolean, payslipDet.ShowInPayslip);
                db.AddInParameter(cmd, "@YTD", DbType.Decimal, payslipDet.YTD);

                payslipDet.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return payslipDet;
        }

        /// <summary>
        /// Updates an existing row in the PayslipDet table.
        /// </summary>
        /// <param name="payslipDet">A PayslipDet entity object.</param>
        public void UpdateById(PayslipDet payslipDet)
        {
            const string SQL_STATEMENT =
                "UPDATE [PayslipDet] " +
                "SET " +
                    "[EmpNo]=@EmpNo, " +
                    "[EmployeeId]=@EmployeeId, " +
                    "[EmpTxnId]=@EmpTxnId, " +
                    "[Period]=@Period, " +
                    "[Year]=@Year, " +
                    "[Description]=@Description, " +
                    "[TaxTracking]=@TaxTracking, " +
                    "[Amount]=@Amount, " +
                    "[DEType]=@DEType, " +
                    "[IsStatutory]=@IsStatutory, " +
                    "[ShowInPayslip]=@ShowInPayslip, " +
                    "[YTD]=@YTD " +
                "WHERE [Id]=@Id;";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@EmpNo", DbType.String, payslipDet.EmpNo);
                db.AddInParameter(cmd, "@EmployeeId", DbType.Int32, payslipDet.EmployeeId);
                db.AddInParameter(cmd, "@EmpTxnId", DbType.Int32, payslipDet.EmpTxnId);
                db.AddInParameter(cmd, "@Period", DbType.Int32, payslipDet.Period);
                db.AddInParameter(cmd, "@Year", DbType.Int32, payslipDet.Year);
                db.AddInParameter(cmd, "@Description", DbType.String, payslipDet.Description);
                db.AddInParameter(cmd, "@TaxTracking", DbType.String, payslipDet.TaxTracking);
                db.AddInParameter(cmd, "@Amount", DbType.Decimal, payslipDet.Amount);
                db.AddInParameter(cmd, "@DEType", DbType.String, payslipDet.DEType);
                db.AddInParameter(cmd, "@IsStatutory", DbType.Boolean, payslipDet.IsStatutory);
                db.AddInParameter(cmd, "@ShowInPayslip", DbType.Boolean, payslipDet.ShowInPayslip);
                db.AddInParameter(cmd, "@YTD", DbType.Decimal, payslipDet.YTD);
                db.AddInParameter(cmd, "@Id", DbType.Int32, payslipDet.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the PayslipDet table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE FROM [PayslipDet] WHERE [Id]=@Id;";

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Returns a row from the PayslipDet table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A PayslipDet object with data populated from the database.</returns>
        public PayslipDet SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [EmpNo], [EmployeeId], [EmpTxnId], [Period], [Year], [Description], [TaxTracking]" +
                        ", [Amount], [DEType], [IsStatutory], [ShowInPayslip], [YTD] " +
                "FROM [PayslipDet] " +
                "WHERE [Id]=@Id;";

            PayslipDet payslipDet = null;

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        payslipDet = new PayslipDet();
                        payslipDet.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        payslipDet.EmpNo = base.GetDataValue<string>(dr, "EmpNo");
                        payslipDet.EmployeeId = base.GetDataValue<int>(dr, "EmployeeId");
                        payslipDet.EmpTxnId = base.GetDataValue<int>(dr, "EmpTxnId");
                        payslipDet.Period = base.GetDataValue<int>(dr, "Period");
                        payslipDet.Year = base.GetDataValue<int>(dr, "Year");
                        payslipDet.Description = base.GetDataValue<string>(dr, "Description");
                        payslipDet.TaxTracking = base.GetDataValue<string>(dr, "TaxTracking");
                        payslipDet.Amount = base.GetDataValue<decimal>(dr, "Amount");
                        payslipDet.DEType = base.GetDataValue<string>(dr, "DEType");
                        payslipDet.IsStatutory = base.GetDataValue<bool>(dr, "IsStatutory");
                        payslipDet.ShowInPayslip = base.GetDataValue<bool>(dr, "ShowInPayslip");
                        payslipDet.YTD = base.GetDataValue<decimal>(dr, "YTD");
                    }
                }
            }

            return payslipDet;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the PayslipDet table.
        /// </summary>
        /// <returns>A collection of PayslipDet objects.</returns>		
        public List<PayslipDet> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [EmpNo], [EmployeeId], [EmpTxnId], [Period], [Year], [Description], [TaxTracking]" +
                        ", [Amount], [DEType], [IsStatutory], [ShowInPayslip], [YTD] " +
                "FROM [PayslipDet];";

            List<PayslipDet> result = new List<PayslipDet>();

            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        PayslipDet payslipDet = new PayslipDet();
                        payslipDet.Id = Convert.ToInt32(base.GetDataValue<long>(dr, "Id"));
                        payslipDet.EmpNo = base.GetDataValue<string>(dr, "EmpNo");
                        payslipDet.EmployeeId = base.GetDataValue<int>(dr, "EmployeeId");
                        payslipDet.EmpTxnId = base.GetDataValue<int>(dr, "EmpTxnId");
                        payslipDet.Period = base.GetDataValue<int>(dr, "Period");
                        payslipDet.Year = base.GetDataValue<int>(dr, "Year");
                        payslipDet.Description = base.GetDataValue<string>(dr, "Description");
                        payslipDet.TaxTracking = base.GetDataValue<string>(dr, "TaxTracking");
                        payslipDet.Amount = base.GetDataValue<decimal>(dr, "Amount");
                        payslipDet.DEType = base.GetDataValue<string>(dr, "DEType");
                        payslipDet.IsStatutory = base.GetDataValue<bool>(dr, "IsStatutory");
                        payslipDet.ShowInPayslip = base.GetDataValue<bool>(dr, "ShowInPayslip");
                        payslipDet.YTD = base.GetDataValue<decimal>(dr, "YTD");

                        result.Add(payslipDet);
                    }
                }
            }

            return result;
        }
    }
}