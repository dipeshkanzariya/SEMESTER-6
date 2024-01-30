using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
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
                sqlDb.AddInParameter(cmd, "@MobileNo", SqlDbType.NVarChar, model.MobileNo);
                sqlDb.AddInParameter(cmd, "@Email", SqlDbType.NVarChar, model.Email);
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
    }
}
