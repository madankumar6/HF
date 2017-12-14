using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HealthFactorsSurvey.DAL.Services
{
    public class InitializeDbContextFactory
    {
        public string Database { get; set; }
        public string ConnectionString { get; set; }

        public InitializeDbContextFactory(string dbContextConnectionString)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                    .SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json")
                                                    .Build();

            Database = configuration["Data:Database"];

            if (string.IsNullOrWhiteSpace(dbContextConnectionString))
            {
                ConnectionString = dbContextConnectionString;
            }
            else
            {
                string connection = configuration[$"Data:{dbContextConnectionString}"];
                string connectionStringData = $"ConnectionStrings:{connection}";
                ConnectionString = configuration[connectionStringData];
            }
        }
    }
}
