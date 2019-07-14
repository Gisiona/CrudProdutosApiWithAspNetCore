using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudProdutosApiWithAspNetCore.Data.EF.Maps
{
    class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // Table / PK
            builder.ToTable(nameof(Usuario))
              .HasKey(p => p.Id);

            

            // Colunas
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Nome)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(p => p.Senha)
               .HasColumnType("varchar(50)")
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
