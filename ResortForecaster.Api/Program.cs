using Microsoft.AspNetCore.Mvc;
using ResortForecaster.Api.Controllers;
using ResortForecaster.Api.GraphQL.Queries;
using ResortForecaster.ApiClients.ApiClients;
using ResortForecaster.ApiClients.Interfaces;
using ResortForecaster.Services.Interfaces;
using ResortForecaster.Services.Mappers;
using ResortForecaster.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting();
builder.Services.AddTransient<SkiResortForecastController>();
builder.Services.AddTransient<IOpenWeatherClient, OpenWeatherClient>();
builder.Services.AddTransient<ISkiResortForecastService, SkiResortForecastService>();
builder.Services.AddTransient<IWeatherForecastMapper, WeatherForecastMapper>();

builder
    .Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<SkiResotQuery>()
    .AddType<SkiResortForecastQuery>();

var app = builder.Build();
app.UseRouting();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL();
    });

    app.UseSwagger();
    app.MapGet("/SkiResortForecast", async ([FromServices] SkiResortForecastController skiResortForecastController) =>
    {
        await skiResortForecastController.GetSkiResortForecasts();
    });

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
