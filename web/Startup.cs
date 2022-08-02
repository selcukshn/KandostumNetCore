using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using web.Data.Abstract;
using web.Data.Concrete;
using web.EmailService;
using web.Identity;

namespace web
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer("Data Source=SELCUK;Initial Catalog=KanBagisDb;Integrated Security=SSPI;"));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // password
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                // lockout
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Lockout.AllowedForNewUsers = true;

                // options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
                       {
                           options.LoginPath = "/account/girisyap";
                           options.LogoutPath = "/account/cikisyap";
                           options.AccessDeniedPath = "/account/girisreddedildi";
                           options.SlidingExpiration = true;
                           options.ExpireTimeSpan = TimeSpan.FromDays(1);
                           options.Cookie = new CookieBuilder
                           {
                               HttpOnly = true,
                               Name = ".kanbagis.cookie"
                           };
                       });
            services.AddScoped<IlanlarInterface, IlanlarRepository>();
            services.AddScoped<KanGruplariInterface, KanGruplariRepository>();
            services.AddScoped<HastanelerInterface, HastanelerRepository>();
            services.AddScoped<SehirlerInterface, SehirlerRepository>();
            services.AddScoped<IlcelerInterface, IlcelerRepository>();

            services.AddScoped<IEmailSender, SmtpEmailSender>(i =>
                       new SmtpEmailSender(
                           _configuration["EmailSender:Host"],
                           _configuration.GetValue<int>("EmailSender:Port"),
                           _configuration.GetValue<bool>("EmailSender:EnableSsl"),
                           _configuration["EmailSender:Username"],
                           _configuration["EmailSender:Password"]
                       ));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "login",
                   pattern: "giris-yap",
                   defaults: new { controller = "account", action = "girisyap" }
                );
                endpoints.MapControllerRoute(
                  name: "register",
                  pattern: "kayit-ol",
                  defaults: new { controller = "account", action = "kayitol" }
                );
                endpoints.MapControllerRoute(
                  name: "epostaonay",
                  pattern: "e-posta-onay",
                  defaults: new { controller = "account", action = "epostaonay" }
                );
                endpoints.MapControllerRoute(
                  name: "hastanegetir",
                  pattern: "home/hastanelerigetir/{SehirId?}/{IlceId?}",
                  defaults: new { controller = "home", action = "hastanelerigetir" }
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
