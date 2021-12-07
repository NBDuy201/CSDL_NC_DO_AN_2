--[Phân hệ quản trị]---------------------------------------------------
USE QLCuaHang
GO
CREATE ROLE [AdminROLE] AUTHORIZATION [dbo]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [AdminROLE]
GO
GRANT SELECT ON SanPham TO [AdminROLE]
GRANT EXEC ON NhanVienQuanTri_ThemSanPham TO [AdminROLE]
GRANT EXEC ON NhanVienQuanTri_UpdateSanPham TO [AdminROLE]
GRANT EXEC ON [dbo].[newlogin_TaiXe] TO [AdminROLE]
GRANT EXEC ON [dbo].[grantAccount] TO [AdminROLE]
GRANT EXEC ON [dbo].[denyAccount] TO [AdminROLE]
GO

--[Phân hệ nhân viên]---------------------------------------------------
USE QLCuaHang
GO
CREATE ROLE [StaffROLE] AUTHORIZATION [dbo]
GO
GRANT SELECT,UPDATE(THOIGIANHIEULUC, TINHTRANGPHIKICHHOAT) ON [dbo].[HOPDONG] TO [StaffROLE]
GRANT EXEC ON Approve_Contract TO [StaffROLE]
GRANT EXEC ON Extend_Contract TO [StaffROLE]
GRANT EXEC ON Approve_MonthlyFee TO [StaffROLE]
GRANT EXEC ON View_PendingContract TO [StaffROLE]
GO

--[Phân hệ đối tác(MADOITAC)]---------------------------------------------------
USE QLCuaHang
GO
CREATE ROLE [PartnerROLE] AUTHORIZATION [dbo]
GO
GRANT SELECT,UPDATE ON [dbo].[DOITAC] TO [PartnerROLE]	--self edit profile
GRANT SELECT,UPDATE(TINHTRANGDONHANG) ON [dbo].[DONHANG] TO [PartnerROLE]
GRANT SELECT,INSERT,DELETE,UPDATE ON [dbo].[CHINHANH_SANPHAM] TO [PartnerROLE]
GRANT SELECT,INSERT ON [dbo].[HOPDONG] TO [PartnerROLE]
GRANT SELECT ON [dbo].[THEODOIHOPDONG] TO [PartnerROLE]
GRANT EXEC ON View_Contract TO [PartnerROLE]
GRANT EXEC ON insertContract TO [PartnerROLE]
GRANT EXEC ON updateTinhTrangDonHang TO [PartnerROLE]
GRANT EXEC ON updateDiaChi TO [PartnerROLE]
GRANT EXEC ON deleteSanPham_ChiNhanh TO [PartnerROLE]
GRANT EXEC ON updateSLSanPham_ChiNhanh TO [PartnerROLE]
GRANT EXEC ON update_GiaSanPham TO [PartnerROLE]
GO

--[Phân hệ khách hàng(MAKHACHHANG)]---------------------------------------------------
USE QLCuaHang
GO
CREATE ROLE [CustomerROLE] AUTHORIZATION [dbo]
GO
GRANT SELECT,UPDATE ON [dbo].[KHACHHANG] TO [CustomerROLE]	--self edit profile
GRANT SELECT ON [dbo].[DOITAC] TO [CustomerROLE]
GRANT SELECT ON [dbo].[CHINHANH] TO [CustomerROLE]
GRANT SELECT ON [dbo].[CHINHANH_SANPHAM] TO [CustomerROLE]
GRANT SELECT ON [dbo].[SANPHAM] TO [CustomerROLE]
GRANT SELECT ON [dbo].[DONHANG] TO [CustomerROLE]
GO

--[Phân hệ tài xế(MaNV)]---------------------------------------------------
USE QLCuaHang
GO
CREATE ROLE [DriverROLE] AUTHORIZATION [dbo]
GO
GRANT EXEC ON [dbo].Taixe_XemDonHang TO [DriverROLE]
GRANT EXEC ON [dbo].TaiXe_ChonDonHang TO [DriverROLE]
GRANT EXEC ON [dbo].TaiXe_CapNhatDonHang TO [DriverROLE]
GO





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