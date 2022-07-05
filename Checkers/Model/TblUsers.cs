using System.ComponentModel.DataAnnotations;
namespace Server.Model
{
    public class TblUsers
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3, ErrorMessage = "UserName is too short, min length is {2}")]
        [Required(ErrorMessage = "Username is too short !")]
        public string? Name { get; set; }

        [StringLength(60, MinimumLength = 6, ErrorMessage = "Password too short, min length is {2}")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public int NumOfGames { get; set; }
        [Required]
        //[StringLength(20, ErrorMessage = "phone number is too short, min length is {10}")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }


    }
}
