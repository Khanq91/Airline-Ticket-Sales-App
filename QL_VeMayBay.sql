CREATE DATABASE QL_VeMayBay
USE QL_VeMayBay

CREATE TABLE SANBAY 
(
	ID INT NOT NULL IDENTITY(1,1),
	MaSanBay CHAR(6) NOT NULL,
	TenSB NVARCHAR(50),
	CONSTRAINT PK_SB_IDSanBay PRIMARY KEY(ID)
);

CREATE TABLE MAYBAY
(
	ID INT NOT NULL IDENTITY(1,1),
	MaMayBay CHAR(12) NOT NULL,
	LoaiMB NVARCHAR(50),
	HangBay NVARCHAR(50),
	TongSoGhe INT,
	CONSTRAINT PK_MB_IDMayBay PRIMARY KEY(ID)
);

CREATE TABLE CHANGBAY
(
	ID INT NOT NULL IDENTITY(1,1),
	MaChangBay CHAR(12),
	IDSanBaydi INT NOT NULL,
	IDSanBayden INT NOT NULL,                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
	CONSTRAINT PK_ChB_IDChangBay PRIMARY KEY(ID),
	CONSTRAINT FK_ChB_IDSanBaydi FOREIGN KEY(IDSanBaydi) REFERENCES SANBAY(ID) ON DELETE NO ACTION,
    CONSTRAINT FK_ChB_IDSanBayden FOREIGN KEY(IDSanBayden) REFERENCES SANBAY(ID) ON DELETE NO ACTION
);

CREATE TABLE QLTaiKhoan
(
	ID INT NOT NULL IDENTITY(1,1),
	MaTaiKhoan CHAR(12),
	TenTaiKhoan NVARCHAR(50) NOT NULL,
    TenDangNhap VARCHAR(50) NOT NULL,
	MatKhau VARCHAR(50) NOT NULL,
	LoaiTaiKhoan NVARCHAR(30) NOT NULL CHECK (LoaiTaiKhoan IN (N'Quản lý', N'Nhân viên')), 
	CONSTRAINT PK_TK_IDTaiKhoan PRIMARY KEY(ID)
);

CREATE TABLE NHANVIEN 
(
	ID INT NOT NULL IDENTITY(1,1),
	MaNhanVien CHAR(12),
	TenNV NVARCHAR(50) NOT NULL,
	GioiTinhNV NVARCHAR(4) CHECK(GioiTinhNV IN (N'Nam', N'Nữ')),
	LuongNV MONEY NOT NULL,
	NgaySinhNV DATE NOT NULL,
	DiaChiNV NVARCHAR(50),
	SDTnv VARCHAR(11) CHECK (SDTnv LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	ChucVu NVARCHAR(30) CHECK (ChucVu IN (N'Nhân viên', N'Quản lý')),
	IDSanBay INT NOT NULL,
	IDTaiKhoan INT NOT NULL,
	CONSTRAINT PK_NV_IDNhanVien PRIMARY KEY(ID),
	CONSTRAINT FK_NV_IDSanBay FOREIGN KEY(IDSanBay) REFERENCES SANBAY(ID) ON DELETE NO ACTION,
	CONSTRAINT FK_NV_IDtk FOREIGN KEY(IDTaiKhoan) REFERENCES QLTaiKhoan(ID) ON DELETE NO ACTION
);

CREATE TABLE TUYENBAY
(
	ID INT NOT NULL IDENTITY(1,1),
	MaTuyenBay CHAR(12),
	NgayBay DATE NOT NULL,  
	GioBay TIME NOT NULL,
	GioDen TIME NOT NULL,
	ThoiGianBay TIME,
	SoVeConLai INT,                  
	SoVeDaBan INT DEFAULT 0,
    TrangThaiTuyenBay NVARCHAR(10),           -- Tình trạng vé (VD: 'Còn vé', 'Hết vé')
	IDMayBay INT NOT NULL,
	IDChangBay INT NOT NULL,
	CONSTRAINT PK_tb_IDTuyenBay PRIMARY KEY(ID),
	CONSTRAINT FK_tb_IDMayBay FOREIGN KEY(IDMayBay) REFERENCES MAYBAY(ID),
	CONSTRAINT FK_tb_IDChangBay FOREIGN KEY(IDChangBay) REFERENCES CHANGBAY(ID) ON DELETE NO ACTION
);

CREATE TABLE HANHKHACH 
(
	ID INT NOT NULL IDENTITY(1,1),
	MaHanhKhach CHAR(12),
	TenHK NVARCHAR(50) NOT NULL,      
	GioiTinhHK NVARCHAR(4) CHECK(GioiTinhHK IN (N'Nam', N'Nữ')),
	NgaySinhHK DATE NOT NULL,    
	DiaChiHK NVARCHAR(50) NOT NULL,     
	EmailHK VARCHAR(30) NOT NULL,       
	SDThk CHAR(11) CHECK (SDThk LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	CCCD CHAR(20) UNIQUE NOT NULL,    
	CONSTRAINT PK_HK_IDHanhKhach PRIMARY KEY(ID),
);

CREATE TABLE VE 
(
	ID INT NOT NULL IDENTITY(1,1),
	MaVe CHAR(12),
	GiaVeCoBan MONEY,
	HangVe NVARCHAR(50) NOT NULL,
	DonViTien NCHAR(10),
	ViTriGhe CHAR(10),
	NgayGIAVE DATE,
	IDHanhKhach INT NOT NULL, 
	CONSTRAINT PK_VE_STTve PRIMARY KEY(ID),
	CONSTRAINT FK_VE_IDHanhKhach FOREIGN KEY(IDHanhKhach) REFERENCES HANHKHACH(ID) ON DELETE NO ACTION,
);

CREATE TABLE HANHLY 
(
	ID INT NOT NULL IDENTITY(1,1),
    MaHanhLy CHAR(12), 
    SoKG FLOAT NOT NULL,
    LoaiHanhLy NVARCHAR(30) CHECK (LoaiHanhLy IN (N'Hành lý ký gửi', N'Hành lý xách tay')), 
	Igve INT NOT NULL,
    IDHanhKhach INT NOT NULL,
    IDTuyenBay INT NOT NULL,
    CONSTRAINT PK_HL_IDHanhLy PRIMARY KEY(ID),
	CONSTRAINT FK_HL_Igve FOREIGN KEY(Igve) REFERENCES VE(ID) ON DELETE NO ACTION,
    CONSTRAINT FK_HL_IDHanhKhach FOREIGN KEY(IDHanhKhach) REFERENCES HANHKHACH(ID) ON DELETE NO ACTION, 
    CONSTRAINT FK_HL_IDTuyenBay FOREIGN KEY(IDTuyenBay) REFERENCES TUYENBAY(ID) ON DELETE NO ACTION
);

CREATE TABLE CHITIETPHUPHI
(
	ID INT NOT NULL IDENTITY(1,1),
	MaPhuPhi CHAR(12),
	PhuPhi MONEY DEFAULT 0,
	LoaiPhuPhi NVARCHAR(50) NOT NULL,  -- Thêm loại phụ phí(phụ phí của hành lý hoặc phụ phí của dịch vụ (nếu có))
	IDHanhLy INT NOT NULL,
	CONSTRAINT PK_CTPhuPhi_IDPhuPhi PRIMARY KEY(ID),
	CONSTRAINT FK_CTPhuPhi_IDHanhLy FOREIGN KEY(IDHanhLy) REFERENCES HANHLY(ID) ON DELETE NO ACTION
);

CREATE TABLE HOADON
(
	ID INT NOT NULL IDENTITY(1,1),
    MaHoaDon CHAR(12),         
	--	SoVeDat INT DEFAULT 0,
    NgayLapHoaDon DATE NOT NULL,                    
    TongTien MONEY DEFAULT 0,                    
    HinhThucThanhToan NVARCHAR(20),    -- Hình thức thanh toán (VD: 'Tiền mặt', 'Chuyển khoản')
	TrangThaiHoaDon NVARCHAR(20) CHECK (TrangThaiHoaDon IN (N'Đã thanh toán', N'Chưa thanh toán', N'Đã hoàn tiền')),  -- Trạng thái thanh toán
	IDHanhKhach INT NOT NULL,
    CONSTRAINT PK_HD_IDHoaDon PRIMARY KEY(ID),
	CONSTRAINT FK_HD_IDHanhKhach FOREIGN KEY(IDHanhKhach) REFERENCES HANHKHACH(ID) ON DELETE NO ACTION,
);

CREATE TABLE GIAVE
(
	ID INT NOT NULL IDENTITY(1,1),
	MaGiaVe CHAR(12),
	TongGiaVe MONEY DEFAULT 0,
	GiamGia DECIMAL(3, 2),
	Thue MONEY,
	Igve INT NOT NULL,
	IDPhuPhi INT NOT NULL,
	IDHoaDon INT NOT NULL,
	IDTuyenBay INT NOT NULL,
	CONSTRAINT PK_GV_IDGiaVe PRIMARY KEY(ID),
	CONSTRAINT FK_GV_Igve FOREIGN KEY (Igve) REFERENCES VE(ID) ON DELETE NO ACTION,
	CONSTRAINT FK_GV_IDPhuPhi FOREIGN KEY (IDPhuPhi) REFERENCES CHITIETPHUPHI(ID) ON DELETE NO ACTION,
	CONSTRAINT FK_GV_IDHoaDon FOREIGN KEY (IDHoaDon) REFERENCES HOADON(ID) ON DELETE NO ACTION,
	CONSTRAINT FK_GV_IDTuyenBay FOREIGN KEY(IDTuyenBay) REFERENCES TUYENBAY(ID) ON DELETE NO ACTION,
);

CREATE TABLE NHANXET
(
	IDHanhKhach INT NOT NULL,
	IDTuyenBay INT NOT NULL,
	NoiDungNhanXet NVARCHAR(100),
	DiemDanhGia INT CHECK (DiemDanhGia BETWEEN 1 AND 5),
	CONSTRAINT PK_NX_IDHanhKhach_IDTuyenBay PRIMARY KEY(IDHanhKhach, IDTuyenBay),
	CONSTRAINT FK_NX_IDHanhKhach FOREIGN KEY(IDHanhKhach) REFERENCES HANHKHACH(ID) ON DELETE NO ACTION,
	CONSTRAINT FK_NX_IDTuyenBay FOREIGN KEY(IDTuyenBay) REFERENCES TUYENBAY(ID) ON DELETE NO ACTION
);

-----------------------------------------------------------------------
--								DỮ LIỆU
-----------------------------------------------------------------------
INSERT INTO SANBAY (MaSanBay, TenSB)
VALUES 
    ('SB001', N'Sân bay Tân Sơn Nhất'),
    ('SB002', N'Sân bay Nội Bài'),
    ('SB003', N'Sân bay Đà Nẵng'),
    ('SB004', N'Sân bay Cam Ranh'),
    ('SB005', N'Sân bay Phú Quốc');

INSERT INTO MAYBAY (MaMayBay, LoaiMB, HangBay, TongSoGhe)
VALUES 
    ('VN-A123', N'Airbus A320', N'VietJet Air', 180),
    ('VN-B123', N'Boeing 787', N'Vietnam Airlines', 300),
    ('VN-C123', N'Airbus A321', N'Bamboo Airways', 220),
    ('VN-D123', N'Boeing 777', N'Vietnam Airlines', 350),
    ('VN-E123', N'Airbus A330', N'Bamboo Airways', 260);

INSERT INTO CHANGBAY (IDSanBaydi, IDSanBayden) 
VALUES
	(1, 2),
	(2, 3),
	(3, 4),
	(4, 5),
	(5, 1);

INSERT INTO QLTaiKhoan (TenTaiKhoan, TenDangNhap, MatKhau, LoaiTaiKhoan)
VALUES 
    (N'Nguyễn Văn A', 'nguyenvana', 'password123', N'Quản lý'),
    (N'Trần Thị B', 'tranthib', 'password456', N'Nhân viên'),
    (N'Lê Văn C', 'levanc', 'pass789', N'Nhân viên'),
    (N'Phạm Thị D', 'phamthid', 'secret123', N'Nhân viên'),
    (N'Hoàng Văn E', 'hoangvane', 'secure456', N'Nhân viên');

INSERT INTO NHANVIEN (TenNV, GioiTinhNV, LuongNV, NgaySinhNV, DiaChiNV, SDTnv, ChucVu, IDSanBay, IDTaiKhoan) 
VALUES 
	(N'Nguyễn Văn A', N'Nam', 15000000, '1985-05-12', N'123 Đường ABC', '0912345678', N'Quản lý', 1, 1),
	(N'Trần Thị B', N'Nữ', 18000000, '1990-10-22', N'456 Đường DEF', '0912345679', N'Nhân viên', 2, 2),
	(N'Lê Văn C', N'Nam', 16000000, '1988-08-15', N'789 Đường GHI', '0912345680', N'Nhân viên', 3, 3),
	(N'Phạm Thị D', N'Nữ', 17000000, '1992-03-20', N'321 Đường JKL', '0912345681', N'Nhân viên', 4, 4),
	(N'Hoàng Văn E', N'Nam', 15500000, '1986-06-30', N'654 Đường MNO', '0912345682', N'Nhân viên', 5, 5);

INSERT INTO TUYENBAY (NgayBay, GioBay, GioDen, SoVeConLai, SoVeDaBan, TrangThaiTuyenBay, IDMayBay, IDChangBay)
VALUES 
	('2024-10-30', '08:00', '10:00', 180, 0, N'Còn vé', 4, 1),
    ('2024-11-01', '14:30', '16:45', 300, 0, N'Còn vé', 5, 2),
	('2024-11-02', '10:15', '12:00', 220, 0, N'Còn vé', 1, 3),
    ('2024-11-03', '15:00', '17:00', 350, 0, N'Còn vé', 2, 4),
    ('2024-11-04', '18:00', '20:00', 260, 0, N'Còn vé', 3, 5);

INSERT INTO HANHKHACH (TenHK, GioiTinhHK, NgaySinhHK, DiaChiHK, EmailHK, SDThk, CCCD) 
VALUES 
    (N'Nguyễn Văn F', N'Nam', '1990-01-01', N'Thành phố Hồ Chí Minh', 'f.nguyen@example.com', '0909123456', '0123456789'),
    (N'Trần Thị G', N'Nữ', '1992-02-02', N'Bến Tre', 'g.tran@example.com', '0912123456', '9876543210'),
	(N'Lê Văn H', N'Nam', '1988-03-03', N'Phú Quốc', 'h.le@example.com', '0903123456', '1234567890'),
    (N'Phạm Thị K', N'Nữ', '1991-04-04', N'Tiền Giang', 'k.pham@example.com', '0918123456', '0987654321'),
    (N'Hoàng Văn L', N'Nam', '1985-05-05', N'Yên Bái', 'l.hoang@example.com', '0904123456', '2345678901');

--INSERT INTO HANHLY (SoKG, LoaiHanhLy, MaHangVe, IDHanhKhach, IDTuyenBay)
--VALUES 
--	(26.5, N'Hành lý ký gửi', 'HV001', 1, 1),
--    (10.0, N'Hành lý xách tay', 'HV002', 2, 2),
--    (15.0, N'Hành lý ký gửi', 'HV001', 3, 3),
--    (20.0, N'Hành lý xách tay', 'HV002', 4, 4),
--    (25.0, N'Hành lý ký gửi', 'HV001', 5, 5);

--INSERT INTO CHITIETPHUPHI (PhuPhi, LoaiPhuPhi, IDHanhLy)
--VALUES 
--	(0, N'Phụ phí hành lý', 1),
--    (0, N'Phụ phí hành lý', 2),
--    (0, N'Phụ phí hành lý', 3),
--    (0, N'Phụ phí hành lý', 4),
--    (0, N'Phụ phí hành lý', 5);

--INSERT INTO GIAVE (GiaCoBan, TongGiaVe, GiamGia, IDPhuPhi, IDTuyenBay, MaHangVe)
--VALUES 
--    (1500000, 1500000, 0, 1, 1, 'HV001'),
--    (800000, 800000, 0, 2, 2, 'HV002'),
--    (1200000, 1200000, 100000, 3, 3, 'HV001'),
--    (700000, 700000, 0, 4, 4, 'HV002'),
--    (1300000, 1300000, 200000, 5, 5, 'HV001');

--INSERT INTO HOADON (NgayLapHoaDon, TongTien, HinhThucThanhToan, TrangThai, IDGiaVe)
--VALUES 
--    ('2024-10-09', 3000000, N'Tiền mặt', N'Đã thanh toán', 1),
--    ('2024-10-09', 1600000, N'Chuyển khoản', N'Chưa thanh toán', 2),
--    ('2024-10-09', 2400000, N'Tiền mặt', N'Đã hoàn tiền', 3),
--    ('2024-10-09', 1200000, N'Tiền mặt', N'Đã thanh toán', 4),
--    ('2024-10-09', 2600000, N'Chuyển khoản', N'Đã thanh toán', 5);

--INSERT INTO VE (DonViTien, ViTriGhe, IDHanhKhach, IDGiaVe, IDGiaVe)
--VALUES 
--    (N'VND', '1A', 1, 1, 1),
--    (N'VND', '1B', 2, 2, 2),
--    (N'VND', '1C', 3, 3, 3),
--    (N'VND', '2A', 4, 4, 4),
--    (N'VND', '2B', 5, 5, 5);

--INSERT INTO NHANXET (IDHanhKhach, IDTuyenBay, NoiDungNhanXet, DiemDanhGia)
--VALUES 
--    (1, 1, N'Chuyến bay rất tốt, nhân viên thân thiện.', 5),
--    (2, 2, N'Thời gian bay không đúng lịch trình.', 3),
--    (3, 3, N'Hành lý xách tay hơi ít, nhưng chất lượng tốt.', 4),
--    (4, 4, N'Dịch vụ tốt nhưng cần cải thiện độ trễ.', 4),
--    (5, 5, N'Thích hợp với giá tiền.', 5);

-----------------------------------------------------------------------
--								CHANGBAY
-----------------------------------------------------------------------

CREATE TRIGGER trg_AutoMaChangBay
ON CHANGBAY
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @currentMonthYear CHAR(6) = CONVERT(CHAR(6), GETDATE(), 112), -- Lấy tháng năm hiện tại
			@nextID INT,
			@newMaChangBay CHAR(12),
			@IDSanBaydi INT,
			@IDSanBayden INT; 

    -- Lấy số ID lớn nhất hiện có để tính số tiếp theo
    SELECT @nextID = ISNULL(MAX(CAST(SUBSTRING(MaChangBay, 9, 3) AS INT)), 0) + 1
    FROM CHANGBAY
    WHERE MaChangBay LIKE 'tb' + @currentMonthYear + '%';

    -- Duyệt từng bản ghi trong inserted để chèn với MaChangBay tăng dần
    DECLARE cur CURSOR FOR
    SELECT IDSanBaydi, IDSanBayden FROM inserted;

    OPEN cur;
    FETCH NEXT FROM cur INTO @IDSanBaydi, @IDSanBayden;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Tạo MaChangBay mới với tiền tố "tb"
        SET @newMaChangBay = 'tb' + @currentMonthYear + RIGHT('000' + CAST(@nextID AS VARCHAR(3)), 3);
        
        -- Chèn dữ liệu mới vào bảng CHANGBAY
        INSERT INTO CHANGBAY (MaChangBay, IDSanBaydi, IDSanBayden)
        VALUES (@newMaChangBay, @IDSanBaydi, @IDSanBayden);

        -- Tăng nextID để mã tiếp theo sẽ tăng dần
        SET @nextID = @nextID + 1;

        FETCH NEXT FROM cur INTO @IDSanBaydi, @IDSanBayden;
    END

    CLOSE cur;
    DEALLOCATE cur;
END

-----------------------------------------------------------------------
--								QLTaiKhoan
-----------------------------------------------------------------------

CREATE TRIGGER trg_AutoMaTaiKhoan
ON QLTaiKhoan
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @currentMonthYear CHAR(6) = CONVERT(CHAR(6), GETDATE(), 112), -- Lấy tháng năm hiện tại
			@nextID INT,
			@newMaTaiKhoan CHAR(12),
			@TenTaiKhoan NVARCHAR(50),
			@TenDangNhap VARCHAR(50),
			@MatKhau VARCHAR(50),
			@LoaiTaiKhoan NVARCHAR(30); 

    SELECT @nextID = ISNULL(MAX(CAST(SUBSTRING(MaTaiKhoan, 9, 3) AS INT)), 0) + 1
    FROM QLTaiKhoan
    WHERE MaTaiKhoan LIKE 'TK' + @currentMonthYear + '%';

    DECLARE cur CURSOR FOR
    SELECT TenTaiKhoan, TenDangNhap, MatKhau, LoaiTaiKhoan FROM inserted;

    OPEN cur;
    FETCH NEXT FROM cur INTO @TenTaiKhoan, @TenDangNhap, @MatKhau, @LoaiTaiKhoan;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @newMaTaiKhoan = 'TK' + @currentMonthYear + RIGHT('000' + CAST(@nextID AS VARCHAR(3)), 3);
        
        INSERT INTO QLTaiKhoan (MaTaiKhoan, TenTaiKhoan, TenDangNhap, MatKhau, LoaiTaiKhoan)
        VALUES (@newMaTaiKhoan, @TenTaiKhoan, @TenDangNhap, @MatKhau, @LoaiTaiKhoan);

        SET @nextID = @nextID + 1;

        FETCH NEXT FROM cur INTO @TenTaiKhoan, @TenDangNhap, @MatKhau, @LoaiTaiKhoan;
    END

    CLOSE cur;
    DEALLOCATE cur;
END

-----------------------------------------------------------------------
--								NHANVIEN
-----------------------------------------------------------------------

CREATE TRIGGER trg_AutoMaNhanVien
ON NHANVIEN
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @currentMonthYear CHAR(6) = CONVERT(CHAR(6), GETDATE(), 112), -- Lấy tháng năm hiện tại
			@nextID INT,
			@newMaNhanVien CHAR(12),
			@TenNV NVARCHAR(50),
			@GioiTinhNV NVARCHAR(4),
			@LuongNV MONEY,
			@NgaySinhNV DATE,
			@DiaChiNV NVARCHAR(50),
			@SDTnv VARCHAR(11),
			@ChucVu NVARCHAR(30),
			@IDSanBay INT,
			@IDTaiKhoan INT; 

    SELECT @nextID = ISNULL(MAX(CAST(SUBSTRING(MaNhanVien, 9, 3) AS INT)), 0) + 1
    FROM NHANVIEN
    WHERE MaNhanVien LIKE 'NV' + @currentMonthYear + '%';

    DECLARE cur CURSOR FOR
    SELECT TenNV, GioiTinhNV, LuongNV, NgaySinhNV, DiaChiNV, SDTnv, ChucVu, IDSanBay, IDTaiKhoan FROM inserted;

    OPEN cur;
    FETCH NEXT FROM cur INTO @TenNV, @GioiTinhNV, @LuongNV, @NgaySinhNV, @DiaChiNV, @SDTnv, @ChucVu, @IDSanBay, @IDTaiKhoan;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @newMaNhanVien = 'NV' + @currentMonthYear + RIGHT('000' + CAST(@nextID AS VARCHAR(3)), 3);
        
        INSERT INTO NHANVIEN (MaNhanVien, TenNV, GioiTinhNV, LuongNV, NgaySinhNV, DiaChiNV, SDTnv, ChucVu, IDSanBay, IDTaiKhoan)
        VALUES (@newMaNhanVien, @TenNV, @GioiTinhNV, @LuongNV, @NgaySinhNV, @DiaChiNV, @SDTnv, @ChucVu, @IDSanBay, @IDTaiKhoan);

        SET @nextID = @nextID + 1;

        FETCH NEXT FROM cur INTO @TenNV, @GioiTinhNV, @LuongNV, @NgaySinhNV, @DiaChiNV, @SDTnv, @ChucVu, @IDSanBay,  @IDTaiKhoan;
    END

    CLOSE cur;
    DEALLOCATE cur;
END

-----------------------------------------------------------------------
--								TUYENBAY
-----------------------------------------------------------------------

CREATE TRIGGER trg_AutoMaTuyenBay
ON TUYENBAY
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @currentMonthYear CHAR(6) = CONVERT(CHAR(6), GETDATE(), 112), -- Lấy tháng năm hiện tại
			@nextID INT,
			@newMaTuyenBay CHAR(12),
			@NgayBay DATE,
			@GioBay TIME,
			@GioDen TIME,
			@ThoiGianBay TIME,
			@SoVeConLai INT,
			@SoVeDaBan INT,
			@TrangThaiTuyenBay NVARCHAR(10),
			@IDMayBay INT,
			@IDChangBay INT; 

    SELECT @nextID = ISNULL(MAX(CAST(SUBSTRING(MaTuyenBay, 9, 3) AS INT)), 0) + 1
    FROM TUYENBAY
    WHERE MaTuyenBay LIKE 'TB' + @currentMonthYear + '%';

    DECLARE cur CURSOR FOR
    SELECT NgayBay, GioBay, GioDen, ThoiGianBay, SoVeConLai, SoVeDaBan, TrangThaiTuyenBay, IDMayBay, IDChangBay FROM inserted;

    OPEN cur;
    FETCH NEXT FROM cur INTO @NgayBay, @GioBay, @GioDen, @ThoiGianBay, @SoVeConLai, @SoVeDaBan, @TrangThaiTuyenBay, @IDMayBay, @IDChangBay;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @newMaTuyenBay = 'TB' + @currentMonthYear + RIGHT('000' + CAST(@nextID AS VARCHAR(3)), 3);
        
        INSERT INTO TUYENBAY (MaTuyenBay, NgayBay, GioBay, GioDen, ThoiGianBay, SoVeConLai, SoVeDaBan, TrangThaiTuyenBay, IDMayBay, IDChangBay)
        VALUES (@newMaTuyenBay, @NgayBay, @GioBay, @GioDen, @ThoiGianBay, @SoVeConLai, @SoVeDaBan, @TrangThaiTuyenBay, @IDMayBay, @IDChangBay);

        SET @nextID = @nextID + 1;

        FETCH NEXT FROM cur INTO @NgayBay, @GioBay, @GioDen, @ThoiGianBay, @SoVeConLai, @SoVeDaBan, @TrangThaiTuyenBay, @IDMayBay, @IDChangBay;
    END

    CLOSE cur;
    DEALLOCATE cur;
END

-----------------------------------------------------------------------
--								HANHKHACH
-----------------------------------------------------------------------

CREATE TRIGGER trg_AutoMaHanhKhach
ON HANHKHACH
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @currentMonthYear CHAR(6) = CONVERT(CHAR(6), GETDATE(), 112), -- Lấy tháng năm hiện tại
			@nextID INT,
			@newMaHanhKhach CHAR(12),
			@TenHK NVARCHAR(50),
			@GioiTinhHK NVARCHAR(4),
			@NgaySinhHK DATE,
			@DiaChiHK NVARCHAR(50),
			@EmailHK VARCHAR(30),
			@SDThk CHAR(11),
			@CCCD CHAR(20); 

    SELECT @nextID = ISNULL(MAX(CAST(SUBSTRING(MaHanhKhach, 9, 3) AS INT)), 0) + 1
    FROM HANHKHACH
    WHERE MaHanhKhach LIKE 'HK' + @currentMonthYear + '%';

    DECLARE cur CURSOR FOR
    SELECT TenHK, GioiTinhHK, NgaySinhHK, DiaChiHK, EmailHK, SDThk, CCCD FROM inserted;

    OPEN cur;
    FETCH NEXT FROM cur INTO @TenHK, @GioiTinhHK, @NgaySinhHK, @DiaChiHK, @EmailHK, @SDThk, @CCCD;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @newMaHanhKhach = 'HK' + @currentMonthYear + RIGHT('000' + CAST(@nextID AS VARCHAR(3)), 3);
        
        INSERT INTO HANHKHACH (MaHanhKhach, TenHK, GioiTinhHK, NgaySinhHK, DiaChiHK, EmailHK, SDThk, CCCD)
        VALUES (@newMaHanhKhach, @TenHK, @GioiTinhHK, @NgaySinhHK, @DiaChiHK, @EmailHK, @SDThk, @CCCD);

        SET @nextID = @nextID + 1;

        FETCH NEXT FROM cur INTO @TenHK, @GioiTinhHK, @NgaySinhHK, @DiaChiHK, @EmailHK, @SDThk, @CCCD;
    END

    CLOSE cur;
    DEALLOCATE cur;
END