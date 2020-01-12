using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InventIdea_API
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x =>
                {

                });

            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("ESwoiGlobalEnum", typeof(int));
            });

            services.Configure<MvcOptions>(options =>
            {
                //options.Filters.Add<TokenAuthentivarionFilter>();
            });

            services.AddAutoMapper(typeof(Program));

            //TODO When you will know Quartz
            //services.AddHostedService<QuartzHostedService>();

            //services.AddScoped(CreateInventIdeaEntities);

            //TODO Add sevice and implemintation
            //services.AddTransient<ICompanyUserService, CompanyUser>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "InventIdea API V1");
            });
        }

    }
}
