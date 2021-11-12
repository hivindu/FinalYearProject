using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using UCRDAUsers.API.Data;
using UCRDAUsers.API.Data.Interface;
using UCRDAUsers.API.Repository;
using UCRDAUsers.API.Repository.Interface;
using UCRDAUsers.API.Settings;

namespace UCRDAUsers.API
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
        {
            services.AddControllers();

            services.Configure<UCRDAUserDatabaseSettings>(Configuration.GetSection(nameof(UCRDAUserDatabaseSettings)));

            services.AddSingleton<IUCRDAUserDatabaseSettings>(sp=> sp.GetRequiredService<IOptions<UCRDAUserDatabaseSettings>>().Value);

            services.AddTransient<IUCRDAUserContext,UCRDAUserContext>();

            services.AddTransient<IUCRDAUserRepository, UCRDAUserRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UC & RDA User API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(); // midleware for using swagers
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "UC & RDA User API v1"); });
        }
    }
}
