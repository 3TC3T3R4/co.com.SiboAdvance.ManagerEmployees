using managerEmployees.Domain.Entities;


namespace managerEmployees.UseCases.Gateway.Repositories
{
    public interface lEmployeeRepository
    {

        Task<string> CreateEmployeeAsync(Employee employee);
        Task<List<Employee>> GetAllEmployeesAsync();








    }
}
