using Cxc.OData;
using Cxc.TablasBasicas.Models;
using Cxc_back.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Cxc_Backend
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

            services.AddHttpContextAccessor();

            services.AddDbContext<CntContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddCors(options => options.AddPolicy("AllowAll", p => p.WithOrigins(
                                       "http://localhost:4200",
                                       "https://localhost:4200",
                                       "http://cxc.multiclicksistemas.net",
                                       "https://cxc.multiclicksistemas.net")
                                                                   .AllowAnyMethod()
                                                                    .AllowAnyHeader()
                                                                    .AllowCredentials()));


            //Managers
            services.AddODataScoped();

            services.AddControllers();

            var builder = new CxcODataConventionModelBuilder();

            services.AddOData(opt => opt.AddModel("odata/v1", builder.GetEdmModel()).SetMaxTop(100).Count().Filter().Select().Expand().OrderBy());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = $"CXC API v{this.GetType().Assembly.GetName().Version}",
                    Description = "CXC",
                    Contact = new OpenApiContact
                    {
                        Name = "CXC API",
                        Email = string.Empty
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                    }
                });

                c.DocInclusionPredicate((name, api) => api.HttpMethod != null);
            });

            //services.AddMvcCore(options =>
            //{
            //    foreach (var outputFormatter in options.OutputFormatters.OfType<OutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
            //    {
            //        outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
            //    }
            //    foreach (var inputFormatter in options.InputFormatters.OfType<InputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
            //    {
            //        inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
            //    }
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "cxc_back v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/$odata", ODataRouteHandler.HandleOData);
                endpoints.MapControllers();
            });

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CntContext>();
                if (context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                {
                    context.Database.Migrate();
                }

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
