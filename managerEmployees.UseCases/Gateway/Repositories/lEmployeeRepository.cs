using managerEmployees.Domain.Entities;


namespace managerEmployees.UseCases.Gateway.Repositories
{
    public interface lEmployeeRepository
    {

        Task<Employee> CreateEmployeeAsync(Employee employee);






    }
}
