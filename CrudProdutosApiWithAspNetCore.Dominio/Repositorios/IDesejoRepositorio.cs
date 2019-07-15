using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudProdutosApiWithAspNetCore.Dominio.Repositorios
{
    public interface IDesejoRepositorio: IRepositorio<Desejo>
    {
        Task<IEnumerable<Desejo>> GetDesejosByUserIdAsync(int userId);
        Task<IEnumerable<Desejo>> GetDesejosByIdWithProdutosAsync(int id);
        void DeleteDesejoByUserIdAndByProductIdAsync(Desejo desejo);
        Task<IEnumerable<Desejo>> GetDesejoByUserIdAndProductIdAsync(int userid, int productid);
    }
}
