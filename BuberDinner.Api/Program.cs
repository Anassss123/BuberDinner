using AutoMapper;
using BuberDinner.Api.Filters;
using BuberDinner.Api.Mapping;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme,
        securityScheme: new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            Name = "Authorization",
            Description = "Enter the Bearer Auth : Bearer Generated-JWT-Token",
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Type = SecuritySchemeType.Http, // Utilisez SecuritySchemeType.Http pour le schéma Bearer
            Scheme = "Bearer"
        });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme // Correction du nom de la classe
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                },
                Scheme = "oauth2",
                Name = JwtBearerDefaults.AuthenticationScheme,
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            },
            Array.Empty<string>() // Utilisez Array.Empty<string>() pour une liste vide
        }
    });
});
// builder.Services.AddAutoMapper(typeof(AuthenticationAutoMapper));
builder.Services.AddSingleton(profiler => new MapperConfiguration(cfg => {
    cfg.AddProfile<AutoMappingProfiles>();
}).CreateMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
