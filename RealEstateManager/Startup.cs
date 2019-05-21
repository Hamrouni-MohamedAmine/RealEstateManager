using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstateManager.DataAccess.Repositories;
using RealEstateManager.DataAccess.Repositories.Contracts;
using RealEstateManager.Database;
using RealEstateManager.Queries;
using RealEstateManager.Schema;
using RealEstateManager.Types;
using RealEstateManager.Types.Payment;

namespace RealEstateManager
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
            services.AddMvc();
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();

            services.AddDbContext<RealEstateContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:RealEstateDb"]));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<PropertyQuery>();
            services.AddSingleton<PropertyType>();
            services.AddSingleton<PaymentType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new RealEstateManagerSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, RealEstateContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphiQl();
            app.UseMvc();
            db.EnsureSeedData();
        }
    }
}
