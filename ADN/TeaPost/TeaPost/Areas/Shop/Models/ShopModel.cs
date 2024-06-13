namespace TeaPost.Areas.Shop.Models
{
    public class ShopModel
    {
        public int ShopID { get; set; }

        public string ShopName { get; set; }

        public string ShopImage { get; set; }

        public IFormFile File { get; set; }

        public string ShopArea { get; set; }

        public string SeatingCapacity { get; set; }

        public string VentilationType { get; set; }

        public String ShopDescription { get; set; }

        public string BrewedTea { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }

    public class ShopDropDownModel
    {
        public int ShopID { get; set;}
        public string ShopName { get; set; }

        public string ShopImage { get; set; }
    }
}
