using System.ComponentModel.DataAnnotations;

namespace apointify.VirtualModels
{
    public class resetVM
    {
        [Display(Name = "Password*")]
        [DataType(DataType.Password)]
        [RegularExpression("(?=.)(?=.[a-z])(?=.*[A-Z]).{8,}", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [Required(ErrorMessage = "Password Is Required.")]
        //[DataType(DataType.Password)]
        public string Password { get; set; } = null!;


        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
