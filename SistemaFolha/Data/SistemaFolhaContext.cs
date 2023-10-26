using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaFolha.Models;

namespace SistemaFolha.Data
{
    public class SistemaFolhaContext : DbContext
    {
        public SistemaFolhaContext (DbContextOptions<SistemaFolhaContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaFolha.Models.Cargo> Cargo { get; set; } = default!;

        public DbSet<SistemaFolha.Models.Funcionario> Funcionario { get; set; } = default!;

        public DbSet<SistemaFolha.Models.Ferias> Ferias { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>()
                .HasOne(x => x.Cargo)
                .WithMany(y => y.Funcionarios)
                .HasForeignKey(x => x.CargoId);

            modelBuilder.Entity<Ferias>()
                .HasOne(x => x.Funcionario)
                .WithMany(y => y.Ferias)
                .HasForeignKey(x => x.FuncionarioId);

            modelBuilder.Entity<HorasTrabalhadas>()
                .HasOne(x => x.Funcionario)
                .WithMany(y => y.HorasTrabalhadas)
                .HasForeignKey(x => x.FuncionarioId);

            modelBuilder.Entity<Pagamento>()
                .HasOne(x => x.Funcionario)
                .WithMany(y => y.Pagamentos)
                .HasForeignKey(x => x.FuncionarioId);
        }

    }
}
