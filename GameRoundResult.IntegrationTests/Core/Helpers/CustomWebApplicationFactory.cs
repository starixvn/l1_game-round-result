using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace GameRoundResult.IntegrationTests
{
    public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected string ProjectDir = Directory.GetCurrentDirectory();
        public DatabaseHelper databaseHelper;

        public CustomWebApplicationFactory() : base()
        {
            databaseHelper = new DatabaseHelper();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            var configPath = Path.Combine(ProjectDir, "appsettings.IGT.json");

            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile(configPath, true, false);
            });
        }
    }
}