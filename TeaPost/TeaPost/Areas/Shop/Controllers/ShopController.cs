using Microsoft.AspNetCore.Mvc;
using System.Data;
using TeaPost.Areas.Shop.Models;
using TeaPost.DAL.Shop;

namespace TeaPost.Areas.Shop.Controllers
{
    [Area("Shop")]
    public class ShopController : Controller
    {
        Shop_DAL dalShop = new Shop_DAL();

        #region ShopList
        public IActionResult ShopList()
        {
            DataTable dt = dalShop.dbo_PR_SELECT_ALL_SHOP();
            return View("ShopList", dt);
        }

        #endregion

        #region ShopAddEdit

        public IActionResult ShopAddEdit(int ShopID) 
        {
            if(ShopID != null && ShopID > 0)
            {
                DataTable dt = dalShop.dbo_PR_SELECT_BY_PK_SHOP(ShopID);

                ShopModel model = new ShopModel();

                foreach (DataRow dr in dt.Rows)
                {
                    model.ShopName = dr["ShopName"].ToString();
                    model.ShopImage = dr["ShopImage"].ToString();
                    model.ShopArea = dr["ShopArea"].ToString();
                    model.SeatingCapacity = dr["SeatingCapacity"].ToString();
                    model.VentilationType = dr["VentilationType"].ToString();
                    model.BrewedTea = dr["BrewedTea"].ToString();
                }
                return View(model);
            }
            return View();

        }

        #endregion

        #region ShopSave

        public IActionResult ShopSave(ShopModel model)
        {
            if(model.ShopID == 0)
            {
                DataTable dt = dalShop.dbo_PR_INSERT_SHOP(model.ShopName, model.ShopImage, model.ShopArea, model.SeatingCapacity, model.VentilationType, model.BrewedTea);
                TempData["Data"] = "Record inserted successfully";
            }
            else
            {
                DataTable dt = dalShop.dbo_PR_UPDATE_SHOP(model.ShopID, model.ShopName, model.ShopImage, model.ShopArea, model.SeatingCapacity, model.VentilationType, model.BrewedTea);
                TempData["Data"] = "Record updated successfully";
            }
            return RedirectToAction("ShopList");
        }

        #endregion

        #region DeleteShop

        public IActionResult DeleteShop(int shopID)
        {
            if (Convert.ToBoolean(dalShop.dbo_PR_DELETE_SHOP(shopID)))
            {
                TempData["Data"] = "Record deleted successfully";
                return RedirectToAction("ShopList");
            }
            return RedirectToAction("ShopList");
        }

        #endregion

        #region Shop_Filter

        public IActionResult Shop_Filter(ShopModel model)
        {
            DataTable dt = dalShop.dbo_PR_Shop_Filter(model);
            return View("ShopList", dt);
        }

        #endregion
    }
}
