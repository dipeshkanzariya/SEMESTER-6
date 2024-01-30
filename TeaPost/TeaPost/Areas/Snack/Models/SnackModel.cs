using System.ComponentModel;

namespace TeaPost.Areas.Snack.Models
{
    public class SnackModel
    {
        public int SnackID { get; set; }

        public string SnackName { get; set;}

        public string SnackImage { get; set;}

        public decimal Price { get; set;}

        public string BriefDescription { get; set;}

        public string Size { get; set;}

        public string Description { get; set;}

        public int ShopID { get; set;}

        public string ShopName { get; set;}

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
