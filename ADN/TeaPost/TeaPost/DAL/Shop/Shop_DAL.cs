using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using TeaPost.Areas.Shop.Models;

namespace TeaPost.DAL.Shop
{
    public class Shop_DAL : Shop_DALBase
    {

        #region dbo.PR_Shop_Filter

        public DataTable dbo_PR_Shop_Filter(ShopModel model)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_Shop_Filter");
                sqlDb.AddInParameter(cmd, "@ShopName", SqlDbType.NVarChar, model.ShopName);
                sqlDb.AddInParameter(cmd, "@ShopArea", SqlDbType.NVarChar, model.ShopArea);
                sqlDb.AddInParameter(cmd, "@SeatingCapacity", SqlDbType.NVarChar, model.SeatingCapacity);
                sqlDb.AddInParameter(cmd, "@VentilationType", SqlDbType.NVarChar, model.VentilationType);
                sqlDb.AddInParameter(cmd, "@BrewedTea", SqlDbType.NVarChar, model.BrewedTea);

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
