INSERT INTO dbo.ThanhVien
(
   TV_Ma,
    TV_HoVaTen,
    TV_GioiTinh,
    TV_NgaySinh,
    TV_SoDienThoai,
    TV_Email,
    TV_DiaChi,
    TV_SoCCCD,
    TV_PhuCap
)
VALUES
(   'TV003',   -- TV_Ma - char(10)
    N'Ong Thị Hải Linh', -- TV_HoVaTen - nvarchar(50)
    0, -- TV_GioiTinh - bit
    '2002-01-11', -- TV_NgaySinh - date
    null, -- TV_SoDienThoai - char(10)
    'linh0194266@huce.edu.vn', -- TV_Email - varchar(100)
    N'Lai Châu', -- TV_DiaChi - ntext
	null, -- TV_SoCCCD - char(12)
    400000  -- TV_PhuCap - float
)
SELECT * FROM dbo.ThanhVien
SELECT * FROM dbo.TaiKhoan

DELETE dbo.TaiKhoan WHERE TK_TenDangNhap = 'thuong2003'

CREATE PROC PROC_TaiKhoan_UpdateData_ByUsername

UPDATE dbo.TaiKhoan SET TK_MatKhau = '$2a$10$BwUeH9cTmTIrHweiq5RtH.uGHia8zbsG...cx12LvH2FAgtMlxT.u'
WHERE TK_TenDangNhap = 'thuong2003'

GO
DROP PROC PROC_ThanhVien_GetDatas_ByNumericalOrder

CREATE PROC PROC_ThanhVien_GetDatas_ByNumericalOrder @Page INT , @PageSize INT
AS
BEGIN
	SELECT * FROM ThanhVien TV 
	ORDER BY TV_Ma
	OFFSET (@Page - 1)*@PageSize ROWS FETCH NEXT @PageSize ROWS ONLY
END



DECLARE @Ma INT = 4;
WHILE(@Ma <= 999) 
BEGIN
	INSERT INTO dbo.ThanhVien
	(
	    TV_Ma,
	    TV_HoVaTen,
	    TV_GioiTinh,
	    TV_NgaySinh,
	    TV_SoDienThoai,
	    TV_Email,
	    TV_DiaChi,
	    TV_SoCCCD,
	    TV_PhuCap
	)
	VALUES
	(   'TV' + CASE WHEN @Ma < 10 THEN '00' WHEN @Ma < 100 THEN '0' ELSE '' END + CAST(@Ma AS CHAR(3)),   -- TV_Ma - char(10)
	    N'Nguyễn Văn Thường ' + CAST(@Ma AS NVARCHAR(3)), -- TV_HoVaTen - nvarchar(50)
	    1, -- TV_GioiTinh - bit
	    '2003-11-10', -- TV_NgaySinh - date
	    '0886454996', -- TV_SoDienThoai - char(10)
	    'nguyenvanthuong10112003' + CAST(@Ma AS CHAR(3)) + '@gmail.com', -- TV_Email - varchar(100)
	    N'Nam Định ', -- TV_DiaChi - ntext
	    '036203013524', -- TV_SoCCCD - char(12)
	    1000000 + @Ma  -- TV_PhuCap - float
	)
	SET @Ma = @Ma + 1;
END

SELECT * FROM dbo.ThanhVien




CREATE TABLE REGIONS
(
	REGION_ID INT PRIMARY KEY,
	REGION_NAME NVARCHAR2(20)
)
CREATE TABLE COUNTRIES
(
	COUNTRY_ID INT,
	COUNTRY_NAME NVARCHAR2(20),
	REGION_ID INT
)
ALTER TABLE dbo.COUNTRIES ADD CONSTRAINT COUNTRIES_FK1
FOREIGN KEY (REGION_ID) REFERENCES dbo.REGIONS(REGION_ID)
CREATE TABLE LOCATIONS
(
	LOCATION_ID INT PRIMARY KEY,
	ADDRESS NVARCHAR(30),
	POSTAL_CODE VARCHAR(10),
	CITY NVARCHAR(30),
	STATE NVARCHAR(30),
	COUNTRY_ID INT
)
ALTER TABLE dbo.LOCATIONS ADD CONSTRAINT LOCATIONS_FK1
FOREIGN KEY (COUNTRY_ID) REFERENCES dbo.COUNTRIES(COUNTRY_ID)
CREATE TABLE WAREHOUSES
(
	WAREHOUSE_ID INT PRIMARY KEY,
	WAREHOUSE_NAME NVARCHAR(30),
	LOCATION_ID INT
)
ALTER TABLE dbo.WAREHOUSES ADD CONSTRAINT WAREHOUSES_FK1
FOREIGN KEY (LOCATION_ID) REFERENCES dbo.LOCATIONS(LOCATION_ID)
CREATE TABLE INVENTORIES
(
	PRODUCT_ID INT,
	WAREHOUSE_ID INT,
	QUANTITY FLOAT,
	PRIMARY KEY(PRODUCT_ID, WAREHOUSE_ID)
)
ALTER TABLE dbo.INVENTORIES ADD CONSTRAINT INVENORIES_FK1
FOREIGN KEY (WAREHOUSE_ID) REFERENCES dbo.WAREHOUSES(WAREHOUSE_ID)
CREATE TABLE PRODUCT_CATEGORIES
(
	CATEGORY_ID INT PRIMARY KEY,
	CATEGORY_NAME NVARCHAR(30)
)

