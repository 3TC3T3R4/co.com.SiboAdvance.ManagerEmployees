using managerEmployees.Domain.Commands;
using managerEmployees.Domain.Entities;


namespace managerEmployees.UseCases.Gateway.Repositories
{
    public interface lEmployeeRepository
    {

        Task<string> CreateEmployeeAsync(Employee employee);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<string> UpdateEmployeeAsync(int idEmployee, UpdateEmployee employee);

        Task<Employee> GetEmployeeByIdAsync(int idEmployee);





    }
}
