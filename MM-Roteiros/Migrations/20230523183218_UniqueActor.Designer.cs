﻿// <auto-generated />
using System;
using MM_Roteiros.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MM_Roteiros.Migrations
{
    [DbContext(typeof(MMRoteirosContexto))]
    [Migration("20230523183218_UniqueActor")]
    partial class UniqueActor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MM_Roteiros.Negocio.Ator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("actor_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasColumnType("varchar(45)")
                        .HasColumnName("first_name");

                    b.Property<string>("UltimoNome")
                        .IsRequired()
                        .HasColumnType("varchar(45)")
                        .HasColumnName("last_name");

                    b.Property<DateTime>("last_update")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasAlternateKey("PrimeiroNome", "UltimoNome");

                    b.HasIndex("UltimoNome");

                    b.ToTable("actor", (string)null);
                });

            modelBuilder.Entity("MM_Roteiros.Negocio.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("film_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnoLancamento")
                        .IsRequired()
                        .HasColumnType("varchar(4)")
                        .HasColumnName("release_year");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<short>("Duracao")
                        .HasColumnType("smallint")
                        .HasColumnName("length");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(45)")
                        .HasColumnName("title");

                    b.Property<byte>("language_id")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("last_update")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<byte?>("original_language_id")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("language_id");

                    b.HasIndex("original_language_id");

                    b.ToTable("film", (string)null);
                });

            modelBuilder.Entity("MM_Roteiros.Negocio.FilmeAtor", b =>
                {
                    b.Property<int>("film_id")
                        .HasColumnType("int");

                    b.Property<int>("actor_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("last_update")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("film_id", "actor_id");

                    b.HasIndex("actor_id");

                    b.ToTable("film_actor", (string)null);
                });

            modelBuilder.Entity("MM_Roteiros.Negocio.Idioma", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint")
                        .HasColumnName("language_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("char(20)")
                        .HasColumnName("name");

                    b.Property<DateTime>("last_update")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.ToTable("language", (string)null);
                });

            modelBuilder.Entity("MM_Roteiros.Negocio.Filme", b =>
                {
                    b.HasOne("MM_Roteiros.Negocio.Idioma", "IdiomaFalado")
                        .WithMany("FilmesFalados")
                        .HasForeignKey("language_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MM_Roteiros.Negocio.Idioma", "IdiomaOriginal")
                        .WithMany("FilmesOriginais")
                        .HasForeignKey("original_language_id");

                    b.Navigation("IdiomaFalado");

                    b.Navigation("IdiomaOriginal");
                });

            modelBuilder.Entity("MM_Roteiros.Negocio.FilmeAtor", b =>
                {
                    b.HasOne("MM_Roteiros.Negocio.Ator", "Ator")
                        .WithMany("Filmografia")
                        .HasForeignKey("actor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MM_Roteiros.Negocio.Filme", "Filme")
                        .WithMany("Atores")
                        .HasForeignKey("film_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ator");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("MM_Roteiros.Negocio.Ator", b =>
                {
                    b.Navigation("Filmografia");
                });

            modelBuilder.Entity("MM_Roteiros.Negocio.Filme", b =>
                {
                    b.Navigation("Atores");
                });

            modelBuilder.Entity("MM_Roteiros.Negocio.Idioma", b =>
                {
                    b.Navigation("FilmesFalados");

                    b.Navigation("FilmesOriginais");
                });
#pragma warning restore 612, 618
        }
    }
}
