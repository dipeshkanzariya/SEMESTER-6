using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using TeaPost.Areas.Country.Models;
using TeaPost.Areas.State.Models;

namespace TeaPost.DAL.State
{
    public class State_DAL : State_DALBase
    {
        #region dbo.PR_LOC_Country_ComboBox

        public List<LOC_CountryDropDownModel> dbo_PR_LOC_Country_ComboBox()
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_Country_ComboBox");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDb.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }

                List<LOC_CountryDropDownModel> list = new List<LOC_CountryDropDownModel>();

                foreach(DataRow dr in dt.Rows)
                {
                    LOC_CountryDropDownModel model = new LOC_CountryDropDownModel();
                    model.CountryID = Convert.ToInt32(dr["CountryID"]);
                    model.CountryName = dr["CountryName"].ToString();
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

        #region dbo.PR_LOC_State_Filter

        public DataTable dbo_PR_LOC_State_Filter(LOC_StateModel model)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_State_Filter");
                sqlDb.AddInParameter(cmd, "@StateName", SqlDbType.NVarChar, model.StateName);
                sqlDb.AddInParameter(cmd, "@StateCode", SqlDbType.NVarChar, model.StateCode);
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
