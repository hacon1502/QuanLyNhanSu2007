insert into tblDangNhap(TaiKhoan,MatKhau) values ('admin','admin')

insert into tblPhongBan(MaPB,TenPB) values(1,'Quan Ly Nhan Su')
insert into tblPhongBan(MaPB,TenPB) values(2,'Marketing')
insert into tblPhongBan(MaPB,TenPB) values(3,'Ke Toan')

insert into tblTrinhDo(MaTD,TenTD) values(1,'Tien Si')
insert into tblTrinhDo(MaTD,TenTD) values(2,'Cu Nhan')
insert into tblTrinhDo(MaTD,TenTD) values(3,'Ky Su')

insert into tblChucVu(MaCV,TenCV) values (1,'Truong Phong')
insert into tblChucVu(MaCV,TenCV) values (2,'Nhan Vien')

insert into tblNhanVien(MaNV,MaCV,MaTD,MaPB) values (1,1,1,1)
insert into tblNhanVien(MaNV,MaCV,MaTD,MaPB) values (2,1,3,2)
insert into tblNhanVien(MaNV,MaCV,MaTD,MaPB) values (3,1,2,3)
insert into tblNhanVien(MaNV,MaCV,MaTD,MaPB) values (4,2,1,1)
insert into tblNhanVien(MaNV,MaCV,MaTD,MaPB) values (5,2,2,2)
insert into tblNhanVien(MaNV,MaCV,MaTD,MaPB) values (6,2,3,3)


insert into tblHoSo(MaNV,TenNV,GioiTinh,QueQuan,BaoHiemXH,SoDT) values (1,'Nguyen Van Kien','Nam','Ha Noi','14356','0943535624')
insert into tblHoSo(MaNV,TenNV,GioiTinh,QueQuan,BaoHiemXH,SoDT) values (2,'Tran Thi Lan','Nu','Nam Dinh','43546','0981265357')
insert into tblHoSo(MaNV,TenNV,GioiTinh,QueQuan,BaoHiemXH,SoDT) values (3,'Nguyen Van Dat','Nam','Ha Dong','12332','01932453452')
insert into tblHoSo(MaNV,TenNV,GioiTinh,QueQuan,BaoHiemXH,SoDT) values (4,'Phan Thanh Thuc','Nu','Thai Binh','12532','150324241')
insert into tblHoSo(MaNV,TenNV,GioiTinh,QueQuan,BaoHiemXH,SoDT) values (5,'Ta Van Phu','Nam','Lang Son','53213','0942351342')
insert into tblHoSo(MaNV,TenNV,GioiTinh,QueQuan,BaoHiemXH,SoDT) values (6,'Pham Duc Duy','Nu','Nha Trang','51231','0842372332')

delete tblNhanVien where MaNV=1