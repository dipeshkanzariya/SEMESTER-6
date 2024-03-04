using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using TeaPost.Areas.City.Models;
using TeaPost.Areas.Franchise.Models;

namespace TeaPost.DAL.Franchise
{
    public class Franchise_DAL : Franchise_DALBase
    {
        #region dbo.PR_Filter_Franchise

        public DataTable dbo_PR_Filter_Franchise(FranchiseModel model)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_Filter_Franchise");
                sqlDb.AddInParameter(cmd, "@FirstName", SqlDbType.NVarChar, model.FirstName);
                sqlDb.AddInParameter(cmd, "@LastName", SqlDbType.NVarChar, model.LastName);
                sqlDb.AddInParameter(cmd, "@Gender", SqlDbType.NVarChar, model.Gender);
                sqlDb.AddInParameter(cmd, "@CountryName", SqlDbType.NVarChar, model.CountryName);
                sqlDb.AddInParameter(cmd, "@StateName", SqlDbType.NVarChar, model.StateName);
                sqlDb.AddInParameter(cmd, "@CityName", SqlDbType.NVarChar, model.CityName);

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

        #region dbo.PR_Select_City_By_StateID

        public List<LOC_CityDropDownModel> dbo_PR_Select_City_By_StateID(int StateID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_Select_City_By_StateID");
                sqlDb.AddInParameter(cmd, "@StateID", SqlDbType.Int, StateID);

                DataTable dt = new DataTable();
                using( IDataReader dr = sqlDb.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }

                List<LOC_CityDropDownModel> list = new List<LOC_CityDropDownModel>();

                foreach(DataRow dr in dt.Rows)
                {
                    LOC_CityDropDownModel model = new LOC_CityDropDownModel();

                    model.CityID = Convert.ToInt32(dr["CityID"]);
                    model.CityName = dr["CityName"].ToString();
                    list.Add(model);
                }
                return list;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
