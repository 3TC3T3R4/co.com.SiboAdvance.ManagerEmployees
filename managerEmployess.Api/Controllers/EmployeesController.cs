using AutoMapper;
using managerEmployees.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace managerEmployess.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesUseCase _employeesUseCase;
        private readonly IMapper _mapper;


        public EmployeesController(IEmployeesUseCase employeesUseCase, IMapper mapper)
        {
            _employeesUseCase = employeesUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<string> Create_Employees(CreateEmployeesCommand command)
        {
            return await _employeesUseCase.CreateEmployeesAsync(_mapper.Map<Employee>(command));
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
