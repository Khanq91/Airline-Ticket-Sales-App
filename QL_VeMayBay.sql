CREATE DATABASE QL_VeMayBay
USE QL_VeMayBay

CREATE TABLE SANBAY 
(
	MaSB CHAR(10) NOT NULL,
	TenSB NVARCHAR(50),
	QuocGia NVARCHAR(30),
	CONSTRAINT PK_SB_MaSB PRIMARY KEY(MaSB)
);

CREATE TABLE MAYBAY
(
	MaMB CHAR(10) NOT NULL,
	LoaiMB NVARCHAR(50),
	Hang NVARCHAR(50),
	TongSoGhe INT,
	CONSTRAINT PK_MB_MaMB PRIMARY KEY(MaMB)
);

CREATE TABLE CHANGBAY
(
	MaChB CHAR(10) NOT NULL,
	MaSBdi CHAR(10) NOT NULL,
	MaSBden CHAR(10) NOT NULL,
	NgayBay DATE,                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
	CONSTRAINT PK_ChB_MaChB PRIMARY KEY(MaChB),
	CONSTRAINT FK_ChB_MaSBdi FOREIGN KEY(MaSBdi) REFERENCES SANBAY(MaSB),
    CONSTRAINT FK_ChB_MaSBden FOREIGN KEY(MaSBden) REFERENCES SANBAY(MaSB)
);

CREATE TABLE CHUCVU
(
	MaChucVu CHAR(10) NOT NULL,
	TenChucVu NVARCHAR(30),
	CONSTRAINT PK_CV PRIMARY KEY(MaChucVu)
);

CREATE TABLE QLTaiKhoan
(
	IDTaiKhoan CHAR(20) NOT NULL,
	TenTaiKhoan NVARCHAR(100),
    TenDangNhap VARCHAR(50),
	MatKhau VARCHAR(50),
	LoaiTK NVARCHAR(30) CHECK (LoaiTK IN (N'HANHKHACH', N'NHANVIEN')), 
	CONSTRAINT PK_TK PRIMARY KEY(IDTaiKhoan)
);

CREATE TABLE NHANVIEN 
(
	MaNV CHAR(10) NOT NULL,
	TenNV NVARCHAR(50),
	GioiTinh NVARCHAR(4) CHECK(GioiTinh IN (N'Nam', N'Nữ')),
	Luong MONEY,
	NgaySinhNV DATETIME,
	DiaChiNV NVARCHAR(50) DEFAULT '',
	SDTnv CHAR(11) CHECK (SDTnv LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	MaSB CHAR(10) NOT NULL,
	MaChB CHAR(10) NOT NULL,
	MaChucVu CHAR(10) NOT NULL,
	IDTaiKhoan CHAR(20) NOT NULL,
	CONSTRAINT PK_NV_MaNV PRIMARY KEY(MaNV),
	CONSTRAINT FK_NV_MaSB FOREIGN KEY(MaSB) REFERENCES SANBAY(MaSB),
	CONSTRAINT FK_NV_MaChB FOREIGN KEY(MaChB) REFERENCES CHANGBAY(MaChB),
	CONSTRAINT FK_NV_MaChucVu FOREIGN KEY(MaChucVu) REFERENCES CHUCVU(MaChucVu),
	CONSTRAINT FK_NV_IDtk FOREIGN KEY(IDTaiKhoan) REFERENCES QLTaiKhoan(IDTaiKhoan)
);

CREATE TABLE CHUYENBAY
(
	MaCB CHAR(10) NOT NULL,
	GioBay DATE,
	GioDen DATE,
	GioDuKien DATE,
	MaMB CHAR(10) NOT NULL,
	MaChB CHAR(10) NOT NULL,
	CONSTRAINT PK_CB_MaCB PRIMARY KEY(MaCB),
	CONSTRAINT FK_CB_MaMB FOREIGN KEY(MaMB) REFERENCES MAYBAY(MaMB),
	CONSTRAINT FK_CB_MaChB FOREIGN KEY(MaChB) REFERENCES CHANGBAY(MaChB)
);

CREATE TABLE HANHKHACH 
(
	MaHK CHAR(10) NOT NULL,
	TenHK NVARCHAR(50),
	DiaChi NVARCHAR(50) DEFAULT '', 
	SDT CHAR(11) CHECK (SDT LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	CCCD CHAR(20) UNIQUE,
	HoChieu CHAR(20) UNIQUE,
	NgaySinh DATETIME,
	IDTaiKhoan CHAR(20) NOT NULL,
	CONSTRAINT PK_HK_MaHK PRIMARY KEY(MaHK),
	CONSTRAINT FK_HK_IDtk FOREIGN KEY(IDTaiKhoan) REFERENCES QLTaiKhoan(IDTaiKhoan)
);

CREATE TABLE DATVE
(
	MaDV CHAR(10) NOT NULL,
	--ViTriVe NCHAR(10),
	ThanhTien FLOAT,
	NgayDatVe DATE,
	--MaSB CHAR(10) NOT NULL,
	MaCB CHAR(10) NOT NULL,
	MaHK CHAR(10) NOT NULL,
	CONSTRAINT PK_DV_MaDV PRIMARY KEY(MaDV),
	CONSTRAINT FK_DV_MaHK FOREIGN KEY(MaHK) REFERENCES HANHKHACH(MaHK),
	CONSTRAINT FK_DV_MaCB FOREIGN KEY(MaCB) REFERENCES CHUYENBAY(MaCB)
);

CREATE TABLE HANGVE
(
	MaHangVe CHAR(10) NOT NULL,
	TenHangVe NVARCHAR(50),
	CONSTRAINT PK_HVe_MaVe PRIMARY KEY(MaHangVe)
);

CREATE TABLE VE 
(
	MaVe CHAR(10) NOT NULL,
	GiaVe MONEY,
	DonViTien NCHAR(10),
	ViTriGhe CHAR(10),
	--MaCB CHAR(10) NOT NULL,
	MaHK CHAR(10) NOT NULL, 
	MaDV CHAR(10) NOT NULL,
	MaHangVe CHAR(10) NOT NULL,
	CONSTRAINT PK_VE_MaVe PRIMARY KEY(MaVe),
	--CONSTRAINT FK_VE_MaCB FOREIGN KEY(MaCB) REFERENCES CHUYENBAY(MaCB),
	CONSTRAINT FK_VE_MaHK FOREIGN KEY(MaHK) REFERENCES HANHKHACH(MaHK),
	CONSTRAINT FK_VE_MaDV FOREIGN KEY(MaDV) REFERENCES DATVE(MaDV),
	CONSTRAINT FK_VE_MaHangVe FOREIGN KEY(MaHangVe) REFERENCES HANGVE(MaHangVe)
);

CREATE TABLE NHANXET
(
	MaHK CHAR(10) NOT NULL,
	MaCB CHAR(10) NOT NULL,
	NDNhanXet NVARCHAR(1000),
	DiemDanhGia INT CHECK (DiemDanhGia BETWEEN 1 AND 5),
	CONSTRAINT PK_NX_MaHK_MaCB PRIMARY KEY(MaHK, MaCB),
	CONSTRAINT FK_NX_MaHK FOREIGN KEY(MaHK) REFERENCES HANHKHACH(MaHK),
	CONSTRAINT FK_NX_MaCB FOREIGN KEY(MaCB) REFERENCES CHUYENBAY(MaCB)
);

CREATE TABLE HANHLY 
(
	MaHL CHAR(10) NOT NULL,
	SoKG FLOAT,
	PhuPhi MONEY,
	MaHK CHAR(10) NOT NULL,
	MaCB CHAR(10) NOT NULL,
	CONSTRAINT PK_HL_MaHL PRIMARY KEY(MaHL),
	CONSTRAINT FK_HL_MaHK FOREIGN KEY(MaHK) REFERENCES HANHKHACH(MaHK),
	CONSTRAINT FK_HL_MaCB FOREIGN KEY(MaCB) REFERENCES CHUYENBAY(MaCB)
);

-----------------------------------------------------------------------
--								DỮ LIỆU
-----------------------------------------------------------------------
INSERT INTO SANBAY (MaSB, TenSB, QuocGia) 
VALUES 
	('SB001', 'Tan Son Nhat', 'Vietnam'),
	('SB002', 'Noi Bai', 'Vietnam'),
	('SB003', 'Changi', 'Singapore'),
	('SB004', 'Incheon', 'South Korea'),
	('SB005', 'Suvarnabhumi', 'Thailand');

INSERT INTO MAYBAY (MaMB, LoaiMB, Hang, TongSoGhe) 
VALUES 
	('MB001', 'Boeing 777', 'Vietnam Airlines', 300),
	('MB002', 'Airbus A320', 'VietJet Air', 180),
	('MB003', 'Boeing 787', 'Bamboo Airways', 250),
	('MB004', 'Airbus A350', 'Vietnam Airlines', 320),
	('MB005', 'Boeing 737', 'Thai Airways', 200);

INSERT INTO CHANGBAY (MaChB, MaSBdi, MaSBden, NgayBay) 
VALUES 
	('CB001', 'SB001', 'SB002', '2024-09-01'),
	('CB002', 'SB002', 'SB003', '2024-09-02'),
	('CB003', 'SB003', 'SB004', '2024-09-03'),
	('CB004', 'SB004', 'SB005', '2024-09-04'),
	('CB005', 'SB005', 'SB001', '2024-09-05');

INSERT INTO CHUYENBAY (MaCB, GioBay, GioDen, GioDuKien, MaMB, MaChB) 
VALUES 
	('CBY001', '2024-09-01', '2024-09-01', '2024-09-01', 'MB001', 'CB001'),
	('CBY002', '2024-09-02', '2024-09-02', '2024-09-02', 'MB002', 'CB002'),
	('CBY003', '2024-09-03', '2024-09-03', '2024-09-03', 'MB003', 'CB003'),
	('CBY004', '2024-09-04', '2024-09-04', '2024-09-04', 'MB004', 'CB004'),
	('CBY005', '2024-09-05', '2024-09-05', '2024-09-05', 'MB005', 'CB005');

INSERT INTO CHUCVU (MaChucVu, TenChucVu)
VALUES 
    ('CV001', N'Phi công'),
    ('CV002', N'Tiếp viên'),
    ('CV003', N'Nhân viên mặt đất'),
    ('CV004', N'Kỹ thuật viên bảo trì'),
    ('CV005', N'Quản lý chuyến bay');

INSERT INTO QLTaiKhoan (IDTaiKhoan, TenTaiKhoan, TenDangNhap, MatKhau, LoaiTK)
VALUES 
    ('TK001', N'Nguyen Van A', 'nguyenvana', 'password123', N'NHANVIEN'),
    ('TK002', N'Tran Thi B', 'tranthib', 'password456', N'NHANVIEN'),
    ('TK003', N'Le Van C', 'levanc', 'pass789', N'NHANVIEN'),
    ('TK004', N'Pham Thi D', 'phamthid', 'secret123', N'NHANVIEN'),
    ('TK005', N'Hoang Van E', 'hoangvane', 'secure456', N'NHANVIEN'),
    ('TK006', N'Nguyen Van A', 'nguyenvana1', 'password123', N'HANHKHACH'),
    ('TK007', N'Tran Thi B', 'tranthib1', 'password456', N'HANHKHACH'),
    ('TK008', N'Le Van C', 'levanc1', 'pass789', N'HANHKHACH'),
    ('TK009', N'Pham Thi D', 'phamthid1', 'secret123', N'HANHKHACH'),
    ('TK010', N'Hoang Van E', 'hoangvane1', 'secure456', N'HANHKHACH');

INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, Luong, NgaySinhNV, DiaChiNV, SDTnv, MaSB, MaChB, MaChucVu, IDTaiKhoan) 
VALUES 
	('NV001', 'Nguyen Van X', N'Nam', 15000000, '1980-01-01', 'Ho Chi Minh City', '0905123456', 'SB001', 'CB001', 'CV001', 'TK001'),
	('NV002', 'Tran Thi Y', N'Nữ', 16000000, '1985-02-02', 'Ha Noi', '0906123456', 'SB002', 'CB002', 'CV002', 'TK002'),
	('NV003', 'Le Van Z', N'Nam', 17000000, '1990-03-03', 'Da Nang', '0907123456', 'SB003', 'CB003', 'CV003', 'TK003'),
	('NV004', 'Pham Thi M', N'Nữ', 18000000, '1982-04-04', 'Hai Phong', '0908123456', 'SB004', 'CB004', 'CV004', 'TK004'),
	('NV005', 'Hoang Van N', N'Nam', 19000000, '1987-05-05', 'Can Tho', '0909123456', 'SB005', 'CB005', 'CV005', 'TK005');

INSERT INTO HANHKHACH (MaHK, TenHK, DiaChi, SDT, CCCD, HoChieu, NgaySinh, IDTaiKhoan) 
VALUES 
	('HK001', 'Nguyen Van A', 'Ho Chi Minh City', '0909123456', '0123456789', 'A1234567', '1990-01-01', 'TK006'),
	('HK002', 'Tran Thi B', 'Ha Noi', '0912123456', '9876543210', 'B1234567', '1992-02-02', 'TK007'),
	('HK003', 'Le Van C', 'Da Nang', '0903123456', '1234567890', 'C1234567', '1988-03-03', 'TK008'),
	('HK004', 'Pham Thi D', 'Hai Phong', '0918123456', '0987654321', 'D1234567', '1991-04-04', 'TK009'),
	('HK005', 'Hoang Van E', 'Can Tho', '0904123456', '2345678901', 'E1234567', '1985-05-05', 'TK010');

INSERT INTO DATVE (MaDV, ViTriVe, ThanhTien, NgayDatVe, MaSB, MaCB) 
VALUES 
	('DV001', 'A1', 1000000, '2024-08-01', 'SB001', 'CBY001'),
	('DV002', 'B2', 1500000, '2024-08-02', 'SB002', 'CBY002'),
	('DV003', 'C3', 2000000, '2024-08-03', 'SB003', 'CBY003'),
	('DV004', 'D4', 2500000, '2024-08-04', 'SB004', 'CBY004'),
	('DV005', 'E5', 3000000, '2024-08-05', 'SB005', 'CBY005');

INSERT INTO VE (MaVe, GiaVe, DonViTien, ViTriGhe, MaCB, MaHK, MaDV) 
VALUES 
	('VE001', 1000000, 'VND', 'A1', 'CBY001', 'HK001', 'DV001'),
	('VE002', 1500000, 'VND', 'B2', 'CBY002', 'HK002', 'DV002'),
	('VE003', 2000000, 'VND', 'C3', 'CBY003', 'HK003', 'DV003'),
	('VE004', 2500000, 'VND', 'D4', 'CBY004', 'HK004', 'DV004'),
	('VE005', 3000000, 'VND', 'E5', 'CBY005', 'HK005', 'DV005');

INSERT INTO HANGVE (MaVe, HangVe) 
VALUES 
	('VE001', 'Economy'),
	('VE002', 'Business'),
	('VE003', 'First Class'),
	('VE004', 'Economy'),
	('VE005', 'Business');

INSERT INTO NHANXET (MaHK, MaCB, NDNhanXet, DiemDanhGia) 
VALUES 
	('HK001', 'CBY001', 'Great flight, very comfortable.', 5),
	('HK002', 'CBY002', 'Good service, but the flight was delayed.', 4),
	('HK003', 'CBY003', 'Average experience, nothing special.', 3),
	('HK004', 'CBY004', 'Not satisfied with the service.', 2),
	('HK005', 'CBY005', 'Terrible experience, will not fly again.', 1);

INSERT INTO HANHLY (MaHL, SoKG, PhuPhi, MaHK, MaCB) 
VALUES 
	('HL001', 20, 200000, 'HK001', 'CBY001'),
	('HL002', 25, 250000, 'HK002', 'CBY002'),
	('HL003', 30, 300000, 'HK003', 'CBY003'),
	('HL004', 35, 350000, 'HK004', 'CBY004'),
	('HL005', 40, 400000, 'HK005', 'CBY005');

-----------------------------------------------------------------------
--						CÀI ĐẶT CÁC PROCEDURE
-----------------------------------------------------------------------
--1. Thủ tục thêm hành khách mới
CREATE PROCEDURE ThemHanhKhach
    @MaHK CHAR(10),
    @TenHK NVARCHAR(50),
    @DiaChi NVARCHAR(50),
    @SDT CHAR(11),
    @CCCD CHAR(20),
    @HoChieu CHAR(20),
    @NgaySinh DATETIME,
    @IDTaiKhoan CHAR(20)
AS
BEGIN
    INSERT INTO HANHKHACH (MaHK, TenHK, DiaChi, SDT, CCCD, HoChieu, NgaySinh, IDTaiKhoan)
    VALUES (@MaHK, @TenHK, @DiaChi, @SDT, @CCCD, @HoChieu, @NgaySinh, @IDTaiKhoan);
END

--2. Thủ tục thêm chuyến bay mới
CREATE PROCEDURE ThemChuyenBay
    @MaCB CHAR(10),
    @GioBay DATE,
    @GioDen DATE,
    @GioDuKien DATE,
    @MaMB CHAR(10),
    @MaChB CHAR(10)
AS
BEGIN
    INSERT INTO CHUYENBAY (MaCB, GioBay, GioDen, GioDuKien, MaMB, MaChB)
    VALUES (@MaCB, @GioBay, @GioDen, @GioDuKien, @MaMB, @MaChB);
END

--3. Thủ tục đặt vé máy bay
CREATE PROCEDURE DatVeMayBay
    @MaVe CHAR(10),
    @GiaVe MONEY,
    @DonViTien NCHAR(10),
    @ViTriGhe CHAR(10),
    @MaCB CHAR(10),
    @MaHK CHAR(10),
    @MaDV CHAR(10)
AS
BEGIN
    INSERT INTO VE (MaVe, GiaVe, DonViTien, ViTriGhe, MaCB, MaHK, MaDV)
    VALUES (@MaVe, @GiaVe, @DonViTien, @ViTriGhe, @MaCB, @MaHK, @MaDV);
END

--4. Thủ tục cập nhật thông tin chuyến bay
CREATE PROCEDURE CapNhatChuyenBay
    @MaCB CHAR(10),
    @GioBay DATE,
    @GioDen DATE,
    @GioDuKien DATE
AS
BEGIN
    UPDATE CHUYENBAY
    SET GioBay = @GioBay, GioDen = @GioDen, GioDuKien = @GioDuKien
    WHERE MaCB = @MaCB;
END

--5. Thủ tục hủy vé
CREATE PROCEDURE HuyVe
    @MaVe CHAR(10)
AS
BEGIN
    DELETE FROM VE WHERE MaVe = @MaVe;
END

--6. Thủ tục tìm kiếm chuyến bay theo mã sân bay đi và sân bay đến
CREATE PROCEDURE TimChuyenBay
    @MaSBdi CHAR(10),
    @MaSBden CHAR(10)
AS
BEGIN
    SELECT * 
    FROM CHUYENBAY CB
    JOIN CHANGBAY ChB ON CB.MaChB = ChB.MaChB
    WHERE ChB.MaSBdi = @MaSBdi AND ChB.MaSBden = @MaSBden;
END

--7. Thủ tục xem danh sách vé của hành khách
CREATE PROCEDURE XemVeHanhKhach
    @MaHK CHAR(10)
AS
BEGIN
    SELECT * 
    FROM VE
    WHERE MaHK = @MaHK;
END

--8. Thủ tục thêm đánh giá chuyến bay
CREATE PROCEDURE ThemNhanXet
    @MaHK CHAR(10),
    @MaCB CHAR(10),
    @NDNhanXet NVARCHAR(1000),
    @DiemDanhGia INT
AS
BEGIN
    INSERT INTO NHANXET (MaHK, MaCB, NDNhanXet, DiemDanhGia)
    VALUES (@MaHK, @MaCB, @NDNhanXet, @DiemDanhGia);
END

-----------------------------------------------------------------------
--						CÀI ĐẶT CÁC FUNCTION
-----------------------------------------------------------------------
--1. Hàm tính tổng số vé đã đặt cho một chuyến bay
CREATE FUNCTION TongSoVeDaDat(@MaCB CHAR(10))
RETURNS INT
AS
BEGIN
    DECLARE @SoVe INT;
    SELECT @SoVe = COUNT(*)
    FROM VE
    WHERE MaCB = @MaCB;
    
    RETURN @SoVe;
END

--2. Hàm tính tổng số ghế còn trống trên một chuyến bay
CREATE FUNCTION TongSoGheConTrong(@MaCB CHAR(10))
RETURNS INT
AS
BEGIN
    DECLARE @TongSoGhe INT;
    DECLARE @SoVeDaDat INT;

    -- Lấy tổng số ghế của máy bay
    SELECT @TongSoGhe = MB.TongSoGhe
    FROM MAYBAY MB
    JOIN CHUYENBAY CB ON MB.MaMB = CB.MaMB
    WHERE CB.MaCB = @MaCB;

    -- Lấy tổng số vé đã đặt
    SELECT @SoVeDaDat = COUNT(*)
    FROM VE
    WHERE MaCB = @MaCB;

    -- Trả về số ghế còn trống
    RETURN @TongSoGhe - @SoVeDaDat;
END

--3. Hàm tính tổng tiền vé của một hành khách cho một chuyến bay
CREATE FUNCTION TongTienVeHanhKhach(@MaHK CHAR(10), @MaCB CHAR(10))
RETURNS MONEY
AS
BEGIN
    DECLARE @TongTien MONEY;
    
    SELECT @TongTien = SUM(GiaVe)
    FROM VE
    WHERE MaHK = @MaHK AND MaCB = @MaCB;
    
    RETURN @TongTien;
END

--4. Hàm lấy loại máy bay của một chuyến bay
CREATE FUNCTION LayLoaiMayBay(@MaCB CHAR(10))
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @LoaiMB NVARCHAR(50);

    SELECT @LoaiMB = MB.LoaiMB
    FROM MAYBAY MB
    JOIN CHUYENBAY CB ON MB.MaMB = CB.MaMB
    WHERE CB.MaCB = @MaCB;

    RETURN @LoaiMB;
END

--5. Hàm kiểm tra ghế có còn trống trên một chuyến bay
CREATE FUNCTION KiemTraGheTrong(@MaCB CHAR(10), @ViTriGhe CHAR(10))
RETURNS BIT
AS
BEGIN
    DECLARE @GheTrong BIT;

    IF EXISTS (SELECT 1 FROM VE WHERE MaCB = @MaCB AND ViTriGhe = @ViTriGhe)
    BEGIN
        SET @GheTrong = 0; -- Ghế đã được đặt
    END
    ELSE
    BEGIN
        SET @GheTrong = 1; -- Ghế còn trống
    END

    RETURN @GheTrong;
END

--6. Hàm tính tổng cân hành lý của một hành khách trên chuyến bay
CREATE FUNCTION TongCanHanhLy(@MaHK CHAR(10), @MaCB CHAR(10))
RETURNS FLOAT
AS
BEGIN
    DECLARE @TongCan FLOAT;

    SELECT @TongCan = SUM(SoKG)
    FROM HANHLY
    WHERE MaHK = @MaHK AND MaCB = @MaCB;

    RETURN @TongCan;
END

--7. Hàm lấy đánh giá trung bình của một chuyến bay
CREATE FUNCTION DiemDanhGiaTrungBinh(@MaCB CHAR(10))
RETURNS FLOAT
AS
BEGIN
    DECLARE @DiemTB FLOAT;

    SELECT @DiemTB = AVG(DiemDanhGia)
    FROM NHANXET
    WHERE MaCB = @MaCB;

    RETURN @DiemTB;
END

--8. Hàm kiểm tra tài khoản có phải là nhân viên hay không
CREATE FUNCTION KiemTraNhanVien(@IDTaiKhoan CHAR(20))
RETURNS BIT
AS
BEGIN
    DECLARE @IsNhanVien BIT;

    IF EXISTS (SELECT 1 FROM QLTaiKhoan WHERE IDTaiKhoan = @IDTaiKhoan AND LoaiTK = N'NHANVIEN')
    BEGIN
        SET @IsNhanVien = 1; -- Là nhân viên
    END
    ELSE
    BEGIN
        SET @IsNhanVien = 0; -- Không phải nhân viên
    END

    RETURN @IsNhanVien;
END

-----------------------------------------------------------------------
--						CÀI ĐẶT CÁC TRIGGER
-----------------------------------------------------------------------
--1. Trigger kiểm tra số lượng vé khi thêm mới vé vào bảng VE
--Trigger này sẽ kiểm tra nếu số lượng ghế còn trống đã hết thì không cho phép thêm vé mới.
CREATE TRIGGER KiemTraSoLuongVe
ON VE
FOR INSERT
AS
BEGIN
    DECLARE @MaCB CHAR(10);
    DECLARE @SoVeDaDat INT;
    DECLARE @TongSoGhe INT;

    -- Lấy mã chuyến bay từ bảng được chèn vào
    SELECT @MaCB = MaCB FROM INSERTED;

    -- Lấy tổng số ghế của máy bay và số vé đã đặt
    SELECT @TongSoGhe = MB.TongSoGhe
    FROM MAYBAY MB
    JOIN CHUYENBAY CB ON MB.MaMB = CB.MaMB
    WHERE CB.MaCB = @MaCB;

    SELECT @SoVeDaDat = COUNT(*)
    FROM VE
    WHERE MaCB = @MaCB;

    -- Nếu số vé đã đặt bằng tổng số ghế, thì rollback việc chèn
    IF @SoVeDaDat >= @TongSoGhe
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR(N'Chuyến bay đã hết ghế, không thể đặt thêm vé.', 16, 1);
    END
END;

--2. Trigger cập nhật số ghế còn trống sau khi đặt vé
--Sau khi vé được đặt, trigger này sẽ thực hiện kiểm tra và hiển thị thông báo cảnh báo nếu vé đã hết ghế.
CREATE TRIGGER CapNhatSauDatVe
ON VE
FOR INSERT, DELETE
AS
BEGIN
    DECLARE @MaCB CHAR(10);
    DECLARE @TongSoGhe INT, @SoVeDaDat INT;
    
    -- Lấy mã chuyến bay từ các bản ghi thêm hoặc xóa
    SELECT @MaCB = MaCB FROM INSERTED UNION SELECT @MaCB = MaCB FROM DELETED;

    -- Lấy tổng số ghế của máy bay
    SELECT @TongSoGhe = MB.TongSoGhe
    FROM MAYBAY MB
    JOIN CHUYENBAY CB ON MB.MaMB = CB.MaMB
    WHERE CB.MaCB = @MaCB;

    -- Lấy tổng số vé đã đặt
    SELECT @SoVeDaDat = COUNT(*)
    FROM VE
    WHERE MaCB = @MaCB;

    -- Kiểm tra nếu số vé đã đặt lớn hơn tổng số ghế
    IF @SoVeDaDat > @TongSoGhe
    BEGIN
        RAISERROR(N'Số lượng vé vượt quá số ghế của chuyến bay!', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;

--3. Trigger tự động xóa đánh giá khi hành khách bị xóa
--Khi một hành khách bị xóa, trigger này sẽ tự động xóa các đánh giá liên quan đến hành khách đó.
CREATE TRIGGER XoaNhanXetKhiXoaHanhKhach
ON HANHKHACH
FOR DELETE
AS
BEGIN
    DECLARE @MaHK CHAR(10);

    -- Lấy mã hành khách từ bản ghi bị xóa
    SELECT @MaHK = MaHK FROM DELETED;

    -- Xóa tất cả các nhận xét liên quan đến hành khách đó
    DELETE FROM NHANXET WHERE MaHK = @MaHK;
END;

----4. Trigger tự động cập nhật lương nhân viên khi chức vụ thay đổi
----Nếu chức vụ của một nhân viên thay đổi, trigger này sẽ tự động cập nhật lương của nhân viên dựa trên chức vụ mới.
--CREATE TRIGGER CapNhatLuongKhiThayDoiChucVu
--ON NHANVIEN
--FOR UPDATE
--AS
--BEGIN
--    DECLARE @MaNV CHAR(10), @MaChucVu CHAR(10), @LuongMoi MONEY;

--    -- Lấy mã nhân viên và mã chức vụ mới
--    SELECT @MaNV = MaNV, @MaChucVu = MaChucVu FROM INSERTED;

--    -- Cập nhật lương dựa trên chức vụ mới
--    IF UPDATE(MaChucVu)
--    BEGIN
--        -- Ví dụ: Lương tùy thuộc vào chức vụ
--        IF @MaChucVu = 'CV001'
--            SET @LuongMoi = 20000000;
--        ELSE IF @MaChucVu = 'CV002'
--            SET @LuongMoi = 15000000;
--        ELSE 
--            SET @LuongMoi = 10000000;

--        UPDATE NHANVIEN
--        SET Luong = @LuongMoi
--        WHERE MaNV = @MaNV;
--    END
--END;

--4. Trigger kiểm tra độ tuổi hành khách khi thêm mới
--Trigger này sẽ kiểm tra độ tuổi của hành khách khi thêm mới vào bảng HANHKHACH. Nếu hành khách dưới 18 tuổi, việc thêm mới sẽ bị hủy.
CREATE TRIGGER KiemTraDoTuoiHanhKhach
ON HANHKHACH
FOR INSERT
AS
BEGIN
    DECLARE @NgaySinh DATETIME;
    DECLARE @Tuoi INT;

    -- Lấy ngày sinh của hành khách mới thêm vào
    SELECT @NgaySinh = NgaySinh FROM INSERTED;

    -- Tính tuổi của hành khách
    SET @Tuoi = DATEDIFF(YEAR, @NgaySinh, GETDATE());

    -- Kiểm tra nếu tuổi dưới 18
    IF @Tuoi < 18
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR(N'Hành khách phải đủ 18 tuổi để đăng ký tài khoản.', 16, 1);
    END
END;

--5. Trigger tự động cập nhật trạng thái chuyến bay khi đã đến
--Trigger này sẽ tự động cập nhật trạng thái chuyến bay thành "Đã đến" khi giờ đến (GioDen) đã trôi qua.
CREATE TRIGGER CapNhatTrangThaiChuyenBay
ON CHUYENBAY
FOR UPDATE
AS
BEGIN
    DECLARE @MaCB CHAR(10), @GioDen DATE;

    -- Lấy mã chuyến bay và giờ đến
    SELECT @MaCB = MaCB, @GioDen = GioDen FROM INSERTED;

    -- Kiểm tra nếu giờ hiện tại đã qua giờ đến
    IF @GioDen <= GETDATE()
    BEGIN
        RAISERROR(N'Chuyến bay %s đã đến đích.', 16, 1, @MaCB);
    END
END;

-----------------------------------------------------------------------
--						CÀI ĐẶT CÁC CURSOR
-----------------------------------------------------------------------
--1. Cursor để Duyệt Qua Tất Cả Các Vé Máy Bay
DECLARE @MaVe CHAR(10)
DECLARE @GiaVe MONEY
DECLARE @DonViTien NCHAR(10)
DECLARE @ViTriGhe CHAR(10)
DECLARE @MaCB CHAR(10)
DECLARE @MaHK CHAR(10)
DECLARE @MaDV CHAR(10)

-- Khai báo cursor để lấy thông tin từ bảng VE
DECLARE VeCursor CURSOR FOR
SELECT MaVe, GiaVe, DonViTien, ViTriGhe, MaCB, MaHK, MaDV
FROM VE

OPEN VeCursor

FETCH NEXT FROM VeCursor INTO @MaVe, @GiaVe, @DonViTien, @ViTriGhe, @MaCB, @MaHK, @MaDV

WHILE @@FETCH_STATUS = 0
BEGIN
    -- In ra thông tin vé
    PRINT N'Mã Vé: ' + @MaVe +
          N', Giá Vé: ' + CAST(@GiaVe AS NVARCHAR(50)) +
          N', Đơn Vị Tiền: ' + @DonViTien +
          N', Vị Trí Ghế: ' + @ViTriGhe +
          N', Mã Chuyến Bay: ' + @MaCB +
          N', Mã Hành Khách: ' + @MaHK +
          N', Mã Đặt Vé: ' + @MaDV

    FETCH NEXT FROM VeCursor INTO @MaVe, @GiaVe, @DonViTien, @ViTriGhe, @MaCB, @MaHK, @MaDV
END

CLOSE VeCursor
DEALLOCATE VeCursor

--2. Cursor để tính tổng doanh thu cho từng chuyến bay
DECLARE @MaCB CHAR(10)
DECLARE @TongDoanhThu FLOAT

-- Khai báo cursor để duyệt qua các vé đã đặt
DECLARE DoanhThuCursor CURSOR FOR
SELECT MaCB FROM CHUYENBAY

-- Mở cursor
OPEN DoanhThuCursor

-- Lấy từng bản ghi từ cursor
FETCH NEXT FROM DoanhThuCursor INTO @MaCB

-- Duyệt qua tất cả các bản ghi
WHILE @@FETCH_STATUS = 0
BEGIN
	-- Tính tổng doanh thu
    SELECT @TongDoanhThu = SUM(ThanhTien)
    FROM DATVE
    WHERE MaCB = @MaCB

	-- In ra tổng doanh thu
    PRINT 'Chuyến bay: ' + @MaCB + ' - Tổng doanh thu: ' + CAST(@TongDoanhThu AS NVARCHAR(50))

	-- Lấy bản ghi tiếp theo
    FETCH NEXT FROM DoanhThuCursor INTO @MaCB
END

-- Đóng và giải phóng cursor
CLOSE DoanhThuCursor
DEALLOCATE DoanhThuCursor

--3. Cursor để cập nhật thông tin hành lý ký gửi cho từng hành khách
DECLARE @MaHK CHAR(10)
DECLARE @MaCB CHAR(10)
DECLARE @SoKG FLOAT

DECLARE HanhLyCursor CURSOR FOR
SELECT hk.MaHK, hl.MaCB, hl.SoKG
FROM HANHKHACH hk
JOIN HANHLY hl ON hk.MaHK = hl.MaHK

OPEN HanhLyCursor

FETCH NEXT FROM HanhLyCursor INTO @MaHK, @MaCB, @SoKG

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Cập nhật thông tin hành lý ký gửi hoặc thực hiện tác vụ khác
    UPDATE HANHLY
    SET SoKG = SoKG + 5 -- Ví dụ: tăng thêm 5 kg
    WHERE MaHK = @MaHK AND MaCB = @MaCB

    PRINT 'Cập nhật hành lý cho hành khách: ' + @MaHK + ' trên chuyến bay: ' + @MaCB

    FETCH NEXT FROM HanhLyCursor INTO @MaHK, @MaCB, @SoKG
END

CLOSE HanhLyCursor
DEALLOCATE HanhLyCursor

--4. Cursor để ghi nhận thông tin đánh giá cho từng chuyến bay
DECLARE @MaCB CHAR(10)
DECLARE @DiemDanhGia FLOAT

DECLARE DanhGiaCursor CURSOR FOR
SELECT MaCB, AVG(DiemDanhGia)
FROM NHANXET
GROUP BY MaCB

OPEN DanhGiaCursor

FETCH NEXT FROM DanhGiaCursor INTO @MaCB, @DiemDanhGia

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Cập nhật thông tin đánh giá vào một bảng hoặc thực hiện tác vụ khác
    PRINT 'Chuyến bay: ' + @MaCB + ' - Điểm đánh giá trung bình: ' + CAST(@DiemDanhGia AS NVARCHAR(50))

    FETCH NEXT FROM DanhGiaCursor INTO @MaCB, @DiemDanhGia
END

CLOSE DanhGiaCursor
DEALLOCATE DanhGiaCursor

--5. Cursor để thống kê số lượng vé hủy cho từng chuyến bay
DECLARE @MaCB CHAR(10)
DECLARE @SoVeHuy INT

DECLARE VeHuyCursor CURSOR FOR
SELECT MaCB FROM CHUYENBAY

OPEN VeHuyCursor

FETCH NEXT FROM VeHuyCursor INTO @MaCB

WHILE @@FETCH_STATUS = 0
BEGIN
    SELECT @SoVeHuy = COUNT(*)
    FROM DATVE
    WHERE MaCB = @MaCB AND TrangThai = 'Hủy' -- Cần đảm bảo cột TrangThai có trong bảng DATVE

    PRINT 'Chuyến bay: ' + @MaCB + ' - Số vé đã hủy: ' + CAST(@SoVeHuy AS NVARCHAR(10))

    FETCH NEXT FROM VeHuyCursor INTO @MaCB
END

CLOSE VeHuyCursor
DEALLOCATE VeHuyCursor


----5. Cursor để duyệt qua nhận xét của hành khách và cập nhật điểm đánh giá trung bình
----Cursor này sẽ duyệt qua bảng NHANXET để tính điểm đánh giá trung bình của các chuyến bay.
--DECLARE @MaCB CHAR(10), @TongDiem INT, @SoNhanXet INT, @DiemTB FLOAT;

---- Khai báo cursor để duyệt qua các chuyến bay trong bảng nhận xét
--DECLARE NhanXetCursor CURSOR FOR
--SELECT MaCB
--FROM NHANXET
--GROUP BY MaCB;

---- Mở cursor
--OPEN NhanXetCursor;

---- Lấy từng bản ghi từ cursor
--FETCH NEXT FROM NhanXetCursor INTO @MaCB;

---- Duyệt qua tất cả các bản ghi
--WHILE @@FETCH_STATUS = 0
--BEGIN
--    -- Tính tổng điểm và số lượng nhận xét cho chuyến bay
--    SELECT @TongDiem = SUM(DiemDanhGia), @SoNhanXet = COUNT(*)
--    FROM NHANXET
--    WHERE MaCB = @MaCB;

--    -- Tính điểm trung bình
--    SET @DiemTB = CAST(@TongDiem AS FLOAT) / @SoNhanXet;

--    -- In ra thông tin chuyến bay và điểm đánh giá trung bình
--    PRINT 'Chuyến bay: ' + @MaCB + ', Điểm đánh giá trung bình: ' + CAST(@DiemTB AS NVARCHAR);
    
--    -- Lấy bản ghi tiếp theo
--    FETCH NEXT FROM NhanXetCursor INTO @MaCB;
--END;

---- Đóng và giải phóng cursor
--CLOSE NhanXetCursor;
--DEALLOCATE NhanXetCursor;

-----------------------------------------------------------------------
--						MÔ TẢ YÊU CẦU THỐNG KÊ
-----------------------------------------------------------------------
--1. Thống kê số lượng vé bán ra theo chuyến bay
SELECT 
    cb.MaCB,
    sb1.TenSB AS SBDi,
    sb2.TenSB AS SBDen,
    cb.NgayBay,
    COUNT(dv.MaDV) AS SoVeDaBan
FROM 
    CHUYENBAY cb
LEFT JOIN 
    DATVE dv ON cb.MaCB = dv.MaCB
LEFT JOIN 
    SANBAY sb1 ON cb.MaSBdi = sb1.MaSB
LEFT JOIN 
    SANBAY sb2 ON cb.MaSBden = sb2.MaSB
GROUP BY 
    cb.MaCB, sb1.TenSB, sb2.TenSB, cb.NgayBay;

--2. Thống kê doanh thu từ vé bán ra
SELECT 
    MONTH(dv.NgayDatVe) AS Thang,
    YEAR(dv.NgayDatVe) AS Nam,
    SUM(dv.ThanhTien) AS TongDoanhThu
FROM 
    DATVE dv
GROUP BY 
    MONTH(dv.NgayDatVe), YEAR(dv.NgayDatVe)
ORDER BY 
    Nam, Thang;

--3. Thống kê số lượng ghế trống trên mỗi chuyến bay
SELECT 
    cb.MaCB,
    mb.TongSoGhe,
    COUNT(dv.MaDV) AS SoVeDaBan,
    (mb.TongSoGhe - COUNT(dv.MaDV)) AS SoGheTrong
FROM 
    CHUYENBAY cb
JOIN 
    MAYBAY mb ON cb.MaMB = mb.MaMB
LEFT JOIN 
    DATVE dv ON cb.MaCB = dv.MaCB
GROUP BY 
    cb.MaCB, mb.TongSoGhe;

--4. Thống kê hành khách theo sân bay
SELECT 
    sb.TenSB,
    COUNT(hk.MaHK) AS TongHanhKhach
FROM 
    HANHKHACH hk
JOIN 
    DATVE dv ON hk.MaHK = dv.MaHK
JOIN 
    CHUYENBAY cb ON dv.MaCB = cb.MaCB
JOIN 
    SANBAY sb ON cb.MaSBdi = sb.MaSB
GROUP BY 
    sb.TenSB;

--5. Thống kê đánh giá của hành khách
SELECT 
    cb.MaCB,
    AVG(nx.DiemDanhGia) AS DiemDanhGiaTrungBinh,
    COUNT(nx.MaHK) AS SoLuongDanhGia
FROM 
    NHANXET nx
JOIN 
    CHUYENBAY cb ON nx.MaCB = cb.MaCB
GROUP BY 
    cb.MaCB;

--6. Thống kê hành lý ký gửi
SELECT 
    cb.MaCB,
    SUM(hl.SoKG) AS TongTrongLuongHanhLy
FROM 
    HANHLY hl
JOIN 
    CHUYENBAY cb ON hl.MaCB = cb.MaCB
GROUP BY 
    cb.MaCB;

----6. Thống kê hành lý ký gửi theo chuyến bay
----Yêu cầu: Thống kê tổng trọng lượng hành lý đã ký gửi trên mỗi chuyến bay và số lượng hành lý
---- Tổng trọng lượng hành lý trên mỗi chuyến bay
--SELECT MaCB, SUM(SoKG) AS TongTrongLuongHanhLy
--FROM HANHLY
--GROUP BY MaCB;

---- Số lượng hành lý ký gửi theo chuyến bay
--SELECT MaCB, COUNT(MaHL) AS SoLuongHanhLy
--FROM HANHLY
--GROUP BY MaCB;

--7. Thống kê doanh thu theo phương thức thanh toán
SELECT 
    dv.PhươngThứcThanhToán, -- Cột này cần có trong bảng DATVE
    SUM(dv.ThanhTien) AS TongDoanhThu
FROM 
    DATVE dv
GROUP BY 
    dv.PhươngThứcThanhToán;

--8. Thống kê tỷ lệ hủy vé
sql
Sao chép mã
SELECT 
    cb.MaCB,
    COUNT(dv.MaDV) AS TongVeDaBan,
    COUNT(CASE WHEN dv.TrangThai = N'Hủy' THEN 1 END) AS TongVeBiHuy,
    (COUNT(CASE WHEN dv.TrangThai = N'Hủy' THEN 1 END) * 1.0 / COUNT(dv.MaDV)) * 100 AS TyLeHuy
FROM 
    CHUYENBAY cb
LEFT JOIN 
    DATVE dv ON cb.MaCB = dv.MaCB
GROUP BY 
    cb.MaCB;

-----------------------------------------------------------------------
--					  XÂY DỰNG CÁC CẤU TRÚC VIEW
-----------------------------------------------------------------------
--1. View: Thông tin chi tiết về chuyến bay

--Thông tin chi tiết về chuyến bay, bao gồm loại máy bay, hãng, và ngày giờ bay.
CREATE VIEW V_ThongTinChuyenBay AS
SELECT 
    cb.MaCB, 
    cb.GioBay, 
    cb.GioDen, 
    mb.LoaiMB, 
    mb.Hang AS HangMayBay, 
    sb_di.TenSB AS SanBayDi, 
    sb_den.TenSB AS SanBayDen
FROM CHUYENBAY cb
JOIN MAYBAY mb ON cb.MaMB = mb.MaMB
JOIN CHANGBAY chb ON cb.MaChB = chb.MaChB
JOIN SANBAY sb_di ON chb.MaSBdi = sb_di.MaSB
JOIN SANBAY sb_den ON chb.MaSBden = sb_den.MaSB;

--2. View: Thông tin vé đã bán và hành khách

--Thông tin về vé bán ra, kèm theo thông tin hành khách tương ứng và chuyến bay.
CREATE VIEW V_VeBanRaHanhKhach AS
SELECT 
    v.MaVe, 
    v.GiaVe, 
    v.DonViTien, 
    v.ViTriGhe, 
    hk.TenHK, 
    hk.SDT, 
    cb.MaCB, 
    cb.GioBay, 
    sb_di.TenSB AS SanBayDi, 
    sb_den.TenSB AS SanBayDen
FROM VE v
JOIN HANHKHACH hk ON v.MaHK = hk.MaHK
JOIN CHUYENBAY cb ON v.MaCB = cb.MaCB
JOIN CHANGBAY chb ON cb.MaChB = chb.MaChB
JOIN SANBAY sb_di ON chb.MaSBdi = sb_di.MaSB
JOIN SANBAY sb_den ON chb.MaSBden = sb_den.MaSB;

--3. View: Thống kê số lượng vé đã bán và ghế trống trên mỗi chuyến bay

--Thống kê số lượng vé đã bán và số lượng ghế còn trống trên mỗi chuyến bay.
CREATE VIEW V_ThongKeVeVaGheTrenChuyenBay AS
SELECT 
    cb.MaCB, 
    COUNT(v.MaVe) AS SoVeDaBan, 
    (mb.TongSoGhe - COUNT(v.MaVe)) AS SoGheTrong
FROM CHUYENBAY cb
JOIN MAYBAY mb ON cb.MaMB = mb.MaMB
LEFT JOIN VE v ON cb.MaCB = v.MaCB
GROUP BY cb.MaCB, mb.TongSoGhe;

--4. View: Doanh thu theo chuyến bay

--Tính toán tổng doanh thu từ vé bán ra cho mỗi chuyến bay.
CREATE VIEW V_DoanhThuTheoChuyenBay AS
SELECT 
    cb.MaCB, 
    SUM(v.GiaVe) AS TongDoanhThu
FROM VE v
JOIN CHUYENBAY cb ON v.MaCB = cb.MaCB
GROUP BY cb.MaCB;

--5. View: Thống kê hành khách và số lượng hành lý ký gửi trên chuyến bay

--Thông tin hành khách cùng với số lượng và trọng lượng hành lý ký gửi trên chuyến bay.
CREATE VIEW V_ThongKeHanhLyTheoChuyenBay AS
SELECT 
    cb.MaCB, 
    hk.MaHK, 
    hk.TenHK, 
    COUNT(hl.MaHL) AS SoLuongHanhLy, 
    SUM(hl.SoKG) AS TongTrongLuongHanhLy
FROM HANHKHACH hk
JOIN HANHLY hl ON hk.MaHK = hl.MaHK
JOIN CHUYENBAY cb ON hl.MaCB = cb.MaCB
GROUP BY cb.MaCB, hk.MaHK, hk.TenHK;

--6. View: Thống kê số lượng vé bán ra theo sân bay

--Tính toán số lượng vé đã bán theo từng sân bay đi.
CREATE VIEW V_ThongKeVeTheoSanBay AS
SELECT 
    sb.TenSB AS SanBayDi, 
    COUNT(v.MaVe) AS SoVeDaBan
FROM VE v
JOIN CHUYENBAY cb ON v.MaCB = cb.MaCB
JOIN CHANGBAY chb ON cb.MaChB = chb.MaChB
JOIN SANBAY sb ON chb.MaSBdi = sb.MaSB
GROUP BY sb.TenSB;

--7. View: Thống kê đánh giá của hành khách về chuyến bay

--Tính toán điểm đánh giá trung bình và số lượng nhận xét của hành khách trên mỗi chuyến bay.
CREATE VIEW V_ThongKeDanhGiaChuyenBay AS
SELECT 
    cb.MaCB, 
    AVG(nx.DiemDanhGia) AS DiemDanhGiaTrungBinh, 
    COUNT(nx.MaHK) AS SoLuongNhanXet
FROM NHANXET nx
JOIN CHUYENBAY cb ON nx.MaCB = cb.MaCB
GROUP BY cb.MaCB;

--8. View: Thống kê doanh thu vé theo tháng, quý, năm
--Tính toán doanh thu từ vé bán ra theo từng tháng, quý, năm.

--View doanh thu theo tháng:
CREATE VIEW V_DoanhThuTheoThang AS
SELECT 
    YEAR(v.GioBay) AS Nam, 
    MONTH(v.GioBay) AS Thang, 
    SUM(v.GiaVe) AS DoanhThu
FROM VE v
JOIN CHUYENBAY cb ON v.MaCB = cb.MaCB
GROUP BY YEAR(v.GioBay), MONTH(v.GioBay);

--View doanh thu theo quý:
CREATE VIEW V_DoanhThuTheoQuy AS
SELECT 
    YEAR(v.GioBay) AS Nam, 
    CEILING(MONTH(v.GioBay)/3.0) AS Quy, 
    SUM(v.GiaVe) AS DoanhThu
FROM VE v
JOIN CHUYENBAY cb ON v.MaCB = cb.MaCB
GROUP BY YEAR(v.GioBay), CEILING(MONTH(v.GioBay)/3.0);

