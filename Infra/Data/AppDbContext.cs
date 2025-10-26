using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModell> RegistroUsuario { get; set; }
        public DbSet<FarmModell> RegistroFazenda { get; set; }
        public DbSet<UserFarmModell> UserFarm { get; set; }
        public DbSet<MaquinaModell> RegistroMaquina { get; set; }
        public DbSet<ManutencaoMaquinaModell> ManutencaoMaquina { get; set; }
        public DbSet<PlantacaoModell> RegistroPlantacao { get; set; }
        public DbSet<CustoPlantacaoModell> CustoPlantacaos { get; set; }
        public DbSet<FinancaModell> RegistroFinanca { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<UserModell>()
                .Property(u => u.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))"); // SQLite GUID


            // User <-> Farm (N:N via UserFarmModell)
            modelBuilder.Entity<UserFarmModell>()
                .HasKey(uf => new { uf.UserId, uf.FarmId }); // chave composta

            modelBuilder.Entity<UserFarmModell>()
                .HasOne(uf => uf.User)
                .WithMany(u => u.UserFarms)
                .HasForeignKey(uf => uf.UserId);

            modelBuilder.Entity<UserFarmModell>()
                .HasOne(uf => uf.Farm)
                .WithMany(f => f.UserFarms)
                .HasForeignKey(uf => uf.FarmId);


            // Plantacao <-> Farm
            modelBuilder.Entity<PlantacaoModell>()
                .HasOne(p => p.Farm)
                .WithMany(f => f.Plantacoes)
                .HasForeignKey(p => p.FarmId)
                .OnDelete(DeleteBehavior.Cascade);

            // CustoPlantacao <-> Plantacao
            modelBuilder.Entity<CustoPlantacaoModell>()
                .HasOne(c => c.Plantacao)
                .WithMany(p => p.Custos)
                .HasForeignKey(c => c.PlantacaoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Financa <-> CustoPlantacao
            modelBuilder.Entity<FinancaModell>()
                .HasOne(f => f.CustoPlantacao)
                .WithMany(c => c.Financas)
                .HasForeignKey(f => f.CustoPlantacaoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Financa <-> Manutencao
            modelBuilder.Entity<FinancaModell>()
                .HasOne(f => f.Manutencao)
                .WithMany(m => m.Financas)
                .HasForeignKey(f => f.ManutencaoMaquinaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Financa <-> Farm
            modelBuilder.Entity<FinancaModell>()
                .HasOne(f => f.Farm)
                .WithMany(fa => fa.Financas)
                .HasForeignKey(f => f.FarmId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
