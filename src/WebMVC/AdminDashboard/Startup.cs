using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using InvoiceMicroServices.WebMVC.AdminDashboard.GatewayToMicroServices;
using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using InvoiceMicroServices.WebMVC.AdminDashboard.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace InvoiceMicroServices.WebMVC.AdminDashboard
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
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();


            services.Configure<AppSettings>(Configuration);
            services.AddSingleton<IHttpClient, CustomHttpClient>();
            services.AddTransient<ICompanyInfo, CompanyInfoService>();
            services.AddTransient<IClientInfo, ClientInfoService>();
            services.AddTransient<IProjectInfo, ProjectInfoService>();
            services.AddTransient<IEmployee, EmployeeService>();
            services.AddTransient<IBillingInfo, BillingService>();
            services.AddTransient<IDelete, Delete>();
            services.AddTransient<IAccount, AccountInfo>();
            services.AddTransient<IIdentityService<ApplicationUser>, IdentityService>();



            var identityUrl = Configuration.GetValue<string>("IdentityURL");
            var callBackUrl = Configuration.GetValue<string>("CallBackURL");

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(2);
                options.Cookie.HttpOnly = true;

            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
             .AddOpenIdConnect(options =>
             {
                 options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                 options.Authority = identityUrl.ToString();
                 options.SignedOutRedirectUri = callBackUrl.ToString();
                 options.ClientId = "mvc";
                 options.ClientSecret = "secret";
                 options.ResponseType = "code id_token";
                 options.SaveTokens = true;
                 options.GetClaimsFromUserInfoEndpoint = true;
                 options.RequireHttpsMetadata = false;
                 options.Scope.Add("openid");
                 options.Scope.Add("profile");
                 options.Scope.Add("offline_access");
                 options.Scope.Add("roles");
                 options.ClaimActions.MapUniqueJsonKey("role", "role");
                 options.TokenValidationParameters = new TokenValidationParameters()
                 {

                     NameClaimType = "name",
                     RoleClaimType = "role"
                 };
                 options.Scope.Add("Inovice");
             });

        //    services.AddAuthorization(options =>
        //{
        //    options.AddPolicy("Administrator", policy => policy.RequireRole("Administrator"));
        //    options.AddPolicy("Employee", policy => policy.RequireRole("Employee"));
        //    options.AddPolicy("HR", policy => policy.RequireRole("HR"));
        //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
           
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=AdminHomePage}/{action=Index}/{id?}");
            });
        }
    }
}
