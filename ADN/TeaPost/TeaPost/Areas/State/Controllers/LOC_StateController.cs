using Microsoft.AspNetCore.Mvc;
using System.Data;
using TeaPost.Areas.State.Models;
using TeaPost.DAL.State;

namespace TeaPost.Areas.State.Controllers
{
    [Area("State")]

    public class LOC_StateController : Controller
    {
        State_DAL dalState = new State_DAL();

        #region LOC_StateList
        public IActionResult LOC_StateList()
        {
            DataTable dt = dalState.dbo_PR_SELECT_ALL_LOC_STATE();
            return View("LOC_StateList", dt);
        }

        #endregion

        #region LOC_StateAddEdit

        public IActionResult LOC_StateAddEdit(int StateID)
        {
            ViewBag.CountryList = dalState.dbo_PR_LOC_Country_ComboBox();
            if (StateID != null && StateID > 0) 
            {
                DataTable dt = dalState.dbo_PR_SELECT_BY_PK_LOC_STATE(StateID);

                LOC_StateModel model = new LOC_StateModel();

                foreach (DataRow dr in dt.Rows)
                {
                    model.StateName = dr["StateName"].ToString();
                    model.StateCode = dr["StateCode"].ToString();
                    model.CountryID = Convert.ToInt32(dr["CountryID"]);
                }
                return View(model);
            }
            return View();
        }

        #endregion

        #region LOC_StateSave

        public IActionResult LOC_StateSave(LOC_StateModel model)
        {
            if (model.StateID == 0)
            {
                DataTable dt = dalState.dbo_PR_INSERT_LOC_STATE(model.StateName, model.StateCode, model.CountryID);
                TempData["Data"] = "Record inserted Successfully";
            }
            else
            {
                DataTable dt = dalState.dbo_PR_UPDATE_BY_PK_LOC_STATE(model.StateID, model.StateName, model.StateCode, model.CountryID);
                TempData["Data"] = "Record updated Successfully";
            }
            return RedirectToAction("LOC_StateList");
        }

        #endregion

        #region DeleteState

        public IActionResult DeleteState(int? StateID)
        {
            if(Convert.ToBoolean(dalState.dbo_PR_DELETE_BY_PK_LOC_STATE(StateID)))
            {
                TempData["Data"] = "Record deleted successfully";
            }
            return RedirectToAction("LOC_StateList");
        }

        #endregion

        #region LOC_State_Filter

        public IActionResult LOC_State_Filter(LOC_StateModel model)
        {
            DataTable dt = dalState.dbo_PR_LOC_State_Filter(model);
            return View("LOC_StateList", dt);
        }

        #endregion
    }
}
