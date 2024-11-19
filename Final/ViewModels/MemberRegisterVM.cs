using System.ComponentModel.DataAnnotations;

namespace Final.ViewModels
{
    public class MemberRegisterVM
    {
        
        [Required]

        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
