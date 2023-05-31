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
    public class AreaUseCase : lAreaUseCase
    {

        private readonly lAreaRepository _areaRepository;

        public AreaUseCase(lAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }


        public async Task<List<Area>> GetAllAreasAsync()
        {
            return await _areaRepository.GetAllAreasAsync();
        }

       

     

      
    }
}
