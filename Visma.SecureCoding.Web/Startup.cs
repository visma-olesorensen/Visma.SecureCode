using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Visma.SecureCoding.DataAccess;
using Visma.SecureCoding.DataAccess.Contracts;
using Visma.SecureCoding.Logic.Contracts.Injection;
using Visma.SecureCoding.Logic.Contracts.SensitiveDataExposure;
using Visma.SecureCoding.Logic.Injection;
using Visma.SecureCoding.Logic.SensitiveDataExposure;

namespace Visma.SecureCoding.Web
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
            services.AddTransient<ISqlConnectionFactory, SqlConnectionFactory>();
            services.AddTransient<ISqlWrapper, SqlWrapper>();
            services.AddTransient<IPasswordRepository, PasswordRepository>();
            services.AddTransient<IInitializeDatabaseCommandHandler, InitializeDatabaseCommandHandler>();
            services.AddTransient<IAllowedSqlInjectionQueryHandler, AllowedSqlInjectionQueryHandler>();
            services.AddTransient<IDisallowedSqlInjectionByParametersQueryHandler, DisallowedSqlInjectionByParametersQueryHandler>();
            services.AddTransient<ISecureSensitiveData, SecureSensitiveData>();
            services.AddTransient<IStorePlainTextPasswordCommandHandler, StorePlainTextPasswordCommandHandler>();
            services.AddTransient<IStoreHashedPasswordCommandHandler, StoreHashedPasswordCommandHandler>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
