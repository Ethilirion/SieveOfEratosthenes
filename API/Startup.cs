using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace API
{
    public class Startup
    {
        private static string apiVersion = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(apiVersion, new Info { Title = "API", Version = apiVersion });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder applications, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                applications.UseDeveloperExceptionPage();
            }
            else
            {
                applications.UseHsts();
            }

            applications.UseMvc();
            applications.UseHttpsRedirection();

            applications.UseSwagger();
            applications.UseSwaggerUI(apiApplication =>
            {
                apiApplication.SwaggerEndpoint($"/swagger/{apiVersion}/swagger.json", "API");
                apiApplication.RoutePrefix = string.Empty;

            });

        }
    }
}
