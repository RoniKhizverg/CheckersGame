using System.ComponentModel.DataAnnotations;
namespace Server.Model
{
    public class TblUsers
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 2, ErrorMessage = "UserName is too short, min length is {2}")]
        [Required(ErrorMessage = "Username is too short !")]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 6, ErrorMessage = "Password too short, min length is {2}")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int NumOfGames { get; set; }
        [Range(0500000000, 9999999999, ErrorMessage = "Enter number between 0 to 1000")]
        [DataType(DataType.PhoneNumber)]
        public decimal PhoneNumber { get; set; }


    }
}
