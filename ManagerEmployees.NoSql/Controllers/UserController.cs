using AutoMapper;
using ManagerEmployees.domain.NoSql.Commands;
using ManagerEmployees.domain.NoSql.Entities;
using ManagerEmployees.UseCases.NoSql.Gateway;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagerEmployees.NoSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserUseCase _userUseCase;
        private readonly IMapper _mapper;

        public UserController(IUserUseCase userUseCase, IMapper mapper)
        {
            _userUseCase = userUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<User> Create_User([FromBody] InsertNewUser command)
        {
            return await _userUseCase.AddUser(_mapper.Map<User>(command));
        }
    }
}
