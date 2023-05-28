using AutoMapper;
using managerEmployees.Domain.Commands;
using managerEmployees.Domain.Entities;
using managerEmployees.UseCases.Gateway;
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
        [Route("InsertNewEmployee")]
        public async Task<string> Create_Employees([FromBody] InsertNewEmployee command)
        {
            return await _employeeUseCase.CreateEmployeeAsync(_mapper.Map<Employee>(command));
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<List<Employee>> Get_All_Employee()
        {
            return await _employeeUseCase.GetAllEmployeesAsync();
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<string> Update_Employee(int idEmployee, [FromBody] UpdateEmployee command)
        {
            return await _employeeUseCase.UpdateEmployeeAsync(idEmployee, command);
        }

        //[HttpGet("{idContent}")]
        //public async Task<ContentWithDelivery> Get_ById_Content(string idContent)
        //{
        //    return await _contentUseCase.GetContentByIdAsync(idContent);
        //}




    }
}
