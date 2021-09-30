using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Positano.Application.CQRS;
using Positano.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ApiHeladeria
{
    public class Startup
    {
      
            // This method gets called by the runtime. Use this method to add services to the container.
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public IConfiguration Configuration { get; }
            readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<PositanoContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("Positano.Persistence")
                    )
                );
            services.AddScoped(typeof(GenericRepository<>));
            RegisterCommandQueryHandlers(services);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Positano.ApiHost", Version = "v1" });
                c.CustomSchemaIds(i => i.FullName);
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            services.AddCors();
        }

        private void RegisterCommandQueryHandlers(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(IRequest));
            services.AddMediatR(typeof(IRequest<>));
            services.AddMediatR(typeof(IRequestHandler<>));
            services.AddMediatR(typeof(IRequestHandler<,>));
            services.AddMediatR(typeof(Startup));

            var commandAndQueryHandlers = typeof(AccountLogInQuery).Assembly.GetTypes()
             .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequest<>))
            );

            foreach (var handler in commandAndQueryHandlers)
            {
                services.AddScoped(handler, handler);
            }
          
                

            Type[] handlerInterface = { typeof(IRequestHandler<>), typeof(IRequestHandler<,>) };
            var handlers = typeof(AccountLogInQuery).Assembly.GetTypes()
             .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && handlerInterface.Contains(i.GetGenericTypeDefinition()))
         );
            foreach (var handler in handlers)
            {
                services.AddScoped(handler.GetInterfaces().First(i => i.IsGenericType && handlerInterface.Contains(i.GetGenericTypeDefinition())), handler);
            }  
            
            var assemblies = Assembly
                .GetExecutingAssembly()
                .GetTypes().Where(t => t.Namespace == "Positano.Application.CQRS" && t.IsClass && !t.IsNested);

            foreach (var assembly in assemblies)
            {
                services.AddScoped(assembly, assembly);
            }


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Positano.ApiHost");
                    c.RoutePrefix = string.Empty;
                });

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

