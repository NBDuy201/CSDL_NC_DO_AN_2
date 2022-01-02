USE QLCuaHang
GO
-- =============================================
--- Thống kê doanh thu the tháng - năm
--- Input: Mã nhân viên, tháng, năm
--- Output: Doanh thu của tháng trong năm đó
-- =============================================
CREATE OR ALTER PROC NhanVienQuanLy_ThongKeDoanhThuThang
	@MaNV VARCHAR(8),
	@Month INT,
	@Year INT
AS
BEGIN
	BEGIN TRAN
		-- Mã nhân viên để trống hoặc không tồn tại
		IF (@MaNV IS NULL OR NOT EXISTS (SELECT* FROM NhanVien WHERE MaNV = @MaNV AND ChucVu = N'Quản lý' or ChucVu = N'Quản lí'))
		BEGIN
			RAISERROR (N'Mã nhân viên để trống, không tồn tại hoặc không có quyền cập nhật tình trạng đơn.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Tháng không hợp lệ
		IF @Month <= 0 OR @Month > 12
		BEGIN
			RAISERROR (N'Tháng không hợp lệ.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Năm để trống hoặc không hợp lệ
		IF (@Year IS NULL) OR (@Year <= 0)
		BEGIN
			RAISERROR (N'Năm để trống hoặc không hợp lệ', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Tính doanh thu
		BEGIN TRY
			-- Tính theo năm-tháng
			IF @Month IS NOT NULL
			BEGIN
				SELECT ISNULL(SUM(GiaCuoiCung - PhiVanChuyen), 0) AS DoanhThu -- Trả về 0 hoặc Doanh thu
				FROM DonHang
				WHERE YEAR(NgayLapDon) = @Year AND MONTH(NgayLapDon) = @Month AND TinhTrang = N'Đã nhận'
			END
			-- Tính theo năm
			ELSE
			BEGIN
            	SELECT ISNULL(SUM(GiaCuoiCung - PhiVanChuyen), 0) AS DoanhThu
				FROM DonHang
				WHERE YEAR(NgayLapDon) = @Year AND TinhTrang = N'Đã nhận'
            END
		END TRY
		BEGIN CATCH
			RAISERROR (N'Đã xảy ra lỗi khi tính doanh thu', -1, -1)
			ROLLBACK TRAN
			RETURN
		END CATCH
	COMMIT TRAN
END

go

-- =============================================
--- Thêm khuyến mãi
--- Input: Mã nhân viên, ngày BD, ngày KT, Mức KM (1, 100)
--- Output: Thêm khuyến mãi mới
-- =============================================
CREATE OR ALTER PROC NhanVienQuanLy_ThemKhuyenMai
	@MaNV VARCHAR(8),
	@NgayBD date,
	@NgayKT DATE,
	@MucKM FLOAT
AS
BEGIN
	BEGIN TRAN
		-- Mã nhân viên để trống hoặc không tồn tại
		IF (@MaNV IS NULL OR NOT EXISTS (SELECT* FROM NhanVien WHERE MaNV = @MaNV AND ChucVu = N'Quản lý' OR ChucVu = N'Quản lí'))
		BEGIN
			RAISERROR (N'Mã nhân viên để trống, không tồn tại hoặc không có quyền cập nhật tình trạng đơn.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Mức khuyến mãi <= 0 hoặc lớn hơn 100
		IF @MucKM <= 0 OR @MucKM > 100
		BEGIN
			RAISERROR (N'Mức khuyến mãi phải nằm trong khoảng (1, 100).', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- NgàyBD > ngàyKT
		IF (SELECT DATEDIFF(day, @NgayBD, @NgayKT)) < 0
		BEGIN
			RAISERROR (N'Ngày bắt đầu không được lớn hơn ngày kết thúc.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Thêm khuyến mãi
		BEGIN TRY
			INSERT INTO KhuyenMai (NgayBD, NgayKT, MucKM) VALUES (@NgayBD, @NgayKT, @MucKM)
		END TRY
		BEGIN CATCH
			RAISERROR (N'Đã xảy ra lỗi thêm khuyến mãi', -1, -1)
			ROLLBACK TRAN
			RETURN
		END CATCH
	COMMIT TRAN
END
GO