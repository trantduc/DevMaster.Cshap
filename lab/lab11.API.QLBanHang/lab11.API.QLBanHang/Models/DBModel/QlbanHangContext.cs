using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace lab11.API.QLBanHang.Models.DBModel;

public partial class QlbanHangContext : DbContext
{
    public QlbanHangContext()
    {
    }

    public QlbanHangContext(DbContextOptions<QlbanHangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ctdondh> Ctdondhs { get; set; }

    public virtual DbSet<Ctpnhap> Ctpnhaps { get; set; }

    public virtual DbSet<Ctpxuat> Ctpxuats { get; set; }

    public virtual DbSet<Dondh> Dondhs { get; set; }

    public virtual DbSet<Nhacc> Nhaccs { get; set; }

    public virtual DbSet<Pnhap> Pnhaps { get; set; }

    public virtual DbSet<Pxuat> Pxuats { get; set; }

    public virtual DbSet<Tonkho> Tonkhos { get; set; }

    public virtual DbSet<Vattu> Vattus { get; set; }

    public virtual DbSet<VwGetAll> VwGetAlls { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.;Database=QLBanHang;Trusted_Connection=True;MultipleActiveResultSets=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ctdondh>(entity =>
        {
            entity.HasKey(e => new { e.SoDh, e.Mavtu }).HasName("PK__CTDONDH__AEA1FE798FEE2654");

            entity.ToTable("CTDONDH");

            entity.Property(e => e.SoDh)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SoDH");
            entity.Property(e => e.Mavtu)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MavtuNavigation).WithMany(p => p.Ctdondhs)
                .HasForeignKey(d => d.Mavtu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Frk_CTDONDH_Mavtu");

            entity.HasOne(d => d.SoDhNavigation).WithMany(p => p.Ctdondhs)
                .HasForeignKey(d => d.SoDh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Frk_CTDONDH_sodh");
        });

        modelBuilder.Entity<Ctpnhap>(entity =>
        {
            entity.HasKey(e => new { e.SoPn, e.Mavtu }).HasName("PK__CTPNHAP__AEA090F637B29D8E");

            entity.ToTable("CTPNHAP", tb => tb.HasTrigger("tg_tonkho_insert"));

            entity.Property(e => e.SoPn)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Mavtu)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Dgnhap)
                .HasColumnType("money")
                .HasColumnName("DGNhap");
            entity.Property(e => e.Slnhap).HasColumnName("SLNhap");

            entity.HasOne(d => d.MavtuNavigation).WithMany(p => p.Ctpnhaps)
                .HasForeignKey(d => d.Mavtu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Frk_CTPNHAP_Mavtu");

            entity.HasOne(d => d.SoPnNavigation).WithMany(p => p.Ctpnhaps)
                .HasForeignKey(d => d.SoPn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Frk_CTPNHAP_sopn");
        });

        modelBuilder.Entity<Ctpxuat>(entity =>
        {
            entity.HasKey(e => new { e.SoPx, e.Mavtu }).HasName("PK__CTPXUAT__AEA09300F704E0C2");

            entity.ToTable("CTPXUAT");

            entity.Property(e => e.SoPx)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Mavtu)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Dgxuat)
                .HasColumnType("money")
                .HasColumnName("DGXuat");
            entity.Property(e => e.Slxuat).HasColumnName("SLXuat");

            entity.HasOne(d => d.MavtuNavigation).WithMany(p => p.Ctpxuats)
                .HasForeignKey(d => d.Mavtu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Frk_CTPPXUAT_Mavtu");

            entity.HasOne(d => d.SoPxNavigation).WithMany(p => p.Ctpxuats)
                .HasForeignKey(d => d.SoPx)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Frk_CTPPXUAT_sopx");
        });

        modelBuilder.Entity<Dondh>(entity =>
        {
            entity.HasKey(e => e.SoDh).HasName("PK__DONDH__BC3D04DC14DFEC7C");

            entity.ToTable("DONDH");

            entity.Property(e => e.SoDh)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SoDH");
            entity.Property(e => e.MaNcc)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNCC");
            entity.Property(e => e.NgayDh)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("NgayDH");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.Dondhs)
                .HasForeignKey(d => d.MaNcc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Frk_DONDH_Mancc");
        });

        modelBuilder.Entity<Nhacc>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("PK__NHACC__3A185DEB36702812");

            entity.ToTable("NHACC");

            entity.HasIndex(e => new { e.TenNcc, e.Diachi }, "UNQ_NHACC_TenNcc").IsUnique();

            entity.Property(e => e.MaNcc)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNCC");
            entity.Property(e => e.Diachi).HasMaxLength(200);
            entity.Property(e => e.Dienthoai)
                .HasMaxLength(20)
                .HasDefaultValue("Chưa có");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(100)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<Pnhap>(entity =>
        {
            entity.HasKey(e => e.SoPn).HasName("PK__PNHAP__BC3C6A53998D1AC6");

            entity.ToTable("PNHAP", tb => tb.HasTrigger("tg_PNHAP_Them"));

            entity.Property(e => e.SoPn)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayNhap).HasColumnType("datetime");
            entity.Property(e => e.SoDh)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SoDH");
        });

        modelBuilder.Entity<Pxuat>(entity =>
        {
            entity.HasKey(e => e.SoPx).HasName("PK__PXUAT__BC3C69A5529016B3");

            entity.ToTable("PXUAT");

            entity.Property(e => e.SoPx)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayXuat).HasColumnType("datetime");
            entity.Property(e => e.TenKh)
                .HasMaxLength(100)
                .HasColumnName("TenKH");
        });

        modelBuilder.Entity<Tonkho>(entity =>
        {
            entity.HasKey(e => new { e.NamThang, e.Mavtu }).HasName("PK__TONKHO__F5281E489AF3345D");

            entity.ToTable("TONKHO");

            entity.Property(e => e.NamThang)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Mavtu)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Slcuoi)
                .HasComputedColumnSql("(([SLDau]+[TongSLN])-[TongSLX])", false)
                .HasColumnName("SLCuoi");
            entity.Property(e => e.Sldau)
                .HasDefaultValue(0)
                .HasColumnName("SLDau");
            entity.Property(e => e.TongSln)
                .HasDefaultValue(0)
                .HasColumnName("TongSLN");
            entity.Property(e => e.TongSlx)
                .HasDefaultValue(0)
                .HasColumnName("TongSLX");

            entity.HasOne(d => d.MavtuNavigation).WithMany(p => p.Tonkhos)
                .HasForeignKey(d => d.Mavtu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Frk_TONKHO_Mavtu");
        });

        modelBuilder.Entity<Vattu>(entity =>
        {
            entity.HasKey(e => e.Mavtu).HasName("PK__VATTU__29CFAA50F2C70606");

            entity.ToTable("VATTU");

            entity.HasIndex(e => e.TenVtu, "UNQ_VATTU_Tenvt").IsUnique();

            entity.Property(e => e.Mavtu)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Dvtinh)
                .HasMaxLength(10)
                .HasDefaultValue("");
            entity.Property(e => e.TenVtu)
                .HasMaxLength(100)
                .HasColumnName("TenVTu");
        });

        modelBuilder.Entity<VwGetAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_GetAll");

            entity.Property(e => e.Dgnhap)
                .HasColumnType("money")
                .HasColumnName("DGNhap");
            entity.Property(e => e.NgayNhap).HasColumnType("datetime");
            entity.Property(e => e.Slnhap).HasColumnName("SLNhap");
            entity.Property(e => e.SoPn)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenVtu)
                .HasMaxLength(100)
                .HasColumnName("TenVTu");
            entity.Property(e => e.ThanhTien).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
