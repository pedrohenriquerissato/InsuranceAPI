using FluentValidation.AspNetCore;
using Insurance.API.Configurations;
using Insurance.Application;
using Insurance.Application.RiskAnalysis.Commands;
using Insurance.Application.RiskAnalysis.Validators;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance;
});

builder.Services.AddControllers().AddFluentValidation(option =>
{
    option.RegisterValidatorsFromAssemblyContaining<RiskAnalysisValidator>();
});

builder.Services.AddMediatR(typeof(RiskAnalysisCommand));

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

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var problemDetails = new ValidationProblemDetails(context.ModelState);
        throw new ProblemDetailsException(problemDetails.Errors);
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(x => x.Run(async context =>
{
    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
    var exception = errorFeature?.Error;

    if (exception != null)
    {
        var problemDetails = new ProblemDetails
        {
            Instance = errorFeature switch
            {
                ExceptionHandlerFeature e => e.Path,
                _ => "unknown"
            },
            Extensions =
                {
                    ["trace"] = Activity.Current?.Id ?? context?.TraceIdentifier
                }
        };

        switch (exception)
        {
            case ProblemDetailsException problemDetailsException:
                problemDetails.Type = problemDetailsException.Message;
                problemDetails.Title = "Your request contain invalid data";
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Extensions["errors"] = problemDetailsException?.Errors;
                break;
            default:
                problemDetails.Title = "Some error unexpected occured!";
                problemDetails.Status = StatusCodes.Status500InternalServerError;
                problemDetails.Detail = exception.Message;
                problemDetails.Extensions["InnerException"] = exception?.InnerException;
                problemDetails.Extensions["errors"] = exception?.Data;
                break;
        }
        context.Response.StatusCode = problemDetails.Status.Value;
        context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue()
        {
            NoCache = true,
        };
        context.Response.ContentType = "application/problem+json";
        await context.Response.WriteAsJsonAsync(problemDetails);
    }
}));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();