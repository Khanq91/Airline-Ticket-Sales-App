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
	TenTaiKhoan NVARCHAR(50),
    TenDangNhap VARCHAR(50),
	MatKhau VARCHAR(50),
	LoaiTK NVARCHAR(30) CHECK (LoaiTK IN (N'HANHKHACH', N'NHANVIEN')), 
	CONSTRAINT PK_TK PRIMARY KEY(IDTaiKhoan)
);

CREATE TABLE NHANVIEN 
(
	MaNV CHAR(10) NOT NULL,
	TenNV NVARCHAR(50),
	GioiTinhNV NVARCHAR(4) CHECK(GioiTinhNV IN (N'Nam', N'Nữ')),
	LuongNV MONEY,
	NgaySinhNV DATE,
	DiaChiNV NVARCHAR(50),
	SDTnv VARCHAR(11) CHECK (SDTnv LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
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
	SoVeConLai INT,                   -- Số vé còn lại trên chuyến bay
	SoVeDaBan INT,
    TrangThaiChuyenBay NVARCHAR(20),           -- Tình trạng vé (VD: 'Còn vé', 'Hết vé')
	MaMB CHAR(10) NOT NULL,
	MaChangBay CHAR(10) NOT NULL,
	CONSTRAINT PK_CB_MaCB PRIMARY KEY(MaCB),
	CONSTRAINT FK_CB_MaMB FOREIGN KEY(MaMB) REFERENCES MAYBAY(MaMB),
	CONSTRAINT FK_CB_MaChangBay FOREIGN KEY(MaChangBay) REFERENCES CHANGBAY(MaChangBay)
);

CREATE TABLE HANHKHACH 
(
	MaHK CHAR(10) NOT NULL,
	TenHK NVARCHAR(50) DEFAULT '',      
	GioiTinhHK NVARCHAR(4) CHECK(GioiTinhHK IN (N'Nam', N'Nữ')),
	NgaySinhHK DATE DEFAULT NULL,     -- Có thể để NULL nếu không cung cấp giá trị
	DiaChiHK NVARCHAR(50) DEFAULT '',     
	EmailHK VARCHAR(30) DEFAULT '',       
	SDThk CHAR(11) DEFAULT '' CHECK (SDThk LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	CCCD CHAR(20) UNIQUE DEFAULT '',    
	HoChieu CHAR(20) UNIQUE DEFAULT '', 
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

CREATE TABLE HANHLY 
(
    MaHL CHAR(10) NOT NULL, -- Định nghĩa là UNIQUEIDENTIFIER
    SoKG FLOAT,
    LoaiHanhLy NVARCHAR(30) CHECK (LoaiHanhLy IN (N'Hành lý ký gửi', N'Hành lý xách tay')),
	MaHangVe CHAR(10) NOT NULL,  
    MaHK CHAR(10) NOT NULL,
    MaCB CHAR(10) NOT NULL,
    CONSTRAINT PK_HL_MaHL PRIMARY KEY(MaHL),
	CONSTRAINT FK_HL_MaHangVe FOREIGN KEY(MaHangVe) REFERENCES HANGVE(MaHangVe),
    CONSTRAINT FK_HL_MaHK FOREIGN KEY(MaHK) REFERENCES HANHKHACH(MaHK),
    CONSTRAINT FK_HL_MaCB FOREIGN KEY(MaCB) REFERENCES CHUYENBAY(MaCB)
);

CREATE TABLE CHITIETPHUPHI
(
	MaPhuPhi CHAR(10) NOT NULL,
	PhuPhi MONEY DEFAULT 0,
	LoaiPhuPhi NVARCHAR(50),  -- Thêm loại phụ phí(phụ phí của hành lý hoặc phụ phí của dịch vụ (nếu có))
	MaHL CHAR(10) NOT NULL,
	CONSTRAINT PK_CTPhuPhi_MaPhuPhi PRIMARY KEY(MaPhuPhi),
	CONSTRAINT FK_CTPhuPhi_MaHL FOREIGN KEY(MaHL) REFERENCES HANHLY(MaHL)
);

CREATE TABLE GIAVE
(
	MaGiaVe CHAR(10) NOT NULL,
	GiaCoBan MONEY,
	TongGiaVe MONEY DEFAULT 0,
	GiamGia MONEY DEFAULT 0,
	MaPhuPhi CHAR(10) NOT NULL,
	MaCB CHAR(10) NOT NULL,
	MaHangVe CHAR(10) NOT NULL,
	CONSTRAINT PK_GV_MaGiaVe PRIMARY KEY(MaGiaVe),
	CONSTRAINT FK_GV_MaPhuPhi FOREIGN KEY (MaPhuPhi) REFERENCES CHITIETPHUPHI(MaPhuPhi),
	CONSTRAINT FK_GV_MaCB FOREIGN KEY(MaCB) REFERENCES CHUYENBAY(MaCB),
	CONSTRAINT FK_GV_MaHangVe FOREIGN KEY(MaHangVe) REFERENCES HANGVE(MaHangVe)
);

CREATE TABLE DATVE
(
	MaDV CHAR(10) NOT NULL,
	ThanhTien MONEY DEFAULT 0,
	SoVeDat INT DEFAULT 0,
	NgayDatVe DATE,  
	--MaVe CHAR(10) NOT NULL,
	MaCB CHAR(10) NOT NULL,
	MaHK CHAR(10) NOT NULL,
	CONSTRAINT PK_DV_MaDV PRIMARY KEY(MaDV),
	--CONSTRAINT FK_DV_MaVe FOREIGN KEY(MaVe) REFERENCES VE(MaVe),
	CONSTRAINT FK_DV_MaHK FOREIGN KEY(MaHK) REFERENCES HANHKHACH(MaHK),
	CONSTRAINT FK_DV_MaCB FOREIGN KEY(MaCB) REFERENCES CHUYENBAY(MaCB)
);

CREATE TABLE HOADON
(
    MaHD CHAR(10) NOT NULL,
    MaDV CHAR(10) NOT NULL,            
    NgayLapHD DATE NOT NULL,                    
    TongTien MONEY DEFAULT 0,                    
    HinhThucThanhToan NVARCHAR(20),    -- Hình thức thanh toán (VD: 'Tiền mặt', 'Chuyển khoản')
	TrangThai NVARCHAR(20) CHECK (TrangThai IN (N'Đã thanh toán', N'Chưa thanh toán', N'Đã hoàn tiền')),  -- Trạng      thái thanh toán
    CONSTRAINT PK_HD PRIMARY KEY(MaHD),
    CONSTRAINT FK_HD_MaDV FOREIGN KEY(MaDV) REFERENCES DATVE(MaDV)
);

CREATE TABLE LICHSUGIAODICH
(
    MaGD CHAR(10) NOT NULL,            
    MaHD CHAR(10) NOT NULL,            
    NgayGiaoDich DATETIME NOT NULL,    -- Ngày và giờ giao dịch         
    TrangThaiDatVe NVARCHAR(20),          -- Trạng thái đặt vé (VD: 'Đã xác nhận', 'Đã hủy')
    CONSTRAINT PK_LSGD_MaGD PRIMARY KEY(MaGD),
    CONSTRAINT FK_LSGD_MaHD FOREIGN KEY(MaHD) REFERENCES HOADON(MaHD)  
);

CREATE TABLE VE 
(
	MaVe CHAR(10) NOT NULL,
	DonViTien NCHAR(10),
	ViTriGhe CHAR(10),
	--TrangThai NVARCHAR(20),
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
	NDNhanXet NVARCHAR(100),
	DiemDanhGia INT CHECK (DiemDanhGia BETWEEN 1 AND 5),
	CONSTRAINT PK_NX_MaHK_MaCB PRIMARY KEY(MaHK, MaCB),
	CONSTRAINT FK_NX_MaHK FOREIGN KEY(MaHK) REFERENCES HANHKHACH(MaHK),
	CONSTRAINT FK_NX_MaCB FOREIGN KEY(MaCB) REFERENCES CHUYENBAY(MaCB)
);

-----------------------------------------------------------------------
--				DỮ LIỆU
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
    ('CV002', N'Nhân viên');

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

INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinhNV, LuongNV, NgaySinhNV, DiaChiNV, SDTnv, MaSB, MaChucVu, IDTaiKhoan) 
VALUES 
	('NV001', N'Nguyễn Văn X', N'Nam', 15000000, '1980-01-01', N'Thành phố Hồ Chí Minh', '0905123456', 'SB001', 'CV001', 'TK001'),
	('NV002', N'Trần Thị Y', N'Nữ', 16000000, '1985-02-02', N'Hà Nội', '0906123456', 'SB002', 'CV002', 'TK002'),
	('NV003', N'Lê Văn Z', N'Nam', 17000000, '1990-03-03', N'Đà Nẵng', '0907123456', 'SB003', 'CV002', 'TK003'),
	('NV004', N'Phạm Thị M', N'Nữ', 18000000, '1982-04-04', N'Hải Phòng', '0908123456', 'SB004', 'CV002', 'TK004'),
	('NV005', N'Hoàng Văn N', N'Nam', 19000000, '1987-05-05', N'Cần Thơ', '0909123456', 'SB005', 'CV002', 'TK005');

INSERT INTO CHUYENBAY (MaCB, NgayBay, GioBay, GioDen, ThoiGianBay, SoVeConLai, SoVeDaBan, TrangThaiChuyenBay, MaMB, MaChangBay)
VALUES 
    ('CB001', '2024-10-15', '08:00', '10:00', '02:00', 100, 80, N'Còn vé', 'MB001', 'CBY001'),
    ('CB002', '2024-10-16', '14:00', '16:30', '02:30', 50, 250, N'Hết vé', 'MB002', 'CBY002'),
    ('CB003', '2024-10-17', '09:00', '11:30', '02:30', 120, 100, N'Còn vé', 'MB003', 'CBY003'),
    ('CB004', '2024-10-18', '13:00', '15:30', '02:30', 90, 260, N'Còn vé', 'MB004', 'CBY004'),
    ('CB005', '2024-10-19', '17:00', '19:30', '02:30', 200, 60, N'Còn vé', 'MB005', 'CBY005');

INSERT INTO HANHKHACH (MaHK, TenHK, GioiTinhHK, NgaySinhHK, DiaChiHK, EmailHK, SDThk, CCCD, HoChieu, IDTaiKhoan) 
VALUES 
    ('HK001', N'Nguyễn Văn F', N'Nam', '1990-01-01', N'Thành phố Hồ Chí Minh', 'f.nguyen@example.com', '0909123456', '0123456789', 'A1234567', 'TK006'),
    ('HK002', N'Trần Thị G', N'Nữ', '1992-02-02', N'Bến Tre', 'g.tran@example.com', '0912123456', '9876543210', 'B1234567', 'TK007'),
    ('HK003', N'Lê Văn H', N'Nam', '1988-03-03', N'Phú Quốc', 'h.le@example.com', '0903123456', '1234567890', 'C1234567', 'TK008'),
    ('HK004', N'Phạm Thị K', N'Nữ', '1991-04-04', N'Tiền Giang', 'k.pham@example.com', '0918123456', '0987654321', 'D1234567', 'TK009'),
    ('HK005', N'Hoàng Văn L', N'Nam', '1985-05-05', N'Yên Bái', 'l.hoang@example.com', '0904123456', '2345678901', 'E1234567', 'TK010');

INSERT INTO HANGVE (MaHangVe, TenHangVe) 
VALUES 
	('HV001', N'Hạng thương gia'),
	('HV002', N'Hạng phổ thông');

----------------------------------------------------
INSERT INTO HANHLY (MaHL, SoKG, LoaiHanhLy, MaHangVe, MaHK, MaCB) 
VALUES 
    ('HL001', 35, N'Hành lý ký gửi', 'HV001', 'HK001', 'CB001'), 
    ('HL002', 25, N'Hành lý ký gửi', 'HV002', 'HK002', 'CB002'),
    ('HL003', 5, N'Hành lý xách tay', 'HV001', 'HK001', 'CB001'),
    ('HL004', 8, N'Hành lý xách tay', 'HV002', 'HK002', 'CB002'),
    ('HL005', 30, N'Hành lý ký gửi', 'HV002', 'HK005', 'CB005');


INSERT INTO CHITIETPHUPHI (MaPhuPhi, PhuPhi, LoaiPhuPhi, MaHL)
VALUES
    ('PP001', 0, N'Hành lý', 'HL001'),
    ('PP002', 200000, N'Hành lý', 'HL002'),
    ('PP003', 0, N'Hành lý', 'HL003'),
    ('PP004', 0, N'Hành lý', 'HL004'),
    ('PP005', 150000, N'Hành lý', 'HL005');

INSERT INTO GIAVE (MaGiaVe, GiaCoBan, TongGiaVe, GiamGia, MaPhuPhi, MaCB, MaHangVe)
VALUES
    ('VE001', 3000000, 0, 0, 'PP001', 'CB001', 'HV001'),
    ('VE002', 2000000, 0, 0, 'PP002', 'CB002', 'HV002'),
    ('VE003', 3000000, 0, 0, 'PP003', 'CB003', 'HV001'),
    ('VE004', 2000000, 0, 0, 'PP004', 'CB004', 'HV002'),
    ('VE005', 2000000, 0, 0, 'PP005', 'CB005', 'HV002');
----------------------------------------------------
INSERT INTO DATVE (MaDV, NgayDatVe, SoVeDat, MaCB, MaHK)
VALUES
    ('DV001', '2024-10-10', 1, 'CB001', 'HK001'),
    ('DV002', '2024-10-11', 2, 'CB002', 'HK002'),
    ('DV003', '2024-10-12', 1, 'CB003', 'HK003'),
    ('DV004', '2024-10-13', 1, 'CB004', 'HK004'),
    ('DV005', '2024-10-14', 1, 'CB005', 'HK005');
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
