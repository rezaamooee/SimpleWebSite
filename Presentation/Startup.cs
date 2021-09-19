using Application.Interfaces.Contexts;
using Application.Interfaces.Services.Post;
using Application.Interfaces.Services.Role;
using Application.Interfaces.Services.Topic;
using Application.Interfaces.Services.User;
using Application.Services.Post;
using Application.Services.Role;
using Application.Services.Topic;
using Application.Services.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Peristence.Context;

namespace Presentation
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
            string ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=SiteDbContext;Integrated Security=True;";
            //string ConnectionString = Configuration.GetConnectionString("SiteDbContext.Connection");
            services.AddEntityFrameworkSqlServer().AddDbContext<SiteDbContext>(option => option.UseSqlServer(ConnectionString));
            services.AddScoped<ISiteDbContext, SiteDbContext>();

            services.AddScoped<IUserFacad, UserFacad>();
            services.AddScoped<IPostFacad, PostFacad>();
            services.AddScoped<IRoleFacad, RoleFacad>();
            services.AddScoped<ITopicFacad, TopicFacad>();



            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddAuthorization();



            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
