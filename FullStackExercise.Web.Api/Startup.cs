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

            services.AddMediatR(businessAssembly);

            services.AddAutoMapper(businessAssembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
