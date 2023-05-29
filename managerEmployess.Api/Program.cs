using AutoMapper.Data;
using managerEmployess.Api.AutoMapper;
using managerEmployess.Api.Middlewares;
using managerEmployees.Infraestructure.SqlAdapter.Gateway;
using managerEmployees.Infraestructure.SqlAdapter.Repositories;
using managerEmployees.Infraestructure;
using managerEmployees.UseCases.Gateway;
using managerEmployees.UseCases.Gateway.Repositories;
using managerEmployees.UseCases.UseCases;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                              "https://campusvirtualsofka.web.app",
                              "https://campusvirtualsofka.firebaseapp.com")
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ConfigurationProfile));

builder.Services.AddScoped<lEmployeeUseCase, EmployeeUseCase>();
builder.Services.AddScoped<lEmployeeRepository, EmployeeRepository>();


builder.Services.AddTransient<IDbConnectionBuilder>(e =>
{
    return new DbConnectionBuilder(builder.Configuration.GetConnectionString("urlConnectionSQL"));
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.UseMiddleware<ErrorHandleMiddleware>();

app.MapControllers();

app.Run();
