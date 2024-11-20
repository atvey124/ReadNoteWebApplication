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

namespace ReadNoteWebApplication.Data.Extensions
{
    
    public static class ServicesCollection
    {
        [StackTraceHidden]
        public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection) 
        {
            var builder = WebApplication.CreateBuilder();
            var connectString = builder.Configuration.GetConnectionString("MySqlConn");

            serviceCollection.AddScoped<INoteRepository, NoteRepository>();
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(connectString,ServerVersion.AutoDetect(connectString));
            });

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 10;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAuthentication(optrions =>
            {
                optrions.DefaultAuthenticateScheme =
                optrions.DefaultChallengeScheme = 
                optrions.DefaultForbidScheme = 
                optrions.DefaultScheme = 
                optrions.DefaultSignInScheme = 
                optrions.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(optrions =>
            {
                optrions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey
                    (
                        System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]!) //fix this !
                    )
                };
            });

            return serviceCollection;
        }

        [StackTraceHidden]
        public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddScoped<INoteService, NoteService>();
            return serviceCollection;
        }
    }
}
