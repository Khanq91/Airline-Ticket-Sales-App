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
	TenTaiKhoan VARCHAR(100),
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
	ViTriVe NCHAR(10),
	ThanhTien FLOAT,
	NgayDatVe DATE,
	MaSB CHAR(10) NOT NULL,
	MaCB CHAR(10) NOT NULL,
	CONSTRAINT PK_DV_MaDV PRIMARY KEY(MaDV),
	CONSTRAINT FK_DV_MaSB FOREIGN KEY(MaSB) REFERENCES SANBAY(MaSB),
	CONSTRAINT FK_DV_MaCB FOREIGN KEY(MaCB) REFERENCES CHUYENBAY(MaCB)
);

CREATE TABLE VE 
(
	MaVe CHAR(10) NOT NULL,
	GiaVe MONEY,
	DonViTien NCHAR(10),
	ViTriGhe CHAR(10),
	MaCB CHAR(10) NOT NULL,
	MaHK CHAR(10) NOT NULL, 
	MaDV CHAR(10) NOT NULL,
	CONSTRAINT PK_VE_MaVe PRIMARY KEY(MaVe),
	CONSTRAINT FK_VE_MaCB FOREIGN KEY(MaCB) REFERENCES CHUYENBAY(MaCB),
	CONSTRAINT FK_VE_MaHK FOREIGN KEY(MaHK) REFERENCES HANHKHACH(MaHK),
	CONSTRAINT FK_VE_MaDV FOREIGN KEY(MaDV) REFERENCES DATVE(MaDV)
);

CREATE TABLE HANGVE
(
	MaVe CHAR(10) NOT NULL,
	HangVe NVARCHAR(50),
	CONSTRAINT PK_HVe_MaVe PRIMARY KEY(MaVe),
	CONSTRAINT FK_HVe_MaVe FOREIGN KEY(MaVe) REFERENCES VE(MaVe)
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

INSERT INTO QLTaiKhoan (IDTaiKhoan, TenTaiKhoan, MatKhau, LoaiTK)
VALUES 
    ('TK001', 'NguyenVanA', 'password123', N'NHANVIEN'),
    ('TK002', 'TranThiB', 'password456', N'NHANVIEN'),
    ('TK003', 'LeVanC', 'pass789', N'NHANVIEN'),
    ('TK004', 'PhamThiD', 'secret123', N'NHANVIEN'),
    ('TK005', 'HoangVanE', 'secure456', N'NHANVIEN'),
	('TK006', 'NguyenVanA', 'password123', N'HANHKHACH'),
    ('TK007', 'TranThiB', 'password456', N'HANHKHACH'),
    ('TK008', 'LeVanC', 'pass789', N'HANHKHACH'),
    ('TK009', 'PhamThiD', 'secret123', N'HANHKHACH'),
	('TK010', 'HoangVanE', 'secure456', N'HANHKHACH');

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




