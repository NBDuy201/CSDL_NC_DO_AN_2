USE [master]
GO

IF DB_ID('QLCuaHang') IS NOT NULL
BEGIN
	alter DATABASE [QLCuaHang] set single_user with rollback IMMEDIATE
END
GO

DROP DATABASE IF EXISTS QLCuaHang
GO

create database QLCuaHang
GO

use QLCuaHang
go

CREATE TABLE [khacHang] (
  [MaKH] int identity(1, 1),
  [TenKH] nvarchar(50),
  [DiaChi] nvarchar(100),
  [Sdt] varchar(10),
  PRIMARY KEY ([MaKH])
);
go

CREATE TABLE [NhaCungCap] (
  [MaNCCap] varchar(8),
  [Ten] nvarchar(50),
  [DiaChi] nvarchar(100),
  [Sdt] varchar(10),
  PRIMARY KEY ([MaNCCap])
);
go

CREATE TABLE [NhanVien] (
  [MaNV] varchar(8),
  [TenNV] nvarchar(50),
  [ChucVu] nvarchar(50),
  [Luong] numeric(8, 2),
  PRIMARY KEY ([MaNV])
);
go

CREATE TABLE [KhuyenMai] (
  [MaKM] int identity(1,1),
  [NgayBD] date,
  [NgayKT] date,
  [MucKM] float,
  [Freeship] nvarchar(50),
  PRIMARY KEY ([MaKM])
);
go

CREATE TABLE [DonHang] (
  [MaDH] int identity(1,1),
  [NgayLapDon] date,
  [MaKH] int,
  [TinhTrang] nvarchar(50),
  [MaKM] int,
  [MaNV] varchar(8),
  TongTien numeric(8, 2),
  SoTienGiam numeric(8, 2),
  GiaCuoiCung numeric(8, 2),
  PRIMARY KEY ([MaDH]),
  CONSTRAINT [FK_DonHang.MaKH]
    FOREIGN KEY ([MaKH])
      REFERENCES [khacHang]([MaKH])
	  on update CASCADE
	  ON DELETE CASCADE,
  CONSTRAINT [FK_DonHang.MaNV]
    FOREIGN KEY ([MaNV])
      REFERENCES [NhanVien]([MaNV])
	  on update CASCADE
	  ON DELETE CASCADE,
  CONSTRAINT [FK_DonHang.MaKM]
    FOREIGN KEY ([MaKM])
      REFERENCES [KhuyenMai]([MaKM])
	  on update CASCADE
	  ON DELETE CASCADE
);
go

CREATE TABLE [LoaiSanPham] (
  [MaLoai] varchar(8),
  [TenLoai] nvarchar(50),
  PRIMARY KEY ([MaLoai])
);
go

CREATE TABLE [PhieuDatHang] (
  [MaPhieuDat] int identity(1,1),
  [NgayDat] date,
  [MaNCCap] varchar(8),
  PRIMARY KEY ([MaPhieuDat]),
  CONSTRAINT [FK_PhieuDatHang.MaNCCap]
    FOREIGN KEY ([MaNCCap])
      REFERENCES [NhaCungCap]([MaNCCap])
	  on update CASCADE
	  ON DELETE CASCADE
);
go

CREATE TABLE [PhieuGiaoHang] (
  [MaPhieuGiao] int identity(1,1),
  [NgayGiao] date,
  [MaPhieuDat] int,
  PRIMARY KEY ([MaPhieuGiao]),
  CONSTRAINT [FK_PhieuGiaoHang.MaPhieuDat]
    FOREIGN KEY ([MaPhieuDat])
      REFERENCES [PhieuDatHang]([MaPhieuDat])
	  on update CASCADE
	  ON DELETE CASCADE
);
go

CREATE TABLE [SanPham] (
  [MaSP] varchar(8),
  [TenSP] nvarchar(50),
  [MaLoai] varchar(8),
  [DonGia] numeric(8, 2),
  [SoLuongTon] int,
  [MaNCCap] varchar(8),
  PRIMARY KEY ([MaSP]),
  CONSTRAINT [FK_SanPham.MaNCCap]
    FOREIGN KEY ([MaNCCap])
      REFERENCES [NhaCungCap]([MaNCCap])
	  on update CASCADE
	  ON DELETE CASCADE,
  CONSTRAINT [FK_SanPham.MaLoai]
    FOREIGN KEY ([MaLoai])
      REFERENCES [LoaiSanPham]([MaLoai])
	  on update CASCADE
	  ON DELETE CASCADE
);
go

CREATE TABLE [CT_PhieuGiao_SP] (
  [MaPhieuGiao] int,
  [MaSP] varchar(8),
  [SoLuong] int,
  [DonGia] numeric(8, 2),
  PRIMARY KEY ([MaPhieuGiao], [MaSP]),
  CONSTRAINT [FK_CT_PhieuGiao_SP.MaPhieuGiao]
    FOREIGN KEY ([MaPhieuGiao])
      REFERENCES [PhieuGiaoHang]([MaPhieuGiao])
	  on update CASCADE
	  ON DELETE CASCADE,
  CONSTRAINT [FK_CT_PhieuGiao_SP.MaSP]
    FOREIGN KEY ([MaSP])
      REFERENCES [SanPham]([MaSP])
);
go

CREATE TABLE [CT_PhieuDat_SP] (
  [MaPhieuDat] int,
  [MaSP] varchar(8),
  [SoLuong] int,
  PRIMARY KEY ([MaPhieuDat], [MaSP]),
  CONSTRAINT [FK_CT_PhieuDat_SP.MaSP]
    FOREIGN KEY ([MaSP])
      REFERENCES [SanPham]([MaSP])
	  on update CASCADE
	  ON DELETE CASCADE,
  CONSTRAINT [FK_CT_PhieuDat_SP.MaPhieuDat]
    FOREIGN KEY ([MaPhieuDat])
      REFERENCES [PhieuDatHang]([MaPhieuDat])
);
go

CREATE TABLE [CT_DonHang] (
  [MaSP] varchar(8),
  [MaDH] int,
  [SoLuong] int,
  [DonGia] numeric(8, 2),
  [ThanhTien] numeric(8, 2),
  PRIMARY KEY ([MaSP], [MaDH]),
  CONSTRAINT [FK_CT_DonHang.MaDH]
    FOREIGN KEY ([MaDH])
      REFERENCES [DonHang]([MaDH])
	  on update CASCADE
	  ON DELETE CASCADE,
  CONSTRAINT [FK_CT_DonHang.MaSP]
    FOREIGN KEY ([MaSP])
      REFERENCES [SanPham]([MaSP])
	  on update CASCADE
	  ON DELETE CASCADE
);
go