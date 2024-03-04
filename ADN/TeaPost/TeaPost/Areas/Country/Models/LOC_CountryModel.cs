namespace TeaPost.Areas.Country.Models
{
    public class LOC_CountryModel
    {
        //[Required]
        public int CountryID { get; set; }

        public string? CountryName { get; set; }

        public string? CountryCode { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }
    }

    public class LOC_CountryDropDownModel
    {
        public int CountryID { get; set; }
        public string CountryName { get; set;}
    }
}
