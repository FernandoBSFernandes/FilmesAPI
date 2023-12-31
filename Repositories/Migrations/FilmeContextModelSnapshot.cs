﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.Context;

#nullable disable

namespace Repositories.Migrations
{
    [DbContext(typeof(FilmeContext))]
    partial class FilmeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DiretorFilme", b =>
                {
                    b.Property<long>("DiretoresId")
                        .HasColumnType("bigint");

                    b.Property<long>("FilmesId")
                        .HasColumnType("bigint");

                    b.HasKey("DiretoresId", "FilmesId");

                    b.HasIndex("FilmesId");

                    b.ToTable("DiretorFilme");
                });

            modelBuilder.Entity("Models.Tables.Ator", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("idAtor");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("FilmeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nome");

                    b.Property<string>("Papel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("papel");

                    b.HasKey("Id");

                    b.HasIndex("FilmeId");

                    b.ToTable("Ator");
                });

            modelBuilder.Entity("Models.Tables.Diretor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("idDiretor");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("diretor");
                });

            modelBuilder.Entity("Models.Tables.EstiloFilme", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("idEstilo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("descricao");

                    b.HasKey("Id");

                    b.ToTable("estilo");
                });

            modelBuilder.Entity("Models.Tables.Filme", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("idFilme");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Ano")
                        .HasColumnType("int")
                        .HasColumnName("ano");

                    b.Property<int>("Duracao")
                        .HasColumnType("int")
                        .HasColumnName("duracao");

                    b.Property<long>("EstiloId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("EstiloId");

                    b.ToTable("filme");
                });

            modelBuilder.Entity("DiretorFilme", b =>
                {
                    b.HasOne("Models.Tables.Diretor", null)
                        .WithMany()
                        .HasForeignKey("DiretoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Tables.Filme", null)
                        .WithMany()
                        .HasForeignKey("FilmesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Tables.Ator", b =>
                {
                    b.HasOne("Models.Tables.Filme", null)
                        .WithMany("Atores")
                        .HasForeignKey("FilmeId");
                });

            modelBuilder.Entity("Models.Tables.Filme", b =>
                {
                    b.HasOne("Models.Tables.EstiloFilme", "Estilo")
                        .WithMany()
                        .HasForeignKey("EstiloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estilo");
                });

            modelBuilder.Entity("Models.Tables.Filme", b =>
                {
                    b.Navigation("Atores");
                });
#pragma warning restore 612, 618
        }
    }
}
