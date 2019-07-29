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
        Task<Desejo> GetDesejoByIdAsync(int id);
        void DeleteDesejoById(int desejoId);
        void DeleteByDesejo(Desejo desejo);
        Task<Desejo> GetDesejoByIdAndProductIdAsync(int DesejoId, int productid);
        Task<Desejo> GetDesejoByIdAndUserIdAndProductIdAsync(int desejoId, int userid, int productid);
        Task<Desejo> UpdateDesejoAsync(Desejo desejo);

        
    }
}
