using apointify.Models;
using apointify.VirtualModels;

namespace apointify.ExtentionMethods
{
    public static class HelperClass
    {

        

        public static EmployeeVM ToModel(this Employee obj)
        {
            return new EmployeeVM()
            {
                Id = obj.Id,
                Name = obj.Name,
                Salary = obj.Salary,
                Age = obj.Age,
                Department = obj.Department,
            };
        }
        public static Employee ToContext(this EmployeeVM obj)
        {
            return new Employee()
            {
                Id = obj.Id,
                Name = obj.Name,
                Salary = obj.Salary,
                Age = obj.Age,
                Department = obj.Department,
            };
        }


        public static CustomerVM ToModel(this Customer obj)
        {
            return new CustomerVM()
            {
                CustomerId = obj.CustomerId,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                MobileNo = obj.MobileNo,
                BirthDate = obj.BirthDate,
                UserName = obj.UserName,
                UserEmailAddress = obj.UserEmailAddress,
                Password = obj.Password,
                HomeAddress = obj.HomeAddress,
                City = obj.City,
                State = obj.State,
                Zipcode = obj.Zipcode,
                InsertedDate = obj.InsertedDate,



            };

        }
        public static Customer ToContext(this CustomerVM obj)
        {
            return new Customer()
            {
                CustomerId = obj.CustomerId,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                MobileNo = obj.MobileNo,
                BirthDate = obj.BirthDate,
                UserName = obj.UserName,
                UserEmailAddress = obj.UserEmailAddress,
                Password = obj.Password,
                HomeAddress = obj.HomeAddress,
                City = obj.City,
                State = obj.State,
                Zipcode = obj.Zipcode,
                InsertedDate = obj.InsertedDate,
            };
        }


    }
};
