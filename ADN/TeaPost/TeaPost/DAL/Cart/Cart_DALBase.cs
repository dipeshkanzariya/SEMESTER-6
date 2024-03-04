using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Net.NetworkInformation;
using TeaPost.BAL;

namespace TeaPost.DAL.Cart
{
    public class Cart_DALBase : DAL_Helper
    {

        #region dbo.PR_SELECT_ALL_CART

        public DataTable dbo_PR_SELECT_ALL_CART()
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_ALL_CART");
                sqlDb.AddInParameter(cmd, "@UserID", SqlDbType.Int, @CV.UserID());

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

        #region dbo.PR_INSERT_CART

        public DataTable dbo_PR_INSERT_CART(int? TeaID, int? SnackID, int Quantity)
        {
            try
            {

                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_INSERT_CART");
                sqlDb.AddInParameter(cmd, "@TeaID", SqlDbType.Int, TeaID);
                sqlDb.AddInParameter(cmd, "@SnackID", SqlDbType.Int, SnackID);
                sqlDb.AddInParameter(cmd, "@UserID", SqlDbType.Int, @CV.UserID());
                sqlDb.AddInParameter(cmd, "@Quantity", SqlDbType.Int, Quantity);

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

        #region dbo.PR_UPDATE_CART

        public DataTable dbo_PR_UPDATE_CART(int CartID, int Quantity)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_UPDATE_CART");
                sqlDb.AddInParameter(cmd, "@CartID", SqlDbType.Int, CartID);
                sqlDb.AddInParameter(cmd, "@Quantity", SqlDbType.Int, Quantity);

                DataTable dt = new DataTable();
                int r = sqlDb.ExecuteNonQuery(cmd);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region dbo.PR_DELETE_CART

        public bool? dbo_PR_DELETE_CART(int CartID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_DELETE_CART");
                sqlDb.AddInParameter(cmd, "@CartID", SqlDbType.Int, CartID);

                int delete = sqlDb.ExecuteNonQuery(cmd);

                return delete == -1 ? false : true;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

    }
}
