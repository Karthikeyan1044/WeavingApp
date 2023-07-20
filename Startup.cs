using Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Module.Abstract;
using Module.Repository;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using static Module.Service.StudentService;

namespace Maja
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
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = "https://localhost:5000",
                     ValidAudience = "https://localhost:5000",
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
                 };
             });
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<DBcontext>(options =>
            //{
            //    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            //});

            //----------------need old DbContext------------------
            services.AddDbContext<DBcontext>(opts =>
            {
                opts.UseMySql(Configuration.GetConnectionString("DefaultConnection"));

            });

            services.AddTransient<IStudentService, StudentSevice>();
            services.AddTransient<IStudentRepo, StudentRepo>();
            services.AddLocalization(options => options.ResourcesPath = "Resource folder");

            services.AddSwaggerGen(context =>
            {
                context.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Test API",
                    Version = "v1"
                });
            });

            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(context =>
                {
                    context.PreSerializeFilters.Add((swagger, httpReq) =>
                    {
                        string hostValue = httpReq.Host.Value;
                        if (httpReq.Headers.ContainsKey("X-Forwarded-Host"))
                        {
                            var pathBase = httpReq.Headers["X-Forwarded-Host"].FirstOrDefault();
                            if (!string.IsNullOrWhiteSpace(pathBase))
                            {
                                hostValue = pathBase.Trim();
                            }
                        }
                        swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{hostValue}{httpReq.PathBase.Value}" } };
                    });
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseSwaggerUI(context =>
            {
                context.SwaggerEndpoint("v1/swagger.json", "My SmartTools API V1");
            });

            app.UseRouting();
            app.UseCors();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
