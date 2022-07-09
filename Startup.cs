namespace LenusHealthTechTest
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.EntityFrameworkCore;
    using LenusHealthTechTest.StartupTasks;
    using Newtonsoft.Json.Converters;
    using LenusHealthTechTest.Interfaces.Core;
    using LenusHealthTechTest.Repositories.Core;
    using LenusHealthTechTest.Extentions;
    using Microsoft.AspNetCore.Mvc;

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
            services.AddDbContext<BookStoreContext>(opt => opt.UseInMemoryDatabase("BookStore"));
            services.AddControllers().AddNewtonsoftJson(jsonOptions =>
            {
                jsonOptions.SerializerSettings.Converters.Add(new StringEnumConverter());
            });
            services.AddSingleton<IReflectionService, ReflectionService>();
            services.AddSingleton(sp => sp.GetRequiredService<ILoggerFactory>().CreateLogger("DefaultLogger"));
            services.AddTransient<IStartUpTask, SeedDatabaseStartupTask>();
            services.AddTransient<ICommandRunner, CommandRunner>();
            services.AddTransient<IQueryRunner, QueryRunner>();
            services.RegisterInterfaceImplementations(typeof(ICommand<,>), ServiceLifetime.Transient, new ReflectionService());
            services.RegisterInterfaceImplementations(typeof(IQuery<,>), ServiceLifetime.Transient, new ReflectionService());
            services.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
