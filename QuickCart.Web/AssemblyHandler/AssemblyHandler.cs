using Microsoft.AspNetCore.Authentication;
using QuickCart.Repo;
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
            // Repository

            services.AddTransient<ICategoryRepository, CategoryRepository>();

            //
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();


        }
    }
}
