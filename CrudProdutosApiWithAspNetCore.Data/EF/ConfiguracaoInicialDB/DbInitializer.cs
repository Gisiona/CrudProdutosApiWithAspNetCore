using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CrudProdutosApiWithAspNetCore.Data.EF.ConfiguracaoInicialDB
{
    public static class DbInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
              .HasData(
                  new Categoria() { Id = 1, Nome = "Esporte e Lazer", Descricao = "Produtos relacionado a esporte." },
                  new Categoria() { Id = 2, Nome = "Telefonia", Descricao = "Produtos relacionado a telefonia." },
                  new Categoria() { Id = 3, Nome = "Informática", Descricao = "Produtos relacionado a informática." }
                  );

            modelBuilder.Entity<Produto>()
                .HasData(
                    new Produto() { Id = 1, Nome = "Bicicleta Aro 29 KSW Xlt 21V Câmbios Shimano Freio a Disco Mecânico", Preco = 800.00M, CategoriaId = 1 },
                    new Produto() { Id = 2, Nome = "Iphone 7 Plus 32 Gigas", Preco = 2800.00M, CategoriaId = 2 },
                    new Produto() { Id = 3, Nome = "Notebook DELL Core I5", Preco = 1800.00M, CategoriaId = 3 }
                    );
        }
    }
}
