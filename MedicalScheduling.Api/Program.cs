using MedicalScheduling.Application.Services;
using MedicalScheduling.Domain.Entities;
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

//GET Pacientess
app.MapGet("/Patient", (PatientService service) =>
{
    return Results.Ok(service.GetAll());
})
.WithName("GetPatients");

//POST Pacientes
app.MapPost("/Patient", (PatientService service, Patient patient) =>
{
    var added = service.AddPatient(patient);
    return Results.Created($"/patient/{added.Id}", added);
}).WithName("CreatePatient");

//Update Pacientes
app.MapPut("/Patient/{id}", (int id, Patient patient, PatientService service) =>
{
    patient.Id = id;
    return service.UpdatePatient(id, patient) ? Results.NoContent() : Results.NotFound();
}).WithName("ÚpdatePatient");

//Delete Pacientes
app.MapDelete("/Patient/{id}", (int id, PatientService service) =>
{
    return service.DeletePatient(id) ? Results.NoContent() : Results.NotFound();
}).WithName("DeletePatient");

app.Run();
