using MedicalScheduling.Application.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MedicalScheduling API", Version = "v1" });
});

// Registra o serviço de pacientes na DI
builder.Services.AddSingleton<PatientService>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicalScheduling API V1"));
}

//app.UseHttpLogging();
// app.UseHttpsRedirection(); // comente para rodar só HTTP

// Endpoint GET /pacientes
app.MapGet("/pacientes", (PatientService service) =>
{
    return Results.Ok(service.GetAll());
})
.WithName("GetPacientes");

app.Run();
