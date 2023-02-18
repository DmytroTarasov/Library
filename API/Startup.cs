using System.Reflection;
using API.Middlewares;
using Application.Core;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.Implementations;
using Persistence.Interfaces;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(c => {
                    c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });
            // services.AddFluentValidationAutoValidation();
            
            services.Configure<RouteOptions>(options => 
            { 
                options.LowercaseUrls = true; 
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });
            services.AddDbContext<DataContext>(opt => {
                opt.UseSqlite(_config.GetConnectionString("DefaultConnection"));
            });
            // services.AddCors(opt => {
            //     opt.AddPolicy("CorsPolicy", policy => {
            //         policy
            //             .AllowAnyMethod()
            //             .AllowAnyHeader()
            //             .AllowCredentials()
            //             .WithOrigins("http://localhost:3000");
            //     });
            // });

            // services.AddMediatR(typeof(List.Handler).Assembly);

            services.AddAutoMapper(typeof(MappingConfiguration).Assembly);

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookService, BookService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv5 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            // app.UseCors("CorsPolicy");

            // app.UseAuthentication();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
