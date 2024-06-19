
using QuickCart.Repo;
using QuickCart.Repo.Repositories;
using QuickCart.Services;

namespace QuickCart.Web.AssemblyHandler
{
    public class AssemblyHandler
    {
        public static void HandlehandleDependencies(IServiceCollection services)
        {
            RegisterInterfaces(services);
        }


        private static void RegisterInterfaces(IServiceCollection services)
        {

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Services

            services.AddTransient<ICategoryService, CategoryService>();
                  
            services.AddTransient<ISubCategoryService, SubCategoryService>();

            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<IFileService, FileService>();
            // Repository

            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<ISubCategoryRepository, SubCategoryRepository>();

            services.AddTransient<IProductRepository, ProductRepository>();

            // 
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();


        }
    }
}
