using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjetFinal_6224745.Models;

namespace ProjetFinal_6224745.Data;

public partial class BdGymnastiqueContext : DbContext
{
    public BdGymnastiqueContext()
    {
    }

    public BdGymnastiqueContext(DbContextOptions<BdGymnastiqueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agre> Agres { get; set; }

    public virtual DbSet<Changelog> Changelogs { get; set; }

    public virtual DbSet<Competition> Competitions { get; set; }

    public virtual DbSet<Gymnaste> Gymnastes { get; set; }

    public virtual DbSet<Mouvement> Mouvements { get; set; }

    public virtual DbSet<Performance> Performances { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<VwDetailAgre> VwDetailAgres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=BD_Gymnastique");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agre>(entity =>
        {
            entity.HasKey(e => e.AgreId).HasName("PK_Agre_AgreID");
        });

        modelBuilder.Entity<Changelog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__changelo__3213E83FD48C9422");

            entity.Property(e => e.InstalledOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Competition>(entity =>
        {
            entity.HasKey(e => e.CompetitionId).HasName("PK_Performances_CompetitionID");
        });

        modelBuilder.Entity<Gymnaste>(entity =>
        {
            entity.HasKey(e => e.GymnasteId).HasName("PK_Performances_GymnasteID");
        });

        modelBuilder.Entity<Mouvement>(entity =>
        {
            entity.HasKey(e => e.MouvementId).HasName("PK_Agre_MouvementID");

            entity.HasOne(d => d.Agre).WithMany(p => p.Mouvements).HasConstraintName("FK_AgreID_AgreID");
        });

        modelBuilder.Entity<Performance>(entity =>
        {
            entity.HasKey(e => e.PerformanceId).HasName("PK_Performances_PerformanceID");

            entity.HasOne(d => d.Agres).WithMany(p => p.Performances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgresID_AgresID");

            entity.HasOne(d => d.Competition).WithMany(p => p.Performances).HasConstraintName("FK_CompetitionID_CompetitionID");

            entity.HasOne(d => d.Gymnaste).WithMany(p => p.Performances).HasConstraintName("FK_GymnasteID_GymnasteID");

            entity.HasOne(d => d.Mouvement).WithMany(p => p.Performances)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_MouvementID_MouvementID");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.UtilisateurId).HasName("PK_Utilisateur_UtilisateurID");
        });

        modelBuilder.Entity<VwDetailAgre>(entity =>
        {
            entity.ToView("vw_DetailAgres", "Appareil");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
