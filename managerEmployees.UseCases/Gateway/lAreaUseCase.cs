using managerEmployees.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managerEmployees.UseCases.Gateway
{
    public interface lAreaUseCase
    {
        Task<List<Area>> GetAllAreasAsync();
    
    }
}
