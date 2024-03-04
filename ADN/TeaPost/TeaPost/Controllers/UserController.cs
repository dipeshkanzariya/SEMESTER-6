using Microsoft.AspNetCore.Mvc;
using System.Data;
using TeaPost.Areas.SEC_User.Models;
using TeaPost.DAL.Cart;
using TeaPost.DAL.City;
using TeaPost.DAL.Franchise;
using TeaPost.DAL.Order;
using TeaPost.DAL.SEC_User;
using TeaPost.DAL.Shop;
using TeaPost.DAL.Snack;
using TeaPost.DAL.State;
using TeaPost.DAL.Tea;
using TeaPost.Models;

namespace TeaPost.Controllers
{
    public class UserController : Controller
    {
        Tea_DAL dalTea = new Tea_DAL();
        Snack_DAL dalSnack = new Snack_DAL();
        Shop_DAL dalShop = new Shop_DAL();
        Cart_DAL dalCart = new Cart_DAL();
        State_DAL dalState = new State_DAL();
        City_DAL dalCity = new City_DAL();
        Franchise_DAL dalFranc = new Franchise_DAL();
        Order_DAL dalOrder = new Order_DAL();

        #region Index

        public IActionResult Index()
        {
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            return View();
        }

        public IActionResult Index_Logged_In()
        {
            return View();
        }

        #endregion

        #region About

        public IActionResult About()
        {
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            return View();
        }

        #endregion

        public IActionResult Products()
        {
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            return View();
        }

        public IActionResult TeaProduct()
        {
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            DataTable dt = dalTea.dbo_PR_SELECT_ALL_TEA();
            return View("TeaProduct", dt);
        }

        public IActionResult TeaDetails(int TeaID)
        {
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            DataTable dt = dalTea.dbo_PR_SELECT_BY_PK_TEA(TeaID);
            return View("TeaDetails", dt);
        }

        public IActionResult SnackProduct()
        {
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            DataTable dt = dalSnack.dbo_PR_SELECT_ALL_SNACK();
            return View("SnackProduct", dt);
        }

        public IActionResult SnackDetails(int SnackID)
        {
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            DataTable dt = dalSnack.dbo_PR_SELECT_BY_PK_SNACK(SnackID);
            return View("SnackDetails", dt);
        }

        public IActionResult ShopDetails(int ShopID)
        {
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            DataTable dt = dalShop.dbo_PR_SELECT_BY_PK_SHOP(ShopID);
            return View("ShopDetails", dt);
        }

        public IActionResult Blog_Article()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            return View();
        }

        public IActionResult CartList()
        {
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            DataTable dt = dalCart.dbo_PR_SELECT_ALL_CART();
            return View("CartList", dt);
        }

        public IActionResult CartInsert(int? TeaID, int? SnackID, int Quantity)
        {
            DataTable CartItem = dalCart.dbo_PR_Cart_Select_By_TeaID_Or_SnackID(TeaID, SnackID);
            if (CartItem == null)
            {
                DataTable dt = dalCart.dbo_PR_INSERT_CART(TeaID, SnackID, Quantity);
                TempData["Data"] = "Insert in cart successfully !!";
            }
            else if (CartItem.Rows.Count == 0)
            {
                DataTable dt = dalCart.dbo_PR_INSERT_CART(TeaID, SnackID, Quantity);
                TempData["Data"] = "Insert in cart successfully !!";
            }
            else
            {
                TempData["Data"] = "Already exist in cart !!!";
            }
            return RedirectToAction("CartList");
        }

        public IActionResult CartUpdate(int CartID, int Quantity)
        {
            DataTable dt = dalCart.dbo_PR_UPDATE_CART(CartID, Quantity);
            return RedirectToAction("CartList");
        }

        public IActionResult DeleteCart(int CartID)
        {
            if (Convert.ToBoolean(dalCart.dbo_PR_DELETE_CART(CartID)))
            {

            }
            return RedirectToAction("CartList");
        }

        public IActionResult Franchise()
        {
            ViewBag.CountryList = dalState.dbo_PR_LOC_Country_ComboBox();
            ViewBag.StateList = dalCity.dbo_PR_LOC_StateComboBox();
            ViewBag.CityList = dalCity.dbo_PR_LOC_CityComboBox();
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            return View();
        }

        public IActionResult InsertFranchise(string FirstName, string LastName, DateTime BirthDate, string Gender, string MobileNo, string Email, string Address, int CountryID, int StateID, int CityID)
        {
            ViewBag.CountryList = dalState.dbo_PR_LOC_Country_ComboBox();
            ViewBag.StateList = dalCity.dbo_PR_LOC_StateComboBox();
            ViewBag.CityList = dalCity.dbo_PR_LOC_CityComboBox();

            DataTable dt = dalFranc.dbo_PR_INSERT_FRANCHISE(FirstName, LastName, BirthDate, Gender, MobileNo, Email, Address, CountryID, StateID, CityID);
            return RedirectToAction("Franchise");
        }

        public IActionResult SEC_UserLogin()
        {
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            return View();
        }

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
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("PassWord") != null)
                {
                    return RedirectToAction("Index", "User", new { area = "" });
                }

            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Register

        public IActionResult Register(SEC_UserModel sEC_UserModel)
        {
            SEC_UserDAL sEC_UserDAL = new SEC_UserDAL();
            bool IsSuccess = sEC_UserDAL.dbo_PR_SEC_User_Register(sEC_UserModel.UserName, sEC_UserModel.Email, sEC_UserModel.PhoneNo, sEC_UserModel.FirstName, sEC_UserModel.LastName, sEC_UserModel.Gender, sEC_UserModel.BirthDate, sEC_UserModel.PassWord, sEC_UserModel.CityID, sEC_UserModel.IsAdmin, sEC_UserModel.IsActive);
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

        public IActionResult SEC_UserRegister()
        {
            ViewBag.CountryList = dalState.dbo_PR_LOC_Country_ComboBox();
            ViewBag.StateList = dalCity.dbo_PR_LOC_StateComboBox();
            ViewBag.CityList = dalCity.dbo_PR_LOC_CityComboBox();
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            return View();
        }

        #region Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        #endregion

        public IActionResult OrderList()
        {
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            DataTable dt = dalOrder.dbo_PR_SELECT_ALL_ORDER_BY_USERID();
            return View("OrderList", dt);
        }

        public IActionResult OrderDetails(int Quantity, int? TeaID = null,int? SnackID = null)
        {
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            if (TeaID != null)
            {
                DataTable dt = dalTea.dbo_PR_SELECT_BY_PK_TEA(TeaID);
                OrderModel model = new OrderModel();

                foreach (DataRow dr in dt.Rows)
                {
                    model.TeaID = Convert.ToInt32(dr["TeaID"]);
                    model.Price = Convert.ToDecimal(dr["Price"]);
                    model.Quantity = Quantity;
                }
                return View(model);
            }
            else
            {
                DataTable dt = dalSnack.dbo_PR_SELECT_BY_PK_SNACK(SnackID);
                OrderModel model = new OrderModel();

                foreach (DataRow dr in dt.Rows)
                {
                    model.SnackID = Convert.ToInt32(dr["SnackID"]);
                    model.Price = Convert.ToDecimal(dr["Price"]);
                    model.Quantity = Quantity;
                }
                return View(model);
            }
        }

        public IActionResult InsertOrder(int? TeaID, int? SnackID, int Quantity,decimal Price, string OrderAddress)
        {
            if (TeaID == 0)
            {
                TeaID = null;
            }
            if (SnackID == 0)
            {
                SnackID = null;
            }
            decimal TotalAmount = Price * Quantity;
            DataTable dt = dalOrder.dbo_PR_INSERT_ORDER(TeaID, SnackID, Quantity, TotalAmount, OrderAddress);
            return RedirectToAction("OrderList");
        }

        public IActionResult OrderDetailsFromCart()
        {
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            return View();
        }

        public IActionResult InsertOrderFromCart(string Address)
        {

            DataTable dt = dalCart.dbo_PR_SELECT_ALL_CART();
            foreach (DataRow dr in dt.Rows)
            {
                decimal TotalAmount = Convert.ToDecimal(dr["Price"]) * Convert.ToInt32(dr["Quantity"]);
                DataTable cartOrder = dalOrder.dbo_PR_INSERT_ORDER(dr["TeaID"] != DBNull.Value ? Convert.ToInt32(dr["TeaID"]) : 0, dr["SnackID"] != DBNull.Value ? Convert.ToInt32(dr["SnackID"]) : 0, Convert.ToInt32(dr["Quantity"]), TotalAmount, Address);
            }
            return RedirectToAction("DeleteCartByUserID");
        }

        public IActionResult DeleteCartByUserID()
        {
            if (Convert.ToBoolean(dalCart.dbo_PR_DELETE_ALL_FROM_CART_BY_USERID()))
            {

            }
            return RedirectToAction("OrderList");
        }
    }
}
