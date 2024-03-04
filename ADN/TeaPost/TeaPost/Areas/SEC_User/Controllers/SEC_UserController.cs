using TeaPost.Areas.SEC_User.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TeaPost.DAL.SEC_User;
using TeaPost.DAL.State;
using TeaPost.DAL.City;

namespace TeaPost.Areas.SEC_User.Controllers
{
    [Area("SEC_User")]
    [Route("SEC_User/[controller]/[action]")]
    public class SEC_UserController : Controller
    {
        SEC_UserDAL userDAL = new SEC_UserDAL();
        State_DAL dalState = new State_DAL();
        City_DAL dalCity = new City_DAL();

        #region UserList
        public IActionResult UserList()
        {
            DataTable dt = userDAL.dbo_PR_SELECT_ALL_MST_USER();
            return View("UserList", dt);
        }

        #endregion

        #region SEC_UserLogin
        public IActionResult SEC_UserLogin()
        {
            return View();
        }

        #endregion

        #region SEC_UserRegister
        public IActionResult SEC_UserRegister()
        {
            ViewBag.CountryList = dalState.dbo_PR_LOC_Country_ComboBox();
            ViewBag.StateList = dalCity.dbo_PR_LOC_StateComboBox();
            ViewBag.CityList = dalCity.dbo_PR_LOC_CityComboBox();
            return View();
        }

        #endregion

        #region Login

        [HttpPost]
        public IActionResult Login(SEC_UserModel modelSEC_User)
        {
            string error = null;

            if (modelSEC_User.UserName == null)
            {
                error += "User Name is required";
            }
            if (modelSEC_User.PassWord == null)
            {
                error += "<br/>Password is required";
            }

            if (error != null)
            {
                TempData["Error"] = error;
                return RedirectToAction("SEC_UserLogin");
            }
            else
            {

                SEC_UserDAL sEC_UserDAL = new SEC_UserDAL();
                DataTable dt = sEC_UserDAL.dbo_PR_SEC_User_SelectByUserNamePassword(modelSEC_User.UserName, modelSEC_User.PassWord);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine(dr);
                        HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                        HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                        HttpContext.Session.SetString("Email", dr["Email"].ToString());
                        HttpContext.Session.SetString("PhoneNo", dr["PhoneNo"].ToString());
                        HttpContext.Session.SetString("FirstName", dr["FirstName"].ToString());
                        HttpContext.Session.SetString("LastName", dr["LastName"].ToString());
                        HttpContext.Session.SetString("Gender", dr["Gender"].ToString());
                        HttpContext.Session.SetString("BirthDate", dr["BirthDate"].ToString());
                        HttpContext.Session.SetString("PassWord", dr["PassWord"].ToString());
                        HttpContext.Session.SetString("CityID", dr["CityID"].ToString());
                        HttpContext.Session.SetString("IsAdmin", dr["IsAdmin"].ToString());
                        HttpContext.Session.SetString("IsActive", dr["IsActive"].ToString());
                        break;
                    }
                }
                else
                {
                    TempData["Error"] = "UserName or Password is invalid!";
                    return RedirectToAction("SEC_UserLogin");
                }
                if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("PassWord") != null && HttpContext.Session.GetString("IsAdmin") == "True")
                {
                    return RedirectToAction("Index", "Home", new { area = ""});
                }
                else if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("PassWord") != null)
                {
                    return RedirectToAction("Index", "User", new { area = "" });
                }
                
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Logout
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "User", new { area = ""});
        }

        #endregion

        #region Register

        public IActionResult Register(SEC_UserModel sEC_UserModel)
        {
            SEC_UserDAL sEC_UserDAL = new SEC_UserDAL();
            bool IsSuccess = sEC_UserDAL.dbo_PR_SEC_User_Register(sEC_UserModel.UserName, sEC_UserModel.Email, sEC_UserModel.PhoneNo, sEC_UserModel.FirstName, sEC_UserModel.LastName, sEC_UserModel.Gender, sEC_UserModel.BirthDate, sEC_UserModel.PassWord,sEC_UserModel.CityID, sEC_UserModel.IsAdmin, sEC_UserModel.IsActive);
            if (IsSuccess)
            {
                return RedirectToAction("SEC_UserLogin");
            }
            else
            {
                return RedirectToAction("SEC_UserRegister");
            }
        }

        #endregion

        #region SEC_UserAddEdit

        public IActionResult SEC_UserAddEdit(int UserID)
        {
            ViewBag.CountryList = dalState.dbo_PR_LOC_Country_ComboBox();
            ViewBag.StateList = dalCity.dbo_PR_LOC_StateComboBox();
            ViewBag.CityList = dalCity.dbo_PR_LOC_CityComboBox();

            if (UserID != null && UserID > 0)
            {
                DataTable dt = userDAL.dbo_PR_SELECT_BY_PK_MST_USER(UserID);

                SEC_UserModel model = new SEC_UserModel();

                foreach (DataRow dr in dt.Rows)
                {
                    model.UserName = dr["UserName"].ToString();
                    model.Email = dr["Email"].ToString();
                    model.PhoneNo = dr["PhoneNo"].ToString();
                    model.FirstName = dr["FirstName"].ToString();
                    model.LastName = dr["LastName"].ToString();
                    model.Gender = dr["Gender"].ToString();
                    model.BirthDate = Convert.ToDateTime(dr["BirthDate"]);
                    model.PassWord = dr["PassWord"].ToString();
                    model.CityID = Convert.ToInt32(dr["CityID"]);
                    model.IsAdmin = Convert.ToBoolean(dr["IsAdmin"]);
                    model.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }
                return View(model);
            }
            return View();
        }

        #endregion

        #region SEC_UserSave

        public IActionResult SEC_UserSave(SEC_UserModel model)
        {
            if(model.UserID == 0)
            {
                DataTable dt = userDAL.dbo_PR_INSERT_MST_USER(model.UserName, model.Email, model.PhoneNo, model.FirstName, model.LastName, model.Gender, model.BirthDate, model.PassWord, model.CityID, model.IsAdmin, model.IsActive);
                TempData["Data"] = "Record inserted successfully";
            }
            else
            {
                DataTable dt = userDAL.dbo_PR_UPDATE_BY_PK_MST_USER(model.UserID, model.UserName, model.Email, model.PhoneNo, model.FirstName, model.LastName, model.Gender, model.BirthDate, model.PassWord, model.CityID, model.IsAdmin, model.IsActive);
                TempData["Data"] = "Record updated successfully";
            }
            return RedirectToAction("UserList");
        }

        #endregion

        #region DeleteUser

        public IActionResult DeleteUser(int UserID)
        {
            if (Convert.ToBoolean(userDAL.dbo_PR_DELETE_BY_PK_MST_USER(UserID)))
            {
                TempData["Data"] = "Record deleted successfully";
            }
            return RedirectToAction("UserList");
        }

        #endregion

        #region UserFilter

        public IActionResult UserFilter(SEC_UserModel model)
        {
            DataTable dt = userDAL.dbo_PR_MST_USER_Filter(model);
            return View("UserList", dt);
        }

        #endregion

    }
}   