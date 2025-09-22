using MedicalScheduling.Application.Services;
using MedicalScheduling.Domain.Entities;
using MedicalScheduling.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MedicalScheduling API", Version = "v1" });
});

builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<DoctorService>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicalScheduling API V1"));
}

#region PACIENTES
// GET Patient
app.MapGet("/Patient", (PatientService service) =>
{
    return Results.Ok(service.GetAll());
}).WithTags("Patient");

// GET Patient by ID
app.MapGet("/Patient/{id}", (int id, PatientService service) =>
{
    var patient = service.GetById(id);
    return patient is not null ? Results.Ok(patient) : Results.NotFound();
}).WithTags("Patient");

// POST Patient
app.MapPost("/Patient", (PatientService service, Patient patient) =>
{
    var added = service.AddPatient(patient);
    return Results.Created($"/patient/{added.Id}", added);
}).WithTags("Patient");

// UPDATE Patient
app.MapPut("/Patient/{id}", (int id, Patient patient, PatientService service) =>
{
    patient.Id = id;
    return service.UpdatePatient(id, patient) ? Results.NoContent() : Results.NotFound();
}).WithTags("Patient");

// DELETE Patient
app.MapDelete("/Patient/{id}", (int id, PatientService service) =>
{
    return service.DeletePatient(id) ? Results.NoContent() : Results.NotFound();
}).WithTags("Patient");
#endregion

#region DOCTORES
// GET Doctor
app.MapGet("/Doctor", (DoctorService service) =>
{
    return Results.Ok(service.GetAll());
}).WithTags("Doctor");

// GET Doctor by ID
app.MapGet("/Doctor/{id}", (int id, DoctorService service) =>
{
    var doctor = service.GetById(id);
    return doctor is not null ? Results.Ok(doctor) : Results.NotFound();
}).WithTags("Doctor");

// POST Doctor
app.MapPost("/Doctor", (DoctorService service, Doctor doctor) =>
{
    var added = service.AddDoctor(doctor);
    return Results.Created($"/doctor/{added.Id}", added);
}).WithTags("Doctor");

// UPDATE Doctor
app.MapPut("/Doctor/{id}", (int id, Doctor doctor, DoctorService service) =>
{
    doctor.Id = id;
    return service.UpdateDoctor(id, doctor) ? Results.NoContent() : Results.NotFound();
}).WithTags("Doctor");

// DELETE Doctor
app.MapDelete("/Doctor/{id}", (int id, DoctorService service) =>
{
    return service.DeleteDoctor(id) ? Results.NoContent() : Results.NotFound();
}).WithTags("Doctor");
#endregion

app.Run();
