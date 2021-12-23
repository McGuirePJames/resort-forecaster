using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
builder.Services.AddTransient<ISkiResortService, SkiResortService>();
builder.Services.AddTransient<IFavoriteSkiResortRepo, FavoriteSkiResortRepo>();
builder.Services.AddTransient<ISkiResortRepo, SkiResortRepo>();
builder.Services.AddTransient<IWeatherForecastMapper, WeatherForecastMapper>();

var connectionString = builder.Configuration.GetConnectionString("ResortForecasterDB");
builder.Services.AddDbContext<ResortForecasterContext>(
    options => options.UseSqlServer((connectionString),
        (sqlOptions) =>
        {
            sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromTicks(30), errorNumbersToAdd: null);
        }
    ), ServiceLifetime.Singleton);


builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
});


builder
    .Services
        .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddType<SkiResotQuery>()
            .AddType<SkiResortForecastQuery>();


builder.Services.AddGraphQLServer();

var app = builder.Build();
app.UseRouting();
app.UseAuthorization();
app.UseCors(options => options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

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
        await skiResortForecastController.GetSkiResortForecasts(Guid.NewGuid());
    });

    app.MapPost("/FavoriteSkiResort", async ([FromServices] FavoriteSkiResortController favoriteSkiResortController) =>
    {
        await favoriteSkiResortController.FavoriteSkiResort(Guid.Parse("B1B58459-1139-47EA-9BD3-3BF2A758908F"));
    });

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
