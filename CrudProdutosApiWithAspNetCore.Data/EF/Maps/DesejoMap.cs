using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudProdutosApiWithAspNetCore.Data.EF.Maps
{
    public class DesejoMap : IEntityTypeConfiguration<Desejo>
    {
        public void Configure(EntityTypeBuilder<Desejo> builder)
        {
            // Table / PK
            builder.ToTable(nameof(Desejo))
              .HasKey(p => p.Id);


            // Colunas
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(100)")
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
