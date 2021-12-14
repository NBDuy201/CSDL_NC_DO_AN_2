--[Phân hệ quản trị]---------------------------------------------------
USE QLCuaHang
GO
CREATE ROLE NVQuanTri AUTHORIZATION [dbo]
GO
GRANT SELECT ON SanPham TO NVQuanTri
GRANT EXEC ON NhanVienQuanTri_ThemSanPham TO NVQuanTri
GRANT EXEC ON NhanVienQuanTri_UpdateSanPham TO NVQuanTri
GRANT EXEC ON NhanVienQuanTri_TaoPhieuDathang TO NVQuanTri
GRANT EXEC ON NhanVienQuanTri_ThemSanPhamVaoPhieuDat TO NVQuanTri
GO

--[Phân hệ nhân viên quản lý]---------------------------------------------------
USE QLCuaHang
GO
CREATE ROLE NVQuanLy AUTHORIZATION [dbo]
GO
GRANT SELECT ON DonHang TO NVQuanLy
GRANT EXEC ON NhanVienQuanLy_UpdateTinhTrangDonHang TO NVQuanLy
GRANT EXEC ON NhanVienQuanLy_ThongKeDoanhThuThang TO NVQuanLy
GRANT EXEC ON NhanVienQuanLy_ThemKhuyenMai TO NVQuanLy
GRANT DELETE ON KhuyenMai TO NVQuanLy
GO

--[Phân hệ khách hàng(MAKHACHHANG)]---------------------------------------------------
USE QLCuaHang
GO
CREATE ROLE KhachHang AUTHORIZATION [dbo]
GO
GRANT EXEC ON KhachHang_XemTatCa_Sanpham TO KhachHang
GRANT EXEC ON KhachHang_Xem_CT_Sanpham TO KhachHang
GRANT EXEC ON KhachHang_XemTatCa_DonHang TO KhachHang
GRANT EXEC ON KhachHang_Xem_CT_DonHang TO KhachHang
GRANT EXEC ON KhachHang_Them_GioHang TO KhachHang
GRANT EXEC ON KhachHang_ThemSanPham_GioHang TO KhachHang
GRANT EXEC ON KhachHang_XacNhan_DonHang TO KhachHang

--[Phân hệ tài xế(MaNV)]---------------------------------------------------
USE QLCuaHang
GO
CREATE ROLE TaiXe AUTHORIZATION [dbo]
GO
GRANT EXEC ON [dbo].Taixe_XemDonHang TO TaiXe
GRANT EXEC ON [dbo].TaiXe_ChonDonHang TO TaiXe
GRANT EXEC ON [dbo].TaiXe_CapNhatDonHang TO TaiXe
GO

--[Phân hệ nhà cung cấp]---------------------------------------------------
USE QLCuaHang
GO
CREATE ROLE NhaCungCap AUTHORIZATION [dbo]
GO
GRANT EXEC ON NhaCCap_LapPhieugiao TO NhaCungCap


--[Login]---------------------------------------------------------------
USE [master]
GO
CREATE LOGIN [NVQuanTri01] WITH PASSWORD=N'NVQuanTri01', DEFAULT_DATABASE=[QLCuaHang], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
CREATE LOGIN [NVQuanLy01] WITH PASSWORD=N'NVQuanLy01', DEFAULT_DATABASE=[QLCuaHang], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
CREATE LOGIN [KhachHang01] WITH PASSWORD=N'KhachHang01', DEFAULT_DATABASE=[QLCuaHang], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
CREATE LOGIN [TaiXe01] WITH PASSWORD=N'TaiXe01', DEFAULT_DATABASE=[QLCuaHang], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
CREATE LOGIN [NhaCungCap01] WITH PASSWORD=N'NhaCungCap01', DEFAULT_DATABASE=[QLCuaHang], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

--[User]------------------------------------------------------------------
USE QLCuaHang
GO
CREATE USER [NVQuanTri01] FOR LOGIN [NVQuanTri01] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [NVQuanLy01] FOR LOGIN [NVQuanLy01] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [KhachHang01] FOR LOGIN [KhachHang01] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [TaiXe01] FOR LOGIN [TaiXe01] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [NhaCungCap01] FOR LOGIN [NhaCungCap01] WITH DEFAULT_SCHEMA=[dbo]
GO

--[ADD ROLE]--------------------------------------------------------------
USE QLCuaHang
GO
ALTER ROLE [NVQuanTri] ADD MEMBER [NVQuanTri01]
GO
ALTER ROLE [NVQuanLy] ADD MEMBER [NVQuanLy01]
GO
ALTER ROLE [KhachHang] ADD MEMBER [KhachHang01]
GO
ALTER ROLE [TaiXe] ADD MEMBER [TaiXe01]
GO
ALTER ROLE [NhaCungCap] ADD MEMBER [NhaCungCap01]
GO