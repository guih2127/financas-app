﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Persistence;

namespace api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210302230640_SeedUpdate")]
    partial class SeedUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("api.Domain.Entities.CategoriaOperacaoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataCriacao = new DateTime(2021, 3, 2, 20, 6, 39, 872, DateTimeKind.Local).AddTicks(6724),
                            Nome = "Pokémon TCG",
                            Status = 1
                        });
                });

            modelBuilder.Entity("api.Domain.Entities.OperacaoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoriaOperacaoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TipoOperacao")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaOperacaoId");

                    b.ToTable("Operacoes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoriaOperacaoId = 1,
                            DataCriacao = new DateTime(2021, 3, 2, 20, 6, 39, 874, DateTimeKind.Local).AddTicks(2805),
                            Descricao = "Compra de cartas avulsas de pokémon.",
                            Nome = "Cartas Pokémon TCG",
                            Status = 1,
                            TipoOperacao = 2,
                            Valor = 100.0
                        });
                });

            modelBuilder.Entity("api.Domain.Entities.OperacaoEntity", b =>
                {
                    b.HasOne("api.Domain.Entities.CategoriaOperacaoEntity", "CategoriaOperacao")
                        .WithMany("Operacoes")
                        .HasForeignKey("CategoriaOperacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaOperacao");
                });

            modelBuilder.Entity("api.Domain.Entities.CategoriaOperacaoEntity", b =>
                {
                    b.Navigation("Operacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
