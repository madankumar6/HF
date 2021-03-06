﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthFactorsSurvey.DAL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace HealthFactorsSurvey.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add the database..
            string database = Configuration["Data:Database"];
            string connection = Configuration["Data:HealthFactorsSurveyDbConnection"];
            string connectionString = $"ConnectionStrings:{connection}";

            switch (database.ToUpper())
            {
                case "SQLSERVER":
                    services.AddDbContext<HealthFactorsSurveyDbContext>(options => options.UseSqlServer(Configuration[connectionString], b => b.MigrationsAssembly("HealthFactorsSurvey.DAL")));
                    break;
                case "INMEMORY":
                default:
                    services.AddDbContext<HealthFactorsSurveyDbContext>(options => options.UseSqlServer(Configuration[connectionString], b => b.MigrationsAssembly("HealthFactorsSurvey.DAL")));
                    break;
            }

            services.AddMvc();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Questionnaire API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Questionnaire API V1");
            });

            app.UseMvc();
        }
    }
}
