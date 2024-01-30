using Microsoft.AspNetCore.Mvc;
using System.Data;
using TeaPost.Areas.Franchise.Models;
using TeaPost.DAL.Franchise;

namespace TeaPost.Areas.Franchise.Controllers
{
    [Area("Franchise")]
    public class FranchiseController : Controller
    {
        Franchise_DAL dalFranc = new Franchise_DAL();

        #region FranchiseList

        public IActionResult FranchiseList()
        {
            DataTable dt = dalFranc.dbo_PR_SELECT_ALL_FRANCHISE();
            return View("FranchiseList", dt);
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
    }
}
