using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using TeaPost.BAL;

namespace TeaPost.DAL.Cart
{
    public class Cart_DAL : Cart_DALBase
    {

        #region dbo.PR_Cart_Select_By_TeaID_Or_SnackID

        public DataTable dbo_PR_Cart_Select_By_TeaID_Or_SnackID(int? TeaID, int? SnackID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_Cart_Select_By_TeaID_Or_SnackID");
                sqlDb.AddInParameter(cmd, "@TeaID", SqlDbType.Int, TeaID);
                sqlDb.AddInParameter(cmd, "@SnackID", SqlDbType.Int, SnackID);
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

        #region dbo.PR_DELETE_ALL_FROM_CART_BY_USERID

        public bool? dbo_PR_DELETE_ALL_FROM_CART_BY_USERID()
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_DELETE_ALL_FROM_CART_BY_USERID");
                sqlDb.AddInParameter(cmd, "@UserID", SqlDbType.Int, @CV.UserID());

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
