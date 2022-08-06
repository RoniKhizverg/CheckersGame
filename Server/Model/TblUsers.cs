using System.ComponentModel.DataAnnotations;
namespace Server.Model
{
    public class TblUsers
    {
        [Range(1, 1000, ErrorMessage = "Please Enter id between 0 to 1000")]
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 2, ErrorMessage = "UserName is too short, min length is {2}")]
        [Required(ErrorMessage = "Username is too short !")]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 6, ErrorMessage = "Password too short, min length is {2}")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int NumOfGames { get; set; }
        [Range(0500000000, 999999999, ErrorMessage = "phone number must be 10 digits")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


    }
}
