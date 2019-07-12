using CrudProdutosApiWithAspNetCore.Data.DataContext;
using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using CrudProdutosApiWithAspNetCore.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudProdutosApiWithAspNetCore.Data.EF.Repositorios
{
    public abstract class RepositorioEF<TEntity> : IRepositorio<TEntity> where TEntity : EntidadeBase
    {
        protected readonly ApiWithAspNetCoreDataContext _context;
        protected readonly DbSet<TEntity> _db;

        public RepositorioEF(ApiWithAspNetCoreDataContext ctx)
        {
            _context = ctx;
            _db = _context.Set<TEntity>();
        }


        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(object id)
        {
           return await _context.Set<TEntity>().FindAsync(id);           
        }


        public void Add(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();

        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

     

        public void Update(TEntity entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
