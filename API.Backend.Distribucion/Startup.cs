using API.Backend.Infraestructura.Injector;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace API.Backend.Distribucion
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(g =>
               {
                   g.TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = Configuration["ConfiguracionToken:Issuer"],
                       ValidAudience = Configuration["ConfiguracionToken:AudienciaPermitida"],
                       IssuerSigningKey = new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes(Configuration["ConfiguracionToken:ClaveSecreta"])
                       )
                   };
               });
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
                c.AddPolicy("AllowHeader", options => options.AllowAnyHeader());
                c.AddPolicy("AllowMethod", options => options.AllowAnyMethod());
            });
            services.AddMvc()
                .AddJsonOptions(g => 
                    g.SerializerSettings.ContractResolver = new DefaultContractResolver())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var Injector = new InjectorDependencia(services);
            Injector.ContenedorDependencias(Configuration["ConexionBaseDatos"]);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseCors(options =>
            {
                options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
