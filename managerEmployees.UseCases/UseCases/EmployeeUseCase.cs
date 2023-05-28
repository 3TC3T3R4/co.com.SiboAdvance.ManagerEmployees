using managerEmployees.Domain.Entities;
using managerEmployees.UseCases.Gateway;
using managerEmployees.UseCases.Gateway.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managerEmployees.UseCases.UseCases
{
    public class EmployeeUseCase : lEmployeeUseCase
    {
        private readonly lEmployeeRepository _employeeRepository;

        public EmployeeUseCase(lEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<string> CreateEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.CreateEmployeeAsync(employee);
        }

        public async Task<List<Employee>> GetAllEmployeesAsync() {
            
            return await _employeeRepository.GetAllEmployeesAsync();

        }




    }
}
