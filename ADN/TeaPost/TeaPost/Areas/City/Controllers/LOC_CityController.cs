using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TeaPost.Areas.City.Models;
using TeaPost.Areas.State.Models;
using TeaPost.BAL;
using TeaPost.DAL.City;
using TeaPost.DAL.State;

namespace TeaPost.Areas.City.Controllers
{
    [Area("City")]
    //[CheckAccess]   
    public class LOC_CityController : Controller
    {
        City_DAL dalCity = new City_DAL();
        State_DAL dalState = new State_DAL();

        #region LOC_CityList
        public IActionResult LOC_CityList()
        {
            DataTable dt = dalCity.dbo_PR_SELECT_ALL_LOC_CITY();
            return View("LOC_CityList", dt);
        }

        #endregion

        #region LOC_CityAddEdit

        public IActionResult LOC_CityAddEdit(int? CityID)
        {
            ViewBag.CountryList = dalState.dbo_PR_LOC_Country_ComboBox();
            ViewBag.StateList = dalCity.dbo_PR_LOC_StateComboBox();
            if (CityID != null && CityID > 0)
            {
                DataTable dt = dalCity.dbo_PR_SELECT_BY_PK_LOC_CITY(CityID);

                LOC_CityModel model = new LOC_CityModel();

                foreach (DataRow dr in dt.Rows)
                {
                    model.CityName = dr["CityName"].ToString();
                    model.CityCode = dr["CityCode"].ToString();
                    model.StateID = Convert.ToInt32(dr["StateID"]);
                    model.CountryID = Convert.ToInt32(dr["CountryID"]);
                }
                return View(model);
            }
            return View();
        }

        #endregion

        #region LOC_CitySave

        public IActionResult LOC_CitySave(LOC_CityModel model)
        {
            if (model.CityID == 0)
            {
                DataTable dt = dalCity.dbo_PR_INSERT_LOC_CITY(model.CityName, model.CityCode, model.StateID, model.CountryID);
                TempData["Data"] = "Record inserted successfully";
            }
            else
            {
                DataTable dt = dalCity.dbo_PR_UPDATE_BY_PK_LOC_CITY(model.CityID, model.CityName, model.CityCode, model.StateID, model.CountryID);
                TempData["Data"] = "Record updated successfully";
            }
            return RedirectToAction("LOC_CityList");
        }

        #endregion

        #region DeleteCity

        public IActionResult DeleteCity(int CityID)
        {
            if (Convert.ToBoolean(dalCity.dbo_PR_DELETE_BY_PK_LOC_CITY(CityID)))
            {
                TempData["Data"] = "Record deleted successfully";
            }
            return RedirectToAction("LOC_CityList");
        }

        #endregion

        #region StatesForComboBox

        [AllowAnonymous]
        public IActionResult StatesForComboBox(int? CountryID)
        {
            List<LOC_StateDropDownModel> list = dalCity.dbo_PR_State_StateByCountryID(CountryID);
            return Json(list);
        }

        #endregion

        #region LOC_City_Filter

        public IActionResult LOC_City_Filter(LOC_CityModel model)
        {
            DataTable dt = dalCity.dbo_PR_LOC_City_Filter(model);
            return View("LOC_CityList", dt);
        }

        #endregion
    }
}
