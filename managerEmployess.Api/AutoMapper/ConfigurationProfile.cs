using AutoMapper;
using managerEmployees.Domain.Commands;
using managerEmployees.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace managerEmployess.Api.AutoMapper
{
    public class ConfigurationProfile : Profile
    {

        public ConfigurationProfile()
        {



            #region Employees
            CreateMap<InsertNewEmployee, Employee>().ReverseMap();
            //CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
            #endregion




        }
    }
}
