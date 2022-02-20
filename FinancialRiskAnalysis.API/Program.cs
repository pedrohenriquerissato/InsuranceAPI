using Insurance.API.Configurations;
using Insurance.Application.RiskAnalysis.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance;
});

// Adds all of other Validators found on the same Assembly
builder.Services.AddControllers().AddFluentValidation(option =>
{
    option.RegisterValidatorsFromAssemblyContaining<RiskAnalysisValidator>();
});

builder.Services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Insurance API",
        Description = "An API to analyze and process insurance requests.",
        Contact = new OpenApiContact
        {
            Email = "pedro_giberti@hotmail.com"
        },
        License = new OpenApiLicense
        {
            Name = "Terms of Service",
            Url = new Uri("https://github.com/OriginFinancial/origin-backend-take-home-assignment")
        }
    });
});

var app = builder.Build();

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