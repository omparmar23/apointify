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
}
