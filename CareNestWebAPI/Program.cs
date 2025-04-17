using Application.Commands.Patients;
using Application.Commands.Psychologists;
using Application.Common.Interfaces;
using Application.Common.Mediator;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Repositories;
using Application.Services;
using Infrastructure.Cache;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using MySqlConnector;
using StackExchange.Redis;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var redisConfiguration = builder.Configuration.GetConnectionString("Redis") ?? "localhost:6379";

builder.Services.AddScoped<IDbConnection>(_ =>
{
    var connection = new MySqlConnection(connectionString);
    connection.Open();
    return connection;
});

builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPsychologistRepository, PsychologistRepository>();

builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPsychologistService, PsychologistService>();
builder.Services.AddScoped<IRedisCacheService, RedisCacheService>();

builder.Services.AddScoped<Mediator>();
builder.Services.AddTransient<IRequestHandler<CreatePatientCommand, int>, CreatePatientCommandHandler>();
builder.Services.AddTransient<IRequestHandler<CreatePsychologistCommand, int>, CreatePsychologistCommandHandler>();

builder.Services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(redisConfiguration));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
