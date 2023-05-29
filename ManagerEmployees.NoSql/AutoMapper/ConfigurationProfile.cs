using ManagerEmployees.domain.NoSql.Commands;
using ManagerEmployees.domain.NoSql.Entities;
using ManagerEmployees.Infraestructure.NoSql.Entities;
using AutoMapper;
namespace ManagerEmployees.NoSql.AutoMapper
{
    public class ConfigurationProfile:Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<InsertNewUser, User>().ReverseMap();
            CreateMap<UserEntity, User>().ReverseMap();

        }
    }
}
