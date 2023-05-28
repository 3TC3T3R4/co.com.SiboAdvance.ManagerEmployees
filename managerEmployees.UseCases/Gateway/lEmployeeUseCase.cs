using managerEmployees.Domain.Entities;
using managerEmployees.UseCases.Gateway.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managerEmployees.UseCases.Gateway
{
    public interface lEmployeeUseCase
    {

        Task<string> CreateEmployeeAsync(Employee employee);





    }
}
