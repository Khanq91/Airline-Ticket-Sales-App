CREATE DATABASE QL_VeMayBay
USE QL_VeMayBay

CREATE TABLE SANBAY 
(
	MaSB CHAR(10) NOT NULL,
	TenSB NVARCHAR(50),
	CONSTRAINT PK_SB_MaSB PRIMARY KEY(MaSB)
);

CREATE TABLE MAYBAY
(
	MaMB CHAR(10) NOT NULL,
	LoaiMB NVARCHAR(50),
	HangBay NVARCHAR(50),
	TongSoGhe INT,
	CONSTRAINT PK_MB_MaMB PRIMARY KEY(MaMB)
);

CREATE TABLE CHANGBAY
(
	MaChangBay CHAR(10) NOT NULL,
	MaSBdi CHAR(10) NOT NULL,
	MaSBden CHAR(10) NOT NULL,                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
	CONSTRAINT PK_ChB_MaChangBay PRIMARY KEY(MaChangBay),
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
	NgaySinhNV DATE,
	DiaChiNV NVARCHAR(50),
	SDTnv CHAR(11) CHECK (SDTnv LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	MaSB CHAR(10) NOT NULL,
	MaChucVu CHAR(10) NOT NULL,
	IDTaiKhoan CHAR(20) NOT NULL,
	CONSTRAINT PK_NV_MaNV PRIMARY KEY(MaNV),
	CONSTRAINT FK_NV_MaSB FOREIGN KEY(MaSB) REFERENCES SANBAY(MaSB),
	CONSTRAINT FK_NV_MaChucVu FOREIGN KEY(MaChucVu) REFERENCES CHUCVU(MaChucVu),
	CONSTRAINT FK_NV_IDtk FOREIGN KEY(IDTaiKhoan) REFERENCES QLTaiKhoan(IDTaiKhoan)
);

CREATE TABLE CHUYENBAY
(
	MaCB CHAR(10) NOT NULL,
	NgayBay DATE,  
	GioBay TIME,
	GioDen TIME,
	ThoiGianBay TIME,
	MaMB CHAR(10) NOT NULL,
	MaChangBay CHAR(10) NOT NULL,
	CONSTRAINT PK_CB_MaCB PRIMARY KEY(MaCB),
	CONSTRAINT FK_CB_MaMB FOREIGN KEY(MaMB) REFERENCES MAYBAY(MaMB),
	CONSTRAINT FK_CB_MaChangBay FOREIGN KEY(MaChangBay) REFERENCES CHANGBAY(MaChangBay)
);

CREATE TABLE HANHKHACH 
(
	MaHK CHAR(10) NOT NULL,
	TenHK NVARCHAR(50) DEFAULT '',      -- Mặc định là chuỗi rỗng
	DiaChi NVARCHAR(50) DEFAULT '',     -- Mặc định là chuỗi rỗng
	Email VARCHAR(30) DEFAULT '',       -- Mặc định là chuỗi rỗng
	SDT CHAR(11) DEFAULT '' CHECK (SDT LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),-- Mặc định là chuỗi rỗng (nếu muốn)
	CCCD CHAR(20) UNIQUE DEFAULT '',    -- Mặc định là chuỗi rỗng (nếu muốn)
	HoChieu CHAR(20) UNIQUE DEFAULT '', -- Mặc định là chuỗi rỗng (nếu muốn)
	NgaySinh DATE DEFAULT NULL,     -- Có thể để NULL nếu không cung cấp giá trị
	IDTaiKhoan CHAR(20) NOT NULL,
	CONSTRAINT PK_HK_MaHK PRIMARY KEY(MaHK),
	CONSTRAINT FK_HK_IDtk FOREIGN KEY(IDTaiKhoan) REFERENCES QLTaiKhoan(IDTaiKhoan)
);

CREATE TABLE HANGVE
(
	MaHangVe CHAR(10) NOT NULL,
	TenHangVe NVARCHAR(50),
	CONSTRAINT PK_HVe_MaVe PRIMARY KEY(MaHangVe)
);

CREATE TABLE CHITIETPHUPHI
(
	MaPhuPhi CHAR(10) NOT NULL,
	PhuPhi MONEY DEFAULT 0,
	LoaiPhuPhi NVARCHAR(50),  -- Thêm loại phụ phí(phụ phí của hành lý hoặc phụ phí của dịch vụ (nếu có))
	CONSTRAINT PK_CTPhuPhi_MaPhuPhi PRIMARY KEY(MaPhuPhi)
);

CREATE TABLE GIAVE
(
	MaGiaVe CHAR(10) NOT NULL,
	GiaCoBan MONEY,
	TongGiaVe MONEY DEFAULT 0,
	PhuPhi MONEY DEFAULT 0,
	GiamGia MONEY DEFAULT 0,
	MaCB CHAR(10) NOT NULL,
	MaHangVe CHAR(10) NOT NULL,
	NgayDatVe DATE,  -- Ngày đặt vé (nếu có)
	CONSTRAINT PK_GV_MaGiaVe PRIMARY KEY(MaGiaVe),
	CONSTRAINT FK_GV_MaCB FOREIGN KEY(MaCB) REFERENCES CHUYENBAY(MaCB),
	CONSTRAINT FK_GV_MaHangVe FOREIGN KEY(MaHangVe) REFERENCES HANGVE(MaHangVe)
);

CREATE TABLE DATVE
(
	MaDV CHAR(10) NOT NULL,
	ThanhTien MONEY DEFAULT 0,
	SoVeDat INT DEFAULT 0,
	--MaVe CHAR(10) NOT NULL,
	MaCB CHAR(10) NOT NULL,
	MaHK CHAR(10) NOT NULL,
	CONSTRAINT PK_DV_MaDV PRIMARY KEY(MaDV),
	--CONSTRAINT FK_DV_MaVe FOREIGN KEY(MaVe) REFERENCES VE(MaVe),
	CONSTRAINT FK_DV_MaHK FOREIGN KEY(MaHK) REFERENCES HANHKHACH(MaHK),
	CONSTRAINT FK_DV_MaCB FOREIGN KEY(MaCB) REFERENCES CHUYENBAY(MaCB)
);

CREATE TABLE VE 
(
	MaVe CHAR(10) NOT NULL,
	DonViTien NCHAR(10),
	ViTriGhe CHAR(10),
	MaHK CHAR(10) NOT NULL, 
	MaDV CHAR(10) NOT NULL,
	MaGiaVe CHAR(10) NOT NULL,
	CONSTRAINT PK_VE_MaVe PRIMARY KEY(MaVe),
	CONSTRAINT FK_VE_MaHK FOREIGN KEY(MaHK) REFERENCES HANHKHACH(MaHK),
	CONSTRAINT FK_VE_MaDV FOREIGN KEY(MaDV) REFERENCES DATVE(MaDV),
	CONSTRAINT FK_VE_MaGiaVe FOREIGN KEY(MaGiaVe) REFERENCES GIAVE(MaGiaVe)
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
	LoaiHanhLy NVARCHAR(30),
	MaPhuPhi CHAR(10) NOT NULL,
	MaHK CHAR(10) NOT NULL,
	MaCB CHAR(10) NOT NULL,
	CONSTRAINT PK_HL_MaHL PRIMARY KEY(MaHL),
	CONSTRAINT FK_HL_MaPhuPhi FOREIGN KEY(MaPhuPhi) REFERENCES CHITIETPHUPHI(MaPhuPhi),
	CONSTRAINT FK_HL_MaHK FOREIGN KEY(MaHK) REFERENCES HANHKHACH(MaHK),
	CONSTRAINT FK_HL_MaCB FOREIGN KEY(MaCB) REFERENCES CHUYENBAY(MaCB)
);

-----------------------------------------------------------------------
--								DỮ LIỆU
-----------------------------------------------------------------------
INSERT INTO SANBAY (MaSB, TenSB)
VALUES 
    ('SB001', N'Sân bay Tân Sơn Nhất'),
    ('SB002', N'Sân bay Nội Bài'),
    ('SB003', N'Sân bay Đà Nẵng'),
    ('SB004', N'Sân bay Cam Ranh'),
    ('SB005', N'Sân bay Phú Quốc');

INSERT INTO MAYBAY (MaMB, LoaiMB, HangBay, TongSoGhe)
VALUES 
    ('MB001', N'Airbus A320', N'VietJet Air', 180),
    ('MB002', N'Boeing 787', N'Vietnam Airlines', 300),
    ('MB003', N'Airbus A321', N'Bamboo Airways', 220),
    ('MB004', N'Boeing 777', N'Vietnam Airlines', 350),
    ('MB005', N'Airbus A330', N'Bamboo Airways', 260);

INSERT INTO CHANGBAY (MaChangBay, MaSBdi, MaSBden)
VALUES 
    ('CBY001', 'SB001', 'SB002'),
    ('CBY002', 'SB002', 'SB003'),
    ('CBY003', 'SB003', 'SB004'),
    ('CBY004', 'SB004', 'SB005'),
    ('CBY005', 'SB005', 'SB001');

INSERT INTO CHUCVU (MaChucVu, TenChucVu)
VALUES 
    ('CV001', N'Quản lý'),
    ('CV002', N'Nhân viên đặt vé');

INSERT INTO QLTaiKhoan (IDTaiKhoan, TenTaiKhoan, TenDangNhap, MatKhau, LoaiTK)
VALUES 
    ('TK001',  N'Nguyễn Văn A', 'nguyenvana', 'password123', N'NHANVIEN'),
    ('TK002',  N'Trần Thị B', 'tranthib', 'password456', N'NHANVIEN'),
    ('TK003', N'Lê Văn C', 'levanc', 'pass789', N'NHANVIEN'),
    ('TK004', N'Phạm Thị D', 'phamthid', 'secret123', N'NHANVIEN'),
    ('TK005', N'Hoàng Văn E', 'hoangvane', 'secure456', N'NHANVIEN'),
    ('TK006', N'Nguyễn Văn F', 'nguyenvanf1', 'password123', N'HANHKHACH'),
    ('TK007', N'Trần Thị G', 'tranthig1', 'password456', N'HANHKHACH'),
    ('TK008', N'Lê Văn H', 'levanh1', 'pass789', N'HANHKHACH'),
    ('TK009', N'Phạm Thị K', 'phamthik1', 'secret123', N'HANHKHACH'),
    ('TK010', N'Hoàng Văn L', 'hoangvanl1', 'secure456', N'HANHKHACH');

INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, Luong, NgaySinhNV, DiaChiNV, SDTnv, MaSB, MaChucVu, IDTaiKhoan) 
VALUES 
	('NV001', N'Nguyễn Văn X', N'Nam', 15000000, '1980-01-01', N'Thành phố Hồ Chí Minh', '0905123456', 'SB001', 'CV001', 'TK001'),
	('NV002', N'Trần Thị Y', N'Nữ', 16000000, '1985-02-02', N'Hà Nội', '0906123456', 'SB002', 'CV002', 'TK002'),
	('NV003', N'Lê Văn Z', N'Nam', 17000000, '1990-03-03', N'Đà Nẵng', '0907123456', 'SB003', 'CV002', 'TK003'),
	('NV004', N'Phạm Thị M', N'Nữ', 18000000, '1982-04-04', N'Hải Phòng', '0908123456', 'SB004', 'CV002', 'TK004'),
	('NV005', N'Hoàng Văn N', N'Nam', 19000000, '1987-05-05', N'Cần Thơ', '0909123456', 'SB005', 'CV002', 'TK005');

INSERT INTO CHUYENBAY (MaCB, NgayBay, GioBay, GioDen, ThoiGianBay, MaMB, MaChangBay)
VALUES 
    ('CB001', '2024-10-15', '08:00', '10:00', '02:00', 'MB001', 'CBY001'),
    ('CB002', '2024-10-16', '14:00', '16:30', '02:30', 'MB002', 'CBY002'),
    ('CB003', '2024-10-17', '09:00', '11:30', '02:30', 'MB003', 'CBY003'),
    ('CB004', '2024-10-18', '13:00', '15:30', '02:30', 'MB004', 'CBY004'),
    ('CB005', '2024-10-19', '17:00', '19:30', '02:30', 'MB005', 'CBY005');

INSERT INTO HANHKHACH (MaHK, TenHK, DiaChi, SDT, CCCD, HoChieu, NgaySinh, IDTaiKhoan) 
VALUES 
	('HK001', N'Nguyễn Văn F', N'Thành phố Hồ Chí Minh', '0909123456', '0123456789', 'A1234567', '1990-01-01', 'TK006'),
	('HK002', N'Trần Thị G', N'Bến Tre', '0912123456', '9876543210', 'B1234567', '1992-02-02', 'TK007'),
	('HK003', N'Lê Văn H', N'Phú Quốc', '0903123456', '1234567890', 'C1234567', '1988-03-03', 'TK008'),
	('HK004', N'Phạm Thị K', N'Tiền Giang', '0918123456', '0987654321', 'D1234567', '1991-04-04', 'TK009'),
	('HK005', N'Hoàng Văn L', N'Yên Bái', '0904123456', '2345678901', 'E1234567', '1985-05-05', 'TK010');

INSERT INTO HANGVE (MaHangVe, TenHangVe) 
VALUES 
	('HV001', N'Hạng nhất'),
	('HV002', N'Hạng thương gia'),
	('HV003', N'Hạng phổ thông đặc biệt'),
	('HV004', N'Hạng phổ thông');

INSERT INTO CHITIETPHUPHI (MaPhuPhi, PhuPhi, LoaiPhuPhi)
VALUES
    ('PP001', 200000, N'Hành lý quá cân'),
    ('PP002', 250000, N'Hành lý quá cân'),
    ('PP003', 300000, N'Hành lý quá cân'),
    ('PP004', 350000, N'Hành lý quá cân'),
    ('PP005', 400000, N'Hành lý quá cân');

INSERT INTO GIAVE (MaGiaVe, GiaCoBan, TongGiaVe, PhuPhi, GiamGia, MaCB, MaHangVe, NgayDatVe)
VALUES 
    ('GV001', 2000000, 0, 0, 0, 'CB001', 'HV001', '2024-10-01'),
    ('GV002', 3500000, 0, 0, 0, 'CB002', 'HV002', '2024-10-02'),
    ('GV003', 5000000, 0, 0, 0, 'CB003', 'HV003', '2024-10-03'),
    ('GV004', 4000000, 0, 0, 0, 'CB004', 'HV004', '2024-10-04'),
    ('GV005', 1500000, 0, 0, 0, 'CB005', 'HV004', '2024-10-05');
----------------------------------------------------
INSERT INTO DATVE (MaDV, ThanhTien, SoVeDat, MaCB, MaHK)
VALUES 
    ('DV001', 0, 1, 'CB001', 'HK001'),
    ('DV002', 0, 1, 'CB002', 'HK002'),
    ('DV003', 0, 1, 'CB003', 'HK003'),
    ('DV004', 0, 1, 'CB004', 'HK004'),
    ('DV005', 0, 1, 'CB005', 'HK005');
----------------------------------------------------
INSERT INTO VE (MaVe, DonViTien, ViTriGhe, MaHK, MaDV, MaGiaVe) 
VALUES 
	('VE001', 'VND', 'A1', 'HK001', 'DV001', 'GV001'),
	('VE002', 'VND', 'B2', 'HK002', 'DV002', 'GV002'),
	('VE003', 'VND', 'C3', 'HK003', 'DV003', 'GV003'),
	('VE004', 'VND', 'D4', 'HK004', 'DV004', 'GV004'),
	('VE005', 'VND', 'E5', 'HK005', 'DV005', 'GV005');
----------------------------------------------------
INSERT INTO NHANXET (MaHK, MaCB, NDNhanXet, DiemDanhGia)
VALUES 
    ('HK001', 'CB001', N'Trải nghiệm tuyệt vời, rất hài lòng.', 5),
    ('HK002', 'CB002', N'Dịch vụ tốt, nhưng có thể cải thiện.', 4),
    ('HK003', 'CB003', N'Chuyến bay ổn, nhưng ghế hơi chật.', 3),
    ('HK004', 'CB004', N'Trễ chuyến bay, nhưng nhân viên hỗ trợ tốt.', 4),
    ('HK005', 'CB005', N'Chuyến bay hoàn hảo, không có gì để chê.', 5);
----------------------------------------------------
INSERT INTO HANHLY (MaHL, SoKG, LoaiHanhLy, MaPhuPhi, MaHK, MaCB)
VALUES 
    ('HL001', 20, N'Hành lý ký gửi', 'PP001', 'HK001', 'CB001'),
    ('HL002', 15, N'Hành lý xách tay', 'PP002', 'HK002', 'CB002'),
    ('HL003', 25, N'Hành lý ký gửi', 'PP001', 'HK003', 'CB003'),
    ('HL004', 10, N'Hành lý xách tay', 'PP003', 'HK004', 'CB004'),
    ('HL005', 30, N'Hành lý ký gửi', 'PP004', 'HK005', 'CB005');

--	XEM DỮ LIỆU BẢNG
SELECT * FROM SANBAY
SELECT * FROM MAYBAY
SELECT * FROM CHANGBAY
SELECT * FROM CHUCVU
SELECT * FROM QLTaiKhoan
SELECT * FROM NHANVIEN
SELECT * FROM CHUYENBAY
SELECT * FROM HANHKHACH
SELECT * FROM HANGVE
SELECT * FROM CHITIETPHUPHI
SELECT * FROM GIAVE
SELECT * FROM VE
SELECT * FROM DATVE
SELECT * FROM NHANXET
SELECT * FROM HANHLY

-----------------------------------------------------------------------
--						CÀI ĐẶT CÁC TRIGGER
-----------------------------------------------------------------------
--TRIGGER
--1. Tính giá vé (GIAVE)
--2. Tính thành tiền (DATVE)
--3. Tính phụ phí
--4. Check tuổi
-------------------------
--		SANBAY
-------------------------
-- Trigger kiểm tra mã sân bay không được trùng khi cập nhật
CREATE TRIGGER trg_SANBAY_CHECK_MaSB
ON SANBAY
FOR INSERT, UPDATE 
AS
BEGIN
    IF EXISTS (
		SELECT 1
		FROM INSERTED i
		WHERE EXISTS (
			SELECT 1 
			FROM SANBAY sb
			WHERE sb.MaSB = i.MaSB 
				  AND MaSB NOT IN (SELECT MaSB FROM DELETED)
		)
	)
		BEGIN
			PRINT N'Mã sân bay đã tồn tại ở bản ghi khác!';
			ROLLBACK TRANSACTION;
		END
END;

-- Trigger để kiểm tra trước khi chèn và cập nhật vào SANBAY
CREATE TRIGGER trg_SANBAY_ThemMoi
ON SANBAY
FOR INSERT, UPDATE 
AS
BEGIN
    IF EXISTS (SELECT 1 FROM INSERTED WHERE TenSB = '')
		BEGIN
			PRINT N'Tên sân bay không được để trống!';
			ROLLBACK TRANSACTION;
			RETURN;
		END
END;

-- Trigger để ghi log khi xóa SANBAY
CREATE TRIGGER trg_SANBAY_DELETE
ON SANBAY
FOR DELETE
AS
BEGIN
    DECLARE @MaSB CHAR(10);
    SELECT @MaSB = MaSB FROM DELETED;
    
    PRINT N'Sân bay có mã ' + @MaSB + N' đã bị xóa khỏi hệ thống.';
END;

-------------------------
--		MAYBAY
-------------------------
-- Trigger kiểm tra mã máy bay không được trùng khi cập nhật
CREATE TRIGGER trg_MAYBAY_CHECK_MaMB
ON MAYBAY
FOR INSERT, UPDATE 
AS
BEGIN
    -- Kiểm tra nếu mã đã tồn tại ở bản ghi khác
    IF EXISTS (
		SELECT 1
		FROM INSERTED i
		WHERE EXISTS (
			SELECT 1 
			FROM MAYBAY mb
			WHERE mb.MaMB = i.MaMB 
				  AND MaMB NOT IN (SELECT MaMB FROM DELETED)
		)
	)
		BEGIN
			PRINT N'Mã máy bay đã tồn tại ở bản ghi khác!';
			ROLLBACK TRANSACTION;
		END
END;

-- Trigger kiểm tra khi chèn và cập nhật dữ liệu vào bảng MAYBAY
CREATE TRIGGER trg_MAYBAY_ThemMoi
ON MAYBAY
FOR INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra nếu LoaiMB để trống
    IF EXISTS (SELECT 1 FROM INSERTED WHERE LoaiMB = '')
		BEGIN
			PRINT N'Loại máy bay không được để trống!';
			ROLLBACK TRANSACTION;
			RETURN;
		END

    -- Kiểm tra nếu HangBay để trống
    IF EXISTS (SELECT 1 FROM INSERTED WHERE HangBay = '')
		BEGIN
			PRINT N'Hãng bay không được để trống!';
			ROLLBACK TRANSACTION;
			RETURN;
		END

    -- Kiểm tra nếu TongSoGhe không hợp lệ (ví dụ: nhỏ hơn hoặc bằng 0)
    IF EXISTS (SELECT 1 FROM INSERTED WHERE TongSoGhe <= 0)
		BEGIN
			PRINT N'Tổng số ghế phải lớn hơn 0!';
			ROLLBACK TRANSACTION;
			RETURN;
		END
END;

-- Trigger để ghi log khi xóa MAYBAY
CREATE TRIGGER trg_MAYBAY_DELETE
ON MAYBAY
FOR DELETE
AS
BEGIN
    DECLARE @MaMB CHAR(10);
    SELECT @MaMB = MaMB FROM DELETED;

    PRINT N'Máy bay có mã ' + @MaMB + N' đã bị xóa khỏi hệ thống.';
END;

-------------------------
--		CHANGBAY
-------------------------
-- Trigger kiểm tra mã chặng bay không được trùng khi cập nhật
CREATE TRIGGER trg_CHANGBAY_CHECK_MaChangBay
ON CHANGBAY
FOR INSERT, UPDATE 
AS
BEGIN
    -- Kiểm tra nếu mã đã tồn tại ở bản ghi khác
    IF EXISTS (
		SELECT 1
		FROM INSERTED i
		WHERE EXISTS(
			SELECT 1 
			FROM CHANGBAY chb
			WHERE chb.MaChangBay = i.MaChangBay 
				  AND MaChangBay NOT IN (SELECT MaChangBay FROM DELETED)
		)
	)
		BEGIN
			PRINT N'Mã chặng bay đã tồn tại ở bản ghi khác!';
			ROLLBACK TRANSACTION;
		END
END;

-- Trigger để kiểm tra trước khi chèn và cập nhật vào CHANGBAY
CREATE TRIGGER trg_CHANGBAY_ThemMoi
ON CHANGBAY
FOR INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM INSERTED WHERE MaSBdi = MaSBden)
		BEGIN
			PRINT N'Mã sân bay đi và sân bay đến không được trùng nhau!';
			ROLLBACK TRANSACTION;
			RETURN;
		END
END;

-- Trigger để ghi log khi xóa CHANGBAY
CREATE TRIGGER trg_CHANGBAY_DELETE
ON CHANGBAY
FOR DELETE
AS
BEGIN
    DECLARE @MaChangBay CHAR(10);
    SELECT @MaChangBay = MaChangBay FROM DELETED;

    PRINT N'Chặng bay có mã ' + @MaChangBay + N' đã bị xóa khỏi hệ thống.';
END;

-------------------------
--		CHUCVU
-------------------------
-- Trigger kiểm tra giá trị của TenChucVu chỉ là 'Nhân viên đặt vé' hoặc 'Quản lý'
CREATE TRIGGER trg_CHUCVU_TenChucVu
ON CHUCVU
FOR INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra nếu có bất kỳ bản ghi nào trong INSERTED có TenChucVu không hợp lệ
    IF EXISTS (
        SELECT 1 
        FROM INSERTED 
        WHERE TenChucVu NOT IN (N'Nhân viên đặt vé', N'Quản lý')
    )
		BEGIN
			PRINT N'Tên chức vụ không hợp lệ! Chỉ được phép là "Nhân viên đặt vé" hoặc "Quản lý".';
			ROLLBACK TRANSACTION;
		END
END;

-------------------------
--		QLTaiKhoan
-------------------------
-- Trigger kiểm tra ID tài khoản không được trùng khi cập nhật
CREATE TRIGGER trg_QLTaiKhoan_CHECK_IDTaiKhoan
ON QLTaiKhoan
FOR INSERT, UPDATE 
AS
BEGIN
    -- Kiểm tra nếu mã đã tồn tại ở bản ghi khác
    IF EXISTS (
		SELECT 1 
		FROM INSERTED i
		WHERE EXISTS (
			SELECT 1 
			FROM QLTaiKhoan qltk
			WHERE qltk.IDTaiKhoan = i.IDTaiKhoan
				  AND qltk.IDTaiKhoan NOT IN (SELECT IDTaiKhoan FROM DELETED)
		)
	)
		BEGIN
			PRINT N'ID tài khoản đã tồn tại ở bản ghi khác!';
			ROLLBACK TRANSACTION;
		END
END;

--Trigger kiểm tra khi thêm mới vào QLTaiKhoan
CREATE TRIGGER trg_QLTaiKhoan_ThemMoi
ON QLTaiKhoan
FOR INSERT, UPDATE
AS
BEGIN
	IF EXISTS (SELECT 1 FROM INSERTED WHERE TenTaiKhoan = '')
		BEGIN
			PRINT N'Tên tài khoản không được để trống!';
			ROLLBACK TRANSACTION;
			RETURN;
		END
	IF EXISTS (SELECT 1 FROM INSERTED WHERE TenDangNhap = '')
		BEGIN
			PRINT N'Tên đăng nhập không được để trống!';
			ROLLBACK TRANSACTION;
			RETURN;
		END
	IF EXISTS (SELECT 1 FROM INSERTED WHERE MatKhau = '')
		BEGIN
			PRINT N'Mật khẩu không được để trống!';
			ROLLBACK TRANSACTION;
			RETURN;
		END
END;

-------------------------
--		NHANVIEN
-------------------------
--Trigger kiểm tra mã nhân viên không được trùng khi thêm mới và cập nhật dữ liệu
CREATE TRIGGER trg_NHANVIEN_CHECK_MaNV
ON NHANVIEN 
FOR INSERT, UPDATE
AS
BEGIN
	IF EXISTS (
		SELECT 1 
		FROM INSERTED i
		WHERE EXISTS (
			SELECT 1 
			FROM NHANVIEN nv
			WHERE nv.MaNV = i.MaNV
				  AND nv.MaNV NOT IN (SELECT MaNV FROM DELETED)  -- Đảm bảo không kiểm tra chính bản ghi đang cập nhật
		)
	)
		BEGIN
			PRINT N'Mã nhân viên này đã tồn tại!';
			ROLLBACK TRANSACTION;
		END
END;

--Trigger kiểm tra khi thêm mới vào NHANVIEN
CREATE TRIGGER trg_NHANVIEN_ThemMoi
ON NHANVIEN
FOR INSERT, UPDATE
AS 
BEGIN
	DECLARE @TenNV NVARCHAR(50);
	DECLARE @GioiTinh NVARCHAR(4);
	DECLARE @Luong MONEY;
	DECLARE @NgaySinhNV DATE;
	DECLARE @DiaChiNV NVARCHAR(50);
	DECLARE @SDTnv CHAR(11);
	
	SELECT @TenNV = TenNV, 
		   @GioiTinh = GioiTinh, 
		   @Luong = Luong, 
		   @NgaySinhNV = NgaySinhNV, 
		   @DiaChiNV = DiaChiNV, 
		   @SDTnv = SDTnv 
	FROM INSERTED;

	IF @TenNV = ''
		BEGIN
			PRINT N'Tên nhân viên không được để trống!';
			ROLLBACK TRANSACTION;
			RETURN;
		END
	IF @GioiTinh NOT IN (N'Nam', N'Nữ')
		BEGIN
			PRINT N'Giới tính của nhân viên phải là "Nam" hoặc "Nữ"!';
			ROLLBACK TRANSACTION;
			RETURN;
		END
	IF @Luong IS NULL OR @Luong <= 0
		BEGIN
			PRINT N'Lương của nhân viên phải lớn hơn 0!';
			ROLLBACK TRANSACTION;
			RETURN;
		END
	IF @NgaySinhNV IS NULL OR @NgaySinhNV >= GETDATE()
		BEGIN
			PRINT N'Ngày sinh của nhân viên phải nhỏ hơn ngày hiện tại!';
			ROLLBACK TRANSACTION;
			RETURN;
		END
	IF @DiaChiNV = ''
		BEGIN
			PRINT N'Địa chỉ nhân viên không được để trống!';
			ROLLBACK TRANSACTION;
			RETURN;
		END
	-- Kiểm tra Số điện thoại nhân viên (phải là 10 chữ số)
    IF LEN(@SDTnv) <> 10
		BEGIN
			PRINT N'Số điện thoại nhân viên phải có đúng 10 chữ số!';
			ROLLBACK TRANSACTION;
			RETURN;
		END
END;

-------------------------
--		CHUYENBAY
-------------------------
