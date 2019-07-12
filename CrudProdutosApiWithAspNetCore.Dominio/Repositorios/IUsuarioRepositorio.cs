using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudProdutosApiWithAspNetCore.Dominio.Repositorios
{
    public interface IUsuarioRepositorio: IRepositorio<Usuario>
    {
        Task<IEnumerable<Usuario>> GetByNome(string name);        
    }
}
