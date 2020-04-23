using System;
using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Interfaces;
using NerdStore.Catalogo.Domain.Entities;
using System.Linq.Enumerable.SelectMany;

namespace NerdStore.Catalogo.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {

        public CatalogoContext(DbContextOptions<CatalogoContext> options)
            : base(options) {}

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))
            ))
                property.Relational().ColumnType = "varchar(100)";

            base.OnModelCreating(modelBuilder);
        }

        public Task<bool> Commit() 
        {
            throw new System.NotImplementedException();
        }
    }
}
