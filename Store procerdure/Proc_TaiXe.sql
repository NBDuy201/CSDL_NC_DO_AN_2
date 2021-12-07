USE QLCuaHang
GO

-- =============================================
--- Xem danh sách đơn hàng có thể giao:
--- Input: Mã tài xế
--- Output: Các đơn hàng có tình trạng = 'Đồng ý' và chưa được chọn bởi tài xế nào
-- =============================================
CREATE OR ALTER PROC Taixe_XemDonHang
AS
BEGIN
	BEGIN TRAN
		SELECT dh.MaDH, kh.TenKH, kh.DiaChi, kh.Sdt, dh.GiaCuoiCung, dh.PhiVanChuyen
		FROM DonHang dh JOIN KhacHang kh
		ON dh.MaKH = kh.MaKH
		WHERE 
			TinhTrang = N'Đồng ý' AND 
			MaNV IS NULL
	COMMIT TRAN
END
GO

-- =============================================
--- Xác nhận giao 1 đơn hàng
--- Input: Mã tài xế, Mã đơn hàng
--- Output: Cập nhật tình trạng đơn hàng = 'Đang giao' và thêm vào MaNV
-- =============================================
CREATE OR ALTER PROC TaiXe_ChonDonHang
	@MaTXe INT,
	@MaDHang INT
AS
BEGIN
	BEGIN TRAN
		-- Mã tài xế để trống hoặc không tồn tại
		IF (@MaTXe IS NULL OR NOT EXISTS (SELECT* FROM NhanVien WHERE MaNV = @MaTXe AND ChucVu = N'Tài xế'))
		BEGIN
			RAISERROR (N'Mã tài xế để trống hoặc không tồn tại.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Mã đơn hàng không tồn tại hoặc không hợp lệ
		IF @MaDHang IS NULL OR NOT EXISTS (SELECT* FROM DonHang WHERE MaDH = @MaDHang AND TinhTrang = N'Đồng ý')
		BEGIN
			RAISERROR (N'Mã đơn hàng không tồn tại hoặc không hợp lệ.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		BEGIN TRY
			UPDATE DonHang
			SET MaNV = @MaTXe, TinhTrang = N'Đang giao'
			WHERE MaDH = @MaDHang
		END TRY
		BEGIN CATCH
			ROLLBACK TRAN
			RETURN
		END CATCH
	COMMIT TRAN
END
GO

-- =============================================
--- Cập nhật 1 đơn hàng
--- Input: Mã tài xế, Mã đơn hàng
--- Output: Cập nhật tình trạng đơn hàng = 'Đã nhận'
-- =============================================
CREATE OR ALTER PROC TaiXe_CapNhatDonHang
	@MaTXe INT,
	@MaDHang INT
AS
BEGIN
	BEGIN TRAN
		-- Mã tài xế không tồn tại hoặc không hợp lệ
		IF (@MaTXe IS NULL OR NOT EXISTS (SELECT* FROM NhanVien WHERE MaNV = @MaTXe AND ChucVu = N'Tài xế'))
		BEGIN
			RAISERROR (N'Mã tài xế không tồn tại hoặc không hợp lệ.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Mã đơn hàng không tồn tại hoặc không hợp lệ
		IF @MaDHang IS NULL OR NOT EXISTS (SELECT* FROM DonHang WHERE MaDH = @MaDHang AND TinhTrang = N'Đang giao')
		BEGIN
			RAISERROR (N'Mã đơn hàng không tồn tại hoặc không hợp lệ.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Đơn hàng không do bạn giao
		IF NOT EXISTS (SELECT* FROM DonHang WHERE MaDH = @MaDHang AND MaNV = @MaTXe)
		BEGIN
			RAISERROR (N'Không được cập nhật đơn hàng không được giao bởi bạn.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		BEGIN TRY
			UPDATE DonHang
			SET TinhTrang = N'Đã nhận'
			WHERE MaDH = @MaDHang
		END TRY
		BEGIN CATCH
			ROLLBACK TRAN
			RETURN
		END CATCH
	COMMIT TRAN
END
GO