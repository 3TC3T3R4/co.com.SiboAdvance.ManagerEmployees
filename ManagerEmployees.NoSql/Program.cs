using AutoMapper.Data;
using ManagerEmployees.Infraestructure.NoSql;
using ManagerEmployees.Infraestructure.NoSql.Interfaces;
using ManagerEmployees.Infraestructure.NoSql.Repositories;
using ManagerEmployees.NoSql.AutoMapper;
using ManagerEmployees.UseCases.NoSql.Gateway;
using ManagerEmployees.UseCases.NoSql.Gateway.Repositories.Commands;
using ManagerEmployees.UseCases.NoSql.UseCases;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ConfigurationProfile));


builder.Services.AddScoped<IUserUseCase, UserUseCase>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddCors(options =>
{

    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); ;
    });

});

builder.Services.AddSingleton<IContext>(provider => new Context(builder.Configuration.GetConnectionString("urlConnection"), "SiboAdvance"));

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

app.MapControllers();

app.Run();
