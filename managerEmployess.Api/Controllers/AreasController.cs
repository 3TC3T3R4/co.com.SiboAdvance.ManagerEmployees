using AutoMapper;
using managerEmployees.Domain.Entities;
using managerEmployees.UseCases.Gateway;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace managerEmployess.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly lAreaUseCase _areaUseCase;
        private readonly IMapper _mapper;

        public AreasController(lAreaUseCase areaUseCase, IMapper mapper)
        {
            _areaUseCase = areaUseCase;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllAreas")]
        public async Task<List<Area>> Get_All_Areas()
        {
            return await _areaUseCase.GetAllAreasAsync();
        }



    }
}
