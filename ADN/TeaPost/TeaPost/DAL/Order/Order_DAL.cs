using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace TeaPost.DAL.Order
{
    public class Order_DAL : Order_DALBase
    {

        #region dbo.PR_ORDER_FILTER

        public DataTable dbo_PR_ORDER_FILTER(string? UserName, DateTime? FromDate, DateTime? ToDate)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_ORDER_FILTER");
                sqlDb.AddInParameter(cmd, "@UserName", SqlDbType.NVarChar, UserName);
                sqlDb.AddInParameter(cmd, "@FromDate", SqlDbType.DateTime, FromDate);
                sqlDb.AddInParameter(cmd, "@ToDate", SqlDbType.DateTime, ToDate);

                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDb.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

    }
}
