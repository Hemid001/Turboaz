using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace TurboProject.APILayer
{
    public static class ApiLayerConfig
    {
        public static void AddHybridLogging(this ILoggingBuilder loggingBuilder, IConfiguration configuration)
        {
            var logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.MSSqlServer(
        connectionString: configuration.GetConnectionString("Default"),
        sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true },
        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error
             )
    .CreateLogger();

            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog(logger);

        }
    }
}
