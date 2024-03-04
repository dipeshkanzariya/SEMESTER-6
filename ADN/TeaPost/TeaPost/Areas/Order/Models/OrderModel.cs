namespace TeaPost.Areas.Order.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }

        public int Quantity { get; set; }

        public decimal TotalAmount { get; set; }

        public string OrderAddress { get; set; }

        public string OrderStatus { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
