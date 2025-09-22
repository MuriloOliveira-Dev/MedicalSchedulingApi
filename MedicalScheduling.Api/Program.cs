using MedicalScheduling.Application.Services;
using MedicalScheduling.Domain.Entities;
using MedicalScheduling.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MedicalScheduling.Application.DTO;

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicalScheduling API V1"));
}
#region PACIENTES
// GET all
app.MapGet("/Patient", async (PatientService service) =>
    Results.Ok(await service.GetAll())
).WithTags("Patient");

// GET by ID
app.MapGet("/Patient/{id}", async (PatientService service, int id) =>
{
    var patient = await service.GetById(id);
    return patient is not null ? Results.Ok(patient) : Results.NotFound();
}).WithTags("Patient");

// POST
app.MapPost("/Patient", async (PatientService service, PatientDTO dto) =>
{
    var patient = new Patient { Name = dto.Name, Email = dto.Email };
    var added = await service.Add(patient);
    return Results.Created($"/Patient/{added.Id}", added);
}).WithTags("Patient");

// PUT
app.MapPut("/Patient/{id}", async (int id, PatientUpdateDto dto, ApplicationDbContext db) =>
{
    var patientExist = await db.Patients.FindAsync(id);
    if (patientExist is null) return Results.NotFound();

    patientExist.Name = dto.Name;
    patientExist.Email = dto.Email;

    await db.SaveChangesAsync();
    return Results.NoContent();
}).WithTags("Patient");

// DELETE
app.MapDelete("/Patient/{id}", async (PatientService service, int id) =>
    await service.Delete(id) ? Results.NoContent() : Results.NotFound()
).WithTags("Patient");
#endregion

#region DOCTORES
// GET all
app.MapGet("/Doctor", async (DoctorService service) =>
    Results.Ok(await service.GetAll())
).WithTags("Doctor");

// GET by ID
app.MapGet("/Doctor/{id}", async (DoctorService service, int id) =>
{
    var doctor = await service.GetById(id);
    return doctor is not null ? Results.Ok(doctor) : Results.NotFound();
}).WithTags("Doctor");

// POST
app.MapPost("/Doctor", async (DoctorService service, DoctorCreateDto dto) =>
{
    var doctor = new Doctor { Name = dto.Name, Specialty = dto.Specialty };
    var added = await service.Add(doctor);
    return Results.Created($"/Doctor/{added.Id}", added);
}).WithTags("Doctor");

// PUT
app.MapPut("/Doctor/{id}", async (int id, DoctorUpdateDto dto, ApplicationDbContext db) =>
{
    var doctorExist = await db.Doctors.FindAsync(id);
    if (doctorExist is null) return Results.NotFound();

    doctorExist.Name = dto.Name;
    doctorExist.Specialty = dto.Specialty;

    await db.SaveChangesAsync();
    return Results.NoContent();
}).WithTags("Doctor");

// DELETE
app.MapDelete("/Doctor/{id}", async (DoctorService service, int id) =>
    await service.Delete(id) ? Results.NoContent() : Results.NotFound()
).WithTags("Doctor");
#endregion

app.Run();
