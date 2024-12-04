use master
go

IF( EXISTS (SELECT name FROM master.dbo. sysdatabases WHERE name = N'Shop'))
	drop database  Shop

create database Shop
go
use Shop
go

CREATE TABLE DonHang (
	STT int IDENTITY(1,1) primary key not null,
  	MaDonHang  int null,
	MaKH int,
	MaSP int,
	TenSP nvarchar(50),
	SoLuong int,
	NgayLap datetime,
	--MaTK int,
	GiaBan int ,
	TongTien int  null,
) 
go

CREATE TABLE DONDATHANG
(
	STT int IDENTITY(1,1) primary key not null,
	--MaDonHang int null,
	MaKH int,
	NgayDat datetime,
	TongSoLuong int ,
	TinhTrangGiao varchar(30),
	DaThanhToan varchar(10),
	TongTien int 
)
go

CREATE TABLE HangSX (
  MaHangSX int IDENTITY(1,1) primary key not null,
  TenHangSX nvarchar(50) ,
  )

CREATE TABLE loaisanpham (
  MaLoaiSP int IDENTITY(1,1) primary key not null,
  TenLoaiSP nvarchar(50),
 
 )

CREATE TABLE sanpham (
  MaSP int IDENTITY(1,1) primary key not null,
  TenSP nvarchar(50),
  GiaSP int ,
  Hinh nvarchar(300),
  SoLuotXem int ,
  SoLuongBan int ,
  SoLuongTon int,
  TinhTrang varchar(10),
  NgayNhap datetime ,
  MoTa nvarchar(600),
  ChiTiet ntext,
  XuatXu nvarchar(50),
  MaLoaiSP int ,
  MaHangSX int ,
 
) 

CREATE TABLE taikhoan (
  MaTK int IDENTITY(1,1) primary key not null,
  TenDN varchar(50) ,
  MatKhau varchar(50) ,
  HoTen nvarchar(50) ,
  DiaChi nvarchar(100),
  SDT int,
  Email varchar(256) ,
  DOB varchar(11),
  MaLoaiTK int,
  Hinh  nvarchar(300),
)
--go
--alter table  DONDATHANG
--add constraint FK_DONDATHANG_DonHang
--Foreign key (STT)
--references DonHang(MaDonHang)
--go

INSERT INTO HangSX VALUES ('Fujifilm');
INSERT INTO HangSX VALUES ('Sony ');
INSERT INTO HangSX VALUES ('Canon ');
INSERT INTO HangSX VALUES ('Nikon ');
INSERT INTO HangSX VALUES ( 'Olympus ');
INSERT INTO HangSX VALUES ('Panasonic ');
INSERT INTO HangSX VALUES ('Khác');

INSERT INTO loaisanpham VALUES (N'Máy ảnh không gương lật');
INSERT INTO loaisanpham VALUES (N'Máy ảnh DSLR');
INSERT INTO loaisanpham VALUES (N'Máy Ảnh Số Du Lịch');
INSERT INTO loaisanpham VALUES (N'Máy Ảnh chụp lấy ngay');
INSERT INTO loaisanpham VALUES (N'Máy Ảnh MINI');
INSERT INTO loaisanpham VALUES (N'Khác');


INSERT INTO DONDATHANG VALUES (1,N'2017-05-19',4,N'false',N'false',54482000);
INSERT INTO DONDATHANG VALUES (2,N'2017-05-19',4,N'false',N'false',54482000);
INSERT INTO DONDATHANG VALUES (3,N'2017-05-19',4,N'false',N'false',192362000);
INSERT INTO DONDATHANG VALUES (4,N'2017-05-19',3,N'false',N'false',46280000);

INSERT INTO DonHang VALUES ('',1,1,N'Fujifilm X-A2',1,N'2017-05-19 00:00:00.000',10924000,10924000);
INSERT INTO DonHang VALUES ('',1,4,N'mirrorless Canon EOS M3',1,N'2017-05-19 00:00:00.000',10390000,10390000);
INSERT INTO DonHang VALUES ('',1,22,N'Panasonic DMC-LX100',1,N'2017-05-19 00:00:00.000',19668000,19668000);
INSERT INTO DonHang VALUES ('',1,3,N'Sony Alpha ILCE-6000L',1,N'2017-05-19 00:00:00.000',13500000,13500000);
INSERT INTO DonHang VALUES ('',2,1,N'Fujifilm X-A2',1,N'2017-05-19 00:00:00.000',10924000,10924000);
INSERT INTO DonHang VALUES ('',2,4,N'mirrorless Canon EOS M3',1,N'2017-05-19 00:00:00.000',10390000,10390000);
INSERT INTO DonHang VALUES ('',2,22,N'Panasonic DMC-LX100',1,N'2017-05-19 00:00:00.000',19668000,19668000);
INSERT INTO DonHang VALUES ('',2,3,N'Sony Alpha ILCE-6000L',1,N'2017-05-19 00:00:00.000',13500000,13500000);
INSERT INTO DonHang VALUES ('',3,1,N'Fujifilm X-A2',3,N'2017-05-19 00:00:00.000',10924000,32772000);
INSERT INTO DonHang VALUES ('',3,9,N'Panasonic Lumix DMC-GH4 body',3,N'2017-05-19 00:00:00.000',42000000,126000000);
INSERT INTO DonHang VALUES ('',3,14,N'Nikon D7200',1,N'2017-05-19 00:00:00.000',24090000,24090000);
INSERT INTO DonHang VALUES ('',3,23,N'KTS Panasonic lDMC-LX7 Lumix',1,N'2017-05-19 00:00:00.000',9500000,9500000);
INSERT INTO DonHang VALUES ('',4,2,N'Fujifilm X-T10',1,N'2017-05-19 00:00:00.000',22390000,22390000);
INSERT INTO DonHang VALUES ('',4,3,N'Sony Alpha ILCE-6000L',1,N'2017-05-19 00:00:00.000',13500000,13500000);
INSERT INTO DonHang VALUES ('',4,4,N'mirrorless Canon EOS M3',1,N'2017-05-19 00:00:00.000',10390000,10390000);







INSERT INTO taikhoan VALUES (N'truongvanhau','123456',N'Trương Văn Hậu',N'Ga lai',01685236542, 'truongvanhau911995@gmail.com','1996-9-12 ','0',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\img\o.jpg');
INSERT INTO taikhoan VALUES (N'hau','123456',N'Nguyễn Hoài Linh',N'Da Nang',01681232542,  'Tinhdaukhophai102@gmail.com','1995-12-12 ','0',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\img\o.jpg');
INSERT INTO taikhoan VALUES (N'hero','123456',N'Nguyễn Văn Nên',N'Da Nang',01681232542,  'hotdau911995@gmail.com','1995-12-12 ','0',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\img\o.jpg');
INSERT INTO taikhoan VALUES (N'hotdau','123456',N'Nguyễn Nô Tài',N'Da Nang',01681232542,  'Nguyennotai91193@gmail.com','1995-12-12 ','0',N'/SHOP;component/img/o.jpg');
INSERT INTO taikhoan VALUES (N'tinhdau102','123456',N'Mạnh Văn Yếu',N'Da Nang',01681232542,  'TranVanSua1995@gmail.com','1995-12-12 ','0',N'/SHOP;component/img/o.jpg');
INSERT INTO taikhoan VALUES (N'truongvanphuong','123456',N'Nguyễn Công Danh',N'Da Nang',01681232542,  'congdanhnguyen1998@gmail.com','1995-12-12 ','0',N'/SHOP;component/img/o.jpg');
INSERT INTO taikhoan VALUES (N'hau1','123456',N'Nguyễn Thi Loan',N'Da Nang',01681232542,  'loanthinguyen1995@gmail.com','1995-12-12 ','0',N'/SHOP;component/img/o.jpg');
INSERT INTO taikhoan VALUES (N'admin','123456',N'Trương Văn Hậu',N'Hà Nội',01689194021,  'Hau_Hero911995@gmail.com','2016-12-12 ','1',N'/SHOP;component/img/o.jpg');

INSERT INTO sanpham VALUES ('Fujifilm X-A2', '10924000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\1\a.png', '2', '1','2','New','2016-12-12 00:15:11', N'Nhỏ gọn với khả năng vượt trội, thỏa sức sáng tạo', N'- Cảm biến 16.3MP APS-C CMOS \n- Quay phim Full HD 1080p 30 fps \n- Màn hình 3.0” LCD xoay 175° \n- Chụp macro ở khoảng cách 15cm \n- AF nhận diện mắt, AF chụp Macro Tự động và AF đa điểm  \n- Dung lượng pin cực lớn chụp tới 410 bức ảnh \n - Hệ thống chống rung ảnh 3 đến 3.5 điểm dừng \n- ISO 25600.', N'Thái Lan', '1', '1');
INSERT INTO sanpham VALUES ('Fujifilm X-T10', '22390000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\2\a.png', '1', '4','4','Old','2016-12-06 00:15:36', N' thiết kế đẹp mắt,Độc đáo', N'-Cảm biến APS-C X-Trans CMOS II 16.3 MP , Tích hợp Pop-Up Flash\n- Màn hình LCD lật 3.0 inch 920.000 điểm \n- Quay phim Full HD 1080p tại 60 fps\n- Chế độ lấy nét tự động thông minh 77 khu vực\n- Chụp 8 hình/giây and ISO 51200, hỗ trợ kết nối  Wi-Fi \n ', N'Nhật Bản', '1', '1');
INSERT INTO sanpham VALUES ('Sony Alpha ILCE-6000L', '13500000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\3\a.png', '1','5','14','New',   '2016-11-02 00:15:43', N'Thiết kế đọc đáo, hình ảnh chất lương cao', N'\n- Kích thước màn hình 3 inch,  Độ phân giải camera 24,3 MP,  Loại màn hình TFT LCD\n- Kích thước sản phẩm 14.5x13x15.5, Độ nhạy sáng ISO Auto – 25600\n- Cổng kết nối Mass-storage, MTP, PC remote, HDMI micro (Type-D)\n- Bộ xử lý BIONZ cho tốc độ xử lý nhanh\n ', N'Nhật Bản', '1', '2');
INSERT INTO sanpham VALUES ('mirrorless Canon EOS M3', '10390000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\4\a.png', '6', '25','1','New',  '2016-11-06 00:16:13', N'Cảm biến và bộ xử lý hình ảnh cao cấp', N'\n- Cảm biến CMOS APS-C 24.2MP\n- Cảm biến hình ảnh DIGIC 6\n- Màn hình cảm ứng LCD 3.0 inch 1.040k-Dot\n- Quay phim Full HD 1080p tại 24/24/30fps\n- Tích hợp kết nối NFC và Wifi\n- Công nghệ lấy nét Hybrid CMOS AF với 49 điểm\n- ISO 100-12800; mở rộng 25600\n ', N'Nhật Bản', '1', '3');
INSERT INTO sanpham VALUES ('Nikon 1 J2', '6900000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\5\a.png', '5', '14','17','New',  '2016-11-17 00:15:52', N'Nhỏ gọn đày nữ tính', N'\n- Kích thước màn hình 3 inch, Độ phân giải camera 10 MP\n- Kích thước sản phẩm (D x R x C cm) 15x8x16, Zoom quang 1.0\n- [ Chế độ Chọn Ảnh Thông minh ] Bắt đầu chụp trước khi nhấn cửa trập\n- Quay phim Full HD 1080p tại 24/24/30fps\n- [ Full HD ] Tận hưởng khả năng quay phim Full HD\n- Đèn nháy gắn sẵn \n- Bật/tắt với thấu kính có thể thu lại\n ', N'Nhật Bản', '1', '4');
INSERT INTO sanpham VALUES ('Olympus PEN mini E-PM2', '12029000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\6\a.png', '2', '13','1','New',  '2016-11-06 00:16:00', N'Hình ảnh chất lượng cao, Lấy nét chỉ bằng động tác chạm ngón tay', N'\n- Độ phân giải camera  16.1MP\n- Cảm biến 4/3 Live MOS Sensor\n- Lens M.ZUIKO 14-42mm, Độ nhạy sáng ISO 200 – 25600\n- Màn hình 3” LCD, Mẫu mã E-PM2-1442-2RK(G)RED/SLV\n- Trọng lượng 0.325 kg', N'Việt Nam', '1', '5');
INSERT INTO sanpham VALUES ('Olympus PEN E-PM2', '10359000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\7\a.png', '2', '14','8','New',  '2016-11-02 00:16:07', N'Quay phim HD, giảm rung và chống bám bẩn', N'\n- Màn hình cảm ứng 3.0 inch, Độ phân giải camera 16 MP\n- Lấy nét nhanh chóng từ màn hình, Chất lượng hình ảnh 4608 x 3456\n- Kích thước sản phẩm  0.325 x 24.5 x 10  (D x R x C cm)\n- Độ nhạy sáng ISO 200 – 26500\n- Trọng lượng 0.325 kg ', N'Trung quốc', '1', '5');
INSERT INTO sanpham VALUES ('Nikon J3', '7959000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\8\a.png', '1', '34','7','Old',  '2016-07-05 00:16:23', N'Thiết kế cao cấp, Kiểu dáng nhỏ gọn và nhiều màu sắc đa dạng', N'\n- Cảm biến 1/" CX-CMOS độ phân giải 14.2 Megapixels\n- Tốc độ chụp liên tiếp 10 hình/giây khi lấy nét tự động\n- Bộ xử lý ảnh EXPEED 3 - ISO 160-6400\n- Quay phim Full-HD 1080p với âm thanh Stereo\n- Màn hình siêu nét 3” độ phân giải 921K điểm ảnh\n- Sản phẩm mới 100%; Giá gồm VAT', N'Trung quốc', '1', '4');
INSERT INTO sanpham VALUES ('Panasonic Lumix DMC-GH4 body  ', '42000000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\9\a.png', '3', '23','1','New',  '2016-01-11 00:16:30', N'đẹp , bền, có khả nang chống nước, chống bụi', N'\n- Cảm biến Live-MOS 16-Mpix \n- Chụp liên tục 12 khung hình/giây khi lấy nét đơn (AF-S) \n- Hệ thống lấy nét tự động theo tương phản 49 điểm\n- Màn hình OLED sau lật xoay 3.0 inch 1.03 triệu điểm ảnh\n- Quay phim DCI 4K (4096 x 2160) 24p\n- Quay phim UHD 4K 3840 x 2160 30/24p\n- Quay phim Full HD lên tới 60p\n- Đầu ra HDMI 4:2:2 8-Bit hoặc 10-Bit  ', N'Trung quốc', '1', '6');
INSERT INTO sanpham VALUES ('Canon EOS 700D', '9850000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\10\a.png', '5', '20','7','Old',  '2016-05-09 00:16:38', N'Thiết kế mới , tinh sảo', N'\n- Kích thước màn hình 3inch, Có Ống kính đi kèm(18-55 STM) \n- Độ phân giải camera   18 Megapixels,Loại pin: Li-ion\n- SensorType: CMOS, Kích thước sản phẩm 13.2 x 9.9x 7.9 (D x R x C cm)\n- LensModel: Lens EF-S 18-55mm IS STM\n- LensKit: Có,CameraAddAcc: Thẻ nhớ 8GB\n- ', N'Đài Loan', '2', '3');
INSERT INTO sanpham VALUES ('Canon EOS 70D', '19200000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\11\a.png', '0', '33','7','New',  '2016-09-29 00:16:44', N'Giá rẻ với nhiều tính năng hấp dẫn', N'\n- Cảm biến CMOS 20.2 MP kích thước APS-C\n- Đóng nhãn hiệu: Torrini\n- Bộ xử lý hình ảnh: DIGIC 5+\n- Màn hình LCD ClearView II 3inch\n- ISO 100-12.800 (mở rộng 25.600), quay phim tối đa 6.400\n- Hỗ trợ kết nối Wi-Fi\n- Hệ thống lấy nét Dual pixel AF 19 điểm\n- Tốc độ chụp 7 fps\n- Quay phim Full HD 1920 x 1080 pixel\n- \n- Cảm biến CMOS 20.2 MP kích thước APS-C\n- Đóng nhãn hiệu: Torrini', N'Nhật Bản', '2', '3');
INSERT INTO sanpham VALUES ('Sony SLT-A57K', '15990000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\12\a.png', '2', '12','1','Old',  '2016-02-08 00:16:51',N'Thiết kế mạnh mẽ, cá tính', N'\n- Loại ống kính: 18 - 55mm f3.5 - 5.6 , Độ phân giải 16.1 Mega Pixels\n- Độ lớn màn hình LCD (inch), Màn hình xoay lật 3.0/" Clear Photo LCD\n- Bộ cảm biến hình ảnh: APS-C HD CMOS, Độ nhạy sáng: ISO 16000\n- Tốc độ màn trập 1/4000 - 30s, digital Zoom Zoom kỹ thuật số rõ nét với Clear Image Zoom\n- Loại pin sử dụng: Pin Stamina có thời lượng sử dụng cao, quay phim: Chuẩn Full HD\n- Bộ nhớ trong: (Mb) Sử dụng thẻ MS và SD ', N'Nhật Bản', '2', '2');
INSERT INTO sanpham VALUES ('Sony A77 Mark II', '24289000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\13\a.png', '0', '23','4','New',  '2016-02-02 00:17:05', N'Kính ngắm điện tử độ phân giải cao XGA OLED, Nhiều hiệu ứng hình ảnh sáng tạo', N'\n- Cảm biến Exmor CMOS 24.3MP\n- Màn hình xoay 3 chiều 3.0” OLED Tru-Finder\n- Quay phim Full HD\n- Hệ thống lấy nét 79 điểm\n- Vi xử lý BIONZ tiên tiến\n- Công nghệ gương mờ Translucent Mirror lấy nét nhanh và chính xác\n- Kết nối Wifi, NFC tích hợp', N'Nhật Bản', '2', '2');
INSERT INTO sanpham VALUES ('Nikon D7200', '24090000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\14\a.png', '6', '12','2','Old',  '2016-03-01 00:17:12', N'chụp ảnh tốc độ cao kéo dài, sắc nét ngay cả trong điều kiện ánh sáng yếu', N'\n- Cảm biến ảnh: CMOS 24.2 MP. DX format. kích thước APS-C\n- Bộ xử lý hình ảnh: EXPEED 4\n- Bộ chuyển tín hiệu A/D: 14-bit. 12-bit\n- Màn hình: LCD 3.2/" độ phân giải 1.228.800 điểm ảnh\n- ISO: 25.600. tối ưu 100 - 6.400. mở rộng 102.800 với ảnh đen trắng\n- Hệ thống lấy nét: 51 điểm. 15 điểm cross-type\n- Quay phim: 1.920 x 1.080 pixel\n- Chụp liên tiếp: 6 fps ', N'Thái Lan', '2', '4');
INSERT INTO sanpham VALUES ('Nikon D750', '36000000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\15\a.png', '1', '23','1','Old',  '2016-04-29 00:17:21', N'Tính Năng nổi bật, hình ảnh sắt nét', N'\n- Màn hình RGB 3.2-inch;,1.2 triệu điểm ảnh hỗ trợ lật xoay nghiêng\n- Độ phân giải camera 24.3 MP, Kích thước màn hình 3 inch\n- Kích thước sản phẩm 40x40x25 (D x R x C cm), Trọng lượng 0.9  (KG)\n- Loại pin/ác quy Removable Rechargeable Battery\n- ', N'Thái Lan', '2', '4');
INSERT INTO sanpham VALUES ('KTS Fujifilm FinePix S9900W', '6800000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\16\a.png', '6', '5','4','New',  '2016-12-05 00:17:28', N'lý tưởng cho người dùng yêu thích chụp ảnh hoàng hôn', N'\n- Ống kính siêu zoom 50x (24mm-1200mm)\n- Ống kính zoom quang FUJINON có khẩu độ F2.9 – F6.5 sẽ giảm tối đa hiện tượng \n- Ống kính có tiêu cự (24mm-1200mm) cho khả năng zoom lên đến 50x \n- Kính ngắm EVF và cảm biến BSI-CMOS 16.2MP\n- Quay phim Full HD 1080i/60fps\n- Kích thước sản phẩm 12.26 x 8.69 x 11.62 (D x R x C cm)\n- Chụp ảnh thông minh, chụp ảnh từ xa và chỉ sẻ tức thì ', N'Trung Quốc', '2', '1');
INSERT INTO sanpham VALUES ('Canon EOS 6D Wifi', '40490000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\17\a.png', '1', '3','4','New',  '2016-10-11 00:17:34', N'Vỏ thiết kế chống nước, bụi bặm', N'\n- Cảm biến Full-Frame CMOS 20.2MP\n- Bộ xử lý ảnh DIGIC 5+\n- Màn hình LCD Clear View 3.0/" 1.04m-Dot\n- Quay phim Full HD 1080p 30fps\n- Tích hợp Wifi và GPS\n- Hỗ trợ lấy nét tự động 11 điểm\n- Chụp ảnh liên tục 4.5 fps', N'Nhật Bản', '2', '3');
INSERT INTO sanpham VALUES ('Compact Fujifilm XF1 (Nâu)', '7900000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\18\a.png', '1', '2','7','New',  '2016-05-29 00:17:42',N'Thiết kế quyến rũ tinh tế mang phong cách cổ điển', N'\n- Cảm biến EXR CMOS 2/3/" độ phân giải 12.0 Mps\n- Ống kính Fujinon 25-100mm độ mở lớn tới f1.8\n- Tốc độ chụp liên tục lên tới 10 hình/s, ISO tới 12.800\n- Hỗ trợ định dạng RAW với các chế độ chuyên nghiệp\n- Quay phim FullHD 1920*1080, chụp Panorama 360°\n- Hỗ trợ lấy nét tự động 11 điểm ', N'Trung Quốc', '3', '1');
INSERT INTO sanpham VALUES ('Olympus Stylus TG-4 Tough', '7288000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\19\a.png', '0', '5','4','New',  '2016-12-07 00:17:51', N'Nhỏ gọn, năng động', N'\n- Cảm biến BSI CMOS 1/2.3/" 16 triệu điểm ảnh\n- Chống nước với độ sâu tới 15m (sẽ được gia tăng lên 45m với bộ giáp lặn PT-056) \n- Chống băng giá với nhiệt độ xuống tới -10 độ C\n- Chống lực đè nén lên tới 100kg\n- Chống sốc với độ cao 2.1m \n- Ống kính siêu nhanh f/2.0 với dải zoom rộng: 25-100mm (quy chuẩn 35mm) f/2.0-4.9\n- Màn hình lớn 3 inch với tấm nền bảo vệ chắc chắn\n- ISO 100-6400 và chụp ảnh liên tiếp 5 hình/giây  ', N'Việt Nam', '3', '5');
INSERT INTO sanpham VALUES ('Olympus Stylus 1', '15948000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\20\a.png', '2', '7','3','Old',  '2016-01-02 00:17:56', N'Thiết kế tinh sảo, chắc chắn', N'\n- Cảm biến CMOS 1/1.7/" 12MP\n- Định dạng ảnh: JPEG, RAW\n- Định dạng video: MJPEG, MOV, MPEG-4 AVC/H.264\n- Định dạng âm thanh: Linear PCM (Stereo)\n- Tiêu cự: 6.0-64.3 mm (tương đương 28-300 mm trên máy full-frame) \n- Tốc độ màn trập 60 - 1/2000 seconds ', N'Nhật Bản', '3', '5');
INSERT INTO sanpham VALUES ('Canon EOS M10', '7290000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\21\a.png', '1', '9','4','New',  '2016-11-08 00:18:07', N'Nhỏ gon, thân thiện với người dùng', N'\n- Độ phân giải 18 Megapixel\n- Tiêu cự 24-600mm\n- Hệ thống zoom zoom quang học 25x\n- Bộ xử lý ảnh DIGIC 6\n- Màn hình LCD cảm ứng điện dung 3.2 inch \n- Tốc độ ISO ISO 12012.800 auto\n- Nguồn điện Bộ pin NB-10L\n- Quay Phim Full HD 60p, MP4, chống rung ', N'Nhật Bản', '3', '3');
INSERT INTO sanpham VALUES ('Panasonic DMC-LX100', '19668000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\22\a.png', '0', '11','4','Old',  '2016-09-13 00:18:16', N'bộ xử lý hình ảnh Venus Engine thế hệ mới, nhỏ gọn, trọng lượng nhẹ', N'\n- Chụp ảnh rõ nét với cảm biến CMOS 12.8MP 1, zoom quang 3.1x\n- HĐộ nhạy sáng  ISO 200-25600\n- Quay phim Full HD\n- Màn hình LCD 3 inch sắc nét, Kích thước sản phẩm 12 x 7 x 6 (D x R x C cm)\n- Kết nối Wi-Fi\n- Nguồn điện Bộ pin NB-10L\n- Quay Phim Full HD 60p, MP4, chống rung ', N'Trugn Quốc', '3', '6');
INSERT INTO sanpham VALUES ('KTS Panasonic lDMC-LX7 Lumix', '9500000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\23\a.png', '0', '12','2','New',  '2016-05-07 00:18:26', N'Trang bị thêm nhiều tính năng hiện đại, Thiết kế nhỏ gọn, tiện lợi', N'\n- Độ phân giải 10.1 MPXs\n- Góc chụp siêu rộng 24mm\n- Ống kính LEICA DC VARIO-SUMMICRON 3.8x độ mở F2.0\n- Bộ xử lý ảnh tiên tiến Venus Engine thế hệ IV\n- Độ nhạy sáng ISO lên tới 12.800, chụp Macro 1cm\n- Quay phim HD chất lượng cao âm thanh Stereo\n- Màn hình 3 inch, độ phân giải tới 460.000 điểm ảnh ', N'Nhật Bản', '3', '6');
INSERT INTO sanpham VALUES ('KTS Olympus Tough TG-2', '11000000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\24\a.png', '5', '9','4','Old',  '2016-12-08 00:18:38', N'Thiết kế ấn tượng, Hình ảnh chat lượng cao, rõ nét', N'\n- Độ phân giải camera 12(MP), Kích thước sản phẩm 13.5x 10.7x 14.9 (D x R x C cm)\n- Zoom quang 4x\n- Màn hình LCD 3.0 inch\n- Pin Lithium-Ion LI90B\n- Chụp dưới nước tối đa 15m\n- độ phân giải tới 460.000 điểm ảnh  ', N'Nhật Bản', '3', '5');
INSERT INTO sanpham VALUES ('Fujifilm Instax Wide 300 (Đen)', '3350000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\25\a.png', '2', '18','7','Old',  '2016-06-04 00:18:42', N'Chụp lấy ngay, tiện lợi dễ sử dụng', N'\n- Kích thước ảnh: 99mm x 62mm, Đóng mở ống kính Fujino, 2 bộ phận, 2 cấu trúc, f = 95mm, F = 14\n- Chế độ Bình thường: 0.9 ~ 3m – Chế độ phong cảnh: 3m ~ ∞, Màn trập điện tử được lập trình, 1/64 ~ 1/200 giây\n- pin AA x 4,Kích thước: 94,5 H x 178.5 W 117,5 D ( mm),Trọng lượng (chỉ tính thân máy): 612g\n- Kích thước sản phẩm (D x R x C cm)  là 11.75 x 17.85 x 9.45\n- Trọng lượng 0.275 kg ', N'Trung Quốc', '4', '1');
INSERT INTO sanpham VALUES ('Fujifilm Instax Mini 50s (Đen)', '3350000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\26\a.png', '0', '5','1','Old',  '2016-05-05 00:18:50', N'Tinh tế và hoài cổ', N'\n- Độ phân giải camera 1.5 MP\n- Chế độ Bình thường: 0.9 ~ 3m – Chế độ phong cảnh: 3m ~ ∞, Màn trập điện tử được lập trình, 1/64 ~ 1/200 giây\n- pin AA x 4,Kích thước: 94,5 H x 178.5 W 117,5 D ( mm),Trọng lượng (chỉ tính thân máy): 612g\n- Kích thước sản phẩm (D x R x C cm)  là 11.75 x 17.85 x 9.45. ', N'Trung Quốc', '4', '1');
INSERT INTO sanpham VALUES ('Fujifilm Instax mini 8', '1890000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\27\a.png', '0', '7','7','Old',  '2016-10-03 00:18:58', N'Lấy hình ngay trong nhích nháy, Thiết kế trẻ trung và độc lạ', N'\n- Kích thước ảnh 62x46mm\n- Model: Instax Mini 8 \n- Kích thước ảnh 62x46mm\n- Sử dụng pin AA\n- ', N'Trung Quốc', '4', '1');
INSERT INTO sanpham VALUES ('Mini DV Recorder', '219000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\28\a.png', '2', '4','7','Old',  '2016-08-12 00:19:09', N'Cực Nhỏ , với kích thước gọn đến không ngờ, tích hợp đủ chức năng', N'\n- Độ phân giải : VGA 1280 * 960. 29fps\n- Hình ảnh độ phân giải: 5 MP\n- Độ phân giải webcam: 320 * 240\n- Ống kính góc: 60 độ\n- Chức năng phát hiện chuyển động video\n- Định dạng: AVI (video); JPG (ảnh); WAV (âm thanh) ', N'Hồng Công', '5', '7');
INSERT INTO sanpham VALUES ('ASOCA002K', '1570000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\29\a.png', '4', '3','4','New',  '2016-02-04 00:19:17', N'Nhỏ , gọn, nhẹ', N'\n- Chụp ảnh 16 mega pixels (16MP)\n- Màn hình hiển thị TFT LCD 2.7inch\n- Thẻ nhớ SD, MMC, hỗ trợ dung lượng lên đến 32GB\n- Chống rung, tự động nhận diện khuôn mặt, chụp nụ cười, chụp paranoma, pin sạc (BL-4C) qua cáp USB\n- Định dạng: AVI (video); JPG (ảnh); WAV (âm thanh) ', N'Trung quốc', '5', '7');
INSERT INTO sanpham VALUES ('Fujifilm Instax Mini 70', '3660000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\30\a.png', '1', '7', '1','New', '2016-03-03 00:19:24', N'Thiết kế thời trang,sành điệu phù hợp với giới trẻ', N'\n- Kích cỡ ảnh: 62 x 46 mm\n- Tích hợp đèn Flash\n- Pin: CR2/DL CR2 Lithium ', N'Trung Quốc', '5', '1');
INSERT INTO sanpham VALUES ('Canon PowerShot SX420 IS', '4950000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\31\a.png', '4', '8','12','New',  '2016-12-02 00:19:34', N'Gọn, phù hợp với các chuyến đi xa', N'\n- Độ lớn màn hình LCD (inch): 3.0 inch\n- Megapixel (Số điểm ảnh hiệu dụng): 20 Megapixel\n- Độ phân giải ảnh lớn nhất: 5152 x 3864\n- Optical Zoom (Zoom quang): 42x\n- Digital Zoom (Zoom số): 4.0x\n- Tính năng: Wifi, Nhận dạng khuôn mặt, Voice Recording, Quay phim HD Ready', N'Nhật Bản', '3', '3');
INSERT INTO sanpham VALUES ('KTS NiKonCoolpix L840', '6500000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\32\a.png', '2', '5','4','Old',  '2016-07-29 00:19:38', N'Kiểu dáng mới lạ,đẹp mắt', N'\n- DisplaySize: 3\n- OpticalZoom: 38\n- Độ phân giải ảnh 16 Megapixels\n- BatteryType: alkaline LR6/L40 ', N'Trung Quốc', '3', '4');
INSERT INTO sanpham VALUES ('Samsung camera 2 GC200', '4500000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\33\a.png', '1', '5','14','Old',  '2017-01-12 23:33:07', N'nhỏ gọn, xinh xắn', N'\n- Hệ điều hành Android 4.3 tiên tiến\n- Kết nối wifi và NFC cực nhanh\n- cho phép thu hình với chất lượng tối đa Full HD 1.080p tốc độ 30 hình mỗi giây\n- kích thước 4.8 inch, có độ phân giải 720p sử dụng công nghệ LCD ', N'Trung Quốc', '5', '7');
INSERT INTO sanpham VALUES ('HD VIDEO RECORDER - PK19-234', '230000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\34\a.png', '0', '4','5','Old',  '2017-01-12 23:51:50', N'thiết kế mới, lạ mắt', N'\n- Độ phân giải: 720 x 480 (chuẩn DVD)\n- Tốc độ quay: 30 fps\n- Định dạng video: AVI\n- Thẻ nhớ: MicroSD, dung lượng tối đa: 8G\n- Thời lượng quay: 2h', N'Việt Nam', '5', '7');
INSERT INTO sanpham VALUES ('Polaroid', '3900000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\35\a.png', '0', '7','4', 'New', '2017-01-12 23:56:25', N'Trẻ trung, khoe cá tính', N'\n- Độ phân giải: 720 x 480 (chuẩn DVD)\n- Máy ảnh lấy hình tức khắcPolaroid Z2300 10MP Digital Instant Print Camera – Black\n- Định dạng video: AVI\n- Thẻ nhớ: MicroSD, dung lượng tối đa: 8G\n- Polaroid ZIP Mobile Printer w/ZINK Zero Ink Printing Technology – Compatible w/iOS & Android Devices ', N'Trung Quốc', '4', '7');
INSERT INTO sanpham VALUES ('KTS Webvision L29', '699000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\36\a.png', '1', '4','1','Old',  '2017-01-12 23:58:49', N'Nhỏ nhắn, tiện lợi,Dễ sử dụng', N'\n- Màn hình 2.7 inch,Độ phân giải 18MP\n- Zoom quang 8x,Pin sạc Lithium\n- Chế độ chống sốc\n- Thẻ nhớ: MicroSD, dung lượng tối đa: 8G\n- Compatible w/iOS & Android Devices', N'Thái Lan', '5', '7');
INSERT INTO sanpham VALUES ('SKT Canon Powershot G9X', '5690000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\37\a.png', '0', '4','2','New',  '2017-01-13 00:03:41', N'Thỏa sức khám phá', N'\n- Màn hình 2.7 inch,Độ phân giải 18MP\n- Cảm biến BSI-CMOS 20.2MP\n- Chế độ chống sốc,Quay video Full HD\n- Độ nhạy sáng ISO 125 – 12800,Bộ pin NB-13L\n- Compatible w/iOS & Android Devices', N'Nhật Bản', '3', '3');
INSERT INTO sanpham VALUES (' Duble Screen HD', '1351000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\38\a.png', '4', '3','1','Old',  '2017-01-13 00:05:55', N'Thiết kế thân máy mỏng nhẹ và thời trang', N'\n- Cảm biến BSI-CMOS 20.2MP\n- Cảm biến BSI-CMOS 20.2MP\n- Quay phim HD chất lượng cao âm thanh Stereo\n- Màn hình 3 inch, độ phân giải tới 460.000 điểm ảnh \n- Độ nhạy sáng ISO 125 – 12800,Bộ pin NB-13L\n- Compatible w/iOS & Android Devices ', N'Việt Nam', '5', '7');
INSERT INTO sanpham VALUES ('SONY DSC-WX350/WCE32', '5190000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\39\a.png', '1', '2','5','New',  '2017-01-13 00:10:20', N'Nhỏ gọn,Tinh tế', N'\n- Thiết kế hiện đại với ngoại hình nhỏ gọn, thuận tiện để bạn mang theo bên mình\n- Độ phân giải 18.2 MP đem đến hình ảnh chất lượng cao, rõ ràng đến từng chi tiết\n- Quay phim HD chất lượng cao âm thanh Stereo\n- Nhiều chế độ chụp thú vị, tạo nên phong cách riêng của bạn\n- Độ nhạy sáng ISO 125 – 12800,Bộ pin NB-13L ', N'Thái Lan', '3', '2');
INSERT INTO sanpham VALUES ('PowerShot D30', '7500000',N'E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\imge\40\a.png', '2', '3','4','New',  '2017-01-13 00:17:06', N'Chống nước ở độ sâu lớn nhất', N'\n- Được thiết kế lớn hơn để người dùng dễ dàng sử dụng ngay cả khi đeo bao tay\n- Độ phân giải 18.2 MP đem đến hình ảnh chất lượng cao, rõ ràng đến từng chi tiết\n- Màn hình LCD được nâng cấp với chế độ Sunlight\n- Cho phép nhìn dễ dàng ngay cả dưới ánh sáng mặt trời\n- Độ nhạy sáng ISO 125 – 12800,Bộ pin NB-13L ', N'Nhật Bản', '5', '3');

