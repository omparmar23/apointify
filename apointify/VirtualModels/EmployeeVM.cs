using apointify.Models;

namespace apointify.VirtualModels
{
    public class EmployeeVM
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Age { get; set; }

        public int Salary { get; set; }

        public string Department { get; set; } = null!;
    }



    public class CustomerVM
    {
        public long CustomerId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MobileNo { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? UserName { get; set; }

        public string? UserEmailAddress { get; set; }

        public string? Password { get; set; }

        public string? HomeAddress { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Zipcode { get; set; }

        public DateTime? InsertedDate { get; set; }


    }

}
