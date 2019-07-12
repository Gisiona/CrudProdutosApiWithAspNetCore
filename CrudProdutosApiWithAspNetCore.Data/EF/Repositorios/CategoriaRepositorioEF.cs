using CrudProdutosApiWithAspNetCore.Data.DataContext;
using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using CrudProdutosApiWithAspNetCore.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProdutosApiWithAspNetCore.Data.EF.Repositorios
{
    public class CategoriaRepositorioEF : RepositorioEF<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorioEF(ApiWithAspNetCoreDataContext ctx) : base(ctx)
        {           
        }

        public async Task<IEnumerable<Categoria>> GetByNomeCategoriaAsync(string name)
        {
            return await _db.Where(p => p.Nome.Contains(name)).ToListAsync();
        }
    }
}
