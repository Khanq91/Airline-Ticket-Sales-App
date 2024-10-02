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
	TenTaiKhoan VARCHAR(100),
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

CREATE TABLE HANGVE
(
	MaHangVe CHAR(10) NOT NULL,
	TenHangVe NVARCHAR(50),
	CONSTRAINT PK_HVe_MaVe PRIMARY KEY(MaHangVe)
);

CREATE TABLE CHITIETPHUPHI
(
	MaPhuPhi CHAR(10) NOT NULL,
	PhuPhi MONEY,
	LoaiPhuPhi NVARCHAR(50),  -- Thêm loại phụ phí(phụ phí của hành lý hoặc phụ phí của dịch vụ (nếu có))
	CONSTRAINT PK_CTPhuPhi_MaPhuPhi PRIMARY KEY(MaPhuPhi)
);

CREATE TABLE GIAVE
(
	MaGiaVe CHAR(10) NOT NULL,
	GiaVe MONEY,
	MaCB CHAR(10) NOT NULL,
	MaHangVe CHAR(10) NOT NULL,
	NgayDatVe DATE,  -- Ngày đặt vé (nếu có)
	--PhuPhi MONEY DEFAULT 0,  -- Giá vé có thể bao gồm phụ phí
	CONSTRAINT PK_GV_MaGiaVe PRIMARY KEY(MaGiaVe),
	CONSTRAINT FK_GV_MaCB FOREIGN KEY(MaCB) REFERENCES CHUYENBAY(MaCB),
	CONSTRAINT FK_GV_MaHangVe FOREIGN KEY(MaHangVe) REFERENCES HANGVE(MaHangVe)
);

CREATE TABLE VE 
(
	MaVe CHAR(10) NOT NULL,
	DonViTien NCHAR(10),
	ViTriGhe CHAR(10),
	MaHK CHAR(10) NOT NULL, 
	--MaDV CHAR(10) NOT NULL,
	MaGiaVe CHAR(10) NOT NULL,
	CONSTRAINT PK_VE_MaVe PRIMARY KEY(MaVe),
	CONSTRAINT FK_VE_MaHK FOREIGN KEY(MaHK) REFERENCES HANHKHACH(MaHK),
	--CONSTRAINT FK_VE_MaDV FOREIGN KEY(MaDV) REFERENCES DATVE(MaDV),
	CONSTRAINT FK_VE_MaGiaVe FOREIGN KEY(MaGiaVe) REFERENCES GIAVE(MaGiaVe)
);

CREATE TABLE DATVE
(
	MaDV CHAR(10) NOT NULL,
	ThanhTien MONEY DEFAULT 0,
	PhuPhi MONEY DEFAULT 0,
	MaVe CHAR(10) NOT NULL,
	MaCB CHAR(10) NOT NULL,
	MaHK CHAR(10) NOT NULL,
	CONSTRAINT PK_DV_MaDV PRIMARY KEY(MaDV),
	CONSTRAINT FK_DV_MaVe FOREIGN KEY(MaVe) REFERENCES VE(MaVe),
	CONSTRAINT FK_DV_MaHK FOREIGN KEY(MaHK) REFERENCES HANHKHACH(MaHK),
	CONSTRAINT FK_DV_MaCB FOREIGN KEY(MaCB) REFERENCES CHUYENBAY(MaCB)
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

INSERT INTO CHANGBAY (MaChangBay, MaSBdi, MaSBden) 
VALUES 
	('CB001', 'SB001', 'SB002'),
	('CB002', 'SB002', 'SB003'),
	('CB003', 'SB003', 'SB004'),
	('CB004', 'SB004', 'SB005'),
	('CB005', 'SB005', 'SB001');

INSERT INTO CHUCVU (MaChucVu, TenChucVu)
VALUES 
    ('CV001', N'Quản lý'),
    ('CV002', N'Nhân viên đặt vé');

INSERT INTO QLTaiKhoan (IDTaiKhoan, TenTaiKhoan, TenDangNhap, MatKhau, LoaiTK)
VALUES 
    ('TK001', 'Nguyen Van A', 'nguyenvana', 'password123', N'NHANVIEN'),
    ('TK002', 'Tran Thi B', 'tranthib', 'password456', N'NHANVIEN'),
    ('TK003', 'Le Van C', 'levanc', 'pass789', N'NHANVIEN'),
    ('TK004', 'Pham Thi D', 'phamthid', 'secret123', N'NHANVIEN'),
    ('TK005', 'Hoang Van E', 'hoangvane', 'secure456', N'NHANVIEN'),
    ('TK006', 'Nguyen Van A', 'nguyenvana1', 'password123', N'HANHKHACH'),
    ('TK007', 'Tran Thi B', 'tranthib1', 'password456', N'HANHKHACH'),
    ('TK008', 'Le Van C', 'levanc1', 'pass789', N'HANHKHACH'),
    ('TK009', 'Pham Thi D', 'phamthid1', 'secret123', N'HANHKHACH'),
    ('TK010', 'Hoang Van E', 'hoangvane1', 'secure456', N'HANHKHACH');

INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, Luong, NgaySinhNV, DiaChiNV, SDTnv, MaSB, MaChucVu, IDTaiKhoan) 
VALUES 
	('NV001', N'Nguyễn Văn X', N'Nam', 15000000, '1980-01-01', N'Thành phố Hồ Chí Minh', '0905123456', 'SB001', 'CV001', 'TK001'),
	('NV002', N'Trần Thị Y', N'Nữ', 16000000, '1985-02-02', N'Hà Nội', '0906123456', 'SB002', 'CV002', 'TK002'),
	('NV003', N'Lê Văn Z', N'Nam', 17000000, '1990-03-03', N'Đà Nẵng', '0907123456', 'SB003', 'CV002', 'TK003'),
	('NV004', N'Phạm Thị M', N'Nữ', 18000000, '1982-04-04', N'Hải Phòng', '0908123456', 'SB004', 'CV002', 'TK004'),
	('NV005', N'Hoàng Văn N', N'Nam', 19000000, '1987-05-05', N'Cần Thơ', '0909123456', 'SB005', 'CV002', 'TK005');

INSERT INTO CHUYENBAY (MaCB, NgayBay, GioBay, GioDen, ThoiGianBay, MaMB, MaChangBay) 
VALUES 
	('CBY001', '2024-09-01', '07:00:00', '09:00:00', '02:00:00', 'MB001', 'CB001'),
	('CBY002', '2024-09-02', '08:00:00', '11:00:00', '03:00:00', 'MB002', 'CB002'),
	('CBY003', '2024-09-03', '09:00:00', '12:30:00', '03:30:00', 'MB003', 'CB003'),
	('CBY004', '2024-09-04', '06:00:00', '08:30:00', '02:30:00', 'MB004', 'CB004'),
	('CBY005', '2024-09-05', '05:30:00', '08:00:00', '02:30:00', 'MB005', 'CB005');

INSERT INTO HANHKHACH (MaHK, TenHK, DiaChi, SDT, CCCD, HoChieu, NgaySinh, IDTaiKhoan) 
VALUES 
	('HK001', N'Nguyễn Văn A', N'Ho Chi Minh City', '0909123456', '0123456789', 'A1234567', '1990-01-01', 'TK006'),
	('HK002', N'Trần Thị B', N'Ha Noi', '0912123456', '9876543210', 'B1234567', '1992-02-02', 'TK007'),
	('HK003', N'Lê Văn C', N'Da Nang', '0903123456', '1234567890', 'C1234567', '1988-03-03', 'TK008'),
	('HK004', N'Phạm Thị D', N'Hai Phong', '0918123456', '0987654321', 'D1234567', '1991-04-04', 'TK009'),
	('HK005', N'Hoàng Văn E', N'Can Tho', '0904123456', '2345678901', 'E1234567', '1985-05-05', 'TK010');

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

INSERT INTO GIAVE (MaGiaVe, GiaVe, MaCB, MaHangVe, NgayDatVe) 
VALUES 
	('GV001', 1000000, 'CBY001', 'HV001', '2024-08-01'),
	('GV002', 1500000, 'CBY002', 'HV002', '2024-08-02'),
	('GV003', 2000000, 'CBY003', 'HV003', '2024-08-03'),
	('GV004', 2500000, 'CBY004', 'HV004', '2024-08-04'),
	('GV005', 3000000, 'CBY005', 'HV004', '2024-08-05');

INSERT INTO VE (MaVe, DonViTien, ViTriGhe, MaHK, MaGiaVe) 
VALUES 
	('VE001', 'VND', 'A1', 'HK001', 'GV001'),
	('VE002', 'VND', 'B2', 'HK002', 'GV002'),
	('VE003', 'VND', 'C3', 'HK003', 'GV003'),
	('VE004', 'VND', 'D4', 'HK004', 'GV004'),
	('VE005', 'VND', 'E5', 'HK005', 'GV005');

INSERT INTO DATVE (MaDV, ThanhTien, PhuPhi, MaVe, MaCB, MaHK) 
VALUES 
	('DV001', 1200000, 200000, 'VE001', 'CBY001', 'HK001'),
	('DV002', 1750000, 250000, 'VE002', 'CBY002', 'HK002'),
	('DV003', 2300000, 300000, 'VE003', 'CBY003', 'HK003'),
	('DV004', 2850000, 350000, 'VE004', 'CBY004', 'HK004'),
	('DV005', 3400000, 400000, 'VE005', 'CBY005', 'HK005');

INSERT INTO NHANXET (MaHK, MaCB, NDNhanXet, DiemDanhGia) 
VALUES 
	('HK001', 'CBY001', N'Chuyến bay tuyệt vời, rất thoải mái.', 5),
	('HK002', 'CBY002', N'Dịch vụ tốt nhưng chuyến bay bị hoãn.', 4),
	('HK003', 'CBY003', N'Trải nghiệm bình thường, không có gì đặc biệt.', 3),
	('HK004', 'CBY004', N'Không hài lòng với dịch vụ.', 2),
	('HK005', 'CBY005', N'Trải nghiệm khủng khiếp, sẽ không dùng hãng bay này nữa.', 1);

INSERT INTO HANHLY (MaHL, SoKG, MaPhuPhi, MaHK, MaCB) 
VALUES 
	('HL001', 20, 'PP001', 'HK001', 'CBY001'),
	('HL002', 25, 'PP002', 'HK002', 'CBY002'),
	('HL003', 30, 'PP003', 'HK003', 'CBY003'),
	('HL004', 35, 'PP004', 'HK004', 'CBY004'),
	('HL005', 40, 'PP005', 'HK005', 'CBY005');

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
