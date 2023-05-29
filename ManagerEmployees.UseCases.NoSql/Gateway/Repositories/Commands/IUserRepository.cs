using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEmployees.UseCases.NoSql.Gateway.Repositories.Commands
{
    public interface IUserRepository
    {

        Task<User> InsertUserAsync(User user);
    }
}
