using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace TeaPost.DAL.Tea
{
    public class Tea_DALBase : DAL_Helper
    {
        #region dbo.PR_SELECT_ALL_TEA

        public DataTable dbo_PR_SELECT_ALL_TEA()
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_ALL_TEA");

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

        #region dbo.PR_SELECT_BY_PK_TEA

        public DataTable dbo_PR_SELECT_BY_PK_TEA(int? TeaID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_BY_PK_TEA");
                sqlDb.AddInParameter(cmd, "@TeaID", SqlDbType.Int, TeaID);

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

        #region dbo.PR_INSERT_TEA

        public DataTable dbo_PR_INSERT_TEA(string TeaName, string TeaImage, decimal Price, string BriefDescription, string Weight, string Stock, string Description, int ShopID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_INSERT_TEA");
                sqlDb.AddInParameter(cmd, "@TeaName", SqlDbType.NVarChar, TeaName);
                sqlDb.AddInParameter(cmd, "@TeaImage", SqlDbType.NVarChar, TeaImage);
                sqlDb.AddInParameter(cmd, "@Price", SqlDbType.Decimal, Price);
                sqlDb.AddInParameter(cmd, "@BriefDescription", SqlDbType.NVarChar, BriefDescription);
                sqlDb.AddInParameter(cmd, "@Weight", SqlDbType.NVarChar, Weight);
                sqlDb.AddInParameter(cmd, "@Stock", SqlDbType.NVarChar, Stock);
                sqlDb.AddInParameter(cmd, "@Description", SqlDbType.NVarChar, Description);
                sqlDb.AddInParameter(cmd, "@ShopID", SqlDbType.Int, ShopID);

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

        #region dbo.PR_UPDATE_TEA

        public DataTable dbo_PR_UPDATE_TEA(int TeaID, string TeaName, string TeaImage, decimal Price, string BriefDescription, string Weight, string Stock, string Description, int ShopID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_UPDATE_TEA");
                sqlDb.AddInParameter(cmd, "@TeaID", SqlDbType.Int, TeaID);
                sqlDb.AddInParameter(cmd, "@TeaName", SqlDbType.NVarChar, TeaName);
                sqlDb.AddInParameter(cmd, "@TeaImage", SqlDbType.NVarChar, TeaImage);
                sqlDb.AddInParameter(cmd, "@Price", SqlDbType.Decimal, Price);
                sqlDb.AddInParameter(cmd, "@BriefDescription", SqlDbType.NVarChar, BriefDescription);
                sqlDb.AddInParameter(cmd, "@Weight", SqlDbType.NVarChar, Weight);
                sqlDb.AddInParameter(cmd, "@Stock", SqlDbType.NVarChar, Stock);
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

        #region dbo.PR_DELETE_TEA

        public bool? dbo_PR_DELETE_TEA(int? TeaID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_DELETE_TEA");
                sqlDb.AddInParameter(cmd, "@TeaID", SqlDbType.Int, TeaID);

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
