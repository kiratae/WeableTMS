using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Weable.TMS.Entity.Repository;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.RepositoryModel;
using Weable.TMS.Model.Service;
using Weable.TMS.Model.ServiceModel;
using Weable.TMS.Web.Helper;

namespace Web
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var cultureInfo = new CultureInfo("th-TH");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            // DbContext
            services.AddDbContext<TMSDBContext>(option =>
                option.UseMySql(Configuration.GetConnectionString("TMSDbContext"),
                mySqlOptions =>
                {
                    mySqlOptions.ServerVersion(new Version(10, 1, 37), ServerType.MariaDb)
                    .DisableBackslashEscaping();
                }));

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseService, CourseService>();

            services.AddTransient<IFileRepository, FileRepository>();
            services.AddTransient<IFileService, FileService>();

            services.AddTransient<IRegisTrainingRepository, RegisTrainingRepository>();
            services.AddTransient<IRegisTrainingService, RegisTrainingService>();

            services.AddTransient<ITrainingRepository, TrainingRepository>();
            services.AddTransient<ITrainingService, TrainingService>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
