using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lab07DatabaseFirst.Models
{
    public partial class QLSinhVienContext : DbContext
    {
        public QLSinhVienContext()
        {
        }

        public QLSinhVienContext(DbContextOptions<QLSinhVienContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dmkhoa> Dmkhoas { get; set; } = null!;
        public virtual DbSet<DmmonHoc> DmmonHocs { get; set; } = null!;
        public virtual DbSet<DssinhVien> DssinhViens { get; set; } = null!;
        public virtual DbSet<KetQua> KetQuas { get; set; } = null!;
        public virtual DbSet<View1> View1s { get; set; } = null!;
        public virtual DbSet<View2> View2s { get; set; } = null!;
        public virtual DbSet<View3> View3s { get; set; } = null!;
        public virtual DbSet<View4> View4s { get; set; } = null!;
        public virtual DbSet<View5> View5s { get; set; } = null!;
        public virtual DbSet<View6> View6s { get; set; } = null!;
        public virtual DbSet<View7> View7s { get; set; } = null!;
        public virtual DbSet<View8> View8s { get; set; } = null!;
        public virtual DbSet<View9> View9s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=TRIPLEK\\SQLEXPRESS;Initial Catalog=QLSinhVien;Integrated Security=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dmkhoa>(entity =>
            {
                entity.HasKey(e => e.MaKhoa)
                    .HasName("PK__DMKhoa__65390405D8EF94AD");

                entity.ToTable("DMKhoa");

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenKhoa).HasMaxLength(30);
            });

            modelBuilder.Entity<DmmonHoc>(entity =>
            {
                entity.HasKey(e => e.MaMh)
                    .HasName("DMMH_MaMH_pk");

                entity.ToTable("DMMonHoc");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("MaMH")
                    .IsFixedLength();

                entity.Property(e => e.GhiChu)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.TenMh)
                    .HasMaxLength(25)
                    .HasColumnName("TenMH");
            });

            modelBuilder.Entity<DssinhVien>(entity =>
            {
                entity.HasKey(e => e.MaSv)
                    .HasName("PK__DSSinhVi__2725081AFA1DE9C4");

                entity.ToTable("DSSinhVien");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("MaSV")
                    .IsFixedLength();

                entity.Property(e => e.HoSv)
                    .HasMaxLength(15)
                    .HasColumnName("HoSV");

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.NoiSinh).HasMaxLength(20);

                entity.Property(e => e.Phai)
                    .HasMaxLength(7)
                    .IsFixedLength();

                entity.Property(e => e.TenSv)
                    .HasMaxLength(7)
                    .HasColumnName("TenSV");

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.DssinhViens)
                    .HasForeignKey(d => d.MaKhoa)
                    .HasConstraintName("DMKhoa_MaKhoa_fk");
            });

            modelBuilder.Entity<KetQua>(entity =>
            {
                entity.HasKey(e => new { e.MaSv, e.MaMh, e.LanThi })
                    .HasName("KetQua_MaSV_MaMH_LanThi_pk");

                entity.ToTable("KetQua");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("MaSV")
                    .IsFixedLength();

                entity.Property(e => e.MaMh)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("MaMH")
                    .IsFixedLength();

                entity.Property(e => e.Diem).HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.KetQuas)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DMMH_MaMH_fk");

                entity.HasOne(d => d.MaSvNavigation)
                    .WithMany(p => p.KetQuas)
                    .HasForeignKey(d => d.MaSv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KetQua_MaSV_fk");
            });

            modelBuilder.Entity<View1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View1");

                entity.Property(e => e.HoSv)
                    .HasMaxLength(15)
                    .HasColumnName("HoSV");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("MaSV")
                    .IsFixedLength();

                entity.Property(e => e.TenSv)
                    .HasMaxLength(7)
                    .HasColumnName("TenSV");
            });

            modelBuilder.Entity<View2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View2");

                entity.Property(e => e.HoSv)
                    .HasMaxLength(15)
                    .HasColumnName("HoSV");

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NoiSinh).HasMaxLength(20);

                entity.Property(e => e.TenSv)
                    .HasMaxLength(7)
                    .HasColumnName("TenSV");
            });

            modelBuilder.Entity<View3>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View3");

                entity.Property(e => e.HoSv)
                    .HasMaxLength(15)
                    .HasColumnName("HoSV");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Phai)
                    .HasMaxLength(7)
                    .IsFixedLength();

                entity.Property(e => e.TenKhoa).HasMaxLength(30);

                entity.Property(e => e.TenSv)
                    .HasMaxLength(7)
                    .HasColumnName("TenSV");
            });

            modelBuilder.Entity<View4>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View4");

                entity.Property(e => e.HoSv)
                    .HasMaxLength(15)
                    .HasColumnName("HoSV");

                entity.Property(e => e.TenKhoa).HasMaxLength(30);

                entity.Property(e => e.TenSv)
                    .HasMaxLength(7)
                    .HasColumnName("TenSV");
            });

            modelBuilder.Entity<View5>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View5");

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaSv)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("MaSV")
                    .IsFixedLength();

                entity.Property(e => e.MucHocBong).HasMaxLength(14);

                entity.Property(e => e.Phai)
                    .HasMaxLength(7)
                    .IsFixedLength();
            });

            modelBuilder.Entity<View6>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View6");

                entity.Property(e => e.HoSv)
                    .HasMaxLength(15)
                    .HasColumnName("HoSV");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("MaSV")
                    .IsFixedLength();

                entity.Property(e => e.TenSv)
                    .HasMaxLength(7)
                    .HasColumnName("TenSV");
            });

            modelBuilder.Entity<View7>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View7");

                entity.Property(e => e.Diem).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.HoSv)
                    .HasMaxLength(15)
                    .HasColumnName("HoSV");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("MaMH")
                    .IsFixedLength();

                entity.Property(e => e.MaSv)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("MaSV")
                    .IsFixedLength();

                entity.Property(e => e.TenSv)
                    .HasMaxLength(7)
                    .HasColumnName("TenSV");
            });

            modelBuilder.Entity<View8>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View8");

                entity.Property(e => e.HoSv)
                    .HasMaxLength(15)
                    .HasColumnName("HoSV");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("MaSV")
                    .IsFixedLength();

                entity.Property(e => e.TenSv)
                    .HasMaxLength(7)
                    .HasColumnName("TenSV");
            });

            modelBuilder.Entity<View9>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View9");

                entity.Property(e => e.HoSv)
                    .HasMaxLength(15)
                    .HasColumnName("HoSV");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("MaSV")
                    .IsFixedLength();

                entity.Property(e => e.TenSv)
                    .HasMaxLength(7)
                    .HasColumnName("TenSV");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
