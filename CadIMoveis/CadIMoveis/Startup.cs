using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CadIMoveis
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
            services.AddControllersWithViews();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<ORM.Interface.ICliente, ORM.Repository.ClienteRepository>();
            services.AddTransient<ORM.Interface.IIMovel, ORM.Repository.ImoveisRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
               

                endpoints.MapControllerRoute(
                    name: "Home",
                    pattern: "Home",
                    defaults: new { controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(

                    name: "Cliente",
                    pattern: "/Cliente",
                    defaults: new { controller = "Cliente", Action = "Index" });


                endpoints.MapControllerRoute(
                    name: "CadastrarCliente",
                    pattern: "/Cliente/Cadastrar",
                    defaults: new { controller = "Cliente", Action = "Cadastrar" });

                endpoints.MapControllerRoute(
                    name: "EditarCliente",
                    pattern: "/Cliente/Editar/{Id?}",
                    defaults: new { controller = "Cliente", Action = "Editar" });

                endpoints.MapControllerRoute(
                    name: "EditarImovel",
                    pattern: "/ImoveL/Editar/{Id?}",
                    defaults: new { controller = "Imovel", Action = "Editar" });

                endpoints.MapControllerRoute(

                    name: "Imovel",
                    pattern: "/Imovel",
                    defaults: new { controller = "Imovel", Action = "Index" });

                endpoints.MapControllerRoute(
                    name: "FIlter",
                    pattern: "/Cliente/FIlter",
                    defaults: new { controller = "Cliente", Action = "filterCliente" });


                endpoints.MapControllerRoute(

                    name: "MeusImoveis",
                    pattern: "/Imovel/MeusImoveis/{IdCliente?}",
                    defaults: new { controller = "Imovel", Action = "ListaImoveisUsuario" });



                endpoints.MapControllerRoute(
                    name: "CadastroImovel",
                    pattern: "/Imovel/Cadastrar/{IdCliente?}",
                    defaults: new { controller = "Imovel", Action = "Cadastrar" });

                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}");



            });
        }
    }
}
