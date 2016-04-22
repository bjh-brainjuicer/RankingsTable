using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RankingsTable.EF;

namespace RankingsTable.UI
{
    using AutoMapper;

    using RankingsTable.EF.Entities;
    using RankingsTable.UI.Mapping;

    public class Startup
    {
        // TODO this is a bit hacky, needs to be in config file
        private string ConnStr = "Server=localhost;Database=RankingsTable;Trusted_Connection=True;MultipleActiveResultSets=true;";

        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Add data services
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<RankingsTableDbContext>(options =>
                {
                    options.UseSqlServer(this.ConnStr);
                });

            // Register components
            services.Add(new ServiceDescriptor(typeof(IRankingsTableDbContext), typeof(RankingsTableDbContext), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IDTOMapper), typeof(DTOMapper), ServiceLifetime.Singleton));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseMvc(
                routes =>
                    {
                        routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                    });
            
#if DEBUG
            this.SeedTestData();
#endif
        }
        
        private void SeedTestData()
        {
            var options = new DbContextOptionsBuilder<RankingsTableDbContext>();
            options.UseSqlServer(this.ConnStr);
            using (var db = new RankingsTableDbContext(options.Options))
            {
                if (!db.Players.Any(p => p.Name == "Ben"))
                {
                    var season = new Season { Id = Guid.NewGuid(), Number = 1 };

                    var player1 = new Player { Id = Guid.NewGuid(), Name = "Ben" };
                    var player2 = new Player { Id = Guid.NewGuid(), Name = "Foo" };

                    var seasonPlayer1 = new SeasonPlayer { Id = Guid.NewGuid(), Season = season, Player = player1 };
                    var seasonPlayer2 = new SeasonPlayer { Id = Guid.NewGuid(), Season = season, Player = player2 };
                    player1.SeasonPlayers.Add(seasonPlayer1);
                    player2.SeasonPlayers.Add(seasonPlayer2);

                    var fixture = new Fixture
                                      {
                                          Id = Guid.NewGuid(),
                                          Season = season,
                                          HomePlayer = seasonPlayer1,
                                          HomeGoals = 1,
                                          AwayPlayer = seasonPlayer2,
                                          AwayGoals = 3
                                      };
                    season.Fixtures.Add(fixture);
                    seasonPlayer1.HomeFixtures.Add(fixture);
                    seasonPlayer2.AwayFixtures.Add(fixture);
                    
                    db.Seasons.Add(season);
                    db.Players.Add(player1);
                    db.Players.Add(player2);

                    db.SaveChanges();
                }
            }
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
