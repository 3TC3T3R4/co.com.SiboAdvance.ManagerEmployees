using AutoMapper;
using Dapper;
using managerEmployees.Domain.Entities;
using managerEmployees.Infraestructure.SqlAdapter.Gateway;
using managerEmployees.UseCases.Gateway.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managerEmployees.Infraestructure.SqlAdapter.Repositories
{
    public class AreaRepository: lAreaRepository
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly IMapper _mapper;

        private readonly string _tableArea = "Area";

        public AreaRepository(IDbConnectionBuilder dbConnectionBuilder, IMapper mapper)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            _mapper = mapper;
        }
        public async Task<List<Area>> GetAllAreasAsync()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            string sqlQuery = $"SELECT * FROM {_tableArea}";
            var area = await connection.QueryAsync<Area>(sqlQuery);
            connection.Close();
            return area.ToList();

        }


    }
}
