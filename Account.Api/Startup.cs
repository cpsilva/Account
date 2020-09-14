using Account.Api.Extensions;
using Account.DataAccess.Database.Context;
using Account.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencyInjectionCustom(Configuration);
            services.AddCors();
            services.AddMvcCustom();
            Container.RegisterServices(services);
            Container.AddDbContextInMemoryDatabase<DatabaseContext>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionCustom(env);
            app.UseCorsCustom();
            app.UseMvcWithDefaultRoute();
        }
    }
}