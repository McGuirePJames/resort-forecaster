using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResortForecaster.Api.Controllers;
using ResortForecaster.Api.GraphQL.Queries;
using ResortForecaster.ApiClients.ApiClients;
using ResortForecaster.ApiClients.Interfaces;
using ResortForecaster.Repos;
using ResortForecaster.Repos.Interfaces;
using ResortForecaster.Repos.Repos;
using ResortForecaster.Services.Interfaces;
using ResortForecaster.Services.Mappers;
using ResortForecaster.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting();
builder.Services.AddTransient<SkiResortForecastController>();
builder.Services.AddTransient<FavoriteSkiResortController>();
builder.Services.AddTransient<IOpenWeatherClient, OpenWeatherClient>();
builder.Services.AddTransient<ISkiResortForecastService, SkiResortForecastService>();
builder.Services.AddTransient<IFavoriteSkiResortService, FavoriteSkiResortService>();
builder.Services.AddTransient<IFavoriteSkiResortRepo, FavoriteSkiResortRepo>();
builder.Services.AddTransient<IWeatherForecastMapper, WeatherForecastMapper>();
var connectionString = builder.Configuration.GetConnectionString("ResortForecasterDB");
builder.Services.AddDbContext<ResortForecasterContext>(
    options => options.UseSqlServer(connectionString, 
        (sqlOptions) =>
        {
            sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromTicks(30), errorNumbersToAdd: null);
        }
    ));

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

    app.MapPost("/FavoriteSkiResort", async ([FromServices] FavoriteSkiResortController favoriteSkiResortController) =>
    {
        await favoriteSkiResortController.FavoriteSkiResort();
    });

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
