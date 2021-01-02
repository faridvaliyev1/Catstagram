using Catstagram.Server.Data;
using Catstagram.Server.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Catstagram.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        =>
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.getDefaultConnectionString()))
                .AddIdentity()
                .AddJwtAuthentication(services.GetAppSettings(Configuration))
                .AddApplicationServices()
                .AddSwagger()
                .AddControllers();
                

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }

            app.UseSwaggerUI()
             .UseRouting()
             .UseCors(options => options.
                AllowAnyOrigin().
                AllowAnyMethod().
                AllowAnyHeader())
             .UseAuthentication()
             .UseAuthorization()
             .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            })
            .ApplyMigrations();
        }
    }
}
