using System;
using api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<OperacaoEntity> Operacoes { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CategoriaOperacaoEntity>().ToTable("Categorias");
            builder.Entity<OperacaoEntity>().ToTable("Operacoes");

            builder.Entity<CategoriaOperacaoEntity>().HasKey(p => p.Id);
            builder.Entity<CategoriaOperacaoEntity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<CategoriaOperacaoEntity>().Property(p => p.Nome).IsRequired().HasMaxLength(30);
            builder.Entity<CategoriaOperacaoEntity>().Property(p => p.Status).IsRequired();
            builder.Entity<CategoriaOperacaoEntity>().Property(p => p.DataCriacao).IsRequired();
            builder.Entity<CategoriaOperacaoEntity>()
                .HasMany(p => p.Operacoes)
                .WithOne(p => p.CategoriaOperacao)
                .HasForeignKey(p => p.CategoriaOperacaoId);

            builder.Entity<OperacaoEntity>().HasKey(p => p.Id);
            builder.Entity<OperacaoEntity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<OperacaoEntity>().Property(p => p.Nome).IsRequired().HasMaxLength(30);
            builder.Entity<OperacaoEntity>().Property(p => p.TipoOperacao).IsRequired();
            builder.Entity<OperacaoEntity>().Property(p => p.CategoriaOperacaoId).IsRequired();
            builder.Entity<OperacaoEntity>().Property(p => p.DataCriacao).IsRequired();

            builder.Entity<CategoriaOperacaoEntity>().HasData
            (
                new CategoriaOperacaoEntity { Id = 1, Nome = "Pokémon TCG", DataCriacao = DateTime.Now, Status = StatusEnum.Ativo }
            );

            builder.Entity<OperacaoEntity>().HasData
            (
                new OperacaoEntity 
                { 
                    Id = 1, 
                    Nome = "Cartas Pokémon TCG", 
                    Descricao = "Compra de cartas avulsas de pokémon.", 
                    DataCriacao = DateTime.Now, CategoriaOperacaoId = 1, 
                    Valor = 100.00, 
                    TipoOperacao = TipoOperacaoEnum.Despesa, 
                    Status = StatusEnum.Ativo 
                }
            );
        }
    }
}