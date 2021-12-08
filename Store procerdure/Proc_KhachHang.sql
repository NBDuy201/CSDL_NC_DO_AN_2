use TEST_QLCuaHang
go

-- Khách hàng
-- xem *TẤT CẢ* sản phẩm
CREATE 
--ALTER 
PROC KhachHang_Xem_Sanpham
AS
BEGIN TRAN
	select * FROM SanPham
COMMIT
GO

EXEC KhachHang_Xem_Sanpham
GO

-- xem CHI TIẾT sản phẩm
CREATE 
--ALTER 
PROC KhachHang_Xem_CT_Sanpham
	@MaSP varchar(8),
	@TenSP nvarchar(50)
AS
BEGIN TRAN
	select * FROM SanPham
	where MaSP = @MaSP and TenSP = @TenSP
COMMIT
GO

select * from DonHang
select * from CT_DonHang
select * from KhuyenMai
select * from KhacHang
select * from NhanVien
go
insert into KhacHang values (N'Thủ Khoa Nha', '202 Thái Phú', 0911222999)
go
insert into NhanVien values ('NV03', N'Minh Trung', N'Tài xế', 9000)  
go
insert into KhuyenMai values ('2021-7-1', '2021-7-10', 0.30)
go
insert into CT_DonHang values ('SP02', 1, 2, 500)
go
insert into DonHang values ('2021-7-1', 2, N'Đang lấy hàng', 2, 'NV02', N'Không', 10, 0, 0)

go

-- xem đơn hàng
CREATE 
--ALTER 
PROC KhachHang_Xem_DonHang
AS
BEGIN TRAN
	select * FROM DonHang
COMMIT
GO

EXEC KhachHang_Xem_DonHang
GO

-- xem CHI TIẾT sản phẩm
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

-- KHÁCH HÀNG THÊM SẢN PHẨM VÀO GIỎ VÀ TIẾN HÀNG VIỆC THANH TOÁN
CREATE 
--ALTER 
PROC KhachHang_DatHang_ThanhToan
	@NgayLapDon date,
	@MaKH int,
	@TinhTrang nvarchar(50),
	@MaKM int,
	@MaNV varchar(8),
	@FreeShip nvarchar(50),
	@PhiVanChuyen NUMERIC(5, 2),
	@TongTien NUMERIC(9, 2),
	@SoTienGiam NUMERIC(9, 2),
	@MaSP varchar(8), 
	@MaDH int,
	@SoLuong int,
	@Dongia numeric(8, 2)
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

	insert into DonHang values (@NgayLapDon, @MaKH, @TinhTrang, @MaKM, @MaNV, @FreeShip, @PhiVanChuyen, @TongTien, @SoTienGiam)

	insert into CT_DonHang values (@MaSP, @MaDH, @SoLuong, @DonGia)

COMMIT TRAN
GO

EXEC KhachHang_DatHang_ThanhToan '2021-7-2', 2, N'Đang chờ', 3, 'NV02', N'Không', 0, 0, 0, 'SP01', 2, 3, 100