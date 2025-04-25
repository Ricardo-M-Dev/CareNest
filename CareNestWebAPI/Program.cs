using Application.Commands.Patients;
using Application.Commands.Psychologists;
using Application.Common;
using Application.Common.Factory;
using Application.Common.Interfaces;
using Application.Common.Mediator;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Queries.Patients;
using Application.Queries.Psychologists;
using Application.Repositories;
using Application.Services;
using Domain.Entities;
using Infrastructure.Cache;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Diagnostics;
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

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPsychologistRepository, PsychologistRepository>();

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPsychologistService, PsychologistService>();

builder.Services.AddScoped<IPasswordHasher, Pbkdf2PasswordHasher>();
builder.Services.AddScoped<IRedisCacheService, RedisCacheService>();
builder.Services.AddScoped<IPersonFactory, PersonFactory>();

builder.Services.AddTransient<IRequestHandler<GetPatientByIdQuery, Patient?>, GetPatientByIdQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllPatientsQuery, IEnumerable<Patient?>>, GetAllPatientsQueryHandler>();

builder.Services.AddTransient<IRequestHandler<GetPsychologistByIdQuery, Psychologist?>, GetPsychologistByIdQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllPsychologistsQuery, IEnumerable<Psychologist?>>, GetAllPsychologistsQueryHandler>();

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

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var error = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (error is ArgumentException)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(new { message = error.Message });
        }
    });
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
