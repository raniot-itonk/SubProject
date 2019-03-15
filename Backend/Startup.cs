using Backend.DB;
using Backend.OptionModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace Backend
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvcCore().AddAuthorization().AddJsonFormatters();
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            SetupDatabase(services, _env);
            services.Configure<Services>(Configuration.GetSection(nameof(Services)));
            //services.Configure<TaxInfo>(Configuration.GetSection(nameof(TaxInfo)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            InitializeDatabase(app, env);

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void InitializeDatabase(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                if(env.IsDevelopment())
                    scope.ServiceProvider.GetRequiredService<CraftsmanContext>().Database.EnsureCreated();
                else
                    scope.ServiceProvider.GetRequiredService<CraftsmanContext>().Database.Migrate();

            }
        }
        private void SetupDatabase(IServiceCollection services, IHostingEnvironment env)
        {
            if(env.IsDevelopment())
            {
                //services.AddDbContext<CraftsmanContext>(options => options.UseInMemoryDatabase("InMemoryDbForTesting"));
                services.AddDbContext<CraftsmanContext>
                    (options => options.UseSqlServer(Configuration.GetConnectionString("CraftsmenDatabase")));
            }
            else
            {
                services.AddDbContext<CraftsmanContext>
                    (options => options.UseSqlServer(Configuration.GetConnectionString("CraftsmenDatabase")));
            }
        }
    }
}
