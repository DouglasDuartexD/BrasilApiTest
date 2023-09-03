﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BrasilApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230903023035_mssql.onprem_migration_156")]
    partial class mssqlonprem_migration_156
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClimaAeroporto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("CodigoICAO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Condicao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CondicaoDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DirecaoVento")
                        .HasColumnType("int");

                    b.Property<int>("PressaoAtmosferica")
                        .HasColumnType("int");

                    b.Property<int>("Temperatura")
                        .HasColumnType("int");

                    b.Property<int>("Umidade")
                        .HasColumnType("int");

                    b.Property<int>("Vento")
                        .HasColumnType("int");

                    b.Property<string>("Visibilidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClimaAeroporto");
                });

            modelBuilder.Entity("ClimaCidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClimaCidade");
                });

            modelBuilder.Entity("PrevisaoClima", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClimaCidadeId")
                        .HasColumnType("int");

                    b.Property<string>("Condicao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CondicaoDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("IndiceUV")
                        .HasColumnType("int");

                    b.Property<int>("Max")
                        .HasColumnType("int");

                    b.Property<int>("Min")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClimaCidadeId");

                    b.ToTable("PrevisaoClima");
                });

            modelBuilder.Entity("PrevisaoClima", b =>
                {
                    b.HasOne("ClimaCidade", null)
                        .WithMany("Clima")
                        .HasForeignKey("ClimaCidadeId");
                });

            modelBuilder.Entity("ClimaCidade", b =>
                {
                    b.Navigation("Clima");
                });
#pragma warning restore 612, 618
        }
    }
}
