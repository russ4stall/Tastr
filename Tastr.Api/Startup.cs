using Tastr.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using System.Collections.Generic;

namespace Tastr.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            var connection = Configuration["Data:DefaultConnection:ConnectionString"];
            services.AddDbContext<TastrContext>(options => options.UseMySQL(connection));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            Seed(app);
        }

        private void Seed(IApplicationBuilder app) {
            var context = app.ApplicationServices.GetRequiredService<TastrContext>();
            context.Database.EnsureCreated();
            var user1 = new User
                    {                        
                        Email = "russ4stall@gmail.com",
                        FirstName = "Russ",
                        LastName = "Forstall"
                    };


            var session1 = new Session() {
                Title = "Whiskey Tasting",
                Description = "",
                Location = "My House",
                DateTime = new System.DateTime()                
            };
            var sessions = new List<Session>();
            
            sessions.Add(session1);
            user1.Sessions = sessions;
            context.Users.Add(user1);
            context.SaveChanges();
        }
    }
}
