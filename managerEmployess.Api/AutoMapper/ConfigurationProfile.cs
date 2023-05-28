using AutoMapper;
using managerEmployees.Domain.Commands;
using managerEmployees.Domain.Entities;


namespace managerEmployess.Api.AutoMapper
{
    public class ConfigurationProfile : Profile
    {

        public ConfigurationProfile()
        {



            #region Employees
            CreateMap<InsertNewEmployee, Employee>().ReverseMap();
            CreateMap<UpdateEmployee, Employee>().ReverseMap();
            #endregion




        }
    }
}
