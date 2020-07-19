using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OMDSP.UserService.Models
{
    public partial class OMDSPDBContext : DbContext
    {
        public OMDSPDBContext()
        {
        }

        public OMDSPDBContext(DbContextOptions<OMDSPDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MedicineList> MedicineList { get; set; }
        public virtual DbSet<NgoList> NgoList { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-HQTQ739\\SQLEXPRESS;Initial Catalog=OMDSPDB;User ID=sa;Password=Reachm@27");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicineList>(entity =>
            {
                entity.HasKey(e => e.MId)
                    .HasName("PK__medicine__DF513ED4F0C70599");

                entity.ToTable("medicineList");

                entity.Property(e => e.MId)
                    .HasColumnName("mId")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DonorAddress)
                    .HasColumnName("donorAddress")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DonorCity)
                    .HasColumnName("donorCity")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DonorMobile)
                    .IsRequired()
                    .HasColumnName("donorMobile")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DonorName)
                    .HasColumnName("donorName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ExpDate)
                    .HasColumnName("expDate")
                    .HasColumnType("date");

                entity.Property(e => e.MName)
                    .IsRequired()
                    .HasColumnName("mName")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NgoList>(entity =>
            {
                entity.HasKey(e => e.NgoId)
                    .HasName("PK__ngoList__236D3EAB77D84CFD");

                entity.ToTable("ngoList");

                entity.HasIndex(e => e.NgoName)
                    .HasName("UQ__ngoList__BB630DAFEF651440")
                    .IsUnique();

                entity.Property(e => e.NgoId)
                    .HasColumnName("ngoId")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NgoAddress)
                    .IsRequired()
                    .HasColumnName("ngoAddress")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.NgoCity)
                    .IsRequired()
                    .HasColumnName("ngoCity")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgoDesc)
                    .IsRequired()
                    .HasColumnName("ngoDesc")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NgoGmail)
                    .IsRequired()
                    .HasColumnName("ngoGmail")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NgoMobile)
                    .IsRequired()
                    .HasColumnName("ngoMobile")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgoName)
                    .IsRequired()
                    .HasColumnName("ngoName")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__registra__CB9A1CFF4AABAF43");

                entity.ToTable("registration");

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__registra__66DCF95C0521FFC1")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPwd)
                    .HasColumnName("userPwd")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
