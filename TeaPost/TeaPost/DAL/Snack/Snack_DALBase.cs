using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace TeaPost.DAL.Snack
{
    public class Snack_DALBase : DAL_Helper
    {
        #region dbo.PR_SELECT_ALL_SNACK

        public DataTable dbo_PR_SELECT_ALL_SNACK()
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_ALL_SNACK");

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

        #region dbo.PR_SELECT_BY_PK_SNACK

        public DataTable dbo_PR_SELECT_BY_PK_SNACK(int SnackID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_BY_PK_SNACK");
                sqlDb.AddInParameter(cmd, "@SnackID", SqlDbType.Int, SnackID);

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

        #region dbo.PR_INSERT_SNACK

        public DataTable dbo_PR_PR_INSERT_SNACK(string Snackname, string SnackImage, decimal Price, string BriefDescription, string Size, string Description, int ShopID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_INSERT_SNACK");
                sqlDb.AddInParameter(cmd, "@SnackName", SqlDbType.NVarChar, Snackname);
                sqlDb.AddInParameter(cmd, "@SnackImage", SqlDbType.NVarChar, SnackImage);
                sqlDb.AddInParameter(cmd, "@Price", SqlDbType.Decimal, Price);
                sqlDb.AddInParameter(cmd, "@BriefDescription", SqlDbType.NVarChar, BriefDescription);
                sqlDb.AddInParameter(cmd, "@Size", SqlDbType.NVarChar, Size);
                sqlDb.AddInParameter(cmd, "@Description", SqlDbType.NVarChar, Description);
                sqlDb.AddInParameter(cmd, "@ShopID", SqlDbType.Int, ShopID);

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

        #region dbo.PR_UPDATE_SNACK

        public DataTable dbo_PR_UPDATE_SNACK(int SnackID, string Snackname, string SnackImage, decimal Price, string BriefDescription, string Size, string Description, int ShopID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_UPDATE_SNACK");
                sqlDb.AddInParameter(cmd, "@SnackID", SqlDbType.Int, SnackID);
                sqlDb.AddInParameter(cmd, "@SnackName", SqlDbType.NVarChar, Snackname);
                sqlDb.AddInParameter(cmd, "@SnackImage", SqlDbType.NVarChar, SnackImage);
                sqlDb.AddInParameter(cmd, "@Price", SqlDbType.Decimal, Price);
                sqlDb.AddInParameter(cmd, "@BriefDescription", SqlDbType.NVarChar, BriefDescription);
                sqlDb.AddInParameter(cmd, "@Size", SqlDbType.NVarChar, Size);
                sqlDb.AddInParameter(cmd, "@Description", SqlDbType.NVarChar, Description);
                sqlDb.AddInParameter(cmd, "@ShopID", SqlDbType.Int, ShopID);

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

        #region dbo.PR_DELETE_SNACK

        public bool? dbo_PR_DELETE_SNACK(int SnackID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_DELETE_SNACK");
                sqlDb.AddInParameter(cmd, "@SnackID", SqlDbType.Int, SnackID);

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
