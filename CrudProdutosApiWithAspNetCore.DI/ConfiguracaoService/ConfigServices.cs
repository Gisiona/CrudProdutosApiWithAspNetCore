using CrudProdutosApiWithAspNetCore.Data.DataContext;
using Microsoft.Extensions.DependencyInjection;

namespace CrudProdutosApiWithAspNetCore.DI.ConfiguracaoService
{
    public static  class ConfigServices
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            // Instancia única em todo o prodeto
            //services.AddSingleton<ApiWithAspNetCoreDataContext>();

            // Instancia por requisicao
            //services.AddScoped<ApiWithAspNetCoreDataContext>();


            // Instancia por chamada
            //services.AddTransient<>();

            services.AddScoped<ApiWithAspNetCoreDataContext>();
            services.AddTransient<Dominio.Repositorios.IProdutoRepositorio, Data.EF.Repositorios.ProdutoRepositorioEF>();
            services.AddTransient<Dominio.Repositorios.ICategoriaRepositorio, Data.EF.Repositorios.CategoriaRepositorioEF>();
            services.AddTransient<Dominio.Repositorios.IUsuarioRepositorio, Data.EF.Repositorios.UsuarioRepositorioEF>();
            services.AddTransient<Dominio.Repositorios.IDesejoRepositorio, Data.EF.Repositorios.DesejoRepositorioEF>();

        }
    }
}
