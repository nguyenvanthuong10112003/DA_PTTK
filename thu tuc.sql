
GO					
CREATE PROC proc_ThanhVien_GetData_ByKey @username VARCHAR(50)
AS
BEGIN
	SELECT TV.* FROM ThanhVien TV INNER JOIN TaiKhoan TK ON TK.TV_Ma = TV.TV_Ma AND TK.TK_TenDangNhap = @username 
END
GO
CREATE PROC proc_TaiKhoan_CheckLogin @username VARCHAR(50), @password VARCHAR(60)
AS
BEGIN
	IF (SELECT COUNT(*) FROM dbo.TaiKhoan WHERE TK_TenDangNhap = @username AND TK_MatKhau = @password) >= 1
		SELECT 1
	ELSE 
		SELECT 0
END

SELECT * FROM dbo.TaiKhoan

UPDATE dbo.TaiKhoan SET TK_BiKhoa = 0, TK_ThoiGianMoKhoa = null
WHERE TK_TenDangNhap = 'admin'


CREATE TYPE dbo.IDList
AS TABLE
(


go
CREATE PROC proc_ThanhVien_GetData_ByCode @code CHAR(10)
AS
BEGIN
	SELECT * FROM dbo.ThanhVien WHERE TV_Ma = @code
END
go
  [key] NVARCHAR(100),
  [value] NVARCHAR(100)
);
GO
CREATE PROC proc_TaiKhoan_UpdateData_ByKey @keyValue dbo.IDList, @keyValueNew dbo.IDList
AS
BEGIN
	IF EXISTS(SELECT * FROM @keyValueNew) 
	BEGIN
		DECLARE @index INT;
		SET @index = 1
		UPDATE dbo.TaiKhoan SET
		WHILE()
	END
END

SELECT * FROM dbo.TaiKhoan

EXEC dbo.proc_ThanhVien_GetData_ByCode @code = 'admin' -- char(10)
