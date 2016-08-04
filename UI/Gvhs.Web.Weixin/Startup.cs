using Gvhs.Web.Services;
using Gvhs.Web.ServiceContracts;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Gvhs.Web.Weixin.Infrastructures;
using Microsoft.AspNet.Http;
using Gvhs.Web.Pms.DataContracts;
using Gvhs.Web.Pms;

namespace Gvhs.Web.Weixin
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<WeixinDbContext>(options =>
                options.UseSqlServer(Configuration["Data:WeixinConnection:ConnectionString"]));

            services.AddMvc();

            services.AddTransient<IBllServiceProvider, BllServiceProvider>();
            services.AddTransient<WeixinHelper>();
            services.AddTransient<IPmsService>( t => {
                return new PmsService(Configuration["Data:Api:Url"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // 加载中间件Http请求处理

            app.UseIISPlatformHandler();
            if (env.IsDevelopment())
                app.UseStaticFiles();
            else
                app.UseStaticFiles("/weixinsrc");
            
            // 设置认证Cookie的参数
            app.UseCookieAuthentication(options =>
            {
                options.AuthenticationScheme = "Weixin";
                options.ExpireTimeSpan = new System.TimeSpan(30, 0, 0, 0);
                options.LoginPath = new PathString("/Weixin/Home/Denied");
                options.AccessDeniedPath = new PathString("/Weixin/Home/Denied");
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
            });

            //app.UseMvc();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "Weixin/{controller=Home}/{action=Index}");
            });


        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }

}
