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

		-- INSERT thông tin Đối tác
		BEGIN TRY
			INSERT KhacHang (TenKH, DiaChi, Sdt)
			VALUES (@TenKH, @DiaChi, @Sdt)
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

exec newlogin_KhachHang 'Tuan', '0921', '012 KHOA HONG', 'tuan123', 'tuan123'

select * from KhacHang