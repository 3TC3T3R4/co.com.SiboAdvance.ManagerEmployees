using AutoMapper;
using managerEmployees.Domain.Entities;
using managerEmployees.UseCases.Gateway;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace managerEmployess.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubAreasController : ControllerBase
    {
        private readonly lSubAreaUseCase _subAreaUseCase;
        private readonly IMapper _mapper;

        public SubAreasController(lSubAreaUseCase SubAreaUseCase, IMapper mapper)
        {
            _subAreaUseCase = SubAreaUseCase;
            _mapper = mapper;
        }

        [HttpGet("{idArea}")]
        public async Task<List<SubArea>> Get_SubAreas_ById_Area(int idArea)
        {
            return await _subAreaUseCase.GetAllSubAreasByIdAreaAsync(idArea);
        }

    }
}
