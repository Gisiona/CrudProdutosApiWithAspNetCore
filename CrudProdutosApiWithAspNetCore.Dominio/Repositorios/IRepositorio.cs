using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudProdutosApiWithAspNetCore.Dominio.Repositorios
{
    public interface IRepositorio<TEntity> where TEntity : EntidadeBase
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(object id);

    }
}
