using MedicalScheduling.Application.DTO;
using MedicalScheduling.Application.Services;
using MedicalScheduling.Domain.Entities;
using MedicalScheduling.Domain.Repositories;
using MedicalScheduling.Infrastructure.Persistence;
using MedicalScheduling.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// DbContext (Postgres)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MedicalScheduling API", Version = "v1" });
});

// DI: services and repositories
builder.Services.AddScoped<IPatientRepository, EfPatientRepository>();
builder.Services.AddScoped<IDoctorRepository, EfDoctorRepository>();

builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<DoctorService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Helper: validate DTOs using DataAnnotations
static bool ValidateDto<T>(T dto, out List<string> errors)
{
    var context = new ValidationContext(dto, serviceProvider: null, items: null);
    var results = new List<ValidationResult>();
    var isValid = Validator.TryValidateObject(dto, context, results, validateAllProperties: true);
    errors = results.Select(r => r.ErrorMessage ?? "Validation error").ToList();
    return isValid;
}

#region PATIENT
app.MapGet("/Patient", async (PatientService svc) =>
    Results.Ok(await svc.GetAll())
).WithTags("Patient");

app.MapGet("/Patient/{id}", async (int id, PatientService svc) =>
{
    var p = await svc.GetById(id);
    return p is not null ? Results.Ok(p) : Results.NotFound();
}).WithTags("Patient");

app.MapPost("/Patient", async (PatientCreateDto dto, PatientService svc) =>
{
    if (!ValidateDto(dto, out var errors)) return Results.BadRequest(new { errors });

    var patient = new Patient { Name = dto.Name, Email = dto.Email };
    var added = await svc.Add(patient);
    return Results.Created($"/Patient/{added.Id}", added);
}).WithTags("Patient");

app.MapPut("/Patient/{id}", async (int id, PatientCreateDto dto, PatientService svc) =>
{
    if (!ValidateDto(dto, out var errors)) return Results.BadRequest(new { errors });

    var patient = new Patient { Name = dto.Name, Email = dto.Email };
    var updated = await svc.Update(patient, id);
    return updated ? Results.NoContent() : Results.NotFound();
}).WithTags("Patient");

app.MapDelete("/Patient/{id}", async (int id, PatientService svc) =>
{
    var deleted = await svc.Delete(id);
    return deleted ? Results.NoContent() : Results.NotFound();
}).WithTags("Patient");
#endregion

#region DOCTOR
app.MapGet("/Doctor", async (DoctorService svc) =>
    Results.Ok(await svc.GetAll())
).WithTags("Doctor");

app.MapGet("/Doctor/{id}", async (int id, DoctorService svc) =>
{
    var d = await svc.GetById(id);
    return d is not null ? Results.Ok(d) : Results.NotFound();
}).WithTags("Doctor");

app.MapPost("/Doctor", async (DoctorCreateDto dto, DoctorService svc) =>
{
    if (!ValidateDto(dto, out var errors)) return Results.BadRequest(new { errors });

    var doctor = new Doctor { Name = dto.Name, Specialty = dto.Specialty };
    var added = await svc.Add(doctor);
    return Results.Created($"/Doctor/{added.Id}", added);
}).WithTags("Doctor");

app.MapPut("/Doctor/{id}", async (int id, DoctorCreateDto dto, DoctorService svc) =>
{
    if (!ValidateDto(dto, out var errors)) return Results.BadRequest(new { errors });

    var doctor = new Doctor { Name = dto.Name, Specialty = dto.Specialty };
    var updated = await svc.Update(doctor, id);
    return updated ? Results.NoContent() : Results.NotFound();
}).WithTags("Doctor");

app.MapDelete("/Doctor/{id}", async (int id, DoctorService svc) =>
{
    var deleted = await svc.Delete(id);
    return deleted ? Results.NoContent() : Results.NotFound();
}).WithTags("Doctor");
#endregion

app.Run();
