using ManagerEmployees.Infraestructure.NoSql.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEmployees.Infraestructure.NoSql.Interfaces
{
    public interface IContext
    {
        public IMongoCollection<UserEntity> User { get; }


    }
}
