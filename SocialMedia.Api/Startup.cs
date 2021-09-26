using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using SocialMedia.Infrastructure.Filters;
using SocialMedia.Infrastructure.Repositories;
using System;


namespace SocialMedia.Api
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
            //Obtener compilados de proyecto y con eso detecta los mapeos registrados
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



            //isntalar el paquete desde nuget
            //Necasrio para evitar la referenceloopHandling ignorar error y mostrar el nodo siguiemte pero vacio
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }).ConfigureApiBehaviorOptions(options => {


                //options.SuppressModelStateInvalidFilter = true; //validando modelo de forma manual
                //Comentandolo--- la validacion se trabajaria desde ApiController


            });




            services.AddControllers();

            //inyecccion de dependencias--- conexion a db
            services.AddDbContext<SocialMediaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SocialMedia"))    
            );


            //resolviendo dependencias

            services.AddTransient<IPostRepository, PostRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SocialMedia.Api", Version = "v1" });
            });


            //Agregando filter a nivel global con compartibilidad a mvc -- agregando validators

            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();


            }).AddFluentValidation(options =>
            {

                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SocialMedia.Api v1"));
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
