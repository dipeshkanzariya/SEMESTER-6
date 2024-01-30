using Microsoft.AspNetCore.Mvc;
using System.Data;
using TeaPost.Areas.Snack.Models;
using TeaPost.DAL.Snack;
using TeaPost.DAL.Tea;

namespace TeaPost.Areas.Snack.Controllers
{
    [Area("Snack")]
    public class SnackController : Controller
    {
        Snack_DAL dalSnack = new Snack_DAL();
        Tea_DAL dalTea = new Tea_DAL();

        #region SnackList

        public IActionResult SnackList()
        {
            DataTable dt = dalSnack.dbo_PR_SELECT_ALL_SNACK();
            return View("SnackList", dt);
        }

        #endregion

        #region SnackAddEdit

        public IActionResult SnackAddEdit(int SnackID)
        {
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            if(SnackID != null && SnackID > 0)
            {
                DataTable dt = dalSnack.dbo_PR_SELECT_BY_PK_SNACK(SnackID);

                SnackModel model = new SnackModel();

                foreach (DataRow dr in dt.Rows)
                {
                    model.SnackName = dr["SnackName"].ToString();
                    model.SnackImage = dr["SnackImage"].ToString();
                    model.Price = Convert.ToDecimal(dr["Price"]);
                    model.BriefDescription = dr["BriefDescription"].ToString();
                    model.Size = dr["Size"].ToString();
                    model.Description = dr["Description"].ToString();
                    model.ShopID = Convert.ToInt32(dr["ShopID"]);
                }
                return View(model);
            }
            return View();
        }

        #endregion

        #region SaveSnack

        public IActionResult SaveSnack(SnackModel model)
        {
            if (model.SnackID == 0)
            {
                DataTable dt = dalSnack.dbo_PR_PR_INSERT_SNACK(model.SnackName, model.SnackImage, model.Price, model.BriefDescription, model.Size, model.Description, model.ShopID);
                TempData["Data"] = "Record inserted successfully";
            }
            else
            {
                DataTable dt = dalSnack.dbo_PR_UPDATE_SNACK(model.SnackID, model.SnackName, model.SnackImage, model.Price, model.BriefDescription, model.Size, model.Description, model.ShopID);
                TempData["Data"] = "Record updated successfully";
            }
            return RedirectToAction("SnackList");
        }

        #endregion

        #region DeleteSnack

        public IActionResult DeleteSnack(int SnackID)
        {
            if (Convert.ToBoolean(dalSnack.dbo_PR_DELETE_SNACK(SnackID)))
            {
                TempData["Data"] = "Record deleted successfully";
            }
            return RedirectToAction("SnackList");
        }

        #endregion
    }
}
