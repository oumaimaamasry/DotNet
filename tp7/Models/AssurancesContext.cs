using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace tp7.Models;

public partial class AssurancesContext : DbContext
{
    public AssurancesContext()
    {
    }

    public AssurancesContext(DbContextOptions<AssurancesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Contrat> Contrats { get; set; }

    public virtual DbSet<Correspondant> Correspondants { get; set; }

    public virtual DbSet<DossiersSinistre> DossiersSinistres { get; set; }

    public virtual DbSet<Expert> Experts { get; set; }

    public virtual DbSet<Formule> Formules { get; set; }

    public virtual DbSet<Garanty> Garanties { get; set; }

    public virtual DbSet<Intervention> Interventions { get; set; }

    public virtual DbSet<Prevision> Previsions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-B3LHQ83I\\SQLEXPRESS;Trusted_Connection=True;encrypt=false;Database=Assurances;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client__3214EC275D270E57");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adresse)
                .HasMaxLength(50)
                .HasColumnName("adresse");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .HasColumnName("prenom");
            entity.Property(e => e.Ville)
                .HasMaxLength(50)
                .HasColumnName("ville");
        });

        modelBuilder.Entity<Contrat>(entity =>
        {
            entity.HasKey(e => e.Num).HasName("PK__Contrat__DF908D65FD4144F5");

            entity.Property(e => e.Num).HasColumnName("num");
            entity.Property(e => e.DateEcheance)
                .HasColumnType("date")
                .HasColumnName("dateEcheance");
            entity.Property(e => e.DateSouscription).HasColumnType("date");
            entity.Property(e => e.NumFor).HasColumnName("numFor");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Contrats)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("fk_Contrat");

            entity.HasOne(d => d.NumForNavigation).WithMany(p => p.Contrats)
                .HasForeignKey(d => d.NumFor)
                .HasConstraintName("fk_contrat2");
        });

        modelBuilder.Entity<Correspondant>(entity =>
        {
            entity.HasKey(e => e.IdCorrespondant).HasName("PK__Correspo__C3096999DD9A37CD");

            entity.Property(e => e.IdCorrespondant).HasColumnName("idCorrespondant");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Telephone)
                .HasMaxLength(50)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<DossiersSinistre>(entity =>
        {
            entity.HasKey(e => e.CodeDossier).HasName("PK__DossierS__EE64F91AA6BD35FE");

            entity.Property(e => e.CodeDossier).HasColumnName("codeDossier");
            entity.Property(e => e.DateCloture)
                .HasColumnType("date")
                .HasColumnName("dateCloture");
            entity.Property(e => e.DateOuverture).HasColumnType("date");
            entity.Property(e => e.IdExpert).HasColumnName("idExpert");
            entity.Property(e => e.Idcorrespondant).HasColumnName("idcorrespondant");
            entity.Property(e => e.Indemnite)
                .HasMaxLength(50)
                .HasColumnName("indemnite");
            entity.Property(e => e.NumContrat).HasColumnName("numContrat");

            entity.HasOne(d => d.IdExpertNavigation).WithMany(p => p.DossiersSinistres)
                .HasForeignKey(d => d.IdExpert)
                .HasConstraintName("fk_expert");

            entity.HasOne(d => d.IdcorrespondantNavigation).WithMany(p => p.DossiersSinistres)
                .HasForeignKey(d => d.Idcorrespondant)
                .HasConstraintName("fk_correspondant");

            entity.HasOne(d => d.NumContratNavigation).WithMany(p => p.DossiersSinistres)
                .HasForeignKey(d => d.NumContrat)
                .HasConstraintName("fk_dossinistre");
        });

        modelBuilder.Entity<Expert>(entity =>
        {
            entity.HasKey(e => e.IdExpert).HasName("PK__Expert__EC4036BA8A5685A0");

            entity.Property(e => e.IdExpert).HasColumnName("idExpert");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Telephone)
                .HasMaxLength(50)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<Formule>(entity =>
        {
            entity.HasKey(e => e.CodeFormule).HasName("PK__Formule__7994DFCB99597E75");

            entity.Property(e => e.CodeFormule).HasColumnName("codeFormule");
            entity.Property(e => e.Libelle)
                .HasMaxLength(50)
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<Garanty>(entity =>
        {
            entity.HasKey(e => e.CodeGarantie).HasName("PK__Garantie__543EEB909D06398C");

            entity.Property(e => e.CodeGarantie).HasColumnName("codeGarantie");
            entity.Property(e => e.Libelle)
                .HasMaxLength(50)
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<Intervention>(entity =>
        {
            entity.HasKey(e => e.CodeIntervention).HasName("PK__Interven__502D49DC1FF1B39A");

            entity.Property(e => e.CodeIntervention).HasColumnName("codeIntervention");
            entity.Property(e => e.CodeDos).HasColumnName("codeDos");
            entity.Property(e => e.DateIntervention)
                .HasColumnType("date")
                .HasColumnName("dateIntervention");

            entity.HasOne(d => d.CodeDosNavigation).WithMany(p => p.Interventions)
                .HasForeignKey(d => d.CodeDos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Intervention");
        });

        modelBuilder.Entity<Prevision>(entity =>
        {
            entity.HasKey(e => e.CodeProvision).HasName("PK__Prevoir__307E50CC2E16A2CC");

            entity.Property(e => e.CodeProvision).HasColumnName("codeProvision");
            entity.Property(e => e.CodeFor).HasColumnName("codeFor");
            entity.Property(e => e.CodeGar).HasColumnName("codeGar");
            entity.Property(e => e.PlafondFranchie)
                .HasMaxLength(50)
                .HasColumnName("plafondFranchie");

            entity.HasOne(d => d.CodeForNavigation).WithMany(p => p.Previsions)
                .HasForeignKey(d => d.CodeFor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Prevoir");

            entity.HasOne(d => d.CodeGarNavigation).WithMany(p => p.Previsions)
                .HasForeignKey(d => d.CodeGar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Prevoir2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
