using TeaPost.Areas.SEC_User.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TeaPost.DAL.SEC_User;

namespace TeaPost.Areas.SEC_User.Controllers
{
    [Area("SEC_User")]
    [Route("SEC_User/[controller]/[action]")]
    public class SEC_UserController : Controller
    {
        SEC_UserDAL userDAL = new SEC_UserDAL();

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
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SEC_UserLogin");
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

    }
}   