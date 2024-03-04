using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace TeaPost.DAL.Shop
{
    public class Shop_DALBase : DAL_Helper
    {
        #region dbo.PR_SELECT_ALL_SHOP

        public DataTable dbo_PR_SELECT_ALL_SHOP()
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_ALL_SHOP");

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

        #region dbo.PR_SELECT_BY_PK_SHOP

        public DataTable dbo_PR_SELECT_BY_PK_SHOP(int ShopID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_BY_PK_SHOP");
                sqlDb.AddInParameter(cmd, "@ShopID", SqlDbType.Int, ShopID);

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

        #region dbo.PR_INSERT_SHOP

        public DataTable dbo_PR_INSERT_SHOP(string ShopName, string ShopImage, string ShopArea, string SeatingCapacity, string VentilationType, string ShopDescription, string BrewedTea)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_INSERT_SHOP");
                sqlDb.AddInParameter(cmd, "@ShopName", SqlDbType.NVarChar, ShopName);
                sqlDb.AddInParameter(cmd, "@ShopImage", SqlDbType.NVarChar, ShopImage);
                sqlDb.AddInParameter(cmd, "@ShopArea", SqlDbType.NVarChar, ShopArea);
                sqlDb.AddInParameter(cmd, "@SeatingCapacity", SqlDbType.NVarChar, SeatingCapacity);
                sqlDb.AddInParameter(cmd, "@VentilationType", SqlDbType.NVarChar, VentilationType);
                sqlDb.AddInParameter(cmd, "@ShopDescription", SqlDbType.NVarChar, ShopDescription);
                sqlDb.AddInParameter(cmd, "@BrewedTea", SqlDbType.NVarChar, BrewedTea);

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

        #region dbo.PR_UPDATE_SHOP

        public DataTable dbo_PR_UPDATE_SHOP(int ShopID, string ShopName, string ShopImage, string ShopArea, string SeatingCapacity, string VentilationType, string ShopDescription,string BrewedTea)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_UPDATE_SHOP");
                sqlDb.AddInParameter(cmd, "@ShopID", SqlDbType.NVarChar, ShopID);
                sqlDb.AddInParameter(cmd, "@ShopName", SqlDbType.NVarChar, ShopName);
                sqlDb.AddInParameter(cmd, "@ShopImage", SqlDbType.NVarChar, ShopImage);
                sqlDb.AddInParameter(cmd, "@ShopArea", SqlDbType.NVarChar, ShopArea);
                sqlDb.AddInParameter(cmd, "@SeatingCapacity", SqlDbType.NVarChar, SeatingCapacity);
                sqlDb.AddInParameter(cmd, "@VentilationType", SqlDbType.NVarChar, VentilationType);
                sqlDb.AddInParameter(cmd, "@ShopDescription", SqlDbType.NVarChar, ShopDescription);
                sqlDb.AddInParameter(cmd, "@BrewedTea", SqlDbType.NVarChar, BrewedTea);

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

        #region dbo.PR_DELETE_SHOP

        public bool? dbo_PR_DELETE_SHOP(int ShopID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_DELETE_SHOP");
                sqlDb.AddInParameter(cmd, "@ShopID", SqlDbType.Int, ShopID);

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
