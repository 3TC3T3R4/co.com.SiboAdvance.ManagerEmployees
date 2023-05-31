using ManagerEmployees.Infraestructure.NoSql.Entities;
using ManagerEmployees.Infraestructure.NoSql.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEmployees.Infraestructure.NoSql
{
    public class Context : IContext

    {
        private readonly IMongoDatabase _database;

        public Context(string stringConnection, string DBname)
        {
            MongoClient cliente = new(stringConnection);
            _database = cliente.GetDatabase(DBname);
        }

        public IMongoCollection<UserEntity> User => _database.GetCollection<UserEntity>("Users");


    }
}
