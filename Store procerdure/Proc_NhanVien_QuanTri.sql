USE QLCuaHang
GO

-- =============================================
--- Thêm sản phẩm
--- Input: Mã nhân viên, các thông tin sản phẩm
--- Output: Sản phẩm được thêm vào với thông tin trong input
-- =============================================
CREATE OR ALTER PROC NhanVienQuanTri_ThemSanPham
	@MaNV INT,
	@TenSP nvarchar(50),
	@MaLoai varchar(8),
	@DonGia numeric(9, 2),
	@SoLuongTon int,
	@MaNCCap varchar(8)
AS
BEGIN
	BEGIN TRAN
		-- Mã nhân viên để trống hoặc không tồn tại
		IF (@MaNV IS NULL OR NOT EXISTS (SELECT* FROM NhanVien WHERE MaNV = @MaNV AND ChucVu = N'Quản trị'))
		BEGIN
			RAISERROR (N'Mã nhân viên để trống, không tồn tại hoặc không có quyền thêm sản phẩm.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Tên sản phẩm để trống
		IF (@TenSP IS NULL)
		BEGIN
			RAISERROR (N'Tên sản phẩm để trống.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Mã loại để trống hoặc không tồn tại
		IF (@MaLoai IS NULL OR NOT EXISTS (SELECT* FROM LoaiSanPham WHERE MaLoai = @MaLoai))
		BEGIN
			RAISERROR (N'Mã loại sản phẩm để trống hoặc không tồn tại.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Đơn giá hoặc số lượng âm 
		IF (@DonGia IS NULL OR @DonGia <= 0) OR
			(@SoLuongTon IS NULL OR @SoLuongTon <= 0)
		BEGIN
			RAISERROR (N'Đơn giá hoặc số lượng tồn phải lớn hơn 0.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Mã nhà cung cấp để trống hoặc không tồn tại
		IF (@MaNCCap IS NULL OR NOT EXISTS (SELECT* FROM NhaCungCap WHERE MaNCCap = @MaNCCap))
		BEGIN
			RAISERROR (N'Mã nhà cung cấp để trống hoặc không tồn tại.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Thêm sản phẩm
		INSERT INTO SanPham (TenSP, MaLoai, DonGia, SoLuongTon, MaNCCap) 
		VALUES (@TenSP, @MaLoai, @DonGia, @SoLuongTon, @MaNCCap)
	COMMIT TRAN
END
GO

-- =============================================
--- Cập nhật sản phẩm
--- Input: Mã sản phẩm, tên, giá, số lượng (optional)
--- Output: Sản phẩm được cập nhật với thông tin tương ứng
-- =============================================
CREATE OR ALTER PROC NhanVienQuanTri_UpdateSanPham
	@MaNV INT,
	@MaSP INT,
	@ten NVARCHAR(50),
	@gia NUMERIC(9,2),
	@soluong int
AS
BEGIN
	BEGIN TRAN
		-- Mã nhân viên không tồn tại hoặc không hợp lệ
		IF (@MaNV IS NULL OR NOT EXISTS (SELECT* FROM NhanVien WHERE MaNV = @MaNV AND ChucVu = N'Quản trị'))
		BEGIN
			RAISERROR (N'Mã nhân viên để trống, không tồn tại hoặc không có quyền cập nhật sản phẩm.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Mã đơn hàng không tồn tại hoặc không hợp lệ
		IF @MaSP IS NULL OR NOT EXISTS (SELECT* FROM SanPham WHERE MaSP = @MaSP)
		BEGIN
			RAISERROR (N'Mã sản phẩm không tồn tại hoặc không hợp lệ.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Giá và số lượng tồn < 0
		IF @gia <= 0 OR @soluong <= 0
		BEGIN
			RAISERROR (N'Giá và số lượng phải lớn hơn 0.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		BEGIN TRY
			-- Update tên
			IF @ten IS NOT NULL
			BEGIN
				UPDATE SanPham
				SET TenSP = @ten
				WHERE MaSP = @MaSP
			END

			-- Update giá
			IF @gia IS NOT NULL
			BEGIN
				UPDATE SanPham
				SET DonGia = @gia
				WHERE MaSP = @MaSP
			END

			-- Update số lượng tồn
			IF @soluong IS NOT NULL
			BEGIN
				UPDATE SanPham
				SET SoLuongTon = @soluong
				WHERE MaSP = @MaSP
			END
		END TRY
		BEGIN CATCH
			RAISERROR (N'Quá trình cập nhật xảy ra lỗi.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END CATCH
	COMMIT TRAN
END
GO

-- =============================================
--- Thêm phiếu đặt hàng
--- Input: Mã nhà cung cấp
--- Output: Thêm phiếu đặt mới + trả về mã phiếu đặt được tạo
-- =============================================
CREATE OR ALTER PROC NhanVienQuanTri_TaoPhieuDathang
	@MaNV INT,
	@MaNCCap VARCHAR(8)
AS
BEGIN
	BEGIN TRAN
		-- Mã nhân viên không tồn tại hoặc không hợp lệ
		IF (@MaNV IS NULL OR NOT EXISTS (SELECT* FROM NhanVien WHERE MaNV = @MaNV AND ChucVu = N'Quản trị'))
		BEGIN
			RAISERROR (N'Mã nhân viên để trống, không tồn tại hoặc không có quyền đặt sản phẩm.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Mã nhà cung cấp không tồn tại hoặc không hợp lệ
		IF @MaNCCap IS NULL OR NOT EXISTS (SELECT* FROM NhaCungCap WHERE MaNCCap = @MaNCCap)
		BEGIN
			RAISERROR (N'Mã nhà cung cấp không tồn tại hoặc không hợp lệ.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		BEGIN TRY
			INSERT INTO PhieuDatHang (NgayDat, MaNCCap)
			VALUES (GETDATE(), @MaNCCap)
			SELECT SCOPE_IDENTITY() AS MaPhieuDat
		END TRY
		BEGIN CATCH
			RAISERROR (N'Quá trình thêm xảy ra lỗi.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END CATCH
	COMMIT TRAN
END
GO

-- =============================================
--- Thêm sản phẩm vào phiếu đặt hàng
--- Input: Mã nhân viên, Mã phiếu đặt, Mã sản phẩm, số lượng
--- Output: Thêm sản phẩm mới vào phiếu đặt
-- =============================================
CREATE OR ALTER PROC NhanVienQuanTri_ThemSanPhamVaoPhieuDat
	@MaNV INT,
	@MaPhieuDat INT,
	@MaSP INT,
	@soluong INT
AS
BEGIN
	BEGIN TRAN
		-- Mã nhân viên không tồn tại hoặc không hợp lệ
		IF (@MaNV IS NULL OR NOT EXISTS (SELECT* FROM NhanVien WHERE MaNV = @MaNV AND ChucVu = N'Quản trị'))
		BEGIN
			RAISERROR (N'Mã nhân viên để trống, không tồn tại hoặc không có quyền đặt thêm sản phẩm.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Mã phiếu đặt không tồn tại hoặc không hợp lệ
		IF (@MaNV IS NULL OR NOT EXISTS (SELECT* FROM PhieuDatHang WHERE MaPhieuDat = @MaPhieuDat))
		BEGIN
			RAISERROR (N'Mã phiếu đặt không tồn tại hoặc không hợp lệ.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Mã sản phẩm không tồn tại hoặc không hợp lệ
		IF @MaSP IS NULL OR NOT EXISTS (SELECT* FROM SanPham WHERE MaSP = @MaSP)
		BEGIN
			RAISERROR (N'Mã sản phẩm không tồn tại hoặc không hợp lệ.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Số lượng không hợp lệ
		IF @soluong IS NULL OR @soluong <= 0
		BEGIN
			RAISERROR (N'Số lượng để trống hoặc không hợp lệ.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		-- Sản phẩm không được cung ứng bởi nhà cung cấp
		DECLARE @MaNCC VARCHAR(8) = (SELECT MaNCCap FROM PhieuDatHang WHERE MaPhieuDat = @MaPhieuDat)
		IF @MaNCC <> (SELECT MaNCCap FROM SanPham WHERE MaSP = @MaSP)
		BEGIN
			RAISERROR (N'Nhà cung cấp không có sản phẩm này.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END

		BEGIN TRY
			-- Nếu sản phẩm đã tồn tại thì chỉ cập nhật thêm số lượng
			if EXISTS (SELECT* FROM CT_PhieuDat_SP WHERE MaSP = @MaSP AND MaPhieuDat = @MaPhieuDat)
			BEGIN
				UPDATE CT_PhieuDat_SP
				SET SoLuong = SoLuong + @soluong
				WHERE
					MaPhieuDat = @MaPhieuDat AND
					MaSP = @MaSP
			END
			ELSE
			-- Nếu không thì thêm mới
			BEGIN
				INSERT INTO CT_PhieuDat_SP (MaPhieuDat, MaSP, SoLuong)
				VALUES (@MaPhieuDat, @MaSP, @soluong)
			END
		END TRY
		BEGIN CATCH
			RAISERROR (N'Quá trình thêm xảy ra lỗi.', -1, -1)
			ROLLBACK TRAN
			RETURN
		END CATCH
	COMMIT TRAN
END
GO