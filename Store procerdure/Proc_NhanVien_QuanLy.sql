USE QLCuaHang
GO

-- =============================================
--- Cập nhật tình trạng đơn hàng
--- Input: Mã nhân viên, mã đơn hàng, tình trạng
--- Output: Đơn hàng được update tình trạng -> 'Đã nhận'
-- =============================================
CREATE OR ALTER PROC NhanVienQuanLy_UpdateTinhTrangDonHang
	@MaNV VARCHAR(8),
	@MaDH INT
AS
BEGIN
	BEGIN TRAN
		-- Mã nhân viên để trống hoặc không tồn tại
		IF (@MaNV IS NULL OR NOT EXISTS (SELECT* FROM NhanVien WHERE MaNV = @MaNV AND ChucVu = N'Quản lý'))
		BEGIN
			RAISERROR (N'Mã nhân viên để trống, không tồn tại hoặc không có quyền cập nhật tình trạng đơn.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Mã đơn hàng để trống hoặc không tồn tại
		IF (@MaDH IS NULL OR NOT EXISTS (SELECT* FROM DonHang WHERE MaDH = @MaDH))
		BEGIN
			RAISERROR (N'Mã đơn hàng để trống hoặc không tồn tại.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Update tình trạng đơn -> 'Đã nhận'
		IF (SELECT TinhTrang FROM DonHang WHERE MaDH = @MaDH) = N'Đang giao'
		BEGIN  
        	UPDATE DonHang
			SET TinhTrang = N'Đã nhận'
			WHERE MaDH = @MaDH
        END
		ELSE
		BEGIN
			RAISERROR (N'Không thể cập nhật đơn hàng chưa đi giao.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END
	COMMIT TRAN
END
GO

-- =============================================
--- Thống kê doanh thu the tháng - năm
--- Input: Mã nhân viên, tháng, năm
--- Output: Doanh thu của tháng trong năm đó
-- =============================================
CREATE OR ALTER PROC NhanVienQuanLy_ThongKeDoanhThuThang
	@MaNV VARCHAR(8),
	@Month INT,
	@Year INT,
	@offset int,
	@rows int
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
				SELECT MaDH, ISNULL(SUM(GiaCuoiCung - PhiVanChuyen), 0) AS DoanhThu -- Trả về 0 hoặc Doanh thu
				FROM DonHang
				WHERE YEAR(NgayLapDon) = @Year AND MONTH(NgayLapDon) = @Month AND TinhTrang = N'Đã nhận'
				Group by MaDH
				order by MaDH 
				offset @offset rows fetch next @rows rows only		
			END
			-- Tính theo năm
			ELSE
			BEGIN
            	SELECT MaDH, ISNULL(SUM(GiaCuoiCung - PhiVanChuyen), 0) AS DoanhThu
				FROM DonHang
				WHERE YEAR(NgayLapDon) = @Year AND TinhTrang = N'Đã nhận'
				Group by MaDH
				order by MaDH 
				offset @offset rows fetch next @rows rows only
            END
		END TRY
		BEGIN CATCH
			RAISERROR (N'Đã xảy ra lỗi khi tính doanh thu', -1, -1)
			ROLLBACK TRAN
			RETURN
		END CATCH
	COMMIT TRAN
END

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
		IF (@MaNV IS NULL OR NOT EXISTS (SELECT* FROM NhanVien WHERE MaNV = @MaNV AND ChucVu = N'Quản lý'))
		BEGIN
			RAISERROR (N'Mã nhân viên để trống, không tồn tại hoặc không có quyền cập nhật tình trạng đơn.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		---- Ngày không đúng format
		--IF ISDATE(@NgayBD) <> 1 OR ISDATE(@NgayKT) <> 1
		--BEGIN
		--	RAISERROR (N'Ngày bắt đầu hoặc kết thúc không đúng format.', -1, -1)
		--	ROLLBACK TRAN
		--	RETURN
		--END

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