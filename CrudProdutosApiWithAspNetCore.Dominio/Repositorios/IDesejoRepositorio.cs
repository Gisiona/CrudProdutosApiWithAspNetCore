using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProdutosApiWithAspNetCore.Dominio.Repositorios
{
    public interface IDesejoRepositorio: IRepositorio<Desejo>
    {
        Task<IEnumerable<Desejo>> GetDesejosByUserIdAsync(int userId);
        Task<IQueryable<Desejo>> GetDesejosByUserIdAsync(int userId, int pageSize, int page);
        Task<IEnumerable<Desejo>> GetDesejosByIdAsync(int id);
        Task<Desejo> GetDesejoByIdAsync(int id);
        void DeleteDesejoByUserIdAndByProductIdAsync(Desejo desejo);
        Task<Desejo> GetDesejoByUserIdAndProductIdAsync(int userid, int productid);
        Task<Desejo> GetDesejoByIdAndUserIdAndProductIdAsync(int desejoId, int userid, int productid);
        Task<Desejo> UpdateDesejoAsync(Desejo desejo);
        
    }
}
