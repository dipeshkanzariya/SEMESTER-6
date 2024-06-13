using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TeaPost.Areas.City.Models;
using TeaPost.Areas.Franchise.Models;
using TeaPost.Areas.State.Models;
using TeaPost.DAL.City;
using TeaPost.DAL.Franchise;
using TeaPost.DAL.State;

namespace TeaPost.Areas.Franchise.Controllers
{
    [Area("Franchise")]
    public class FranchiseController : Controller
    {
        Franchise_DAL dalFranc = new Franchise_DAL();
        State_DAL dalState = new State_DAL();
        City_DAL dalCity = new City_DAL();

        #region FranchiseList

        public IActionResult FranchiseList()
        {
            DataTable dt = dalFranc.dbo_PR_SELECT_ALL_FRANCHISE();
            return View("FranchiseList", dt);
        }

        #endregion

        #region FranchiseAddEdit

        public IActionResult FranchiseAddEdit(int FID)
        {
            ViewBag.CountryList = dalState.dbo_PR_LOC_Country_ComboBox();
            ViewBag.StateList = dalCity.dbo_PR_LOC_StateComboBox();
            ViewBag.CityList = dalCity.dbo_PR_LOC_CityComboBox();
            if (FID != null && FID > 0)
            {
                DataTable dt = dalFranc.dbo_PR_SELECT_BY_PK_FRANCHISE(FID);

                FranchiseModel model = new FranchiseModel();

                foreach(DataRow dr in dt.Rows)
                {
                    model.FirstName = dr["FirstName"].ToString();
                    model.LastName = dr["LastName"].ToString();
                    model.BirthDate = Convert.ToDateTime(dr["BirthDate"]);
                    model.Gender = dr["Gender"].ToString();
                    model.MobileNo = dr["MobileNo"].ToString();
                    model.Email = dr["Email"].ToString();
                    model.Address = dr["Address"].ToString();
                    model.CountryID = Convert.ToInt32(dr["CountryID"]);
                    model.StateID = Convert.ToInt32(dr["StateID"]);
                    model.CityID = Convert.ToInt32(dr["CityID"]);
                }
                return View(model);
            }
            return View();
        }

        #endregion

        #region FranchiseSave

        public IActionResult FranchiseSave(FranchiseModel model)
        {
            if (model.FID == 0)
            {
                DataTable dt = dalFranc.dbo_PR_INSERT_FRANCHISE(model.FirstName, model.LastName, model.BirthDate, model.Gender, model.MobileNo, model.Email, model.Address, model.CountryID, model.StateID, model.CityID);
                TempData["Data"] = "Record inserted successfully";
            }
            else
            {
                DataTable dt = dalFranc.dbo_PR_UPDATE_FRANCHISE(model.FID, model.FirstName, model.LastName, model.BirthDate, model.Gender, model.MobileNo, model.Email, model.Address, model.CountryID, model.StateID, model.CityID);
                TempData["Data"] = "Record updated successfully";
            }
            return RedirectToAction("FranchiseList");
        }

        #endregion

        #region DeleteFranchise

        public IActionResult DeleteFranchise(int FID)
        {
            if(Convert.ToBoolean(dalFranc.dbo_PR_DELETE_FRANCHISE(FID)))
            {
                TempData["Data"] = "Record deleted Successfully";
            }
            return RedirectToAction("FranchiseList");
        }

        #endregion

        #region Franchise_Filter

        public IActionResult Franchise_Filter(FranchiseModel model)
        {
            DataTable dt = dalFranc.dbo_PR_Filter_Franchise(model);
            return View("FranchiseList", dt);
        }

        #endregion

        #region LOC_CityForComboBox

        [AllowAnonymous]
        public IActionResult LOC_CityForComboBox(int StateID)
        {
            List<LOC_CityDropDownModel> list = dalFranc.dbo_PR_Select_City_By_StateID(StateID);
            return Json(list);
        }

        #endregion
    }
}
