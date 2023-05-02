using apointify.Models;
using System.ComponentModel.DataAnnotations;





namespace apointify.VirtualModels
{
    public partial class UserVM
    {
        public int UserId { get; set; }

        public int? Role { get; set; }

        [Display(Name = "UserName*")]
        [Required(ErrorMessage = "UserName Is Required.")]
        public string Username { get; set; } = null!;

        [Display(Name = "Name*")]
        [Required(ErrorMessage = "Name Is Required.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Email*")]
        [Required(ErrorMessage = "Email Is Required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = null!;



        [Display(Name = "Password*")]
        [RegularExpression("(?=.)(?=.[a-z])(?=.*[A-Z]).{8,}", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [Required(ErrorMessage = "Password Is Required.")]
        //[DataType(DataType.Password)]
        public string Password { get; set; } = null!;


        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mobile Number*")]
        [Required(ErrorMessage = "Mobile is required")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Please enter 10 digit Mobile No.")]
        public string? MobileNumber { get; set; }

        [Display(Name = "City*")]
        [Required(ErrorMessage = "City is required.")]
        public string? City { get; set; }

        public DateTime? InsertData { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();

        public virtual Role RoleNavigation { get; set; } = null!;
    }
}
