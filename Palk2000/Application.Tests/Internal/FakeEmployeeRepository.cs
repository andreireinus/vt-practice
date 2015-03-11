namespace Palk2000.Application.Tests.Internal
{
    using System.Collections.Generic;
    using System.Linq;

    public class FakeEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> employees = new List<Employee>();

        public IEnumerable<Employee> GetEmployees()
        {
            return this.employees.AsEnumerable();
        }

        public void Add(Employee employee)
        {
            this.employees.Add(employee);
        }
    }
}