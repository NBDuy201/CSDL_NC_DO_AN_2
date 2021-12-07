use TEST_QLCuaHang
go

-- NHÀ CUNG CẤP
-- LAP PHIEUGIAO

insert into NhaCungCap values ('NCC02', N'Nguyễn Bá Quang', '11 Đồng Khởi', '0903992983')
select * from NhaCungCap 
select * from PhieuDatHang
go

insert into PhieuDatHang values ( '2021-6-12', 'NCC02')
go

select * from PhieuGiaoHang
go

insert into PhieuGiaoHang values ( '2021-7-12', 1)
go

select * from LoaiSanPham
go
insert into LoaiSanPham values ('L02', N'Hoa gia đình')
go

select * from SanPham
go
insert into SanPham values ('SP02', N'Ngọn nến', 'L02', 120.000, 2, 'NCC02')
go

select * from CT_PhieuGiao_SP
go

insert into CT_PhieuGiao_SP values (1, 'SP01', 2, 600.000)
go

CREATE 
--ALTER 
PROC NhaCCap_LapPhieugiao
	@MaphieuGiao int,
	@MaPhieuDat int,
	@MaSP varchar(8), 
	@NgayGiao date,
	@SoLuong int,
	@Dongia numeric(8, 2)
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

	insert into PhieuGiaoHang values (@NgayGiao, @MaPhieuDat)

	insert into CT_PhieuGiao_SP values (@MaPhieuGiao, @MaSP, @SoLuong, @DonGia)

COMMIT TRAN
GO

﻿EXEC NhaCCap_LapPhieugiao 2, 2, 'SP02', '2021-6-22', 1, 122.000
go

select * from PhieuGiaoHang
select * from CT_PhieuGiao_SP