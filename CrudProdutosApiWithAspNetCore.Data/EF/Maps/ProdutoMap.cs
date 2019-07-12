using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudProdutosApiWithAspNetCore.Data.EF.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            // Table / PK
            builder.ToTable(nameof(Produto))
              .HasKey(p => p.HashId);           

            // Colunas
            builder.Property(p => p.HashId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Preco)
               .HasColumnType("money")
               .IsRequired();

            builder.Property(p => p.DataCadastro)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.DataAlteracao)
               .HasColumnType("datetime")
               .IsRequired();
        }
    }
}
