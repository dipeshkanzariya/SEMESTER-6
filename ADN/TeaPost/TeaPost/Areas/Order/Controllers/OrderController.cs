using Microsoft.AspNetCore.Mvc;
using System.Data;
using TeaPost.Areas.Order.Models;
using TeaPost.DAL.Order;

namespace TeaPost.Areas.Order.Controllers
{
    [Area("Order")]
    public class OrderController : Controller
    {
        Order_DAL dalOrder = new Order_DAL();
        
        #region OrderList

        public IActionResult OrderList()
        {
            DataTable dt = dalOrder.dbo_PR_SELECT_ALL_ORDER();
            return View("OrderList", dt);
        }


        #endregion

        #region OrderEdit

        public IActionResult OrderEdit(int OrderID)
        {
            if (OrderID != null && OrderID > 0)
            {
                DataTable dt = dalOrder.dbo_PR_SELECT_BY_PK_ORDER(OrderID);

                OrderModel model = new OrderModel();

                foreach (DataRow dr in dt.Rows)
                {
                    model.OrderAddress = dr["OrderAddress"].ToString();
                    model.OrderStatus = dr["OrderStatus"].ToString();
                }
                return View(model);
            }
            return View();
        }

        #endregion

        #region UpdateOrder

        public IActionResult UpdateOrder(OrderModel model)
        {
            if (model.OrderID != null)
            {
                DataTable dt = dalOrder.dbo_PR_UPDATE_ORDER(model.OrderID, model.OrderAddress, model.OrderStatus);
                TempData["Data"] = "Record updated successfully";
            }
            return RedirectToAction("OrderList");
        }

        #endregion

        #region PR_ORDER_FILTER

        public IActionResult PR_ORDER_FILTER(string? UserName, DateTime? FromDate, DateTime? ToDate)
        {
            DataTable dt = dalOrder.dbo_PR_ORDER_FILTER(UserName, FromDate, ToDate);
            return View("OrderList", dt);
        }

        #endregion
    }
}
