using Api.Assemblies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
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
            services.AddControllers();

            services.AddAutoMapper(AssemblyUtil.Assemblies());
            IoC.Mapeamento.Mapear(services);

            ConfigurarSwagger(services);
        }

        private void ConfigurarSwagger(IServiceCollection services)
        {
            var informacoes = new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "CEP API",
                Version = "v1",
                Description = "API para obter informações de CEP"
            };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", informacoes);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            UsarSwagger(app);
        }

        private void UsarSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API CEP");
            });
        }
    }
}
