using editorial_webapi.Configurations;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var policy = "policy";

//Inyeccion de dependencias
GlobalConfiguration.Configuration = configuration;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("OpenAPISpec", new OpenApiInfo
    {
        Title = "Api Editorial",
        Description = "Api para gestión de libros",
        Version = "v1"
    });

    // Para agregar comentarios en cada EndPoint
    // Agregar esto en el archivo .csproj
    // <GenerateDocumentationFile>true</GenerateDocumentationFile>
    // <NoWarn>$(NoWarn);1591</NoWarn>
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddCors(o => o.AddPolicy(policy, builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

// Injection Configurations
DependencyInjection.Config(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

app.UseSwagger();
//app.UseSwaggerUI();
app.UseSwaggerUI(c =>
{
    string swaggerPath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "";
    c.SwaggerEndpoint($"{c.RoutePrefix}/OpenAPISpec/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});

app.UseCors(policy);

//Middleware
app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
