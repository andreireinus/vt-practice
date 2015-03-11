namespace Palk2000.Application
{
    using System.Collections.Generic;

    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
    }
}