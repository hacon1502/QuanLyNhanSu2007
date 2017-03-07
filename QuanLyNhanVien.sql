create table tblDangNhap(
TaiKhoan varchar(20),
MatKhau varchar(20)
)

create table tblPhongBan(
MaPB int,
TenPB nvarchar(30),
primary key (MaPB)
)

create table tblTrinhDo(
MaTD int, 
TenTD nvarchar(20),
primary key (MaTD)
)

create table tblChucVu(
MaCV int,
TenCV nvarchar(20),
primary key (MaCV)
)


create table tblNhanVien(
MaNV int,
MaPB int,
MaTD int,
MaCV int,
primary key (MaNV),
foreign key (MaPb) references tblPhongBan(MaPB),
foreign key (MaTD) references tblTrinhDo(MaTD),
foreign key (MaCV) references tblChucVu(MaCV),
)
create table tblHoSo(
MaNV int not null,
TenNV nvarchar(100),
GioiTinh varchar(3),
QueQuan nvarchar(100),
BaoHiemXH varchar(15),
SoDT varchar(15),
primary key (MaNV),
foreign key (MaNV) references tblNhanVien(MaNV)
)
