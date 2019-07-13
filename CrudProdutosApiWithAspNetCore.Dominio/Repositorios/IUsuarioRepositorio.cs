using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using System.Threading.Tasks;

namespace CrudProdutosApiWithAspNetCore.Dominio.Repositorios
{
    public interface IUsuarioRepositorio: IRepositorio<Usuario>
    {        
        Task<Usuario> GetByEmailAsync(string email);
    }
}
