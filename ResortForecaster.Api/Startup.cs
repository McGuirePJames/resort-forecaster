using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ResortForecaster.Api.Controllers;
using ResortForecaster.Api.GraphQL.Mutations;
using ResortForecaster.Api.GraphQL.Queries;
using ResortForecaster.Api.GraphQL.Resolvers;
using ResortForecaster.ApiClients.ApiClients;
using ResortForecaster.ApiClients.Interfaces;
using ResortForecaster.Models;
using ResortForecaster.Repos;
using ResortForecaster.Repos.Interfaces;
using ResortForecaster.Repos.Repos;
using ResortForecaster.Services.Interfaces;
using ResortForecaster.Services.Mappers;
using ResortForecaster.Services.Services;

namespace ResortForecaster.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();

            if (env.EnvironmentName == "Production")
            {
                builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            }
            else
            {
                builder.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddRouting();
            services.AddTransient<SkiResortForecastController>();
            services.AddTransient<FavoriteSkiResortController>();

            services.Configure<AzureAccountStorageOptions>((accountStorageOptions) =>
            {
                accountStorageOptions.ConnectionString = Configuration.GetSection("AzureAccountStorageOptions:ConnectionString").Value;
                accountStorageOptions.ContainerName = Configuration.GetSection("AzureAccountStorageOptions:ContainerName").Value;
            });

            this.ConfigureDependencyInjections(services);

            services
            .AddGraphQLServer()
            .AddFiltering()
            .AddSorting()
            .AddProjections()
            .AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<SkiResortQuery>()
                .AddTypeExtension<SkiResortForecastQuery>()
                .AddTypeExtension<AvalancheQuery>()
            .AddMutationType(d => d.Name("Mutation"))
                .AddTypeExtension<AvalancheMutation>()
                .AddTypeExtension<FeedbackMutation>()
            .AddType<SkiResortResolver>();

            services.AddGraphQLServer();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            var connectionString = Configuration.GetConnectionString("ResortForecasterDB");
            services.AddDbContext<ResortForecasterContext>(
                options => options.UseSqlServer((connectionString),
                (sqlOptions) =>
                {
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromTicks(30), errorNumbersToAdd: null);
                }), ServiceLifetime.Singleton);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseCors(options => options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });


            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ResortForecasterContext>();
                context.Database.EnsureCreated();
            }
        }

        private void ConfigureDependencyInjections(IServiceCollection services)
        {
            services.AddSingleton<AzureAccountStorageOptions>();

            // Clients
            services.AddTransient<IOpenWeatherClient, OpenWeatherClient>();

            // Services
            services.AddTransient<IAvalancheService, AvalancheService>();
            services.AddTransient<ISkiResortForecastService, SkiResortForecastService>();
            services.AddTransient<IFavoriteSkiResortService, FavoriteSkiResortService>();
            services.AddTransient<IFeedbackService, FeedbackService>();
            services.AddTransient<IBlobStorageService, BlobStorageService>();
            services.AddTransient(typeof(IBaseService<>), typeof(BaseEntityService<>));

            // Repos
            services.AddTransient(typeof(IBaseRepo<>), typeof(BaseRepo<>));
            services.AddTransient<IAvalancheRepo, AvalancheRepo>();
            services.AddTransient<ISkiResortService, SkiResortService>();
            services.AddTransient<IFeedbackRepo, FeedbackRepo>();
            services.AddTransient<IFavoriteSkiResortRepo, FavoriteSkiResortRepo>();
            services.AddTransient<ISkiResortRepo, SkiResortRepo>();

            // Mappers
            services.AddTransient<IWeatherForecastMapper, WeatherForecastMapper>();
            services.AddTransient<IAvalancheMapper, AvalanceMapper>();
        }
    }
}
