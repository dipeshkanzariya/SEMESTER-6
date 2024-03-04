using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace TeaPost.DAL.City
{
    public class City_DALBase : DAL_Helper
    {
        #region dbo.PR_SELECT_ALL_LOC_CITY

        public DataTable dbo_PR_SELECT_ALL_LOC_CITY()
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_ALL_LOC_CITY");

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

        #region dbo.PR_SELECT_BY_PK_LOC_CITY

        public DataTable dbo_PR_SELECT_BY_PK_LOC_CITY(int? CityID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_BY_PK_LOC_CITY");
                sqlDb.AddInParameter(cmd, "@CityID", SqlDbType.Int, CityID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDb.ExecuteReader(cmd))
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

        #region dbo.PR_INSERT_LOC_CITY

        public DataTable dbo_PR_INSERT_LOC_CITY(string CityName, string CityCode, int StateID, int CountryID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_INSERT_LOC_CITY");
                sqlDb.AddInParameter(cmd, "@CityName", SqlDbType.NVarChar, CityName);
                sqlDb.AddInParameter(cmd, "@CityCode", SqlDbType.NVarChar, CityCode);
                sqlDb.AddInParameter(cmd, "@StateID", SqlDbType.Int, StateID);
                sqlDb.AddInParameter(cmd, "@CountryID", SqlDbType.Int, CountryID);

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

        #region dbo.PR_UPDATE_BY_PK_LOC_CITY

        public DataTable dbo_PR_UPDATE_BY_PK_LOC_CITY(int CityID, string CityName, string CityCode, int StateID, int CountryID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_UPDATE_BY_PK_LOC_CITY");
                sqlDb.AddInParameter(cmd, "@CityID", SqlDbType.Int, CityID);
                sqlDb.AddInParameter(cmd, "@CityName", SqlDbType.NVarChar, CityName);
                sqlDb.AddInParameter(cmd, "@CityCode", SqlDbType.NVarChar, CityCode);
                sqlDb.AddInParameter(cmd, "@StateID", SqlDbType.Int, StateID);
                sqlDb.AddInParameter(cmd, "@CountryID", SqlDbType.Int, CountryID);

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

        #region dbo.PR_DELETE_BY_PK_LOC_CITY

        public bool? dbo_PR_DELETE_BY_PK_LOC_CITY(int CityID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_DELETE_BY_PK_LOC_CITY");
                sqlDb.AddInParameter(cmd, "@CityID", SqlDbType.Int, CityID);

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
