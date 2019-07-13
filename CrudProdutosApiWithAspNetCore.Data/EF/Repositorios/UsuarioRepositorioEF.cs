using CrudProdutosApiWithAspNetCore.Data.DataContext;
using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using CrudProdutosApiWithAspNetCore.Dominio.Repositorios;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProdutosApiWithAspNetCore.Data.EF.Repositorios
{
    public class UsuarioRepositorioEF : RepositorioEF<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorioEF(ApiWithAspNetCoreDataContext ctx) : base(ctx)
        {
        }


       public async Task<Usuario> GetByEmailAsync(string email)
        {
            return _db.Where(p => p.Email.Contains(email)).FirstOrDefault();
        }
    }
}
