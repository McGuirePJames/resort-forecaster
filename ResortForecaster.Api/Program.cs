using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using System.Diagnostics;

namespace ResortForecaster.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));

            return Host.CreateDefaultBuilder(args)
                .UseSerilog((context, configuration) =>
                {
                    var uri = context.Configuration["ElasticConfiguration:Uri"];
                    var elasticSearchOptions = new ElasticsearchSinkOptions(new Uri(uri))
                    {
                        IndexFormat = $"logs-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                        AutoRegisterTemplate = true,
                        NumberOfShards = 2,
                        NumberOfReplicas = 1,
                        ModifyConnectionSettings = (x) => x.BasicAuthentication("elastic", "Abcd1234!"),
                        EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog,
                        MinimumLogEventLevel = Serilog.Events.LogEventLevel.Information
                    };

                    configuration
                        .Enrich.FromLogContext()
                        .Enrich.WithMachineName()
                        .WriteTo.Console()
                        .WriteTo.Elasticsearch(elasticSearchOptions)
                        .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                        .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                        .ReadFrom.Configuration(context.Configuration);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
