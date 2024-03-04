using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using TeaPost.BAL;

namespace TeaPost.DAL.Order
{
    public class Order_DALBase : DAL_Helper
    {

        #region dbo.PR_SELECT_ALL_ORDER_BY_USERID

        public DataTable dbo_PR_SELECT_ALL_ORDER_BY_USERID()
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_ALL_ORDER_BY_USERID");
                sqlDb.AddInParameter(cmd, "@UserID", SqlDbType.Int, @CV.UserID());

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

        #region dbo.PR_SELECT_ALL_ORDER

        public DataTable dbo_PR_SELECT_ALL_ORDER()
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_ALL_ORDER");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDb.ExecuteReader(cmd))
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

        #region dbo.PR_SELECT_BY_PK_ORDER

        public DataTable dbo_PR_SELECT_BY_PK_ORDER(int OrderID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_BY_PK_ORDER");
                sqlDb.AddInParameter(cmd, "@OrderID", SqlDbType.Int, OrderID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDb.ExecuteReader(cmd))
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

        #region dbo.PR_INSERT_ORDER

        public DataTable dbo_PR_INSERT_ORDER(int? TeaID, int? SnackID, int Quantity, decimal TotalAmount, string OrderAddress)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_INSERT_ORDER");
                sqlDb.AddInParameter(cmd, "@TeaID", SqlDbType.Int, TeaID == 0 ? null : TeaID);
                sqlDb.AddInParameter(cmd, "@SnackID", SqlDbType.Int, SnackID == 0 ? null : SnackID);
                sqlDb.AddInParameter(cmd, "@Quantity", SqlDbType.Int, Quantity);
                sqlDb.AddInParameter(cmd, "@TotalAmount", SqlDbType.Decimal, TotalAmount);
                sqlDb.AddInParameter(cmd, "@OrderAddress", SqlDbType.NVarChar, OrderAddress);
                sqlDb.AddInParameter(cmd, "@OrderStatus", SqlDbType.NVarChar, "pending");
                sqlDb.AddInParameter(cmd, "@UserID", SqlDbType.Int, @CV.UserID());

                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDb.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region dbo.PR_UPDATE_ORDER

        public DataTable dbo_PR_UPDATE_ORDER(int OrderID, string OrderAddress, string OrderStatus)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_UPDATE_ORDER");
                sqlDb.AddInParameter(cmd, "@OrderID", SqlDbType.Int, OrderID);
                sqlDb.AddInParameter(cmd, "@OrderAddress", SqlDbType.NVarChar, OrderAddress);
                sqlDb.AddInParameter(cmd, "@OrderStatus", SqlDbType.NVarChar, OrderStatus);

                DataTable dt = new DataTable();
                int r = sqlDb.ExecuteNonQuery(cmd);
                return dt;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region dbo.PR_DELETE_ORDER_BY_USERID

        public bool? dbo_PR_DELETE_ORDER_BY_USERID(int OrderID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_DELETE_ORDER_BY_USERID");
                sqlDb.AddInParameter(cmd, "@OrderID", SqlDbType.Int, OrderID);
                sqlDb.AddInParameter(cmd, "@UserID", SqlDbType.Int, @CV.UserID());

                int delete = sqlDb.ExecuteNonQuery(cmd);

                return delete == -1 ? false : true;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
