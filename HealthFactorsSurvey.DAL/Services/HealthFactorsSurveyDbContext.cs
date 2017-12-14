using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthFactorsSurvey.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthFactorsSurvey.DAL.Services
{
    public class HealthFactorsSurveyDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public HealthFactorsSurveyDbContext(DbContextOptions<HealthFactorsSurveyDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

    }
}
