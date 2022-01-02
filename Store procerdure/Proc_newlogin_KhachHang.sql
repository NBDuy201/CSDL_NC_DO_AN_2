USE QLCuaHang
GO

CREATE OR ALTER PROC [dbo].[newlogin_KhachHang]
@TenKH nvarchar(50),
@Sdt varchar(10),
@DiaChi nvarchar(100),
@USERNAME nvarchar(50),
@PASS nvarchar(50)
AS
BEGIN
	BEGIN TRAN

		-- INSERT thông tin Khách hàng
		BEGIN TRY
			INSERT KhachHang (TenKH, DiaChi, Sdt,UserName,Pass)
			VALUES (@TenKH, @DiaChi, @Sdt,@USERNAME,@PASS)
		END TRY
		BEGIN CATCH
			ROLLBACK TRAN
			RETURN
		END CATCH

		-- Tạo login
		DECLARE @safe_username varchar(40)
		DECLARE @safe_password varchar(40)
		DECLARE @safe_db varchar(40)
		SET @safe_username = REPLACE(@USERNAME,'''','''''')
		SET @safe_password = REPLACE(@PASS,'''','''''')
		SET @safe_db = REPLACE('QLCuaHang','''','''''')

		DECLARE @sql nvarchar(max)
		SET @sql = 'USE ' + @safe_db + ';' +
				   'CREATE LOGIN ' + @safe_username + ' WITH PASSWORD=''' + @safe_password + '''; ' +
				   'CREATE USER ' + @safe_username + ' FOR LOGIN ' + @safe_username + '; ' +
				   'ALTER ROLE [KhachHang] ADD MEMBER ' + @safe_username + ';'
		EXEC (@sql)
	COMMIT TRAN
END
GO
--Các Tài khoản
--exec newlogin_KhachHang 'Nhut', '0764740821', 'Test', 'Customer122345', '123'
--insert into NhaCungCap(MaNCCap,Ten,DiaChi,Sdt,UserName,Pass) values ('NCC9999','ConCung','Test','0838383838','NhaCungCap','123')
--insert into NhanVien(MaNV,TenNV,ChucVu,UserName,Pass) values ('NV9999',N'Phạm Anh Tuấn',N'Quản lí','QuanLi','123')
select ChucVu from NhanVien where MaNV='NV9999'