using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace managerEmployess.Api.AutoMapper
{
    public class ConfigurationProfile : Profile
    {

        public ConfigurationProfile()
        {
         
         
            
            #region Employees
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
            #endregion




        }
    }
