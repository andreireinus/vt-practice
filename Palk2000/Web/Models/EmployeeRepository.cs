namespace Web.Models
{
    using System.Collections.Generic;

    using Palk2000.Application;

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> employees = new List<Employee>
                                                    {
                                                        new Employee { Name = "Marek Helm", Salary = 3900, HasRaisedPensionPercentage = true },
                                                        new Employee { Name = "Ruth Paade", Salary = 2850, HasRaisedPensionPercentage = true },
                                                        new Employee { Name = "Uno Rink", Salary = 1265, HasRaisedPensionPercentage = true },
                                                        new Employee { Name = "Jaanus Jõgi", Salary = 1705, HasRaisedPensionPercentage = true },
                                                        new Employee { Name = "Helve Särgava", Salary = 4225, HasRaisedPensionPercentage = true },
                                                        new Employee { Name = "Leo Kunman", Salary = 3380, HasRaisedPensionPercentage = true },
                                                    };

        public IEnumerable<Employee> GetEmployees()
        {
            return this.employees;
        }
    }
}