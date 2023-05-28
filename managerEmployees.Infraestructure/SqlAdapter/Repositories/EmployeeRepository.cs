using AutoMapper;
using Dapper;
using managerEmployees.Domain.Commands;
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
    public class EmployeeRepository:lEmployeeRepository
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly IMapper _mapper;

        private readonly string _tableEmployee = "Employee";
        

        public EmployeeRepository(IDbConnectionBuilder dbConnectionBuilder, IMapper mapper)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            _mapper = mapper;
        }


        public async Task<string> CreateEmployeeAsync(Employee employee)
        {

            //Guard.Against.Null(learningPath, nameof(learningPath));
            //Guard.Against.NullOrEmpty(learningPath.CoachID, nameof(learningPath.CoachID), "Ingresa por favor el id del coach, no puede ser vacio o nulo");
            //Guard.Against.NullOrEmpty(learningPath.Title, nameof(learningPath.Title), "Ingresa un  titulo por favor, no puedes dejar el campo como nulo o vacio");
            //Guard.Against.NullOrEmpty(learningPath.Description, nameof(learningPath.Description), "No puedes ingresar una descripcion vacia o nula, por favor ingresa alguna descripcion");
            ////Guard.Against.NullOrEmpty(learningPath.Duration.ToString(),nameof(learningPath.Duration), "Ingresa por favor una duracion, no puede ser nula o vacia");
            ////  Guard.Against.NullOrEmpty(learningPath.StatePath.ToString() ,nameof(learningPath.StatePath));

            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var createEmployee = new InsertNewEmployee
            {
               
                subArea_id = employee.subArea_id,
                typeDocument = employee.typeDocument,
                number_ID = employee.number_ID,
                name = employee.name,
                lastName = employee.lastName,

            };

            string sqlQuery = $"INSERT INTO {_tableEmployee} (subArea_id,typeDocument,number_ID,name,lastName) VALUES (@subArea_id,@typeDocument,@number_ID,@name,@lastName) ";
            var rows = await connection.ExecuteAsync(sqlQuery, createEmployee);
            return "Employee created Successfuly";
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            string sqlQuery = $"SELECT * FROM {_tableEmployee}";
            var employees = await connection.QueryAsync<Employee>(sqlQuery);
            
            return employees.ToList();

        }
    }
}
