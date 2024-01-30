using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace TeaPost.DAL.Franchise
{
    public class Franchise_DALBase : DAL_Helper
    {
        #region dbo.PR_SELECT_ALL_FRANCHISE

        public DataTable dbo_PR_SELECT_ALL_FRANCHISE()
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_ALL_FRANCHISE");

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

        #region dbo.PR_SELECT_BY_PK_FRANCHISE

        public DataTable dbo_PR_SELECT_BY_PK_FRANCHISE(int FID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_BY_PK_FRANCHISE");
                sqlDb.AddInParameter(cmd, "@FID", SqlDbType.Int, FID);

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

        #region dbo.PR_INSERT_FRANCHISE

        public DataTable dbo_PR_INSERT_FRANCHISE(string FirstName, string LastName, DateTime BirthDate, string Gender, string MobileNo, string Email, string Address, int CountryID, int StateID, int CityID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_INSERT_FRANCHISE");
                sqlDb.AddInParameter(cmd, "@FirstName", SqlDbType.NVarChar, FirstName);
                sqlDb.AddInParameter(cmd, "@LastName", SqlDbType.NVarChar, LastName);
                sqlDb.AddInParameter(cmd, "@BirthDate", SqlDbType.DateTime, BirthDate);
                sqlDb.AddInParameter(cmd, "@Gender", SqlDbType.NVarChar, Gender);
                sqlDb.AddInParameter(cmd, "@MobileNo", SqlDbType.NVarChar, MobileNo);
                sqlDb.AddInParameter(cmd, "@Email", SqlDbType.NVarChar, Email);
                sqlDb.AddInParameter(cmd, "@Address", SqlDbType.NVarChar, Address);
                sqlDb.AddInParameter(cmd, "@CountryID", SqlDbType.Int, CountryID);
                sqlDb.AddInParameter(cmd, "@StateID", SqlDbType.Int, StateID);
                sqlDb.AddInParameter(cmd, "@CityID", SqlDbType.Int, CityID);

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

        #region dbo.PR_UPDATE_FRANCHISE

        public DataTable dbo_PR_UPDATE_FRANCHISE(int FID, string FirstName, string LastName, DateTime BirthDate, string Gender, string MobileNo, string Email, string Address, int CountryID, int StateID, int CityID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_UPDATE_FRANCHISE");
                sqlDb.AddInParameter(cmd, "@FID", SqlDbType.Int, FID);
                sqlDb.AddInParameter(cmd, "@FirstName", SqlDbType.NVarChar, FirstName);
                sqlDb.AddInParameter(cmd, "@LastName", SqlDbType.NVarChar, LastName);
                sqlDb.AddInParameter(cmd, "@BirthDate", SqlDbType.DateTime, BirthDate);
                sqlDb.AddInParameter(cmd, "@Gender", SqlDbType.NVarChar, Gender);
                sqlDb.AddInParameter(cmd, "@MobileNo", SqlDbType.NVarChar, MobileNo);
                sqlDb.AddInParameter(cmd, "@Email", SqlDbType.NVarChar, Email);
                sqlDb.AddInParameter(cmd, "@Address", SqlDbType.NVarChar, Address);
                sqlDb.AddInParameter(cmd, "@CountryID", SqlDbType.Int, CountryID);
                sqlDb.AddInParameter(cmd, "@StateID", SqlDbType.Int, StateID);
                sqlDb.AddInParameter(cmd, "@CityID", SqlDbType.Int, CityID);

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

        #region dbo.PR_DELETE_FRANCHISE

        public bool? dbo_PR_DELETE_FRANCHISE(int FID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_DELETE_FRANCHISE");
                sqlDb.AddInParameter(cmd, "@FID", SqlDbType.Int, FID);

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
