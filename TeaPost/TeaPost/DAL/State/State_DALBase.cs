using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace TeaPost.DAL.State
{
    public class State_DALBase : DAL_Helper
    {
        #region dbo.PR_SELECT_ALL_LOC_STATE

        public DataTable dbo_PR_SELECT_ALL_LOC_STATE()
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_ALL_LOC_STATE");

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

        #region dbo.PR_SELECT_BY_PK_LOC_STATE

        public DataTable dbo_PR_SELECT_BY_PK_LOC_STATE(int? StateID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_BY_PK_LOC_STATE");
                sqlDb.AddInParameter(cmd, "@StateID", SqlDbType.Int, StateID);

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

        #region dbo.PR_INSERT_LOC_STATE

        public DataTable dbo_PR_INSERT_LOC_STATE(string StateName, string StateCode, int CountryID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_INSERT_LOC_STATE");
                sqlDb.AddInParameter(cmd, "@StateName", SqlDbType.NVarChar, StateName);
                sqlDb.AddInParameter(cmd, "@StateCode", SqlDbType.NVarChar, StateCode);
                sqlDb.AddInParameter(cmd, "@CountryID", SqlDbType.Int, CountryID);

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

        #region dbo.PR_UPDATE_BY_PK_LOC_STATE

        public DataTable dbo_PR_UPDATE_BY_PK_LOC_STATE(int StateID, string StateName, string StateCode, int CountryID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_UPDATE_BY_PK_LOC_STATE");
                sqlDb.AddInParameter(cmd, "@StateID", SqlDbType.Int, StateID);
                sqlDb.AddInParameter(cmd, "@StateName", SqlDbType.NVarChar, StateName);
                sqlDb.AddInParameter(cmd, "@StateCode", SqlDbType.NVarChar, StateCode);
                sqlDb.AddInParameter(cmd, "@CountryID", SqlDbType.Int, CountryID);

                DataTable dt = new DataTable();
                int r = sqlDb.ExecuteNonQuery(cmd);
                return dt;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region dbo.PR_DELETE_BY_PK_LOC_STATE

        public bool? dbo_PR_DELETE_BY_PK_LOC_STATE(int? StateID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_DELETE_BY_PK_LOC_STATE");
                sqlDb.AddInParameter(cmd, "@StateID", SqlDbType.Int, StateID);

                int delete = sqlDb.ExecuteNonQuery(cmd);

                return delete == -1 ? false : true;
            }
            catch(Exception ex) 
            { 
                return null; 
            }
        }

        #endregion
    }
}
