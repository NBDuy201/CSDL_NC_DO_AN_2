use QLCuaHang
go

---- KHÁCH HÀNG
-- xem full san pham
CREATE or ALTER 
PROC KhachHang_XemTatCa_Sanpham
	@offset int,
	@rows int
AS
BEGIN TRAN
	select * FROM SanPham
	order by MaSP 
	offset @offset rows fetch next @rows rows only
COMMIT
GO

--EXEC KhachHang_XemTatCa_Sanpham
GO

-- xem CHI TIẾT sản phẩm
CREATE or ALTER 
PROC KhachHang_Xem_CT_Sanpham
	@TenSP nvarchar(50)
AS
BEGIN TRAN
	select * FROM SanPham
	where TenSP = @TenSP
COMMIT
GO

--EXEC KhachHang_Xem_CT_Sanpham N'Red and pink'
GO

-- xem tất cả đơn hàng
CREATE or ALTER 
PROC KhachHang_XemTatCa_DonHang
	@MaKH int
AS
BEGIN TRAN
	select * FROM DonHang
	where @MaKH = MaKH
	order by MaDH
COMMIT
GO

--EXEC KhachHang_XemTatCa_DonHang 1502
GO

-- xem CHI TIẾT đơn hàng
CREATE or ALTER 
PROC KhachHang_Xem_CT_DonHang
	@MaDH INT
AS
BEGIN TRAN
	select * FROM CT_DonHang
	where MaDH = @MaDH
COMMIT
GO

--EXEC KhachHang_Xem_CT_DonHang 1
GO

-- tạo giỏ hàng mới
CREATE or ALTER 
PROC KhachHang_Them_GioHang
	@MaKH INT,
	@MaKM INT
AS
BEGIN TRAN
	insert into DonHang (NgayLapDon, MaKH, TinhTrang, MaKM, MaNV, Freeship)
	values (NULL, @MaKH, N'Chưa đồng ý', @MaKM, NULL, NULL)
COMMIT
GO


--EXEC KhachHang_Them_GioHang 3,5
GO

-- Thêm vào giỏ hàng
CREATE or ALTER 
PROC KhachHang_ThemSanPham_GioHang
	@MaSP INT,
	@MaDH int,
	@SoLuong int
AS
BEGIN TRAN
	IF (@MaSP IS NULL OR NOT EXISTS (SELECT * FROM SanPham))
	BEGIN
		RAISERROR(N'Không tồn sản phẩm', -1, -1)
		ROLLBACK TRAN
		RETURN
	END
	
	declare @dongia int
	set @dongia = (select DonGia from SanPham where MaSP = @MaSP)

	insert into CT_DonHang (MaSP, MaDH, SoLuong, DonGia) values (@MaSP, @MaDH, @SoLuong, @DonGia)

COMMIT
GO

--Exec KhachHang_ThemSanPham_GioHang 2, 5, 4
go

-- xác nhận và thanh toán đơn hàng
CREATE or ALTER 
PROC KhachHang_XacNhan_DonHang
	@MaDH int,
	@NgayLapDon date,
AS
BEGIN TRAN
	update DonHang set NgayLapDon = @NgayLapDon, TinhTrang = N'Đồng ý' where MaDH = @MaDH

	UPDATE SanPham
	SET SoLuongTon = SoLuongTon - CT_DH.SoLuong
	FROM SanPham SP
	INNER JOIN CT_DonHang CT_DH
	ON SP.MaSP = CT_DH.MaSP
	AND CT_DH.MaDH = @MaDH

	declare @SoLuong2 int
	set @SoLuong2 = (select top 1 SoLuongTon from SanPham where SoLuongTon < 0)
	if @SoLuong2 <= 0
	BEGIN
		RAISERROR(N'Đã hết hàng', -1, -1)
		ROLLBACK TRAN
		RETURN
	END
COMMIT
GO

--EXEC KhachHang_XacNhan_DonHang 5, '2021-7-10', 1
