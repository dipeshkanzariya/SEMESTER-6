using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using TeaPost.Areas.SEC_User.Models;

namespace TeaPost.DAL.SEC_User
{
    public class SEC_UserDAL : SEC_UserDALBase
    {

        #region dbo.PR_MST_USER_Filter

        public DataTable dbo_PR_MST_USER_Filter(SEC_UserModel model)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_MST_USER_Filter");
                sqlDb.AddInParameter(cmd, "@UserName", SqlDbType.NVarChar, model.UserName);
                sqlDb.AddInParameter(cmd, "@FirstName", SqlDbType.NVarChar, model.FirstName);
                sqlDb.AddInParameter(cmd, "@LastName", SqlDbType.NVarChar, model.LastName);
                sqlDb.AddInParameter(cmd, "@Gender", SqlDbType.NVarChar, model.Gender);
                sqlDb.AddInParameter(cmd, "@CountryName", SqlDbType.NVarChar, model.CountryName);
                sqlDb.AddInParameter(cmd, "@StateName", SqlDbType.NVarChar, model.StateName);
                sqlDb.AddInParameter(cmd, "@CityName", SqlDbType.NVarChar, model.CityName);

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

    }
}