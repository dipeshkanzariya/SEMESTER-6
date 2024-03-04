using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace TeaPost.DAL.SEC_User
{
    public class SEC_UserDALBase : DAL_Helper
    {
        #region dbo_PR_SELECT_ALL_MST_USER

        public DataTable dbo_PR_SELECT_ALL_MST_USER()
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_ALL_MST_USER");

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

        #region dbo.PR_SELECT_BY_PK_MST_USER

        public DataTable dbo_PR_SELECT_BY_PK_MST_USER(int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_SELECT_BY_PK_MST_USER");
                sqlDb.AddInParameter(cmd, "@UserID", SqlDbType.Int, UserID);

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

        #region dbo.PR_INSERT_MST_USER

        public DataTable dbo_PR_INSERT_MST_USER(string UserName, string Email, string PhoneNo, string FirstName, string LastName, string Gender, DateTime BirthDate, string PassWord, int CityID, bool IsAdmin, bool IsActive)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_INSERT_MST_USER");
                sqlDb.AddInParameter(cmd, "@UserName", SqlDbType.NVarChar, UserName);
                sqlDb.AddInParameter(cmd, "@Email", SqlDbType.NVarChar, Email);
                sqlDb.AddInParameter(cmd, "@PhoneNo", SqlDbType.NVarChar, PhoneNo);
                sqlDb.AddInParameter(cmd, "@FirstName", SqlDbType.NVarChar, FirstName);
                sqlDb.AddInParameter(cmd, "@LastName", SqlDbType.NVarChar, LastName);
                sqlDb.AddInParameter(cmd, "@Gender", SqlDbType.NVarChar, Gender);
                sqlDb.AddInParameter(cmd, "@BirthDate", SqlDbType.DateTime, BirthDate);
                sqlDb.AddInParameter(cmd, "@PassWord", SqlDbType.NVarChar, PassWord);
                sqlDb.AddInParameter(cmd, "@CityID", SqlDbType.Int, CityID);
                sqlDb.AddInParameter(cmd, "@IsAdmin", SqlDbType.Bit, IsAdmin);
                sqlDb.AddInParameter(cmd, "@IsActive", SqlDbType.Bit, IsAdmin);

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

        #region dbo.PR_UPDATE_BY_PK_MST_USER

        public DataTable dbo_PR_UPDATE_BY_PK_MST_USER(int UserID, string UserName, string Email, string PhoneNo, string FirstName, string LastName, string Gender, DateTime BirthDate, string PassWord, int CityID, bool IsAdmin, bool IsActive)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_UPDATE_BY_PK_MST_USER");
                sqlDb.AddInParameter(cmd, "@UserID", SqlDbType.Int, UserID);
                sqlDb.AddInParameter(cmd, "@UserName", SqlDbType.NVarChar, UserName);
                sqlDb.AddInParameter(cmd, "@Email", SqlDbType.NVarChar, Email);
                sqlDb.AddInParameter(cmd, "@PhoneNo", SqlDbType.NVarChar, PhoneNo);
                sqlDb.AddInParameter(cmd, "@FirstName", SqlDbType.NVarChar, FirstName);
                sqlDb.AddInParameter(cmd, "@LastName", SqlDbType.NVarChar, LastName);
                sqlDb.AddInParameter(cmd, "@Gender", SqlDbType.NVarChar, Gender);
                sqlDb.AddInParameter(cmd, "@BirthDate", SqlDbType.DateTime, BirthDate);
                sqlDb.AddInParameter(cmd, "@PassWord", SqlDbType.NVarChar, PassWord);
                sqlDb.AddInParameter(cmd, "@CityID", SqlDbType.Int, CityID);
                sqlDb.AddInParameter(cmd, "@IsAdmin", SqlDbType.Bit, IsAdmin);
                sqlDb.AddInParameter(cmd, "@IsActive", SqlDbType.Bit, IsAdmin);

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

        #region dbo.PR_DELETE_BY_PK_MST_USER

        public bool? dbo_PR_DELETE_BY_PK_MST_USER(int UserID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_DELETE_BY_PK_MST_USER");
                sqlDb.AddInParameter(cmd, "@UserID", SqlDbType.Int, UserID);

                int delete = sqlDb.ExecuteNonQuery(cmd);

                return delete == -1 ? false : true;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Method: dbo_PR_SEC_User_SelectByUserNamePassword
        public DataTable dbo_PR_SEC_User_SelectByUserNamePassword(string UserName, string PassWord)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_User_SelectByUserNamePassword");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "PassWord", SqlDbType.VarChar, PassWord);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
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

        #region Method: dbo_PR_SEC_User_Register
        public bool dbo_PR_SEC_User_Register(string UserName, string Email, string PhoneNo, string FirstName, string LastName, string Gender, DateTime BirthDate, string PassWord, int CityID, bool IsAdmin, bool IsActive)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_SEC_User_SelectUserName");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, UserName);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDB.ExecuteReader(dbCMD))
                {
                    dataTable.Load(dataReader);
                }
                if (dataTable.Rows.Count > 0)
                {
                    return false;
                }
                else
                {
                    DbCommand dbCMD1 = sqlDB.GetStoredProcCommand("dbo.PR_INSERT_MST_USER");
                    sqlDB.AddInParameter(dbCMD1, "UserName", SqlDbType.NVarChar, UserName);
                    sqlDB.AddInParameter(dbCMD1, "Email", SqlDbType.NVarChar, Email);
                    sqlDB.AddInParameter(dbCMD1, "PhoneNo", SqlDbType.NVarChar, PhoneNo);
                    sqlDB.AddInParameter(dbCMD1, "FirstName", SqlDbType.NVarChar, FirstName);
                    sqlDB.AddInParameter(dbCMD1, "LastName", SqlDbType.NVarChar, LastName);
                    sqlDB.AddInParameter(dbCMD1, "Gender", SqlDbType.NVarChar, Gender);
                    sqlDB.AddInParameter(dbCMD1, "BirthDate", SqlDbType.DateTime, BirthDate);
                    sqlDB.AddInParameter(dbCMD1, "PassWord", SqlDbType.NVarChar, PassWord);
                    sqlDB.AddInParameter(dbCMD1, "CityID", SqlDbType.Int, CityID);
                    sqlDB.AddInParameter(dbCMD1, "IsAdmin", SqlDbType.Bit, IsAdmin);
                    sqlDB.AddInParameter(dbCMD1, "IsActive", SqlDbType.Bit, IsActive);
                    if (Convert.ToBoolean(sqlDB.ExecuteNonQuery(dbCMD1)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}