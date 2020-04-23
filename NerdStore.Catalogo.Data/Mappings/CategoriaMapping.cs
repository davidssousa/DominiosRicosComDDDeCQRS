using NerdStore.Catalogo.Domain.Entities;

namespace NerdStore.Catalogo.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(250)");

            // Relacionamento => 1 : N ( Categorias : Produtos )
            builder.HasMany(c => c.Produtos)
                   .WithOne(p => p.Categoria)
                   .HasForeignKey(p => p.CategoriaId);

            builder.ToTable("Categorias");
            
        }

    }
}