using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MM_Roteiros.Models;

public partial class MmbmoviesContext : DbContext
{
    public MmbmoviesContext()
    {
    }

    public MmbmoviesContext(DbContextOptions<MmbmoviesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<FilmActor> FilmActors { get; set; }

    public virtual DbSet<FilmCategory> FilmCategories { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Top5MostStarredActor> Top5MostStarredActors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;User ID=;Password=;Database=MMBMovies;Trusted_Connection=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.ActorId)
                .HasName("pk_actor")
                .IsClustered(false);

            entity.ToTable("actor");

            entity.HasIndex(e => e.LastName, "idx_actor_last_name");

            entity.Property(e => e.ActorId).HasColumnName("actor_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_update");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId)
                .HasName("pk_category")
                .IsClustered(false);

            entity.ToTable("category");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedOnAdd()
                .HasColumnName("category_id");
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_update");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId)
                .HasName("pk_customer")
                .IsClustered(false);

            entity.ToTable("customer");

            entity.HasIndex(e => e.LastName, "idx_last_name");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedOnAdd()
                .HasColumnName("customer_id");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("('Y')")
                .HasColumnName("active");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_update");
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.FilmId)
                .HasName("pk_film")
                .IsClustered(false);

            entity.ToTable("film");

            entity.HasIndex(e => e.LanguageId, "idx_fk_language_id");

            entity.HasIndex(e => e.OriginalLanguageId, "idx_fk_original_language_id");

            entity.Property(e => e.FilmId).HasColumnName("film_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_update");
            entity.Property(e => e.Length).HasColumnName("length");
            entity.Property(e => e.OriginalLanguageId).HasColumnName("original_language_id");
            entity.Property(e => e.Rating)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('G')")
                .HasColumnName("rating");
            entity.Property(e => e.ReleaseYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("release_year");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Language).WithMany(p => p.FilmLanguages)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_film_language");

            entity.HasOne(d => d.OriginalLanguage).WithMany(p => p.FilmOriginalLanguages)
                .HasForeignKey(d => d.OriginalLanguageId)
                .HasConstraintName("fk_film_language_original");
        });

        modelBuilder.Entity<FilmActor>(entity =>
        {
            entity.HasKey(e => new { e.ActorId, e.FilmId })
                .HasName("pk_film_actor")
                .IsClustered(false);

            entity.ToTable("film_actor");

            entity.HasIndex(e => e.ActorId, "idx_fk_film_actor_actor");

            entity.HasIndex(e => e.FilmId, "idx_fk_film_actor_film");

            entity.Property(e => e.ActorId).HasColumnName("actor_id");
            entity.Property(e => e.FilmId).HasColumnName("film_id");
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_update");

            entity.HasOne(d => d.Actor).WithMany(p => p.FilmActors)
                .HasForeignKey(d => d.ActorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_film_actor_actor");

            entity.HasOne(d => d.Film).WithMany(p => p.FilmActors)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_film_actor_film");
        });

        modelBuilder.Entity<FilmCategory>(entity =>
        {
            entity.HasKey(e => new { e.FilmId, e.CategoryId })
                .HasName("pk_film_category")
                .IsClustered(false);

            entity.ToTable("film_category");

            entity.HasIndex(e => e.CategoryId, "idx_fk_film_category_category");

            entity.HasIndex(e => e.FilmId, "idx_fk_film_category_film");

            entity.Property(e => e.FilmId).HasColumnName("film_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_update");

            entity.HasOne(d => d.Category).WithMany(p => p.FilmCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_film_category_category");

            entity.HasOne(d => d.Film).WithMany(p => p.FilmCategories)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_film_category_film");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId)
                .HasName("pk_language")
                .IsClustered(false);

            entity.ToTable("language");

            entity.Property(e => e.LanguageId)
                .ValueGeneratedOnAdd()
                .HasColumnName("language_id");
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_update");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("name");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId)
                .HasName("pk_staff")
                .IsClustered(false);

            entity.ToTable("staff");

            entity.Property(e => e.StaffId)
                .ValueGeneratedOnAdd()
                .HasColumnName("staff_id");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("active");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_update");
            entity.Property(e => e.Password)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Top5MostStarredActor>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("top5_most_starred_actors");

            entity.Property(e => e.ActorId).HasColumnName("actor_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Total).HasColumnName("total");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
