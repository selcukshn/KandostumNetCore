using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace data
{
    public partial class KanBagisDbContext : DbContext
    {
        public KanBagisDbContext()
        {
        }

        public KanBagisDbContext(DbContextOptions<KanBagisDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hastaneler> Hastanelers { get; set; }
        public virtual DbSet<Ilanlar> Ilanlars { get; set; }
        public virtual DbSet<Ilceler> Ilcelers { get; set; }
        public virtual DbSet<KanGruplari> KanGruplaris { get; set; }
        public virtual DbSet<Sehirler> Sehirlers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SELCUK;Initial Catalog=KanBagisDb;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Hastaneler>(entity =>
            {
                entity.HasKey(e => e.HastaneId);

                entity.ToTable("Hastaneler");

                entity.Property(e => e.Ad).HasMaxLength(100);

                entity.Property(e => e.Adres).HasMaxLength(500);

                entity.Property(e => e.Boylam)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Enlem)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ilce).HasMaxLength(40);

                entity.Property(e => e.Sehir).HasMaxLength(40);

                entity.Property(e => e.UlasimEposta).HasMaxLength(50);

                entity.Property(e => e.UlasimNumarasi).HasMaxLength(20);
            });

            modelBuilder.Entity<Ilanlar>(entity =>
            {
                entity.HasKey(e => e.IlanId)
                    .HasName("PK_ilan");

                entity.ToTable("Ilanlar");

                entity.Property(e => e.GerekliUnite).HasMaxLength(2);

                entity.Property(e => e.HastaTamAd).HasMaxLength(40);

                entity.Property(e => e.HastaYas).HasMaxLength(3);

                entity.Property(e => e.IlanOzeti).HasMaxLength(1000);

                entity.Property(e => e.IlanTarihi)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IletisimNumarasi1).HasMaxLength(20);

                entity.Property(e => e.IletisimNumarasi2).HasMaxLength(20);

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.Hastane)
                    .WithMany(p => p.Ilanlars)
                    .HasForeignKey(d => d.HastaneId)
                    .HasConstraintName("FK_Ilanlar_Hastaneler");

                entity.HasOne(d => d.KanGrubu)
                    .WithMany(p => p.Ilanlars)
                    .HasForeignKey(d => d.KanGrubuId)
                    .HasConstraintName("FK_Ilanlar_KanGruplari");
            });

            modelBuilder.Entity<Ilceler>(entity =>
            {
                entity.HasKey(e => e.IlceId);

                entity.ToTable("Ilceler");

                entity.Property(e => e.IlceAd).HasMaxLength(50);

                entity.HasOne(d => d.Sehir)
                    .WithMany(p => p.Ilcelers)
                    .HasForeignKey(d => d.SehirId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ilceler_Sehirler");
            });

            modelBuilder.Entity<KanGruplari>(entity =>
            {
                entity.HasKey(e => e.KanGrubuId)
                    .HasName("PK_kangrubu");

                entity.ToTable("KanGruplari");

                entity.Property(e => e.KanGrubu)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sehirler>(entity =>
            {
                entity.HasKey(e => e.SehirId);

                entity.ToTable("Sehirler");

                entity.Property(e => e.SehirAd).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
