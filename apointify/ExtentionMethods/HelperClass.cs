using apointify.Models;
using apointify.VirtualModels;

namespace apointify.ExtentionMethods
{
    public static class HelperClass
    {

        #region --> NewsVM

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
        #endregion
    }
}
