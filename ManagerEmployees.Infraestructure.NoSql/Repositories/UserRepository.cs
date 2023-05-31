using AutoMapper;
using ManagerEmployees.domain.NoSql.Entities;
using ManagerEmployees.Infraestructure.NoSql.Entities;
using ManagerEmployees.Infraestructure.NoSql.Interfaces;
using ManagerEmployees.UseCases.NoSql.Gateway.Repositories.Commands;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEmployees.Infraestructure.NoSql.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IMongoCollection<UserEntity> userCollection;
        private readonly IMapper _mapper;
        public UserRepository(IContext context, IMapper mapper)
        {
            this.userCollection = context.User;
            _mapper = mapper;
        }
        public async Task<User> InsertUserAsync(User user)
        {
            var userSave = _mapper.Map<UserEntity>(user);
            await userCollection.InsertOneAsync(userSave);
            return user;
        }



    }
}
