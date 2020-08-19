using luafalcao.api.Persistence.Contexts;

using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using luafalcao.api.Domain.Contracts;
using luafalcao.api.Domain.Services;
using luafalcao.api.Facade.Contracts;
using luafalcao.api.Facade;
using luafalcao.api.Persistence.Contracts.Repositories;
using luafalcao.api.Persistence.Repositories;
using luafalcao.api.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using luafalcao.api.Domain.Contracts.Adapters;
using luafalcao.api.Domain.Adapters;

namespace luafalcao.api.Web.Extensions
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
               b => b.MigrationsAssembly("luafalcao.api.Web")));

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
            services.AddScoped<IBlogFacade, BlogFacade>();
            services.AddScoped<IAuthenticationFacade, AuthenticationFacade>();
        }

        public static void ConfigureAdapters(this IServiceCollection services)
        {
            services.AddScoped<IUserManagerAdapter, UserManagerAdapter>();
        }

        public static void ConfigureDomains(this IServiceCollection services)
        {
            services.AddScoped<IArtigoService, ArtigoService>();
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
    }
}
