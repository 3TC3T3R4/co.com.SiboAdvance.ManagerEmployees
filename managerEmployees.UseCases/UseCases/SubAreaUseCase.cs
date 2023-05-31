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
    public class SubAreaUseCase: lSubAreaUseCase
    {
        private readonly lSubAreaRepository _subAreaRepository;

        public SubAreaUseCase(lSubAreaRepository subAreaRepository)
        {
            _subAreaRepository = subAreaRepository;
        }
        public async Task<List<SubArea>> GetAllSubAreasByIdAreaAsync(int idArea)
        {
            return await _subAreaRepository.GetAllSubAreasByIdAreaAsync(idArea);
        }   
    }
}
