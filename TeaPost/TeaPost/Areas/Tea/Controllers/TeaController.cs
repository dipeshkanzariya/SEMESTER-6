using Microsoft.AspNetCore.Mvc;
using System.Data;
using TeaPost.Areas.Shop.Models;
using TeaPost.Areas.Tea.Models;
using TeaPost.DAL.Tea;

namespace TeaPost.Areas.Tea.Controllers
{
    [Area("Tea")]
    public class TeaController : Controller
    {
        Tea_DAL dalTea = new Tea_DAL();

        #region TeaList

        public IActionResult TeaList()
        {
            DataTable dt = dalTea.dbo_PR_SELECT_ALL_TEA();
            return View("TeaList", dt);
        }

        #endregion

        #region TeaAddEdit

        public IActionResult TeaAddEdit(int? TeaID)
        
        {
            ViewBag.ShopList = dalTea.dbo_PR_Shop_ComboBox();
            if (TeaID != null && TeaID > 0)
            {
                DataTable dt = dalTea.dbo_PR_SELECT_BY_PK_TEA(TeaID);
                
                TeaModel model = new TeaModel();

                foreach(DataRow dr in dt.Rows)
                {
                    model.TeaName = dr["TeaName"].ToString();
                    model.TeaImage = dr["TeaImage"].ToString();
                    model.Price = Convert.ToDecimal(dr["Price"]);
                    model.BriefDescription = dr["BriefDescription"].ToString();
                    model.Weight = dr["Weight"].ToString();
                    model.Stock = dr["Stock"].ToString();
                    model.Description = dr["Description"].ToString();
                    model.ShopID = Convert.ToInt32(dr["ShopID"]);
                }
                return View(model);
            }
            return View();
        }

        #endregion

        #region SaveTea

        public IActionResult SaveTea(TeaModel model)
        {
            if (model.TeaID == 0)
            {
                DataTable dt = dalTea.dbo_PR_INSERT_TEA(model.TeaName, model.TeaImage, model.Price, model.BriefDescription, model.Weight, model.Stock, model.Description, model.ShopID);
                TempData["Data"] = "Record inserted successfully";
            }
            else
            {
                DataTable dt = dalTea.dbo_PR_UPDATE_TEA(model.TeaID, model.TeaName, model.TeaImage, model.Price, model.BriefDescription, model.Weight, model.Stock, model.Description, model.ShopID);
                TempData["Data"] = "Record updated successfully";
            }
            return RedirectToAction("TeaList");
        }

        #endregion

        #region DeleteTea

        public IActionResult DeleteTea(int? TeaID)
        {
            if (Convert.ToBoolean(dalTea.dbo_PR_DELETE_TEA(TeaID)))
            {
                TempData["Data"] = "Record deleted successfully";
                return RedirectToAction("TeaList");
            }
            return RedirectToAction("TeaList");
        }

        #endregion

        #region Tea_Filter

        public IActionResult Tea_Filter(TeaModel model)
        {
            DataTable dt = dalTea.dbo_PR_Tea_Filter(model);
            return View("TeaList", dt);
        }

        #endregion
    }
}
