﻿using ManagerEmployees.UseCases.NoSql.Gateway.Repositories.Commands;
using ManagerEmployees.UseCases.NoSql.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerEmployees.domain.NoSql.Entities;

namespace ManagerEmployees.UseCases.NoSql.UseCases
{
    public class UserUseCase : IUserUseCase
    {

        private readonly IUserRepository _userRepository;

        public UserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddUser(User user)
        {
            return await _userRepository.InsertUserAsync(user);
        }

    }
}
