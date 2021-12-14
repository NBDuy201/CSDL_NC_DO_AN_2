use QLCuaHang
go

---- NHÀ CUNG CẤP

Insert into NhaCungCap (MaNCCap, Ten, DiaChi, Sdt) values ('NCC02', N'Lương Bá Quân', N'101 Bách Khu', '0903920983')
select * from NhaCungCap 
select * from PhieuDatHang
go

insert into PhieuDatHang (NgayDat, MaNCCap) values ( '2021-7-1', 'NCC02')
go

select * from PhieuGiaoHang
go

insert into PhieuGiaoHang (Ngaygiao, MaPhieuDat) values ( '2021-7-12', 1)
go

select * from LoaiSanPham
go
insert into LoaiSanPham (MaLoai, TenLoai) values ('L01', N'Hoa gia đình')
go

select * from SanPham
go
insert into SanPham (TenSP, MaLoai, DonGia, SoLuongTon, MaNCCAP) values ( N'Red and pink', 'L01', 90.000, 10, 'NCC02')
go

select * from CT_PhieuGiao_SP
go

insert into CT_PhieuGiao_SP (MaPhieuGiao, MaSP, SoLuong, DonGia) values (1, 'SP01', 2, 600.000)
go

CREATE 
--ALTER 
PROC NhaCCap_LapPhieugiao
	@MaphieuGiao int,
	@MaPhieuDat int,
	@MaSP int, 
	@NgayGiao date,
	@SoLuong int,
	@Dongia numeric(9, 2)
AS
BEGIN TRAN
	IF (@MaPhieuDat IS NULL OR NOT EXISTS (SELECT * FROM PhieuDatHang))
	BEGIN
		RAISERROR(N'Không tồn tại phiếu đặt', -1, -1)
		ROLLBACK TRAN
		RETURN
	END

	IF (@MaSP IS NULL OR NOT EXISTS (SELECT * FROM SanPham))
	BEGIN
		RAISERROR(N'Không tồn sản phẩm', -1, -1)
		ROLLBACK TRAN
		RETURN
	END

	IF (@SoLuong < 0)
	BEGIN
		RAISERROR(N'Số lượng không được âm', -1, -1)
		ROLLBACK TRAN
		RETURN
	END

	IF (@DonGia < 0)
	BEGIN
		RAISERROR(N'Đơn giá không được âm', -1, -1)
		ROLLBACK TRAN
		RETURN
	END

	insert into PhieuGiaoHang (Ngaygiao, MaPhieuDat) values (@NgayGiao, @MaPhieuDat)

	insert into CT_PhieuGiao_SP (MaPhieuGiao, MaSP, SoLuong, DonGia) values (@MaPhieuGiao, @MaSP, @SoLuong, @DonGia)

COMMIT TRAN
GO

EXEC NhaCCap_LapPhieugiao 5, 2, 2, '2021-7-4', 1, 92.000

go
select * from PhieuGiaoHang
select * from CT_PhieuGiao_SP
