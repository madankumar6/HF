using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HealthFactorsSurvey.DAL.Services
{
    public class HealthFactorsSurveyDbContextFactory : InitializeDbContextFactory, IDesignTimeDbContextFactory<HealthFactorsSurveyDbContext>
    {
        public HealthFactorsSurveyDbContextFactory() : base("HealthFactorsSurveyDbConnection")
        {
        }

        public HealthFactorsSurveyDbContext CreateDbContext(string[] args)
        {
            HealthFactorsSurveyDbContext dbContext = null;
            dbContext = Create();
            return dbContext;
        }

        public HealthFactorsSurveyDbContext Create()
        {
            DbContextOptionsBuilder<HealthFactorsSurveyDbContext> optionsBuilder = new DbContextOptionsBuilder<HealthFactorsSurveyDbContext>();
            Debug.WriteLine("Debug Test" + ConnectionString);
            Trace.WriteLine("Trace Test Trace" + ConnectionString);
            switch (Database)
            {
                case "SQLSERVER":
                    optionsBuilder.UseSqlServer(ConnectionString, option => option.MigrationsAssembly("HealthFactorsSurvey.DAL"));
                    break;
                case "INMEMORY":
                    break;
                default:
                    optionsBuilder.UseSqlServer(ConnectionString, option => option.MigrationsAssembly("HealthFactorsSurvey.DAL"));
                    break;
            }

            return new HealthFactorsSurveyDbContext(optionsBuilder.Options);
        }
    }
}
