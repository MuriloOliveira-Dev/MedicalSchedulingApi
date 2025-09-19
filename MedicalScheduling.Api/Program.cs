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
builder.Services.AddSingleton<DoctorService>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicalScheduling API V1"));
}

#region PACIENTES
//GET Patient
app.MapGet("/Patient", (PatientService service) =>
{
    return Results.Ok(service.GetAll());
}).WithTags("Patient");

//POST Patient
app.MapPost("/Patient", (PatientService service, Patient patient) =>
{
    var added = service.AddPatient(patient);
    return Results.Created($"/patient/{added.Id}", added);
}).WithTags("Patient");

//Update Patient
app.MapPut("/Patient/{id}", (int id, Patient patient, PatientService service) =>
{
    patient.Id = id;
    return service.UpdatePatient(id, patient) ? Results.NoContent() : Results.NotFound();
}).WithTags("Patient");

//Delete Patient
app.MapDelete("/Patient/{id}", (int id, PatientService service) =>
{
    return service.DeletePatient(id) ? Results.NoContent() : Results.NotFound();
}).WithTags("Patient");
#endregion

#region DOUTORES
//GET Doctor
app.MapGet("/Doctor", (DoctorService service) =>
{
    return Results.Ok(service.GetAll());
}).WithTags("Doctor");
//POST Doctor
app.MapPost("/Doctor", (DoctorService service, Doctor doctor) =>
{
    var added = service.AddDoctor(doctor);
    return Results.Created($"/doctor/{added.Id}", added);
}).WithTags("Doctor");

//UPDATE Doctor
app.MapPut("/Doctor/{id}", (int id, Doctor doctor, DoctorService service) =>
{
    doctor.Id = id;
    return service.UpdateDoctor(id, doctor) ? Results.NoContent() : Results.NotFound();
}).WithTags("Doctor");

//DELETE Doctor
app.MapDelete("/Doctor/{id}", (int id, DoctorService service) =>
{
    return service.DeleteDoctor(id) ? Results.NoContent() : Results.NotFound();
}).WithTags("Doctor");
#endregion
app.Run();
