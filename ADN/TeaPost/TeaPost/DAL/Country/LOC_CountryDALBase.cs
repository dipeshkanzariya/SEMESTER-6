using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace TeaPost.DAL.Country
{
    public class LOC_CountryDALBase : DAL_Helper
    {
        #region dbo.PR_SELECT_ALL_LOC_COUNTRY

        public DataTable dbo_PR_SELECT_ALL_LOC_COUNTRY()
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_ALL_LOC_COUNTRY");

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

        #region dbo.PR_SELECT_BY_PK_LOC_COUNTRY

        public DataTable dbo_PR_SELECT_BY_PK_LOC_COUNTRY(int? CountryID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_BY_PK_LOC_COUNTRY");
                sqlDb.AddInParameter(cmd, "@CountryID", SqlDbType.Int, CountryID);

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

        #region dbo.PR_INSERT_LOC_COUNTRY

        public DataTable dbo_PR_INSERT_LOC_COUNTRY(string CountryName, string CountryCode)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_INSERT_LOC_COUNTRY");
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

        #region dbo.PR_UPDATE_BY_PK_LOC_COUNTRY

        public DataTable dbo_PR_UPDATE_BY_PK_LOC_COUNTRY(int? CountryID, string CountryName, string CountryCode)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_UPDATE_BY_PK_LOC_COUNTRY");
                sqlDb.AddInParameter(cmd, "@CountryID", SqlDbType.Int, CountryID);
                sqlDb.AddInParameter(cmd, "@CountryName", SqlDbType.NVarChar, CountryName);
                sqlDb.AddInParameter(cmd, "@CountryCode", SqlDbType.NVarChar, CountryCode);

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

        #region dbo.PR_DELETE_BY_PK_LOC_COUNTRY
        public bool? dbo_PR_DELETE_BY_PK_LOC_COUNTRY(int? CountryID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_DELETE_BY_PK_LOC_COUNTRY");
                sqlDb.AddInParameter(cmd, "@CountryID", SqlDbType.Int, CountryID);

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
