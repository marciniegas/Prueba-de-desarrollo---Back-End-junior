using Bovinos.Models;
using Bovinos.Services;
using Bovinos.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseUrls("http://localhost:8080");

// Configuraci�n del DbContext y cadena de conexi�n para AnimalDbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AnimalDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Configuraci�n del DbContext y cadena de conexi�n para RaceDbContext
var raceDbContextConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RaceDbContext>(options => options.UseMySql(raceDbContextConnectionString, ServerVersion.AutoDetect(raceDbContextConnectionString)));


// Configuracion para Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Informacion de Bovinos", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Inyecci�n de dependencias AnimalServicio y AnimalValidator
builder.Services.AddTransient<IAnimalService, AnimalService>();
builder.Services.AddTransient<AnimalValidator>();

// Inyecci�n de dependencias Race Service y Race Validator
builder.Services.AddTransient<IRaceService, RaceService>();
builder.Services.AddTransient<RaceValidator>();



// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuraci�n de serializaci�n JSON aqu�
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

var app = builder.Build();

// Habilitar Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Informacion Bovinos v1"));
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
