using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEmployees.UseCases.NoSql.Gateway
{
    public interface IUserUseCase
    {

        Task<User> AddUser(User user);
    }
}
