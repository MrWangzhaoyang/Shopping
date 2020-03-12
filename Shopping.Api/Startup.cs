using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Shopping.Api.Models;

namespace Shopping.Api
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
            services.AddCors(c => c.AddPolicy("any", config =>
            {
                config.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddDbContext<ShoppingContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("SqlServerConnctionString"));
            });

            services.AddSwaggerGen(m =>
            {
                m.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1",
                    Description = "这是我的API",
                    TermsOfService = new Uri("https://www.cnblogs.com/wzhaoyang"),
                    Contact = new OpenApiContact
                    {
                        Name = "zhaoyang",
                        Email = "18272903310@163.com",
                        Url = new Uri("https://www.cnblogs.com/wzhaoyang")
                    }
                });

                var xmlPath = AppDomain.CurrentDomain.BaseDirectory + "Shopping.Api.xml";

                m.IncludeXmlComments(xmlPath);
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(m =>
            {
                m.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });

            app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
