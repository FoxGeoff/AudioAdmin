using AudioAdmin.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AudioAdmin.API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _env;
        private readonly string _dbconnect;

        public Startup(IConfiguration config, IHostingEnvironment env)
        {
            _config = config;
            _env = env;
            _dbconnect = _config["dbconnect4"];
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsDevelopment())
            {
                /* Alternative: for connection string from config.json (not a sercure configuraion)
                services.AddDbContext<ProductImageDbContext>(options =>
                options.UseMySql(_config.GetConnectionString("dbconnect"))); */

                services.AddDbContext<AudioDbContext>(options =>
                options.UseMySql(_dbconnect));
            }

            services.AddTransient<AudioImageSeeder>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                AudioImageSeeder.InitializeData(app.ApplicationServices, loggerFactory);
            }

            app.UseMvc();
        }
    }
}
