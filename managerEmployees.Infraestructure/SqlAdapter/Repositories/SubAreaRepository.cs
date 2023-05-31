using AutoMapper;
using Dapper;
using managerEmployees.Domain.Entities;
using managerEmployees.Infraestructure.SqlAdapter.Gateway;
using managerEmployees.UseCases.Gateway.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace managerEmployees.Infraestructure.SqlAdapter.Repositories
{
    public class SubAreaRepository: lSubAreaRepository
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly IMapper _mapper;

        private readonly string _tableSubArea = "SubArea";
        private readonly string _tableArea = "Area";

        public SubAreaRepository(IDbConnectionBuilder dbConnectionBuilder, IMapper mapper)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            _mapper = mapper;
        }

        public async Task<List<SubArea>> GetAllSubAreasByIdAreaAsync(int idArea)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            string sqlQuery = $"SELECT sub.name, sub.description FROM {_tableSubArea} sub " +
                                      $"INNER JOIN {_tableArea} ar ON sub.area_id = ar.area_id " +
                                      $"WHERE ar.area_id = {idArea}";

            var SubAreas = await connection.QueryAsync<SubArea>(sqlQuery);
            connection.Close();
            return SubAreas.ToList();

        }

    }
}
