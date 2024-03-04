using API_Demo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace API_Demo.DAL
{
    public class User_DALBase : DAL_Helpers
    {

        #region PR_SELECT_ALL_USER

        public List<UserModel> PR_SELECT_ALL_USER()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_ALL_USER");
                List<UserModel> userModels = new List<UserModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while(dr.Read())
                    {
                        UserModel userModel = new UserModel();
                        userModel.UserID = Convert.ToInt32(dr["UserID"].ToString());
                        userModel.UserName = dr["UserName"].ToString();
                        userModel.Contact = dr["Contact"].ToString();
                        userModel.Email = dr["Email"].ToString();
                        userModels.Add(userModel);
                    }
                }
                return userModels;
            }catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region PR_SELECT_BY_PK_USER

        public UserModel PR_SELECT_BY_PK_USER(int userID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_BY_PK_USER");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, userID);
                UserModel userModel = new UserModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dr.Read();
                    userModel.UserID = Convert.ToInt32(dr["UserID"].ToString());
                    userModel.UserName = dr["UserName"].ToString();
                    userModel.Contact = dr["Contact"].ToString();
                    userModel.Email = dr["Email"].ToString();
                }
                return userModel;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        #endregion

        #region PR_DELETE_USER

        public bool PR_DELETE_USER(int UserID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_DELETE_USER");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, UserID);
                if(Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region PR_INSERT_USER

        public bool PR_INSERT_USER(UserModel userModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_INSERT_USER");
                sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.VarChar, userModel.UserName);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.VarChar, userModel.Contact);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, userModel.Email);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region PR_UPDATE_USER

        public bool PR_UPDATE_USER(int UserID, UserModel userModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_UPDATE_USER");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, userModel.UserID);
                sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.VarChar, userModel.UserName);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.VarChar, userModel.Contact);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, userModel.Email);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                {
                    return true;
                }
                else
                {
                    return false;
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
