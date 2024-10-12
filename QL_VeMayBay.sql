CREATE DATABASE QL_VeMayBay
USE QL_VeMayBay

CREATE TABLE SANBAY 
(
	MaSB CHAR(6) NOT NULL,
	TenSB NVARCHAR(50),
	CONSTRAINT PK_SB_MaSB PRIMARY KEY(MaSB)
);

CREATE TABLE MAYBAY
(
	MaMB CHAR(10) NOT NULL,
	--  'VN-[A-Z][0-9][0-9][0-9]'
	-- Kiểm tra định dạng mã máy bay phải bắt đầu bằng "VN-" và theo sau là 1 chữ cái + 3 số
	LoaiMB NVARCHAR(50),
	HangBay NVARCHAR(50),
	TongSoGhe INT,
	CONSTRAINT PK_MB_MaMB PRIMARY KEY(MaMB)
);

CREATE TABLE CHANGBAY
(
	STTchangbay INT NOT NULL IDENTITY(1,1),
	MaChangBay CHAR(6) DEFAULT LEFT(CONVERT(VARCHAR(36), NEWID(), 2), 6), -- Chỉ lấy chữ và số từ NEWID
	MaSBdi CHAR(6) NOT NULL,
	MaSBden CHAR(6) NOT NULL,                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
	CONSTRAINT PK_ChB_STTchangbay PRIMARY KEY(STTchangbay),
	CONSTRAINT FK_ChB_MaSBdi FOREIGN KEY(MaSBdi) REFERENCES SANBAY(MaSB),
    CONSTRAINT FK_ChB_MaSBden FOREIGN KEY(MaSBden) REFERENCES SANBAY(MaSB)
);

CREATE TABLE CHUCVU
(
	MaChucVu CHAR(6) NOT NULL,
	TenChucVu NVARCHAR(30) CHECK (TenChucVu IN (N'Nhân viên', N'Quản lý')),
	CONSTRAINT PK_CV PRIMARY KEY(MaChucVu)
);

CREATE TABLE QLTaiKhoan
(
	IDTaiKhoan CHAR(10) NOT NULL DEFAULT RIGHT('0000000000' + CAST(ABS(CHECKSUM(NEWID())) AS VARCHAR(10)), 10),
	TenTaiKhoan NVARCHAR(50) NOT NULL,
    	TenDangNhap VARCHAR(50) NOT NULL,
	MatKhau VARCHAR(50) NOT NULL,
	LoaiTK NVARCHAR(30) NOT NULL CHECK (LoaiTK IN (N'Hành khách', N'Nhân viên')), 
	CONSTRAINT PK_TK PRIMARY KEY(IDTaiKhoan)
);

CREATE TABLE NHANVIEN 
(
	STTnv INT NOT NULL IDENTITY(1,1),
	MaNV CHAR(6) DEFAULT LEFT(CONVERT(VARCHAR(36), NEWID(), 2), 6),
	TenNV NVARCHAR(50) NOT NULL,
	GioiTinhNV NVARCHAR(4) CHECK(GioiTinhNV IN (N'Nam', N'Nữ')),
	LuongNV MONEY NOT NULL,
	NgaySinhNV DATE NOT NULL,
	DiaChiNV NVARCHAR(50),
	SDTnv VARCHAR(11) CHECK (SDTnv LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	MaSB CHAR(6) NOT NULL,
	MaChucVu CHAR(6) NOT NULL,
	IDTaiKhoan CHAR(10) NOT NULL,
	CONSTRAINT PK_NV_STTnv PRIMARY KEY(STTnv),
	CONSTRAINT FK_NV_MaSB FOREIGN KEY(MaSB) REFERENCES SANBAY(MaSB),
	CONSTRAINT FK_NV_MaChucVu FOREIGN KEY(MaChucVu) REFERENCES CHUCVU(MaChucVu),
	CONSTRAINT FK_NV_IDtk FOREIGN KEY(IDTaiKhoan) REFERENCES QLTaiKhoan(IDTaiKhoan)
);

CREATE TABLE CHUYENBAY
(
	STTcb INT NOT NULL IDENTITY(1,1),
	MaCB CHAR(6) DEFAULT LEFT(CONVERT(VARCHAR(36), NEWID()), 6),
	NgayBay DATE NOT NULL,  
	GioBay TIME NOT NULL,
	GioDen TIME NOT NULL,
	ThoiGianBay TIME,
	SoVeConLai INT,                  
	SoVeDaBan INT DEFAULT 0,
    	TrangThaiChuyenBay NVARCHAR(20) NOT NULL,           -- Tình trạng vé (VD: 'Còn vé', 'Hết vé')
	MaMB CHAR(10) NOT NULL,
	STTchangbay INT NOT NULL,
	CONSTRAINT PK_CB_STTcb PRIMARY KEY(STTcb),
	CONSTRAINT FK_CB_MaMB FOREIGN KEY(MaMB) REFERENCES MAYBAY(MaMB),
	CONSTRAINT FK_CB_STTchangbay FOREIGN KEY(STTchangbay) REFERENCES CHANGBAY(STTchangbay) 
);

CREATE TABLE HANHKHACH 
(
	STThk INT NOT NULL IDENTITY(1,1),
	MaHK CHAR(6) DEFAULT LEFT(CONVERT(VARCHAR(36), NEWID()), 6),
	TenHK NVARCHAR(50) NOT NULL,      
	GioiTinhHK NVARCHAR(4) CHECK(GioiTinhHK IN (N'Nam', N'Nữ')),
	NgaySinhHK DATE NOT NULL,    
	DiaChiHK NVARCHAR(50) NOT NULL,     
	EmailHK VARCHAR(30) NOT NULL,       
	SDThk CHAR(11) CHECK (SDThk LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	CCCD CHAR(20) UNIQUE NOT NULL,    
	HoChieu CHAR(20) UNIQUE NOT NULL, 
	IDTaiKhoan CHAR(10) NOT NULL,
	CONSTRAINT PK_HK_STThk PRIMARY KEY(STThk),
	CONSTRAINT FK_HK_IDtk FOREIGN KEY(IDTaiKhoan) REFERENCES QLTaiKhoan(IDTaiKhoan)
);

CREATE TABLE HANGVE
(
	MaHangVe CHAR(6) NOT NULL,
	TenHangVe NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_HVe_MaVe PRIMARY KEY(MaHangVe)
);

CREATE TABLE HANHLY 
(
	STThl INT NOT NULL IDENTITY(1,1),
    MaHL CHAR(6) DEFAULT LEFT(CONVERT(VARCHAR(36), NEWID()), 6), 
    SoKG FLOAT NOT NULL,
    LoaiHanhLy NVARCHAR(30) CHECK (LoaiHanhLy IN (N'Hành lý ký gửi', N'Hành lý xách tay')),
	MaHangVe CHAR(6) NOT NULL,  
    STThk INT NOT NULL,
    STTcb INT NOT NULL,
    CONSTRAINT PK_HL_STThl PRIMARY KEY(STThl),
	CONSTRAINT FK_HL_MaHangVe FOREIGN KEY(MaHangVe) REFERENCES HANGVE(MaHangVe),
    CONSTRAINT FK_HL_STThk FOREIGN KEY(STThk) REFERENCES HANHKHACH(STThk), 
    CONSTRAINT FK_HL_STTcb FOREIGN KEY(STTcb) REFERENCES CHUYENBAY(STTcb)
);

CREATE TABLE CHITIETPHUPHI
(
	STTpp INT NOT NULL IDENTITY(1,1),
	MaPhuPhi CHAR(6) DEFAULT LEFT(CONVERT(VARCHAR(36), NEWID(), 2), 6),
	PhuPhi MONEY DEFAULT 0,
	LoaiPhuPhi NVARCHAR(50) NOT NULL,  -- Thêm loại phụ phí(phụ phí của hành lý hoặc phụ phí của dịch vụ (nếu có))
	STThl INT NOT NULL,
	CONSTRAINT PK_CTPhuPhi_STTpp PRIMARY KEY(STTpp),
	CONSTRAINT FK_CTPhuPhi_STThl FOREIGN KEY(STThl) REFERENCES HANHLY(STThl)
);

CREATE TABLE GIAVE
(
	STTgiave INT NOT NULL IDENTITY(1,1),
	MaGiaVe CHAR(6) DEFAULT LEFT(CONVERT(VARCHAR(36), NEWID(), 2), 6),
	GiaCoBan MONEY,
	TongGiaVe MONEY DEFAULT 0,
	GiamGia MONEY DEFAULT 0,
	STTpp INT NOT NULL,
	STTcb INT NOT NULL,
	MaHangVe CHAR(6) NOT NULL,
	CONSTRAINT PK_GV_STTgiave PRIMARY KEY(STTgiave),
	CONSTRAINT FK_GV_STTpp FOREIGN KEY (STTpp) REFERENCES CHITIETPHUPHI(STTpp),
	CONSTRAINT FK_GV_STTcb FOREIGN KEY(STTcb) REFERENCES CHUYENBAY(STTcb),
	CONSTRAINT FK_GV_MaHangVe FOREIGN KEY(MaHangVe) REFERENCES HANGVE(MaHangVe)
);

CREATE TABLE DATVE
(
	STTdv INT NOT NULL IDENTITY(1,1),
	MaDV CHAR(6) DEFAULT LEFT(CONVERT(VARCHAR(36), NEWID(), 2), 6),
	ThanhTien MONEY DEFAULT 0,
	SoVeDat INT DEFAULT 0,
	NgayDatVe DATE,  
	STThk INT NOT NULL,
	STTcb INT NOT NULL,
	CONSTRAINT PK_DV_STTdv PRIMARY KEY(STTdv),
	CONSTRAINT FK_DV_STThk FOREIGN KEY(STThk) REFERENCES HANHKHACH(STThk),
	CONSTRAINT FK_DV_STTcb FOREIGN KEY(STTcb) REFERENCES CHUYENBAY(STTcb)
);

CREATE TABLE HOADON
(
	STThd INT NOT NULL IDENTITY(1,1),
    MaHD CHAR(6) DEFAULT LEFT(CONVERT(VARCHAR(36), NEWID(), 2), 6),         
    NgayLapHD DATE NOT NULL,                    
    TongTien MONEY DEFAULT 0,                    
    HinhThucThanhToan NVARCHAR(20),    -- Hình thức thanh toán (VD: 'Tiền mặt', 'Chuyển khoản')
	TrangThai NVARCHAR(20) CHECK (TrangThai IN (N'Đã thanh toán', N'Chưa thanh toán', N'Đã hoàn tiền')),  -- Trạng      thái thanh toán
	STTdv INT NOT NULL,   
    CONSTRAINT PK_HD_STThd PRIMARY KEY(STThd),
    CONSTRAINT FK_HD_STTdv FOREIGN KEY(STTdv) REFERENCES DATVE(STTdv)
);

CREATE TABLE LICHSUGIAODICH
(
	STTgd INT NOT NULL IDENTITY(1,1),
    MaGD CHAR(6) DEFAULT LEFT(CONVERT(VARCHAR(36), NEWID(), 2), 6),                        
    NgayGiaoDich DATETIME NOT NULL,    -- Ngày và giờ giao dịch         
    TrangThaiDatVe NVARCHAR(20),          -- Trạng thái đặt vé (VD: 'Đã xác nhận', 'Đã hủy')
	STThd INT NOT NULL,
    CONSTRAINT PK_LSGD_STTgd PRIMARY KEY(STTgd),
    CONSTRAINT FK_LSGD_STThd FOREIGN KEY(STThd) REFERENCES HOADON(STThd)  
);

CREATE TABLE VE 
(
	STTve INT NOT NULL IDENTITY(1,1),
	MaVe CHAR(6) DEFAULT LEFT(CONVERT(VARCHAR(36), NEWID(), 2), 6),
	DonViTien NCHAR(10),
	ViTriGhe CHAR(10),
	STThk INT NOT NULL, 
	STTdv INT NOT NULL,
	STTgiave INT NOT NULL,
	CONSTRAINT PK_VE_STTve PRIMARY KEY(STTve),
	CONSTRAINT FK_VE_STThk FOREIGN KEY(STThk) REFERENCES HANHKHACH(STThk),
	CONSTRAINT FK_VE_STTdv FOREIGN KEY(STTdv) REFERENCES DATVE(STTdv),
	CONSTRAINT FK_VE_STTgiave FOREIGN KEY(STTgiave) REFERENCES GIAVE(STTgiave)
);

CREATE TABLE NHANXET
(
	STThk INT NOT NULL,
	STTcb INT NOT NULL,
	NDNhanXet NVARCHAR(100),
	DiemDanhGia INT CHECK (DiemDanhGia BETWEEN 1 AND 5),
	CONSTRAINT PK_NX_STThk_STTcb PRIMARY KEY(STThk, STTcb),
	CONSTRAINT FK_NX_STThk FOREIGN KEY(STThk) REFERENCES HANHKHACH(STThk),
	CONSTRAINT FK_NX_STTcb FOREIGN KEY(STTcb) REFERENCES CHUYENBAY(STTcb)
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
    ('VN-A123', N'Airbus A320', N'VietJet Air', 180),
    ('VN-B123', N'Boeing 787', N'Vietnam Airlines', 300),
    ('VN-C123', N'Airbus A321', N'Bamboo Airways', 220),
    ('VN-D123', N'Boeing 777', N'Vietnam Airlines', 350),
    ('VN-E123', N'Airbus A330', N'Bamboo Airways', 260);

INSERT INTO CHANGBAY (MaSBdi, MaSBden)
VALUES 
	('SB001', 'SB002'),
    ('SB002', 'SB003'),
    ('SB003', 'SB004'),
    ('SB004', 'SB005'),
    ('SB001', 'SB005');

INSERT INTO CHUCVU (MaChucVu, TenChucVu)
VALUES 
    ('CV001', N'Quản lý'),
    ('CV002', N'Nhân viên');

INSERT INTO QLTaiKhoan (TenTaiKhoan, TenDangNhap, MatKhau, LoaiTK)
VALUES 
    (N'Nguyễn Văn A', 'nguyenvana', 'password123', N'Nhân viên'),
    (N'Trần Thị B', 'tranthib', 'password456', N'Nhân viên'),
    (N'Lê Văn C', 'levanc', 'pass789', N'Nhân viên'),
    (N'Phạm Thị D', 'phamthid', 'secret123', N'Nhân viên'),
    (N'Hoàng Văn E', 'hoangvane', 'secure456', N'Nhân viên'),
    (N'Nguyễn Văn F', 'nguyenvanf1', 'password123', N'Hành khách'),
    (N'Trần Thị G', 'tranthig1', 'password456', N'Hành khách'),
    (N'Lê Văn H', 'levanh1', 'pass789', N'Hành khách'),
    (N'Phạm Thị K', 'phamthik1', 'secret123', N'Hành khách'),
    (N'Hoàng Văn L', 'hoangvanl1', 'secure456', N'Hành khách');

--INSERT INTO NHANVIEN (TenNV, GioiTinhNV, LuongNV, NgaySinhNV, DiaChiNV, SDTnv, MaSB, MaChucVu, IDTaiKhoan) 
--VALUES 
--	(N'Nguyễn Văn A', N'Nam', 15000000, '1980-01-01', N'Thành phố Hồ Chí Minh', '0905123456', 'SB001', 'CV001', '1997323421'),
--	(N'Trần Thị B', N'Nữ', 16000000, '1985-02-02', N'Hà Nội', '0906123456', 'SB002', 'CV002', '0632057652'),
--	(N'Lê Văn C', N'Nam', 17000000, '1990-03-03', N'Đà Nẵng', '0907123456', 'SB003', 'CV002', '1890553715'),
--	(N'Phạm Thị D', N'Nữ', 18000000, '1982-04-04', N'Hải Phòng', '0908123456', 'SB004', 'CV002', '0429002524'),
--	(N'Hoàng Văn E', N'Nam', 19000000, '1987-05-05', N'Cần Thơ', '0909123456', 'SB005', 'CV002', '1196146236');

INSERT INTO CHUYENBAY (NgayBay, GioBay, GioDen, SoVeConLai, SoVeDaBan, TrangThaiChuyenBay, MaMB, STTchangbay)
VALUES 
	('2024-10-13', '08:00', '10:00', 180, 0, N'Còn vé', 'VN-A123', 1),
    ('2024-10-14', '14:30', '16:45', 300, 0, N'Còn vé', 'VN-B123', 2),
	('2024-10-15', '10:15', '12:00', 220, 0, N'Còn vé', 'VN-C123', 3),
    ('2024-10-16', '15:00', '17:00', 350, 0, N'Còn vé', 'VN-D123', 4),
    ('2024-10-17', '18:00', '20:00', 260, 0, N'Còn vé', 'VN-E123', 5);

--INSERT INTO HANHKHACH (TenHK, GioiTinhHK, NgaySinhHK, DiaChiHK, EmailHK, SDThk, CCCD, HoChieu, IDTaiKhoan) 
--VALUES 
--    (N'Nguyễn Văn F', N'Nam', '1990-01-01', N'Thành phố Hồ Chí Minh', 'f.nguyen@example.com', '0909123456', '0123456789', 'A1234567', '1216970441'),
--    (N'Trần Thị G', N'Nữ', '1992-02-02', N'Bến Tre', 'g.tran@example.com', '0912123456', '9876543210', 'B1234567', '0810891894'),
--	(N'Lê Văn H', N'Nam', '1988-03-03', N'Phú Quốc', 'h.le@example.com', '0903123456', '1234567890', 'C1234567', '1829804762'),
--    (N'Phạm Thị K', N'Nữ', '1991-04-04', N'Tiền Giang', 'k.pham@example.com', '0918123456', '0987654321', 'D1234567', '0491677625'),
--    (N'Hoàng Văn L', N'Nam', '1985-05-05', N'Yên Bái', 'l.hoang@example.com', '0904123456', '2345678901', 'E1234567', '0229233613');

INSERT INTO HANGVE (MaHangVe, TenHangVe)
VALUES 
	('HV001', N'Hạng thương gia'),
	('HV002', N'Hạng phổ thông');

--INSERT INTO HANHLY (SoKG, LoaiHanhLy, MaHangVe, STThk, STTcb)
--VALUES 
--	(23.5, N'Hành lý ký gửi', 'HV001', 1, 1),
--    (10.0, N'Hành lý xách tay', 'HV002', 2, 2),
--    (15.0, N'Hành lý ký gửi', 'HV003', 3, 3),
--    (20.0, N'Hành lý xách tay', 'HV004', 4, 4),
--    (25.0, N'Hành lý ký gửi', 'HV005', 5, 5);

--INSERT INTO CHITIETPHUPHI (PhuPhi, LoaiPhuPhi, STThl)
--VALUES 
--	(200000, N'Phụ phí hành lý', 1),
--    (50000, N'Phụ phí hành lý', 2),
--    (100000, N'Phụ phí hành lý', 3),
--    (150000, N'Phụ phí hành lý', 4),
--    (250000, N'Phụ phí hành lý', 5);

--INSERT INTO GIAVE (GiaCoBan, TongGiaVe, GiamGia, STTpp, STTcb, MaHangVe)
--VALUES 
--    (1500000, 1500000, 0, 1, 1, 'HV001'),
--    (800000, 800000, 0, 2, 2, 'HV002'),
--    (1200000, 1200000, 100000, 3, 3, 'HV001'),
--    (700000, 700000, 0, 4, 4, 'HV002'),
--    (1300000, 1300000, 200000, 5, 5, 'HV001');

--INSERT INTO DATVE (ThanhTien, SoVeDat, NgayDatVe, STThk, STTcb)
--VALUES 
--    (3000000, 2, '2024-10-09', 1, 1),
--    (1600000, 2, '2024-10-09', 2, 2),
--    (2400000, 2, '2024-10-09', 3, 3),
--    (1200000, 1, '2024-10-09', 4, 4),
--    (2600000, 2, '2024-10-09', 5, 5);

--INSERT INTO HOADON (NgayLapHD, TongTien, HinhThucThanhToan, TrangThai, STTdv)
--VALUES 
--    ('2024-10-09', 3000000, N'Tiền mặt', N'Đã thanh toán', 1),
--    ('2024-10-09', 1600000, N'Chuyển khoản', N'Chưa thanh toán', 2),
--    ('2024-10-09', 2400000, N'Tiền mặt', N'Đã hoàn tiền', 3),
--    ('2024-10-09', 1200000, N'Tiền mặt', N'Đã thanh toán', 4),
--    ('2024-10-09', 2600000, N'Chuyển khoản', N'Đã thanh toán', 5);

--INSERT INTO LICHSUGIAODICH (NgayGiaoDich, TrangThaiDatVe, STThd)
--VALUES 
--    ('2024-10-09 10:00', N'Đã xác nhận', 1),
--    ('2024-10-09 11:00', N'Đã xác nhận', 2),
--    ('2024-10-09 12:00', N'Đã hủy', 3),
--    ('2024-10-09 13:00', N'Đã xác nhận', 4),
--    ('2024-10-09 14:00', N'Đã xác nhận', 5);

--INSERT INTO VE (DonViTien, ViTriGhe, STThk, STTdv, STTgiave)
--VALUES 
--    (N'VND', '1A', 1, 1, 1),
--    (N'VND', '1B', 2, 2, 2),
--    (N'VND', '1C', 3, 3, 3),
--    (N'VND', '2A', 4, 4, 4),
--    (N'VND', '2B', 5, 5, 5);

--INSERT INTO NHANXET (STThk, STTcb, NDNhanXet, DiemDanhGia)
--VALUES 
--    (1, 1, N'Chuyến bay rất tốt, nhân viên thân thiện.', 5),
--    (2, 2, N'Thời gian bay không đúng lịch trình.', 3),
--    (3, 3, N'Hành lý xách tay hơi ít, nhưng chất lượng tốt.', 4),
--    (4, 4, N'Dịch vụ tốt nhưng cần cải thiện độ trễ.', 4),
--    (5, 5, N'Thích hợp với giá tiền.', 5);

select * from QLTaiKhoan
select * from HANHKHACH
SELECT GioiTinhHK FROM HANHKHACH
