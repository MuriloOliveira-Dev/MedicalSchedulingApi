using MedicalScheduling.Application.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MedicalScheduling API", Version = "v1" });
});

// Registra o servi�o de pacientes na DI
builder.Services.AddSingleton<PatientService>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicalScheduling API V1"));
}

//app.UseHttpLogging();
// app.UseHttpsRedirection(); // comente para rodar s� HTTP

// Endpoint GET /pacientes
app.MapGet("/pacientes", (PatientService service) =>
{
    return Results.Ok(service.GetAll());
})
.WithName("GetPacientes");

app.Run();
