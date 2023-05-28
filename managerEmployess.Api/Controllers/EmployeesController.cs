using AutoMapper;
using managerEmployees.Domain.Commands;
using managerEmployees.Domain.Entities;
using managerEmployees.UseCases.Gateway;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace managerEmployess.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly lEmployeeUseCase _employeeUseCase;
        private readonly IMapper _mapper;


        public EmployeesController(lEmployeeUseCase employeeUseCase, IMapper mapper)
        {
            _employeeUseCase = employeeUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<string> Create_Employees([FromBody] InsertNewEmployee command)
        {
            return await _employeeUseCase.CreateEmployeeAsync(_mapper.Map<Employee>(command));
        }

        //[HttpGet]
        //public async Task<List<ContentWithDeliveries>> Get_All_Content()
        //{
        //    return await _contentUseCase.GetContentsAsync();
        //}

        //[HttpPut]
        //public async Task<string> Update_Content(string idContent, UpdateContentCommand command)
        //{
        //    return await _contentUseCase.UpdateContentAsync(idContent, _mapper.Map<Content>(command));
        //}

        //[HttpGet("{idContent}")]
        //public async Task<ContentWithDelivery> Get_ById_Content(string idContent)
        //{
        //    return await _contentUseCase.GetContentByIdAsync(idContent);
        //}




    }
}
