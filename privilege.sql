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
CREATE LOGIN [Admin01] WITH PASSWORD=N'Admin', DEFAULT_DATABASE=[QLDatChuyenHangOnl], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
CREATE LOGIN [Staff01] WITH PASSWORD=N'Staff', DEFAULT_DATABASE=[QLDatChuyenHangOnl], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
CREATE LOGIN [DTA0000000] WITH PASSWORD=N'Partner', DEFAULT_DATABASE=[QLDatChuyenHangOnl], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
CREATE LOGIN [TXE0000000] WITH PASSWORD=N'Driver', DEFAULT_DATABASE=[QLDatChuyenHangOnl], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
CREATE LOGIN [KHG0000001] WITH PASSWORD=N'Customer', DEFAULT_DATABASE=[QLDatChuyenHangOnl], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

--[User]------------------------------------------------------------------
USE QLCuaHang
GO
CREATE USER [Admin01] FOR LOGIN [Admin01] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [Staff01] FOR LOGIN [Staff01] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [DTA0000000] FOR LOGIN [DTA0000000] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [TXE0000000] FOR LOGIN [TXE0000000] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [KHG0000001] FOR LOGIN [KHG0000001] WITH DEFAULT_SCHEMA=[dbo]
GO

--[ADD ROLE]--------------------------------------------------------------
USE QLCuaHang
GO
ALTER ROLE [AdminROLE] ADD MEMBER [Admin01]
GO
ALTER ROLE [StaffROLE] ADD MEMBER [Staff01]
GO
ALTER ROLE [PartnerROLE] ADD MEMBER [DTA0000000]
GO
ALTER ROLE [DriverROLE] ADD MEMBER [TXE0000000]
GO
ALTER ROLE [CustomerROLE] ADD MEMBER [KHG0000001]
GO