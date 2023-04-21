/*using Microsoft.AspNetCore.Http;


namespace apointify.VirtualModels
{
    public class FirmDetailVM
    {
        public int FirmId { get; set; }

        public int Userd { get; set; }

        public int ServiceId { get; set; } 

        public string ServiceType { get; set; } = null!;

        public string FirmName { get; set; } = null!;

        public IFormFile Image { get; set; } = null!;
        public string FirmImage { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string MobileNumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string City { get; set; } = null!;

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool? IsDeleted { get; set; }


    }
}*/



using System.ComponentModel.DataAnnotations;

namespace apointify.VirtualModels
{
    public class FirmDetailVM
    {
        public int FirmId { get; set; }

        public int Userid { get; set; }

        [Display(Name = "ServiceName*")]
        [Required(ErrorMessage = "Please Select ServiceName.")]
        public int ServiceId { get; set; } 

        [Display(Name = "ServiceType*")]
        [Required(ErrorMessage = "Please Select ServiceType.")]
        public string ServiceType { get; set; } = null!;


        [Display(Name = "FirmName*")]
        [Required(ErrorMessage = "FirmName Is Required.")]
        public string FirmName { get; set; } = null!;

        [Display(Name = "Upload File*")]
        [Required(ErrorMessage = "Please Upload File")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        /*[Validation]*/
        public IFormFile Image { get; set; } = null!;

        public string FirmImage { get; set; } = null!;

        [Display(Name = "Email*")]
        [Required(ErrorMessage = "Email Is Required.")]
        [DataType(DataType.EmailAddress)]
        /*[EmailAddress(ErrorMessage = "Invalid email format.")]*/
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = null!;

        [Display(Name = "Mobile Number*")]
        [Required(ErrorMessage = "Mobile is required")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Please enter 10 digit Mobile No.")]
        public string MobileNumber { get; set; } = null!;

        [Display(Name = "Address*")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = null!;

        [Display(Name = "City*")]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; } = null!;

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool? IsDeleted { get; set; }


    }
    /*public class ValidateFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int MaxLength = 1024 * 1024 * 3; //3 MB
            string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".pdf" };

            var file = value as IFormFile;

            if (file == null)
                return false;
            else if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
            {
                ErrorMessage = "Please upload Your Photo of type: " + string.Join(", ", AllowedFileExtensions);
                return false;
            }
            else if (file.Length > MaxLength)
            {
                ErrorMessage = "Your Photo is too large, maximum allowed size is : " + (MaxLength / 1024).ToString() + "MB";
                return false;
            }
            else
                return true;
        }
    }*/
}
