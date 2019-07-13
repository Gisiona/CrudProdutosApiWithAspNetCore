using CrudProdutosApiWithAspNetCore.Data.EF.ConfiguracaoInicialDB;
using CrudProdutosApiWithAspNetCore.Data.EF.Maps;
using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CrudProdutosApiWithAspNetCore.Data.DataContext
{
    public class ApiWithAspNetCoreDataContext: DbContext
    {
        private readonly IConfiguration _config;

        public ApiWithAspNetCoreDataContext(IConfiguration config)
        {
            _config = config;
            //Verifica se a base existe, se nao existir cria
            Database.EnsureCreated();
        }


        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CrudAspNetCoreApi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            optionsBuilder.UseSqlServer(_config.GetConnectionString("ApiConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeamento das entidades do banco de dados
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            modelBuilder.Seed();
        }
    }
}
