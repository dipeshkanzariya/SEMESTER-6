namespace TeaPost.Areas.Tea.Models
{
    public class TeaModel
    {
        public int TeaID { get; set; }

        public string TeaName { get; set;}

        public string TeaImage { get; set;}

        public IFormFile File { get; set;}

        public decimal Price { get; set;}

        public string BriefDescription { get; set;}

        public decimal Weight { get; set;}

        public int Stock { get; set;}

        public string Description { get; set;}

        public int ShopID { get; set;}

        public string ShopName { get; set;}

        public DateTime? Cretaed { get; set;}

        public DateTime? Modified { get; set;}
    }
}
