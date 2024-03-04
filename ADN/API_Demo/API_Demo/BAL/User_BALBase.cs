using API_Demo.DAL;
using API_Demo.Models;

namespace API_Demo.BAL
{
    public class User_BALBase : DAL_Helpers
    {
        #region PR_SELECT_ALL_USER
        public List<UserModel> PR_SELECT_ALL_USER()
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                List<UserModel> userModels = user_DALBase.PR_SELECT_ALL_USER();
                return userModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region PR_SELECT_BY_PK_USER

        public UserModel PR_SELECT_BY_PK_USER(int UserID)
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                UserModel userModel = user_DALBase.PR_SELECT_BY_PK_USER(UserID);
                return userModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region PR_INSERT_USER

        public bool PR_INSERT_USER(UserModel userModel)
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                if (user_DALBase.PR_INSERT_USER(userModel))
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
                User_DALBase user_DALBase = new User_DALBase();
                if (user_DALBase.PR_UPDATE_USER(UserID, userModel))
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

        #region PR_DELETE_USER

        public bool PR_DELETE_USER(int UserID)
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                if (user_DALBase.PR_DELETE_USER(UserID))
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
    }
}
