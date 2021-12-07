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

CREATE TABLE [KhacHang] (
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
  [Luong] numeric(9, 2),
  PRIMARY KEY ([MaNV])
);
go

CREATE TABLE [KhuyenMai] (
  [MaKM] int identity(1,1),
  [NgayBD] date,
  [NgayKT] date,
  [MucKM] float,
  PRIMARY KEY ([MaKM])
);
go

CREATE TABLE [DonHang] (
  [MaDH] int identity(1,1),
  [NgayLapDon] date,
  [MaKH] int,
  [TinhTrang] nvarchar(50),
  [MaKM] int default NULL,
  [MaNV] varchar(8),
  [Freeship] nvarchar(50) DEFAULT N'Không',
  PhiVanChuyen NUMERIC(5, 2) default 30,
  TongTien numeric(9, 2) default 0,
  SoTienGiam numeric(9, 2) default 0,
  GiaCuoiCung AS (TongTien + PhiVanChuyen) - SoTienGiam,
  PRIMARY KEY ([MaDH]),
  CONSTRAINT [FK_DonHang.MaKH]
    FOREIGN KEY ([MaKH])
      REFERENCES [khacHang]([MaKH])
	  on update CASCADE
	  ON DELETE CASCADE,
  CONSTRAINT [FK_DonHang.MaNV]
    FOREIGN KEY ([MaNV])
      REFERENCES [NhanVien]([MaNV])
	  ON DELETE SET DEFAULT,
  CONSTRAINT [FK_DonHang.MaKM]
    FOREIGN KEY ([MaKM])
      REFERENCES [KhuyenMai]([MaKM])
	  ON DELETE SET DEFAULT
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
  [MaSP] int identity(1,1),
  [TenSP] nvarchar(50),
  [MaLoai] varchar(8),
  [DonGia] numeric(9, 2),
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
  [MaSP] int,
  [SoLuong] int,
  [DonGia] numeric(9, 2),
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
  [MaSP] int,
  [SoLuong] int,
  PRIMARY KEY ([MaPhieuDat], [MaSP]),
  CONSTRAINT [FK_CT_PhieuDat_SP.MaSP]
    FOREIGN KEY ([MaSP])
      REFERENCES [SanPham]([MaSP]),
  CONSTRAINT [FK_CT_PhieuDat_SP.MaPhieuDat]
    FOREIGN KEY ([MaPhieuDat])
      REFERENCES [PhieuDatHang]([MaPhieuDat])
	  on update CASCADE
	  ON DELETE CASCADE
);
go

CREATE TABLE [CT_DonHang] (
  [MaSP] int,
  [MaDH] int,
  [SoLuong] int default 1,
  [DonGia] numeric(9, 2) default 0,
  [ThanhTien] as [SoLuong] * [DonGia],
  PRIMARY KEY ([MaSP], [MaDH]),
  CONSTRAINT [FK_CT_DonHang.MaDH]
    FOREIGN KEY ([MaDH])
      REFERENCES [DonHang]([MaDH])
	  on update CASCADE
	  ON DELETE CASCADE,
  CONSTRAINT [FK_CT_DonHang.MaSP]
    FOREIGN KEY ([MaSP])
      REFERENCES [SanPham]([MaSP])
);
go

-- =============
-- Trigger
-- =============
-- Tổng tiền
CREATE OR ALTER trigger trg_TongTien_CT_HD On CT_DonHang
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
	DECLARE @maDHang int

	-- Insert
	IF EXISTS(SELECT * FROM inserted) AND NOT EXISTS(SELECT * FROM DELETED)
	BEGIN
		SET @maDHang = (SELECT MaDH FROM INSERTED)

		UPDATE DonHang
		SET TongTien = 
		(
			SELECT SUM(ThanhTien)
			FROM CT_DonHang
			WHERE MaDH = @maDHang
		)
		WHERE DonHang.MaDH = @maDHang
	END

	-- Delete
	IF EXISTS(SELECT * FROM DELETED) AND NOT EXISTS(SELECT * FROM INSERTED)
	BEGIN
		SET @maDHang = (SELECT MaDH FROM DELETED)

		UPDATE DonHang
		SET TongTien = 
		(
			SELECT SUM(ThanhTien)
			FROM CT_DonHang
			WHERE MaDH = @maDHang
		)
		WHERE DonHang.MaDH = @maDHang
	END

	-- Update
	IF UPDATE(SoLuong) OR UPDATE(DonGia)
	BEGIN
		SET @maDHang = (SELECT MaDH FROM INSERTED)

		UPDATE DonHang
		SET TongTien = 
		(
			SELECT SUM(ThanhTien)
			FROM CT_DonHang
			WHERE MaDH = @maDHang
		)
		WHERE DonHang.MaDH = @maDHang
	END
END
GO

-- Giá giảm
CREATE OR ALTER trigger trg_GiaGiam_DonHang On DonHang
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE 
		@maDHang int,
		@maKMai INT,
		@FreeShipCheck NVARCHAR(50)
	
	-- Insert dòng mới hoặc update trên TongTien
	IF (EXISTS(SELECT * FROM inserted) AND NOT EXISTS(SELECT * FROM DELETED)) OR Update(TongTien) OR Update(MaKM)
	Begin
		-- Lấy thông tin
		SELECT @maDHang = MaDH, @maKMai = MaKM, @FreeShipCheck = Freeship
		FROM INSERTED

		-- Lấy phần trăm tiền giảm
		DECLARE @mucKM FLOAT = (SELECT MucKM
								FROM KhuyenMai
								where MaKM = @maKMai)
		
		-- Cập nhật tiền giảm
		if(@mucKM is NULL)
		Begin
			UPDATE DonHang
			SET SoTienGiam = 0
			WHERE DonHang.MaDH = @maDHang
		End
		Else
		BEGIN
			UPDATE DonHang
			SET SoTienGiam = TongTien * @mucKM
			WHERE DonHang.MaDH = @maDHang
		END
		
		-- Nếu có free ship
		IF(@FreeShipCheck = N'Có')
		BEGIN
			UPDATE DonHang
			SET PhiVanChuyen = 0
			WHERE DonHang.MaDH = @maDHang
		END
	End
END
GO