using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiboAdvance.UseCases.NoSql.Gateway.Repositories.Commands
{
    public class IUserRepository
    {

        Task<User> InsertUserAsync(User user);

    }
}
