using AutoMapper;
using DNPA.Repositories;
using DNPA.Repositories.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DNPA.API
{
    public class Startup
    {
        readonly string APICorsPolicyName = "_APIAllowAllOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Scoped objects are the same within a request, but different across different requests.
            // Transient objects are always different; a new instance is provided to every controller and every service.
            // Singleton objects are the same for every object and every request.

            // Entity Framework DB context initialization
            services.AddDbContext<DNPADBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            // register the generic repository and db context
            services.AddTransient<DbContext, DNPADBContext>();

            // Critical Generic repo to Concrete EF repo DI initialization
            // Set scoped so one is created on every request - key to unit of work pattern usage
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

            // Enable critical mappings used by Business Layer
            services.AddAutoMapper(typeof(DNPA.Business.AutoMappingProfile));

            services.AddCors(options =>
            {
                options.AddPolicy(name: APICorsPolicyName,
                    builder =>
                    {
                        builder.SetIsOriginAllowed((host) => true);
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "DNPA API",
                    Version = "v1",
                    Description = "API for Dot Net Project Accelerator",
                });
            });

            services.AddControllers();      
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseCors(APICorsPolicyName);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("{ message:'Please see documentation for endpoints to call' }");
                });

                endpoints.MapGet("/heartbeat", async context =>
                {
                    await context.Response.WriteAsync("{ heartbeat:true }");
                });
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "DNPA API"));
        }
    }
}
