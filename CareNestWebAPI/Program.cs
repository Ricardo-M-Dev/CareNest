using Application.Common.Mediator;
using Application.Patients.Commands;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSingleton<Mediator>();
builder.Services.AddTransient<IRequestHandler<CreatePatientCommand, int>, CreatePatientCommandHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
