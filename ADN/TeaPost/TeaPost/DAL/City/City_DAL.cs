using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using TeaPost.Areas.City.Models;
using TeaPost.Areas.State.Models;

namespace TeaPost.DAL.City
{
    public class City_DAL : City_DALBase
    {
        #region dbo.PR_State_StateByCountryID

        public List<LOC_StateDropDownModel> dbo_PR_State_StateByCountryID(int? CountryID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_State_StateByCountryID");
                sqlDb.AddInParameter(cmd, "@CountryID", SqlDbType.Int, CountryID);

                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDb.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }

                List<LOC_StateDropDownModel> list = new List<LOC_StateDropDownModel>();

                foreach(DataRow dr in dt.Rows)
                {
                    LOC_StateDropDownModel model = new LOC_StateDropDownModel();
                    model.StateID = Convert.ToInt32(dr["StateID"]);
                    model.StateName = dr["StateName"].ToString();
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

        #region dbo.PR_LOC_StateComboBox

        public List<LOC_StateDropDownModel> dbo_PR_LOC_StateComboBox()
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_StateComboBox");

                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDb.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }

                List<LOC_StateDropDownModel> list = new List<LOC_StateDropDownModel>();

                foreach(DataRow dr in dt.Rows)
                {
                    LOC_StateDropDownModel model = new LOC_StateDropDownModel();
                    model.StateID = Convert.ToInt32(dr["StateID"]);
                    model.StateName = dr["StateName"].ToString();
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

        #region PR_LOC_CityComboBox
        public List<LOC_CityDropDownModel> dbo_PR_LOC_CityComboBox()
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_CityComboBox");

                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDb.ExecuteReader(cmd))
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
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region dbo.PR_LOC_City_Filter

        public DataTable dbo_PR_LOC_City_Filter(LOC_CityModel model)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_City_Filter");
                sqlDb.AddInParameter(cmd, "@CityName", SqlDbType.NVarChar, model.CityName);
                sqlDb.AddInParameter(cmd, "@CityCode", SqlDbType.NVarChar, model.CityCode);
                sqlDb.AddInParameter(cmd, "@StateName", SqlDbType.NVarChar, model.StateName);
                sqlDb.AddInParameter(cmd, "@CountryName", SqlDbType.NVarChar, model.CountryName);

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
