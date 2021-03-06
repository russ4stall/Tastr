﻿using Tastr.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
            services.AddScoped<ISessionDao, SessionDao>();
            services.AddScoped<IItemDao, ItemDao>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            app.UseStaticFiles();
            //Seed(app);
        }

        private void Seed(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<TastrContext>();
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Create items
            var jd = new Item()
            {
                Name = "Jack Daniels",
                Description = "Tennessee Bourbon. Whiskey made..."
            };

            context.Items.Add(new Item() {
                Name = "Evan Williams",
                Description = "Got dat green label. Cheap but gets the job done."
            });
            context.Items.Add(new Item() {
                Name = "Crown Royal",
                Description = "Canada's finest. Comes in a fancy pouch."
            });
            context.Items.Add(new Item() {
                Name = "Fireball",
                Description = "This is straight up candy."
            });
            context.Items.Add(new Item() {
                Name = "Wild Turkey",
                Description = "Mmm mmm mmm mm good."
            });

            // Create users
            var user1 = new User
            {
                Email = "russ4stall@gmail.com",
                FirstName = "Russ",
                LastName = "Forstall"
            };

            // Create sessions
            var sessions = new List<Session>();
            var sessionItems = new List<SessionItem>();
            
            var session1 = new Session()
            {
                Title = "Whiskey Tasting",
                Description = "",
                Location = "My House",
                DateTime = new System.DateTime()
            };

            sessionItems.Add(new SessionItem() { Item = jd, Session = session1});

            session1.SessionItems = sessionItems;
            sessions.Add(session1);

            user1.Sessions = sessions;

            // Create item experiences
            var exp1 = new ItemExperience
            {
                Item = jd,
                Rating = 4,
                Notes = "Classic whiskey. Love it with Coke."
            };

            var experiences = new List<ItemExperience>();
            experiences.Add(exp1);

            user1.ItemExperiences = experiences;
            
            context.Users.Add(user1);
            context.SaveChanges();
        }
    }
}
