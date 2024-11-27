using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ReadNoteWebApplication.Data.Context;
using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Repository;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using ReadNoteWebApplication.Data.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ReadNoteWebApplication.Data.Services;
using ReadNoteWebApplication.Data.Hashing;
using ReadNoteWebApplication.Data.Helpers;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.Extensions.Options;



namespace ReadNoteWebApplication.Data.Extensions
{
    
    public static class ServicesCollection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection) 
        {
            var builder = WebApplication.CreateBuilder();
            var connectString = builder.Configuration.GetConnectionString("MySqlConn");

            serviceCollection.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
            serviceCollection.AddScoped<INoteRepository, NoteRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(connectString,ServerVersion.AutoDetect(connectString));
            });

            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:SecretKey"]))
                    };

                    options.Events = new JwtBearerEvents()
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["test-cookie"];

                            return Task.CompletedTask;
                        }
                    };
                });

            serviceCollection.AddAuthorization();

            return serviceCollection;
        }

        public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddScoped<INoteService, NoteService>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IPasswordHasher, PasswordHasher>();
            serviceCollection.AddScoped<IJwtProvider, JwtProvider>();
            serviceCollection.AddScoped<IQueryObject, QueryObject>();

            return serviceCollection;
        }

    }
}
