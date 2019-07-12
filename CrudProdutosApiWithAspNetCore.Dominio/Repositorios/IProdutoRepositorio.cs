using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudProdutosApiWithAspNetCore.Dominio.Repositorios
{
    public interface IProdutoRepositorio : IRepositorio<Produto>
    {
        Task<IEnumerable<Produto>> GetByNomeAsync(string name);
    }
}
