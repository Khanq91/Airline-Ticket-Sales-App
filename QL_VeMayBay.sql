CREATE DATABASE QL_VeMayBay_dotNet
USE QL_VeMayBay_dotNet

CREATE TABLE SANBAY 
(
	ID INT NOT NULL IDENTITY(1,1),
	MaSanBay CHAR(6) NOT NULL unique,
	TenSanBay NVARCHAR(50),
	DiaDiem NVARCHAR(50),
	CONSTRAINT PK_SB_IDSanBay PRIMARY KEY(ID)
);

--alter table SANBAY add DiaDiem NVARCHAR(50)
CREATE TABLE MAYBAY
(
	ID INT NOT NULL IDENTITY(1,1),
	MaMayBay CHAR(12) NOT NULL unique,
	LoaiMayBay NVARCHAR(50),
	HangBay NVARCHAR(50),
	TongSoGhe INT,
	CONSTRAINT PK_MB_IDMayBay PRIMARY KEY(ID)
);

CREATE TABLE CHANGBAY
(
	ID INT NOT NULL IDENTITY(1,1),
	MaChangBay CHAR(12) unique,
	IDSanBaydi INT NOT NULL,
	IDSanBayden INT NOT NULL,                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
	CONSTRAINT PK_ChB_IDChangBay PRIMARY KEY(ID),
	CONSTRAINT FK_ChB_IDSanBaydi FOREIGN KEY(IDSanBaydi) REFERENCES SANBAY(ID) ON DELETE NO ACTION,
    CONSTRAINT FK_ChB_IDSanBayden FOREIGN KEY(IDSanBayden) REFERENCES SANBAY(ID) ON DELETE NO ACTION
);

CREATE TABLE QLTaiKhoan
(
	ID INT NOT NULL IDENTITY(1,1),
	MaTaiKhoan CHAR(12) unique,
	TenTaiKhoan NVARCHAR(50) NOT NULL,
    TenDangNhap VARCHAR(50) NOT NULL,
	MatKhau VARCHAR(50) NOT NULL,
	LoaiTaiKhoan NVARCHAR(30) NOT NULL CHECK (LoaiTaiKhoan IN (N'Quản lý', N'Nhân viên', N'Khách hàng')), 
	CONSTRAINT PK_TK_IDTaiKhoan PRIMARY KEY(ID)
);

CREATE TABLE NHANVIEN 
(
	ID INT NOT NULL IDENTITY(1,1),
	MaNhanVien CHAR(12) unique,
	TenNhanVien NVARCHAR(50) NOT NULL,
	GioiTinhNhanVien NVARCHAR(4) CHECK(GioiTinhNhanVien IN (N'Nam', N'Nữ')),
	LuongNhanVien MONEY NOT NULL,
	NgaySinhNhanVien DATE NOT NULL,
	DiaChiNhanVien NVARCHAR(50),
	SDTNhanVien VARCHAR(11) CHECK (SDTNhanVien LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
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
	MaTuyenBay CHAR(12) unique,
	NgayBay DATE NOT NULL,  
	GioBay TIME NOT NULL,
	GioDen TIME NOT NULL,
	ThoiGianBay TIME,
	SoVeConLai INT,                  
	SoVeDaBan INT DEFAULT 0,
    TrangThaiTuyenBay NVARCHAR(10),           -- Tình tr?ng vé (VD: 'Còn vé', 'H?t vé')
	IDMayBay INT NOT NULL,
	IDChangBay INT NOT NULL,
	CONSTRAINT PK_tb_IDTuyenBay PRIMARY KEY(ID),
	CONSTRAINT FK_tb_IDMayBay FOREIGN KEY(IDMayBay) REFERENCES MAYBAY(ID),
	CONSTRAINT FK_tb_IDChangBay FOREIGN KEY(IDChangBay) REFERENCES CHANGBAY(ID) ON DELETE NO ACTION
);

CREATE TABLE HANHKHACH 
(
	ID INT NOT NULL IDENTITY(1,1),
	MaHanhKhach CHAR(12) unique,
	TenHanhKhach NVARCHAR(50) NOT NULL,      
	GioiTinhHanhKhach NVARCHAR(4) CHECK(GioiTinhHanhKhach IN (N'Nam', N'Nữ')),
	NgaySinhHanhKhach DATE NOT NULL,    
	DiaChiHanhKhach NVARCHAR(50),-- NOT NULL,    cho null d? thêm thông tin c?a tr? em, em bé 
	Email VARCHAR(30),-- NOT NULL,       
	SDTHanhKhach CHAR(11) CHECK (SDTHanhKhach LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	CCCD CHAR(20), --UNIQUE NOT NULL,  
	TenNguoiDiCung NVARCHAR(50), --Cho thông tin c?a tr? em và em bíe
	CONSTRAINT PK_HK_IDHanhKhach PRIMARY KEY(ID)
);

CREATE TABLE VE 
(
	ID INT NOT NULL IDENTITY(1,1),
	MaVe CHAR(12) unique,
	GiaVeCoBan MONEY,
	HangVe NVARCHAR(50) NOT NULL,
	DonViTien NCHAR(10),
	ViTriGhe CHAR(10),
	NgayDatVe DATE,
	IDHanhKhach INT NOT NULL, 
	CONSTRAINT PK_VE_STTve PRIMARY KEY(ID),	
	CONSTRAINT FK_VE_IDHanhKhach FOREIGN KEY(IDHanhKhach) REFERENCES HANHKHACH(ID) ON DELETE NO ACTION
);

CREATE TABLE HANHLY 
(
	ID INT NOT NULL IDENTITY(1,1),
    MaHanhLy CHAR(12) unique, 
    SoKG FLOAT NOT NULL,
    LoaiHanhLy NVARCHAR(30) CHECK (LoaiHanhLy IN (N'Hành lý ký gửi', N'Hành lý xách tay')), 
	IDVe INT NOT NULL,
    IDHanhKhach INT NOT NULL,
    IDTuyenBay INT NOT NULL,
    CONSTRAINT PK_HL_IDHanhLy PRIMARY KEY(ID),
	CONSTRAINT FK_HL_IDVe FOREIGN KEY(IDVe) REFERENCES VE(ID) ON DELETE NO ACTION,
    CONSTRAINT FK_HL_IDHanhKhach FOREIGN KEY(IDHanhKhach) REFERENCES HANHKHACH(ID) ON DELETE NO ACTION, 
    CONSTRAINT FK_HL_IDTuyenBay FOREIGN KEY(IDTuyenBay) REFERENCES TUYENBAY(ID) ON DELETE NO ACTION
);

CREATE TABLE CHITIETPHUPHI
(
	ID INT NOT NULL IDENTITY(1,1),
	MaPhuPhi CHAR(12) unique,
	PhuPhi MONEY DEFAULT 0,
	LoaiPhuPhi NVARCHAR(50) NOT NULL,  -- Thêm lo?i ph? phí(ph? phí c?a hành lý ho?c ph? phí c?a d?ch v? (n?u có))
	IDHanhLy INT NOT NULL,
	CONSTRAINT PK_CTPhuPhi_IDPhuPhi PRIMARY KEY(ID),
	CONSTRAINT FK_CTPhuPhi_IDHanhLy FOREIGN KEY(IDHanhLy) REFERENCES HANHLY(ID) ON DELETE NO ACTION
);

CREATE TABLE HOADON
(
	ID INT NOT NULL IDENTITY(1,1),
    MaHoaDon CHAR(12),         
    NgayLapHoaDon DATE NOT NULL,                    
    TongTien MONEY DEFAULT 0,                    
    HinhThucThanhToan NVARCHAR(20),    -- Hình th?c thanh toán (VD: 'Ti?n m?t', 'Chuy?n kho?n')
	TrangThaiHoaDon NVARCHAR(20) CHECK (TrangThaiHoaDon IN (N'Ðã thanh toán', N'Chưa thanh toán', N'Ðã hoàn tiền')),  -- Tr?ng thái thanh toán
	IDHanhKhach INT NOT NULL,
    CONSTRAINT PK_HD_IDHoaDon PRIMARY KEY(ID),
	CONSTRAINT FK_HD_IDHanhKhach FOREIGN KEY(IDHanhKhach) REFERENCES HANHKHACH(ID) ON DELETE NO ACTION
);

CREATE TABLE GIAVE
(
	ID INT NOT NULL IDENTITY(1,1),
	MaGiaVe CHAR(12) unique,
	TongGiaVe MONEY DEFAULT 0,
	GiamGia DECIMAL(3, 2),
	Thue MONEY,
	IDVe INT NOT NULL,
	IDPhuPhi INT NOT NULL,
	IDHoaDon INT NOT NULL,
	IDTuyenBay INT NOT NULL,
	CONSTRAINT PK_GV_IDGiaVe PRIMARY KEY(ID),
	CONSTRAINT FK_GV_IDVe FOREIGN KEY (IDVe) REFERENCES VE(ID) ON DELETE NO ACTION,
	CONSTRAINT FK_GV_IDPhuPhi FOREIGN KEY (IDPhuPhi) REFERENCES CHITIETPHUPHI(ID) ON DELETE NO ACTION,
	CONSTRAINT FK_GV_IDHoaDon FOREIGN KEY (IDHoaDon) REFERENCES HOADON(ID) ON DELETE NO ACTION,
	CONSTRAINT FK_GV_IDTuyenBay FOREIGN KEY(IDTuyenBay) REFERENCES TUYENBAY(ID) ON DELETE NO ACTION
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

CREATE TABLE CHITIETHOADON
(
	ID INT unique,
    MaHoaDon CHAR(12),
	SoLuongVe int,
	Ve MONEY,
	Thue MONEY,
	PhuPhiHeThong MONEY,
	PhuPhiAnNinh MONEY,
	Ghe MONEY,
	HanhLy MONEY,
	KM_ThanhVienLauNam MONEY,
	KM_MaKhuyenMai MONEY,
	TenNhanVienTruc NVARCHAR(30)
	CONSTRAINT PK_CTHD PRIMARY KEY(ID),
	CONSTRAINT FK_CTHD_HD FOREIGN KEY(ID) REFERENCES HOADON(ID)
);
DBCC CHECKIDENT ('SANBAY', RESEED, 0);
DBCC CHECKIDENT ('MAYBAY', RESEED, 0);
DBCC CHECKIDENT ('CHANGBAY', RESEED, 0);
DBCC CHECKIDENT ('QLTAIKHOAN', RESEED, 0);
DBCC CHECKIDENT ('NHANVIEN', RESEED, 0);
DBCC CHECKIDENT ('TUYENBAY', RESEED, 0);
DBCC CHECKIDENT ('HANHKHACH', RESEED, 0);
DBCC CHECKIDENT ('GIAVE', RESEED, 0);
DBCC CHECKIDENT ('HANHLY', RESEED, 0);
DBCC CHECKIDENT ('CHITIETPHUPHI', RESEED, 0);
DBCC CHECKIDENT ('HOADON', RESEED, 0);
DBCC CHECKIDENT ('CHITIETHOADON', RESEED, 0);
DBCC CHECKIDENT ('VE', RESEED, 0);

SELECT * FROM SANBAY
SELECT * FROM MAYBAY
SELECT * FROM CHANGBAY
SELECT * FROM QLTAIKHOAN
SELECT * FROM NHANVIEN
SELECT * FROM TUYENBAY
SELECT * FROM HANHKHACH
SELECT * FROM GIAVE
SELECT * FROM HANHLY
SELECT * FROM CHITIETPHUPHI
SELECT * FROM HOADON
SELECT * FROM CHITIETHOADON
SELECT * FROM VE

-----------------------------------------------------------------------
--								DỮ LIỆU
-----------------------------------------------------------------------
INSERT INTO SANBAY (MaSanBay, TenSanBay, DiaDiem)
VALUES 
    ('SGN', N'Sân bay Quốc tế Tân Sơn Nhất', N'TP.HCM'),
    ('HAN', N'Sân bay Quốc tế Nội Bài', N'Hà Nội'),
    ('DAD', N'Sân bay Quốc tế Đà Nẵng', N'Đà Nẵng'),
    ('CXR', N'Sân bay Quốc tế Cam Ranh', N'Cam Ranh'),
    ('PQC', N'Sân bay Quốc tế Phú Quốc', N'Phú Quốc'),
	('VDO', N'Sân bay Quốc tế Vân Đồn', N'Quảng Ninh');

INSERT INTO MAYBAY (MaMayBay, LoaiMayBay, HangBay, TongSoGhe)
VALUES 
    ('VN-A123', N'Airbus A320', N'VietJet Air', 180),
    ('VN-B123', N'Boeing 787', N'Vietnam Airlines', 300),
    ('VN-C123', N'Airbus A321', N'Bamboo Airways', 220),
    ('VN-D123', N'Boeing 777', N'Vietnam Airlines', 350),
    ('VN-E123', N'Airbus A330', N'Bamboo Airways', 260);

INSERT INTO CHANGBAY(IDSanBaydi, IDSanBayden)
VALUES 
	(1,2),
	(1,3),
	(1,4),
	(1,5),
	(2,1),
	(2,3),
	(2,4),
	(2,5),
	(3,1),
	(3,2),
	(3,4),
	(3,5),
	(4,1),
	(4,2),
	(4,3),
	(4,5),
	(5,1),
	(5,2),
	(5,3),
	(5,4)

INSERT INTO QLTaiKhoan (TenTaiKhoan, TenDangNhap, MatKhau, LoaiTaiKhoan)
VALUES 
    (N'Nguyễn Văn A', 'nguyenvana', 'password123', N'Quản lý'),
    (N'Trần Thị B', 'tranthib', 'password456', N'Nhân viên'),
    (N'Lê Văn C', 'levanc', 'pass789', N'Nhân viên'),
    (N'Phạm Thị D', 'phamthid', 'secret123', N'Nhân viên'),
    (N'Hoàng Văn E', 'hoangvane', 'secure456', N'Nhân viên');

INSERT INTO NHANVIEN (TenNhanVien, GioiTinhNhanVien, LuongNhanVien, NgaySinhNhanVien, DiaChiNhanVien, SDTNhanVien, ChucVu, IDSanBay, IDTaiKhoan) 
VALUES 
	(N'Nguyễn Văn A', N'Nam', 15000000, '1985-05-12', N'123 Đường ABC', '0912345678', N'Quản lý', 1, 1),
	(N'Trần Thị B', N'Nữ', 18000000, '1990-10-22', N'456 Đường DEF', '0912345679', N'Nhân viên', 2, 2),
	(N'Lê Văn C', N'Nam', 16000000, '1988-08-15', N'789 Đường GHI', '0912345680', N'Nhân viên', 3, 3),
	(N'Phạm Thị D', N'Nữ', 17000000, '1992-03-20', N'321 Đường JKL', '0912345681', N'Nhân viên', 4, 4),
	(N'Hoàng Văn E', N'Nam', 15500000, '1986-06-30', N'654 Đường MNO', '0912345682', N'Nhân viên', 5, 5);

INSERT INTO HANHKHACH (TenHanhKhach, GioiTinhHanhKhach, NgaySinhHanhKhach, DiaChiHanhKhach, Email, SDTHanhKhach, CCCD) 
VALUES 
    (N'Nguyễn Văn F', N'Nam', '1990-01-01', N'Thành phố Hồ Chí Minh', 'f.nguyen@example.com', '0909123456', '0123456789'),
    (N'Trần Thị G', N'Nữ', '1992-02-02', N'Bến Tre', 'g.tran@example.com', '0912123456', '9876543210'),
	(N'Lê Văn H', N'Nam', '1988-03-03', N'Phú Quốc', 'h.le@example.com', '0903123456', '1234567890'),
    (N'Phạm Thị K', N'Nữ', '1991-04-04', N'Tiền Giang', 'k.pham@example.com', '0918123456', '0987654321'),
    (N'Hoàng Văn L', N'Nam', '1985-05-05', N'Yên Bái', 'l.hoang@example.com', '0904123456', '2345678901');

--INSERT INTO GIAVE (MaGiaVe, GiaVeCoBan, HangVe, DonViTien)
--VALUES 
--	('TG', 2000000, N'Thương gia', N'VNĐ'),
--	('PT', 500000, N'Phổ thông', N'VNĐ');
	
INSERT INTO HOADON(NgayLapHoaDon, TongTien, HinhThucThanhToan, TrangThaiHoaDon, IDHanhKhach) 
VALUES 
('2024-11-11', 1500000, N'Chuyển khoản', N'Ðã thanh toán', 1),
('2024-11-15', 1500000, N'Chuyển khoản', N'Ðã thanh toán', 2),
('2024-11-17', 1500000, N'Tiền mặt', N'Ðã thanh toán', 3),
('2024-11-25', 1500000, N'Chuyển khoản', N'Ðã thanh toán', 4),
('2024-12-01', 1500000, N'Tiền mặt', N'Ðã thanh toán', 5)

INSERT INTO CHITIETHOADON(ID, MaHoaDon, SoLuongVe, Ve, Thue, PhuPhiHeThong, PhuPhiAnNinh, Ghe, HanhLy, KM_ThanhVienLauNam, KM_MaKhuyenMai, TenNhanVienTruc)
VALUES
(1, 'HD202412001', 2, 500000, 150000, 175000, 175000, 0, 0, 0, 0, N'Trần Thị B'),
(2, 'HD202412002', 2, 500000, 150000, 175000, 175000, 0, 0, 0, 0, N'Nguyễn Văn A'),
(3, 'HD202412003', 2, 500000, 150000, 175000, 175000, 0, 0, 0, 0, N'Lê Văn C'),
(4, 'HD202412004', 2, 500000, 150000, 175000, 175000, 0, 0, 0, 0, N'Nguyễn Văn A'),
(5, 'HD202412005', 2, 500000, 150000, 175000, 175000, 0, 0, 0, 0, N'Hoàng Văn E')

INSERT INTO TUYENBAY (NgayBay, GioBay, GioDen, SoVeConLai, SoVeDaBan, IDMayBay, IDChangBay)
VALUES 
	-- 3 tháng 12
	('2024-12-03', '00:00', '02:00', 180, 0, 1, 7),
	('2024-12-03', '03:00', '05:00', 300, 0, 2, 7),
	('2024-12-03', '06:00', '08:00', 220, 0, 3, 7),
	('2024-12-03', '09:00', '11:00', 350, 0, 4, 7),
	('2024-12-03', '12:00', '14:00', 260, 0, 5, 7),
	('2024-12-03', '15:00', '17:00', 100, 0, 1, 7),
	('2024-12-03', '18:00', '20:00', 160, 0, 2, 7),
	('2024-12-03', '21:00', '23:00', 280, 0, 3, 7),
	-- 4 tháng 12
	('2024-12-04', '00:00', '02:00', 180, 0, 1, 7),
	('2024-12-04', '03:00', '05:00', 300, 0, 2, 7),
	('2024-12-04', '06:00', '08:00', 220, 0, 3, 7),
	('2024-12-04', '09:00', '11:00', 350, 0, 4, 7),
	('2024-12-04', '12:00', '14:00', 260, 0, 5, 7),
	('2024-12-04', '15:00', '17:00', 100, 0, 1, 7),
	('2024-12-04', '18:00', '20:00', 160, 0, 2, 7),
	('2024-12-04', '21:00', '23:00', 280, 0, 3, 7),
	-- 5 tháng 12
	('2024-12-05', '00:00', '02:00', 180, 0, 1, 7),
	('2024-12-05', '03:00', '05:00', 300, 0, 2, 7),
	('2024-12-05', '06:00', '08:00', 220, 0, 3, 7),
	('2024-12-05', '09:00', '11:00', 350, 0, 4, 7),
	('2024-12-05', '12:00', '14:00', 260, 0, 5, 7),
	('2024-12-05', '15:00', '17:00', 100, 0, 1, 7),
	('2024-12-05', '18:00', '20:00', 160, 0, 2, 7),
	('2024-12-05', '21:00', '23:00', 280, 0, 3, 7),
	-- 6 tháng 12
	('2024-12-06', '00:00', '02:00', 180, 0, 1, 7),
	('2024-12-06', '03:00', '05:00', 300, 0, 2, 7),
	('2024-12-06', '06:00', '08:00', 220, 0, 3, 7),
	('2024-12-06', '09:00', '11:00', 350, 0, 4, 7),
	('2024-12-06', '12:00', '14:00', 260, 0, 5, 7),
	('2024-12-06', '15:00', '17:00', 100, 0, 1, 7),
	('2024-12-06', '18:00', '20:00', 160, 0, 2, 7),
	('2024-12-06', '21:00', '23:00', 280, 0, 3, 7),
	-- 7 tháng 12
	('2024-12-07', '00:00', '02:00', 180, 0, 1, 7),
	('2024-12-07', '03:00', '05:00', 300, 0, 2, 7),
	('2024-12-07', '06:00', '08:00', 220, 0, 3, 7),
	('2024-12-07', '09:00', '11:00', 350, 0, 4, 7),
	('2024-12-07', '12:00', '14:00', 260, 0, 5, 7),
	('2024-12-07', '15:00', '17:00', 100, 0, 1, 7),
	('2024-12-07', '18:00', '20:00', 160, 0, 2, 7),
	('2024-12-07', '21:00', '23:00', 280, 0, 3, 7),
	-- 8 tháng 12
	('2024-12-08', '00:00', '02:00', 180, 0, 1, 7),
	('2024-12-08', '03:00', '05:00', 300, 0, 2, 7),
	('2024-12-08', '06:00', '08:00', 220, 0, 3, 7),
	('2024-12-08', '09:00', '11:00', 350, 0, 4, 7),
	('2024-12-08', '12:00', '14:00', 260, 0, 5, 7),
	('2024-12-08', '15:00', '17:00', 100, 0, 1, 7),
	('2024-12-08', '18:00', '20:00', 160, 0, 2, 7),
	('2024-12-08', '21:00', '23:00', 280, 0, 3, 7),
	-- 9 tháng 12
	('2024-12-09', '00:00', '02:00', 180, 0, 1, 7),
	('2024-12-09', '03:00', '05:00', 300, 0, 2, 7),
	('2024-12-09', '06:00', '08:00', 220, 0, 3, 7),
	('2024-12-09', '09:00', '11:00', 350, 0, 4, 7),
	('2024-12-09', '12:00', '14:00', 260, 0, 5, 7),
	('2024-12-09', '15:00', '17:00', 100, 0, 1, 7),
	('2024-12-09', '18:00', '20:00', 160, 0, 2, 7),
	('2024-12-09', '21:00', '23:00', 280, 0, 3, 7),
	-- 10 tháng 12
	('2024-12-10', '00:00', '02:00', 180, 0, 1, 7),
	('2024-12-10', '03:00', '05:00', 300, 0, 2, 7),
	('2024-12-10', '06:00', '08:00', 220, 0, 3, 7),
	('2024-12-10', '09:00', '11:00', 350, 0, 4, 7),
	('2024-12-10', '12:00', '14:00', 260, 0, 5, 7),
	('2024-12-10', '15:00', '17:00', 100, 0, 1, 7),
	('2024-12-10', '18:00', '20:00', 160, 0, 2, 7),
	('2024-12-10', '21:00', '23:00', 280, 0, 3, 7),
	-- 11 tháng 12
	('2024-12-11', '00:00', '02:00', 180, 0, 1, 7),
	('2024-12-11', '03:00', '05:00', 300, 0, 2, 7),
	('2024-12-11', '06:00', '08:00', 220, 0, 3, 7),
	('2024-12-11', '09:00', '11:00', 350, 0, 4, 7),
	('2024-12-11', '12:00', '14:00', 260, 0, 5, 7),
	('2024-12-11', '15:00', '17:00', 100, 0, 1, 7),
	('2024-12-11', '18:00', '20:00', 160, 0, 2, 7),
	('2024-12-11', '21:00', '23:00', 280, 0, 3, 7),
	-- 12 tháng 12
	('2024-12-12', '00:00', '02:00', 180, 0, 1, 7),
	('2024-12-12', '03:00', '05:00', 300, 0, 2, 7),
	('2024-12-12', '06:00', '08:00', 220, 0, 3, 7),
	('2024-12-12', '09:00', '11:00', 350, 0, 4, 7),
	('2024-12-12', '12:00', '14:00', 260, 0, 5, 7),
	('2024-12-12', '15:00', '17:00', 100, 0, 1, 7),
	('2024-12-12', '18:00', '20:00', 160, 0, 2, 7),
	('2024-12-12', '21:00', '23:00', 280, 0, 3, 7),
	-- 13 tháng 12
	('2024-12-13', '00:00', '02:00', 180, 0, 1, 7),
	('2024-12-13', '03:00', '05:00', 300, 0, 2, 7),
	('2024-12-13', '06:00', '08:00', 220, 0, 3, 7),
	('2024-12-13', '09:00', '11:00', 350, 0, 4, 7),
	('2024-12-13', '12:00', '14:00', 260, 0, 5, 7),
	('2024-12-13', '15:00', '17:00', 100, 0, 1, 7),
	('2024-12-13', '18:00', '20:00', 160, 0, 2, 7),
	('2024-12-13', '21:00', '23:00', 280, 0, 3, 7),
	-- 14 tháng 12
	('2024-12-14', '00:00', '02:00', 180, 0, 1, 7),
	('2024-12-14', '03:00', '05:00', 300, 0, 2, 7),
	('2024-12-14', '06:00', '08:00', 220, 0, 3, 7),
	('2024-12-14', '09:00', '11:00', 350, 0, 4, 7),
	('2024-12-14', '12:00', '14:00', 260, 0, 5, 7),
	('2024-12-14', '15:00', '17:00', 100, 0, 1, 7),
	('2024-12-14', '18:00', '20:00', 160, 0, 2, 7),
	('2024-12-14', '21:00', '23:00', 280, 0, 3, 7);

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
    SELECT TenNhanVien, GioiTinhNhanVien, LuongNhanVien, NgaySinhNhanVien, DiaChiNhanVien, SDTNhanVien, ChucVu, IDSanBay, IDTaiKhoan FROM inserted;

    OPEN cur;
    FETCH NEXT FROM cur INTO @TenNV, @GioiTinhNV, @LuongNV, @NgaySinhNV, @DiaChiNV, @SDTnv, @ChucVu, @IDSanBay, @IDTaiKhoan;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @newMaNhanVien = 'NV' + @currentMonthYear + RIGHT('000' + CAST(@nextID AS VARCHAR(3)), 3);
        
        INSERT INTO NHANVIEN (MaNhanVien, TenNhanVien, GioiTinhNhanVien, LuongNhanVien, NgaySinhNhanVien, DiaChiNhanVien, SDTNhanVien, ChucVu, IDSanBay, IDTaiKhoan)
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
    SELECT TenHanhKhach, GioiTinhHanhKhach, NgaySinhHanhKhach, DiaChiHanhKhach, Email, SDTHanhKhach, CCCD FROM inserted;

    OPEN cur;
    FETCH NEXT FROM cur INTO @TenHK, @GioiTinhHK, @NgaySinhHK, @DiaChiHK, @EmailHK, @SDThk, @CCCD;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @newMaHanhKhach = 'HK' + @currentMonthYear + RIGHT('000' + CAST(@nextID AS VARCHAR(3)), 3);
        
        INSERT INTO HANHKHACH (MaHanhKhach, TenHanhKhach, GioiTinhHanhKhach, NgaySinhHanhKhach, DiaChiHanhKhach, Email, SDTHanhKhach, CCCD)
        VALUES (@newMaHanhKhach, @TenHK, @GioiTinhHK, @NgaySinhHK, @DiaChiHK, @EmailHK, @SDThk, @CCCD);

        SET @nextID = @nextID + 1;

        FETCH NEXT FROM cur INTO @TenHK, @GioiTinhHK, @NgaySinhHK, @DiaChiHK, @EmailHK, @SDThk, @CCCD;
    END

    CLOSE cur;
    DEALLOCATE cur;
END

-----------------------------------------------------------------------
--								HOADON
-----------------------------------------------------------------------
CREATE TRIGGER trg_AutoMaHoaDon
ON HOADON
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @currentMonthYear CHAR(6) = CONVERT(CHAR(6), GETDATE(), 112), -- Lấy tháng năm hiện tại
            @nextID INT,
            @newMaHoaDon CHAR(12),
            @NgayLapHoaDon DATE,
            @TongTien MONEY,
            @HinhThucThanhToan NVARCHAR(20),
            @TrangThaiHoaDon NVARCHAR(20),
			@IDHanhKhach INT;

    -- Tìm ID tiếp theo
    SELECT @nextID = ISNULL(MAX(CAST(SUBSTRING(MaHoaDon, 9, 3) AS INT)), 0) + 1
    FROM HOADON
    WHERE MaHoaDon LIKE 'HD' + @currentMonthYear + '%';

    -- Khai báo con trỏ để duyệt qua các bản ghi được chèn vào
    DECLARE cur CURSOR FOR
    SELECT NgayLapHoaDon, TongTien, HinhThucThanhToan, TrangThaiHoaDon, IDHanhKhach
    FROM inserted;

    OPEN cur;

    FETCH NEXT FROM cur INTO @NgayLapHoaDon, @TongTien, @HinhThucThanhToan, @TrangThaiHoaDon, @IDHanhKhach;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @newMaHoaDon = 'HD' + @currentMonthYear + RIGHT('000' + CAST(@nextID AS VARCHAR(3)), 3);

        INSERT INTO HOADON (MaHoaDon, NgayLapHoaDon, TongTien, HinhThucThanhToan, TrangThaiHoaDon, IDHanhKhach)
        VALUES (@newMaHoaDon, @NgayLapHoaDon, @TongTien, @HinhThucThanhToan, @TrangThaiHoaDon, @IDHanhKhach);

        SET @nextID = @nextID + 1;

        FETCH NEXT FROM cur INTO @NgayLapHoaDon, @TongTien, @HinhThucThanhToan, @TrangThaiHoaDon, @IDHanhKhach;
    END

    CLOSE cur;
    DEALLOCATE cur;
END;

CREATE TRIGGER trg_setTrangThaiTUYENBAY
ON TUYENBAY
FOR INSERT, UPDATE
AS
BEGIN
    UPDATE TB
    SET TrangThaiTuyenBay = CASE 
                                WHEN (ins.SoVeConLai - ins.SoVeDaBan) = 0 THEN N'Hết vé'
                                ELSE N'Còn vé'
                            END
    FROM TUYENBAY TB
    INNER JOIN inserted ins ON TB.MaTuyenBay = ins.MaTuyenBay;
END
