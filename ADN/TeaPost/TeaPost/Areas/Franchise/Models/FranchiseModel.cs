namespace TeaPost.Areas.Franchise.Models
{
    public class FranchiseModel
    {
        public int FID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string MobileNo { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public int CountryID { get; set; }

        public string CountryName { get; set; }

        public int StateID { get; set; }

        public string StateName { get; set; }

        public int CityID { get; set; }

        public string CityName { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
