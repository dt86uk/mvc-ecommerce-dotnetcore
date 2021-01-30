using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ECommerceWebsite.BusinessLogic;
using ECommerceService;
using ECommerceService.BusinessLogic;
using ECommerceRepository.BusinessLogic;
using ECommerceDatabase.BusinessLogic;

namespace ECommerceWebsite
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //setup Entity Framework In-Memory database
            new StartupDatabase().InitializeEFInMemoryDatabase();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //session setup
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(7);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();
            services.AddMvc().AddRazorRuntimeCompilation();
            services.AddSession();

            //web
            services.AddTransient<ILoginWebService, LoginWebService>();
            services.AddTransient<IMenuWebService, MenuWebService>();
            services.AddTransient<IProductWebService, ProductWebService>();
            services.AddTransient<ICartWebService, CartWebService>();
            services.AddTransient<IOrderWebService, OrderWebService>();
            services.AddTransient<IUserWebService, UserWebService>();
            services.AddTransient<IUserValidationService, UserValidationService>();
            services.AddTransient<IFileValidationWebService, FileValidationWebService>();

            //service
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<ISalesService, SalesService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductTypeService, ProductTypeService>();
            services.AddTransient<IGenderService, GenderService>();

            //repo
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductSizeRepository, ProductSizeRepository>();
            services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
            services.AddTransient<IGenderRepository, GenderRepository>();

            //database
            services.AddTransient<IPasswordEncryptionService, PasswordEncryptionService>();
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
            
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "admin/{controller}/{action}/{id?}",
                    defaults: new { controller = "Admin", action = "Index" }
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}