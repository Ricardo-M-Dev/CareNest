using Application.Commands.Patients;
using Application.Commands.Psychologists;
using Application.Common.Mediator;
using Application.Interfaces;
using Application.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=app.db";

builder.Services.AddSingleton(new DbConnectionFactory(connectionString));
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPsychologistRepository, PsychologistRepository>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSingleton<Mediator>();
builder.Services.AddTransient<IRequestHandler<CreatePatientCommand, int>, CreatePatientCommandHandler>();
builder.Services.AddTransient<IRequestHandler<CreatePsychologistCommand, int>, CreatePsychologistCommandHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
