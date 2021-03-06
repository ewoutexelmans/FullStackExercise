using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using AutoMapper;
using FullStackExercise.Business.Util;
using FullStackExercise.Data.Access;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FullStackExercise.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var businessAssembly = Assembly.GetAssembly(typeof(QueryableExtensions));

            services.AddControllers();

            services.AddDbContext<AdventureWorksContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AdventureWorksContext")));
            services.AddDbContext<AuthContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AuthContext")));

            services.AddMediatR(businessAssembly);

            services.AddAutoMapper(businessAssembly);

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddSwaggerGen(options =>
            {
                options.CustomOperationIds(desc => desc.ActionDescriptor.RouteValues["action"]);
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FullStackExercise Api",
                    Version = "v1"
                });
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "FullStackExercise Api v1");
                options.RoutePrefix = string.Empty;
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseHttpsRedirection();


            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
