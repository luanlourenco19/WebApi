using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LocadoraApi.Repository;
using LocadoraApi.Data;
using Microsoft.EntityFrameworkCore;

namespace LocadoraApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRelatoriosRepository, RelatoriosRepository>();
            services.AddSingleton<IClienteRepository, ClienteRepository>();


            var connection = @"server=localhost;database=Locadora;user=sa;password=Tc4<P,f*4f[?f@'#";
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

            services.AddMvcCore();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    context.Response.Headers.Add("Content-Type", "text/html; charset=utf-8");
                    await context.Response.WriteAsync("Web API");
                });

                endpoints.MapControllers();
            });
        }
    }
}
