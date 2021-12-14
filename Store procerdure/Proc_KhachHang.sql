use QLCuaHang
go

---- KHÁCH HÀNG
-- xem full san pham
CREATE 
--ALTER 
PROC KhachHang_XemTatCa_Sanpham
AS
BEGIN TRAN
	select * FROM SanPham
COMMIT
GO

EXEC KhachHang_XemTatCa_Sanpham
GO

-- xem CHI TIẾT sản phẩm
CREATE 
--ALTER 
PROC KhachHang_Xem_CT_Sanpham
	@TenSP nvarchar(50)
AS
BEGIN TRAN
	select * FROM SanPham
	where TenSP = @TenSP
COMMIT
GO

EXEC KhachHang_Xem_CT_Sanpham N'Red and pink'
GO

-- xem tất cả đơn hàng
CREATE 
--ALTER 
PROC KhachHang_XemTatCa_DonHang
	@MaKH int
AS
BEGIN TRAN
	select * FROM DonHang
	where @MaKH = MaKH
COMMIT
GO

EXEC KhachHang_XemTatCa_DonHang 1
GO

-- xem CHI TIẾT đơn hàng
CREATE 
--ALTER 
PROC KhachHang_Xem_CT_DonHang
	@MaDH INT
AS
BEGIN TRAN
	select * FROM CT_DonHang
	where MaDH = @MaDH
COMMIT
GO

EXEC KhachHang_Xem_CT_DonHang 1
GO

-- tạo dữ liệu cho khuyến mãi, khách hàng và nhân viên
select * from KhuyenMai
select * from KhacHang
select * from NhanVien
go
insert into KhacHang (TenKH, DiaChi, Sdt) values (N'Thủ Khoa Nha', '202 Thái Phú', 0911222999)
go
insert into NhanVien (MaNV, TenNV, ChucVu, Luong) values ('NV01', N'Minh Trung', N'Tài xế', 9000)  
go
insert into KhuyenMai (NgayBD, NgayKT, MucKM) values ('2021-7-1', '2021-7-10', 0.30)
go


-- bỏ sản phẩm vào giỏ hàng
select * FROM DonHang
select * FROM CT_DonHang
go
CREATE 
--ALTER 
PROC KhachHang_SanPham_GioHang
	@MaKH INT
AS
BEGIN TRAN
	insert into DonHang (NgayLapDon, MaKH, TinhTrang, MaKM, MaNV, Freeship)
	values (NULL, @MaKH, N'Chưa đồng ý', NULL, NULL, NULL)
COMMIT
GO

EXEC KhachHang_SanPham_GioHang 2
GO

-- xác nhận và thanh toán đơn hàng
CREATE 
--ALTER 
PROC KhachHang_XacNhan_DonHang
	@MaDH int,
	@NgayLapDon date,
    @MaKM int,
	@MaSP int,
	@SoLuong int,
	@DonGia numeric(9, 2)
AS
BEGIN TRAN
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

	update DonHang set NgayLapDon = @NgayLapDon, TinhTrang = N'Đồng ý', MaKM = @MaKM  where MaDH = @MaDH
	insert into CT_DonHang (MaSP, MaDH, SoLuong, DonGia) values (@MaSP, @MaDH, @SoLuong, @DonGia)
	update SanPham set SoLuongTon = SoLuongTon - @SoLuong where MaSP = @MaSP

COMMIT
GO

EXEC KhachHang_XacNhan_DonHang 2, '2021-7-5', 1, 2, 2, 40.0

GO
select * from DonHang
select * from CT_DonHang
select * from SanPham
