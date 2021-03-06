// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using FantasyftLibraryy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace FAntasyftt.Models
{
    public partial class fantasyftContext : DbContext
    {
        public fantasyftContext()
        {
        }

        public fantasyftContext(DbContextOptions<fantasyftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coach> Coach { get; set; }
        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Schiedsrichter> Schiedsrichter { get; set; }
        public virtual DbSet<Spieler> Spieler { get; set; }
        public virtual DbSet<Stadion> Stadion { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Uebernehmen> Uebernehmen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=fantasyft;User Id=postgres;Password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("coach_pkey");

                entity.ToTable("coach");

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.Property(e => e.Herkunft)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("herkunft");

                entity.Property(e => e.Nachname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nachname");

                entity.Property(e => e.TId).HasColumnName("t_id");

                entity.Property(e => e.Vorname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("vorname");

                entity.HasOne(d => d.TIdNavigation)
                    .WithMany(p => p.Coach)
                    .HasForeignKey(d => d.TId)
                    .HasConstraintName("coach_t_id_fkey");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasKey(e => e.MId)
                    .HasName("match_pkey");

                entity.ToTable("match");

                entity.Property(e => e.MId).HasColumnName("m_id");

                entity.Property(e => e.Art)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("art");

                entity.Property(e => e.Datum).HasColumnName("datum");

                entity.Property(e => e.SchId).HasColumnName("sch_id");

                entity.Property(e => e.StId).HasColumnName("st_id");

                entity.Property(e => e.Uhrzeit).HasColumnName("uhrzeit");

                entity.HasOne(d => d.Sch)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.SchId)
                    .HasConstraintName("match_sch_id_fkey");

                entity.HasOne(d => d.St)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.StId)
                    .HasConstraintName("match_st_id_fkey");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PosId)
                    .HasName("position_pkey");

                entity.ToTable("position");

                entity.Property(e => e.PosId).HasColumnName("pos_id");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("bezeichnung");
            });

            modelBuilder.Entity<Schiedsrichter>(entity =>
            {
                entity.HasKey(e => e.SchId)
                    .HasName("schiedsrichter_pkey");

                entity.ToTable("schiedsrichter");

                entity.Property(e => e.SchId).HasColumnName("sch_id");

                entity.Property(e => e.Aggressivitaet)
                    .HasColumnName("aggressivitaet")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Herkunft)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("herkunft");

                entity.Property(e => e.Nachname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nachname");

                entity.Property(e => e.Vorname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("vorname");
            });

            modelBuilder.Entity<Spieler>(entity =>
            {
                entity.HasKey(e => e.SId)
                    .HasName("spieler_pkey");

                entity.ToTable("spieler");

                entity.Property(e => e.SId).HasColumnName("s_id");

                entity.Property(e => e.Alter).HasColumnName("alter");

                entity.Property(e => e.Kapitaen).HasColumnName("kapitaen");

                entity.Property(e => e.Nachname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nachname");

                entity.Property(e => e.Preis).HasColumnName("preis");

                entity.Property(e => e.TId).HasColumnName("t_id");

                entity.Property(e => e.Trikotnummer).HasColumnName("trikotnummer");

                entity.Property(e => e.Vorname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("vorname");

                entity.HasOne(d => d.TIdNavigation)
                    .WithMany(p => p.Spieler)
                    .HasForeignKey(d => d.TId)
                    .HasConstraintName("spieler_t_id_fkey");
            });

            modelBuilder.Entity<Stadion>(entity =>
            {
                entity.HasKey(e => e.StId)
                    .HasName("stadion_pkey");

                entity.ToTable("stadion");

                entity.Property(e => e.StId).HasColumnName("st_id");

                entity.Property(e => e.Kapazitaet).HasColumnName("kapazitaet");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.TId).HasColumnName("t_id");

                entity.HasOne(d => d.TIdNavigation)
                    .WithMany(p => p.Stadion)
                    .HasForeignKey(d => d.TId)
                    .HasConstraintName("stadion_t_id_fkey");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TId)
                    .HasName("team_pkey");

                entity.ToTable("team");

                entity.Property(e => e.TId).HasColumnName("t_id");

                entity.Property(e => e.Land)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("land");

                entity.Property(e => e.Liga)
                    .HasMaxLength(50)
                    .HasColumnName("liga");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasMany(d => d.MId)
                    .WithMany(p => p.TId)
                    .UsingEntity<Dictionary<string, object>>(
                        "Spielen",
                        l => l.HasOne<Match>().WithMany().HasForeignKey("MId").HasConstraintName("spielen_m_id_fkey"),
                        r => r.HasOne<Team>().WithMany().HasForeignKey("TId").HasConstraintName("spielen_t_id_fkey"),
                        j =>
                        {
                            j.HasKey("TId", "MId").HasName("spielen_pkey");

                            j.ToTable("spielen");

                            j.IndexerProperty<int>("TId").HasColumnName("t_id");

                            j.IndexerProperty<int>("MId").HasColumnName("m_id");
                        });
            });

            modelBuilder.Entity<Uebernehmen>(entity =>
            {
                entity.HasKey(e => new { e.SId, e.PosId })
                    .HasName("uebernehmen_pkey");

                entity.ToTable("uebernehmen");

                entity.Property(e => e.SId).HasColumnName("s_id");

                entity.Property(e => e.PosId).HasColumnName("pos_id");

                entity.Property(e => e.Abschluss)
                    .HasColumnName("abschluss")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Aggressivitaet)
                    .HasColumnName("aggressivitaet")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Ballsicherheit)
                    .HasColumnName("ballsicherheit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Pass)
                    .HasColumnName("pass")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Reflex)
                    .HasColumnName("reflex")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Technik)
                    .HasColumnName("technik")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tempo)
                    .HasColumnName("tempo")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Verteidigung)
                    .HasColumnName("verteidigung")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Pos)
                    .WithMany(p => p.Uebernehmen)
                    .HasForeignKey(d => d.PosId)
                    .HasConstraintName("uebernehmen_pos_id_fkey");

                entity.HasOne(d => d.SIdNavigation)
                    .WithMany(p => p.Uebernehmen)
                    .HasForeignKey(d => d.SId)
                    .HasConstraintName("uebernehmen_s_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}