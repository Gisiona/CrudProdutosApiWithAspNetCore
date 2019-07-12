using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudProdutosApiWithAspNetCore.Data.EF.Maps
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            // Table / PK
            builder.ToTable(nameof(Categoria))
              .HasKey(p => p.HashId);

            // Colunas
            builder.Property(p => p.HashId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Descricao)
             .HasColumnType("varchar(150)")
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
