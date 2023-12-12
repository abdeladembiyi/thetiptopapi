using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace thetiptopapi.Models;

public partial class ThetiptopContext : DbContext
{
    public ThetiptopContext()
    {
    }

    public ThetiptopContext(DbContextOptions<ThetiptopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Participation> Participations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=root;password=root;database=thetiptop", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.1.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Participation>(entity =>
        {
            entity.HasKey(e => e.IdParticipation).HasName("PRIMARY");

            entity.ToTable("participation");

            entity.HasIndex(e => e.IdUser, "FK_idUser_1432_idx");

            entity.Property(e => e.IdParticipation).HasColumnName("idParticipation");
            entity.Property(e => e.DateParticipation).HasColumnName("dateParticipation");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Participations)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_idUser_1432");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.AncienMotDepasse)
                .HasMaxLength(70)
                .HasColumnName("ancienMotDepasse");
            entity.Property(e => e.DateCreation).HasColumnName("dateCreation");
            entity.Property(e => e.DateDeNaissance)
                .HasMaxLength(70)
                .HasColumnName("dateDeNaissance");
            entity.Property(e => e.DateModification).HasColumnName("dateModification");
            entity.Property(e => e.DateSuppresion).HasColumnName("dateSuppresion");
            entity.Property(e => e.Email)
                .HasMaxLength(70)
                .HasColumnName("email");
            entity.Property(e => e.MotDepasse).HasMaxLength(70);
            entity.Property(e => e.Nom)
                .HasMaxLength(70)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(70)
                .HasColumnName("prenom");
            entity.Property(e => e.Role)
                .HasMaxLength(45)
                .HasColumnName("role");
            entity.Property(e => e.Sexe)
                .HasMaxLength(45)
                .HasColumnName("sexe");
            entity.Property(e => e.Telephone)
                .HasMaxLength(70)
                .HasColumnName("telephone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
