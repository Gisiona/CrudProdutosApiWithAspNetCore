using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudProdutosApiWithAspNetCore.Dominio.Repositorios
{
    public interface IRepositorio<TEntity> where TEntity : EntidadeBase
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        void Delete(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
    }
}
