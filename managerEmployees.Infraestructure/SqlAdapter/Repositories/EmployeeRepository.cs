using Ardalis.GuardClauses;
using AutoMapper;
using Dapper;
using managerEmployees.Domain.Commands;
using managerEmployees.Domain.Entities;
using managerEmployees.Infraestructure.SqlAdapter.Gateway;
using managerEmployees.UseCases.Gateway.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
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

            Guard.Against.Null(employee, nameof(employee));
            Guard.Against.NullOrEmpty(employee.subArea_id.ToString(), nameof(employee.subArea_id), "Ingresa por favor  una sub Area para el empleado");
            Guard.Against.NullOrEmpty(employee.typeDocument, nameof(employee.typeDocument), "Ingresa por favor un tipo de documento al empleado");
            Guard.Against.NullOrEmpty(employee.number_ID.ToString(), nameof(employee.number_ID), "Ingresa por favor un numero de documento al empleado");
            Guard.Against.NullOrEmpty(employee.name, nameof(employee.name), "Ingresa por favor un nombre al empleado");
            Guard.Against.NullOrEmpty(employee.lastName, nameof(employee.lastName), "Ingresa por favor un apellido al empleado");

            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var createEmployee = new InsertNewEmployee
            {
               
                subArea_id = employee.subArea_id,
                typeDocument = employee.typeDocument,
                number_ID = employee.number_ID,
                name = employee.name,
                lastName = employee.lastName,
            };

            // Verificamos  si esa subArea existe para poder crear el empleado ya que es una FK
            string selectQuery = $"SELECT COUNT(*) FROM SubArea WHERE subArea_id = @subArea_id";
            var subAreaCount = await connection.ExecuteScalarAsync<int>(selectQuery, new { subArea_id = employee.subArea_id });
            if (subAreaCount == 0)
            {
                connection.Close();
                return "La sub Área especificada no existe en la base de datos.";
            }

            string sqlQuery = $"INSERT INTO {_tableEmployee} (subArea_id,typeDocument,number_ID,name,lastName) VALUES (@subArea_id,@typeDocument,@number_ID,@name,@lastName) ";
            var rows = await connection.ExecuteAsync(sqlQuery, createEmployee);
            connection.Close();
            return "Employee created Successfuly";
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            string sqlQuery = $"SELECT * FROM {_tableEmployee}";
            var employees = await connection.QueryAsync<Employee>(sqlQuery);
            connection.Close();
            return employees.ToList();

        }

        public async Task<string> UpdateEmployeeAsync(int idEmployee, UpdateEmployee employee)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            Guard.Against.Null(employee, nameof(employee));
            Guard.Against.NullOrEmpty(employee.subArea_id.ToString(), nameof(employee.subArea_id), "Ingresa por favor  una sub Area para el empleado");
            Guard.Against.NullOrEmpty(employee.typeDocument, nameof(employee.typeDocument), "Ingresa por favor un tipo de documento al empleado");
            Guard.Against.NullOrEmpty(employee.number_ID.ToString(), nameof(employee.number_ID), "Ingresa por favor un numero de documento al empleado");
            Guard.Against.NullOrEmpty(employee.name, nameof(employee.name), "Ingresa por favor un nombre al empleado");
            Guard.Against.NullOrEmpty(employee.lastName, nameof(employee.lastName), "Ingresa por favor un apellido al empleado");

            string selectQuery = $"SELECT COUNT(*) FROM SubArea WHERE subArea_id = @subArea_id";
            var subAreaCount = await connection.ExecuteScalarAsync<int>(selectQuery, new { subArea_id = employee.subArea_id });
            if (subAreaCount == 0)
            {
                connection.Close();
                return "La sub Área especificada no existe en la base de datos para poder actualizar el registro.";
            }

            string  sqlQuery = $"UPDATE {_tableEmployee} SET subArea_id = @subArea_id, typeDocument = @typeDocument, number_ID = @number_ID, name = @name, lastName = @lastName WHERE employees_id ='{idEmployee}'";

            var rows = await connection.ExecuteAsync(sqlQuery, employee);
            connection.Close();
            return "Employee updated Successfuly";

        }

        public async Task<Employee> GetEmployeeByIdAsync(int idEmployee) { 
        
           var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            Guard.Against.NullOrEmpty(idEmployee.ToString(), nameof(idEmployee), "Ingresa por favor  un id valido para empleado");

            string selectQuery = $"SELECT COUNT(*) FROM Employee WHERE employees_id = '{idEmployee}'";
            var subAreaCount = await connection.ExecuteScalarAsync<int>(selectQuery, new { employee_id = idEmployee });
            if (subAreaCount == 0)
            {
                connection.Close();
                throw new ArgumentException("User not find in us database");
            }

            string sqlQuery = $"SELECT * FROM {_tableEmployee} WHERE employees_id ='{idEmployee}'";
           var employees = await connection.QueryAsync<Employee>(sqlQuery);
            connection.Close();

            return employees.FirstOrDefault();

        
        
        }



    }
}
