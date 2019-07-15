using CrudProdutosApiWithAspNetCore.Data.DataContext;
using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using CrudProdutosApiWithAspNetCore.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProdutosApiWithAspNetCore.Data.EF.Repositorios
{
    public class DesejoRepositorioEF : RepositorioEF<Desejo>, IDesejoRepositorio
    {

        private readonly ApiWithAspNetCoreDataContext _context;
        public DesejoRepositorioEF(ApiWithAspNetCoreDataContext ctx) : base(ctx)
        {
            _context = ctx;
        }

        public void DeleteDesejoByUserIdAndByProductIdAsync(Desejo desejo)
        {          
            _context.Remove(desejo);
            _context.SaveChanges();            
        }

        
        public async Task<IEnumerable<Desejo>> GetDesejosByIdWithProdutosAsync(int id)
        {
            return await _db.Include(p => p.Produto).Where(p => p.Id == id).ToListAsync();
        }

        public async Task<IEnumerable<Desejo>> GetDesejosByUserIdAsync(int userId)
        {
            return await _db.Include(p => p.Produto).Where(p => p.UsuarioId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Desejo>> GetDesejoByUserIdAndProductIdAsync(int userid, int productid)
        {
            return await _db.Include(p => p.Produto).ToListAsync();
        }
    }
}
