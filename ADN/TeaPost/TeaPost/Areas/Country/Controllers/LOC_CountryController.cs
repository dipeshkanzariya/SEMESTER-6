using Microsoft.AspNetCore.Mvc;
using System.Data;
using TeaPost.Areas.Country.Models;
using TeaPost.BAL;
using TeaPost.DAL.Country;

namespace TeaPost.Areas.Country.Controllers
{
    [Area("Country")]
    //[CheckAccess]
    public class LOC_CountryController : Controller
    {
        LOC_CountryDAL dalLOC_Country = new LOC_CountryDAL();

        #region LOC_CountryList

        public IActionResult LOC_CountryList()
        {
            DataTable dt = dalLOC_Country.dbo_PR_SELECT_ALL_LOC_COUNTRY();
            return View("LOC_CountryList",dt);
        }

        #endregion

        #region LOC_CountryAddEdit
        public IActionResult LOC_CountryAddEdit(int CountryID)
        {
            if(CountryID != null && CountryID > 0) 
            {
                DataTable dt = dalLOC_Country.dbo_PR_SELECT_BY_PK_LOC_COUNTRY(CountryID);

                LOC_CountryModel model = new LOC_CountryModel();

                foreach (DataRow dr in dt.Rows)
                {
                    model.CountryName = dr["CountryName"].ToString();
                    model.CountryCode = dr["CountryCode"].ToString();

                }
                return View(model);
            }
            return View();
        }

        #endregion

        #region LOC_CountrySave
        public IActionResult LOC_CountrySave(LOC_CountryModel model)
        {
            if(model.CountryID == 0)
            {
                DataTable dt = dalLOC_Country.dbo_PR_INSERT_LOC_COUNTRY(model.CountryName, model.CountryCode);
                TempData["Data"] = "Record inserted successfully";
            }
            else
            {
                DataTable dt = dalLOC_Country.dbo_PR_UPDATE_BY_PK_LOC_COUNTRY(model.CountryID, model.CountryName, model.CountryCode);
                TempData["Data"] = "Record updated successfully";
            }
            return RedirectToAction("LOC_CountryList");
        }

        #endregion

        #region DeleteCountry
        public IActionResult DeleteCountry(int? CountryID)
        {
            if(Convert.ToBoolean(dalLOC_Country.dbo_PR_DELETE_BY_PK_LOC_COUNTRY(CountryID)))
            {
                TempData["Data"] = "Record deleted successfully";
                return RedirectToAction("LOC_CountryList");
            }
            return RedirectToAction("LOC_CountryList");
        }

        #endregion

        #region LOC_Country_Filter

        public IActionResult LOC_Country_Filter(string CountryName, string CountryCode)
        {
            DataTable dt = dalLOC_Country.dbo_PR_LOC_Country_Filter(CountryName, CountryCode);

            return View("LOC_CountryList", dt);
        }

        #endregion
    }
}
