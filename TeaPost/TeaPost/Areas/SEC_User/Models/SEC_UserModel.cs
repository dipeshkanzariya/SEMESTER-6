using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeaPost.Areas.SEC_User.Models
{
    public class SEC_UserModel
    {
        public int UserID { get; set; }

        [Required]
        [DisplayName("UserName")]
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        [DisplayName("PassWord")]
        public string PassWord { get; set; }

        public int CityID { get; set; }

        public string CityName { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }
       
    }
}