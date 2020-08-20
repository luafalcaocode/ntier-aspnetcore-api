using alterdata.api.Persistence.Contexts;

using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using alterdata.api.Domain.Contracts;
using alterdata.api.Facade.Contracts;
using alterdata.api.Facade;
using alterdata.api.Persistence.Contracts.Repositories;
using alterdata.api.Persistence.Repositories;
using alterdata.api.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using alterdata.api.Domain.Contracts.Adapters;
using alterdata.api.Domain.Adapters;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace alterdata.api.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddEntityFrameworkNpgsql().AddDbContext<RepositoryContext>(opts => opts.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"),
               b => b.MigrationsAssembly("Alterdata.api.Web")));

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {
            });

        public static void ConfigureMapper(this IServiceCollection services) =>
            services.AddAutoMapper(typeof(Startup));

        public static void ConfigureRazor(this IServiceCollection services) =>
           services.AddRazorPages(options =>
           {

           });

        public static void ConfigureFacades(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationFacade, AuthenticationFacade>();
        }

        public static void ConfigureAdapters(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();
        }

        public static void ConfigureDomains(this IServiceCollection services)
        {
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<Usuario>(option =>
            {
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequiredLength = 10;
                option.User.RequireUniqueEmail = true;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);

            builder.AddEntityFrameworkStores<RepositoryContext>();
            builder.AddDefaultTokenProviders();
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = Environment.GetEnvironmentVariable("SECRET");

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.GetSection("ValidIssuer").Value,
                        ValidAudience = jwtSettings.GetSection("ValidAudience").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "ALTERDATA SOFTWARE API", Version = "v1" });
            });
        }
    }
}
