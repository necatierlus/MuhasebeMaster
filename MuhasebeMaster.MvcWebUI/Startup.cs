using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using MuhasebeMaster.Business.Abstract;
using MuhasebeMaster.Business.Concrete.Managers;
using MuhasebeMaster.DataAccess.Abstract;
using MuhasebeMaster.DataAccess.Concrete.EntityFrameworkCore;
using MuhasebeMaster.MvcWebUI.Identity;
using MuhasebeMaster.MvcWebUI.Services;
using Microsoft.Extensions.Logging;
using MuhasebeMaster.MvcWebUI.Controllers;

namespace MuhasebeMaster.MvcWebUI
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
            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSession();

            //services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration["MuhasebeMasterDbConnection"]));
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration["MuhasebeMasterDbConnection"]));
            //services.AddDbContext<MuhasebeMasterDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MuhasebeMasterDbConnection")));

            services.AddIdentity<AppIdentityUser, AppIdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options => {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;

                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/Security/Login";
                options.LogoutPath = "/Security/Logout";
                options.AccessDeniedPath = "/Security/AccessDenied";
                //options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.Cookie = new CookieBuilder {
                    HttpOnly = true,
                    Name = "MuhasebeMaster.Cookie",
                    Path = "/",
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest
                };
            });

            //Ilogger configuration
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<SecurityController>>();
            services.AddSingleton(typeof(ILogger), logger);
            //Ilogger configuration

            //for authorization
            services.AddAuthorization();
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("RequireAdministratorRole",
            //         policy => policy.RequireRole("Administrator"));
            //});

            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IAccountDal, EfAccountDal>();

            services.AddScoped<IPaymentService, PaymentManager>();
            services.AddScoped<IPaymentDal, EfPaymentDal>();

            services.AddScoped<IProdService, ProdManager>();
            services.AddScoped<IProdDal, EfProdDal>();

            services.AddScoped<ITillService, TillManager>();
            services.AddScoped<ITillDal, EfTillDal>();

            services.AddScoped<ITransactionService, TransactionManager>();
            services.AddScoped<ITransactionDal, EfTransactionDal>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();

            services.AddScoped<IProductImageService, ProductImageManager>();
            services.AddScoped<IProductImageDal, EfProductImageDal>();

            services.AddScoped<IEmailConfiguration,EmailConfiguration>();
            services.AddScoped<IMailService, MailManager>();

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

            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

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
