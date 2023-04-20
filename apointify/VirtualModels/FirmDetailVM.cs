namespace apointify.VirtualModels
{
    public class FirmDetailVM
    {
        public int FirmId { get; set; }

        public int? Userid { get; set; }

        public string ServiceName { get; set; } = null!;

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
}
