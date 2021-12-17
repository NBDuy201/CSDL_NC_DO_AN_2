use QLCuaHang
go

---- NHÀ CUNG CẤP
CREATE or ALTER  
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

--EXEC NhaCCap_LapPhieugiao 5, 2, 2, '2021-7-4', 1, 92.000

