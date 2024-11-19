using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ReadNoteWebApplication.Data.Context;
using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Repository;
using System.Diagnostics;

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
