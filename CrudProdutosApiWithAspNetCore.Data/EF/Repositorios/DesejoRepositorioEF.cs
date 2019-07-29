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

        
        public async Task<IEnumerable<Desejo>> GetDesejosByIdAsync(int id)
        {
            return await _db.Include(p => p.Produto).Include(p => p.Usuario).Where(p => p.Id == id).ToListAsync();
        }

        public async Task<IEnumerable<Desejo>> GetDesejosByUserIdAsync(int userId)
        {
            return await _db.Include(p => p.Produto).Include(p => p.Usuario).Where(p => p.UsuarioId == userId).ToListAsync();
        }

        public async Task<Desejo> GetDesejoByUserIdAndProductIdAsync(int userid, int productid)
        {
            return await _db.Include(p => p.Produto).Include(p => p.Usuario).Where(p => p.UsuarioId == userid && p.ProdutoId == productid ).FirstOrDefaultAsync();
        }

        public async Task<Desejo> GetDesejoByIdAndUserIdAndProductIdAsync(int desejoId, int userid, int productid)
        {
            return await _db.Include(p => p.Produto)
                .Include(p => p.Usuario)
                .Where(p => p.UsuarioId == userid 
                        && p.ProdutoId == productid
                        && p.Id == desejoId).FirstOrDefaultAsync();
        }

        public async Task<Desejo> UpdateDesejoAsync(Desejo desejo)
        {           
            _context.Entry<Desejo>(desejo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return desejo;
        }

        public async Task<IQueryable<Desejo>> GetDesejosByUserIdAsync(int userId, int pageSize, int page)
        {            
           IList<Desejo> pp= (IList<Desejo>)_db.Include(p => p.Produto).Where(p => p.UsuarioId == userId).ToListAsync();
            return (IQueryable<Desejo>) _db.Include(p => p.Produto).Skip(pp.Count * (page-1)).Take(pp.Count).Take(page).ToListAsync();
        }

        public async Task<Desejo> GetDesejoByIdAsync(int id)
        {
            return await _db.Include(p => p.Produto).Include(p => p.Usuario).Where(p => p.Id == id).FirstOrDefaultAsync();
        }
    }
}
