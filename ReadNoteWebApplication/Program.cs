using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using ReadNoteWebApplication.Data.Context;
using ReadNoteWebApplication.Data.Extensions;
using ReadNoteWebApplication.Data.Helpers;
using System.Diagnostics;


namespace ReadNoteWebApplication
{
    public class Program
    {
        [StackTraceHidden]
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDataAccess();
            builder.Services.AddBusinessLogic();
            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.MapControllers();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always
            });
            app.Run();
            
        }
    }
}
