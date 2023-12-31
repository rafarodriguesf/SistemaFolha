﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaFolha.Data;

#nullable disable

namespace SistemaFolha.Migrations
{
    [DbContext(typeof(SistemaFolhaContext))]
    [Migration("20231022161143_fe")]
    partial class fe
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaFolha.Models.Cargo", b =>
                {
                    b.Property<int>("CargoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoId"));

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<decimal>("INSS")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NomeCargo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("SalarioBase")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CargoId");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("SistemaFolha.Models.Ferias", b =>
                {
                    b.Property<int>("FeriasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeriasId"));

                    b.Property<DateTime>("DataFimFerias")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicioFerias")
                        .HasColumnType("datetime2");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorFerias")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("FeriasId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Ferias");
                });

            modelBuilder.Entity("SistemaFolha.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FuncionarioId"));

                    b.Property<int>("Agencia")
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<string>("ContaCorrente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DataAdmissao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Instituicao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("FuncionarioId");

                    b.HasIndex("CargoId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("SistemaFolha.Models.HorasTrabalhadas", b =>
                {
                    b.Property<int>("HorasTrabalhadasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HorasTrabalhadasId"));

                    b.Property<DateTime>("DataHorasTrabalhadas")
                        .HasColumnType("datetime2");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<string>("HoraEntradaHorasTrabalhadas")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("HoraSaidaHorasTrabalhadas")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("HorasTrabalhadasId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("HorasTrabalhadas");
                });

            modelBuilder.Entity("SistemaFolha.Models.Pagamento", b =>
                {
                    b.Property<int>("PagamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PagamentoId"));

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorPago")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PagamentoId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("SistemaFolha.Models.Ferias", b =>
                {
                    b.HasOne("SistemaFolha.Models.Funcionario", "Funcionario")
                        .WithMany("Ferias")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("SistemaFolha.Models.Funcionario", b =>
                {
                    b.HasOne("SistemaFolha.Models.Cargo", "Cargo")
                        .WithMany("Funcionarios")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("SistemaFolha.Models.HorasTrabalhadas", b =>
                {
                    b.HasOne("SistemaFolha.Models.Funcionario", "Funcionario")
                        .WithMany("HorasTrabalhadas")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("SistemaFolha.Models.Pagamento", b =>
                {
                    b.HasOne("SistemaFolha.Models.Funcionario", "Funcionario")
                        .WithMany("Pagamentos")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("SistemaFolha.Models.Cargo", b =>
                {
                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("SistemaFolha.Models.Funcionario", b =>
                {
                    b.Navigation("Ferias");

                    b.Navigation("HorasTrabalhadas");

                    b.Navigation("Pagamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
