using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace TeaPost.DAL.Country
{
    public class LOC_CountryDAL : LOC_CountryDALBase
    {

        #region dbo.PR_LOC_Country_Filter

        public DataTable dbo_PR_LOC_Country_Filter(string CountryName, string CountryCode)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_Country_Filter");
                sqlDb.AddInParameter(cmd, "@CountryName", SqlDbType.NVarChar, CountryName);
                sqlDb.AddInParameter(cmd, "@CountryCode", SqlDbType.NVarChar, CountryCode);

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
