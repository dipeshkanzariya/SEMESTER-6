using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using TeaPost.Areas.Shop.Models;
using TeaPost.Areas.Tea.Models;

namespace TeaPost.DAL.Tea
{
    public class Tea_DAL : Tea_DALBase
    {

        #region dbo.PR_Shop_ComboBox
        public List<ShopDropDownModel> dbo_PR_Shop_ComboBox()
        {
            try
            {
                SqlDatabase sqlDb= new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_Shop_ComboBox");

                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDb.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }

                List<ShopDropDownModel> list = new List<ShopDropDownModel>();

                foreach (DataRow dr in dt.Rows)
                {
                    ShopDropDownModel model = new ShopDropDownModel();
                    model.ShopID = Convert.ToInt32(dr["ShopID"]);
                    model.ShopName = dr["ShopName"].ToString();
                    list.Add(model);
                }

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region dbo.PR_Tea_Filter

        public DataTable dbo_PR_Tea_Filter(TeaModel model)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_Tea_Filter");
                sqlDb.AddInParameter(cmd, "@TeaName", SqlDbType.NVarChar, model.TeaName);
                sqlDb.AddInParameter(cmd, "@Price", SqlDbType.Decimal, model.Price);
                sqlDb.AddInParameter(cmd, "@Weight", SqlDbType.NVarChar, model.Weight);
                sqlDb.AddInParameter(cmd, "@Stock", SqlDbType.NVarChar, model.Stock);

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
    }
}
