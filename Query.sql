use QLCuaHang
go

-- Đơn hàng có năm 2020
select * 
from DonHang
where Year(NgayLapDon) = 2020

-- Xem đơn hàng và mức khuyến mãi của đơn đó
select dh.MaDH, km.MucKM 
from DonHang dh 
join KhuyenMai km
On dh.MaKM = km.MaKM

CREATE INDEX KM_MucKM
ON KhuyenMai (MucKM);

CREATE INDEX DH_MucKM
ON DonHang (MaKM);

select dh.MaDH, km.MucKM 
from DonHang dh WITH(INDEX(DH_MucKM))
join KhuyenMai km WITH(INDEX(KM_MucKM))
On dh.MaKM = km.MaKM

select dh.MaDH, km.MucKM 
from DonHang dh WITH(INDEX(DH_MucKM))
join KhuyenMai km 
On dh.MaKM = km.MaKM

select dh.MaDH, km.MucKM 
from DonHang dh 
join KhuyenMai km WITH(INDEX(KM_MucKM))
On dh.MaKM = km.MaKM

DROP INDEX DH_MucKM on DonHang
DROP INDEX KM_MucKM on KhuyenMai

-- Lấy ra mã đơn hàng, tên khách hàng mà tình trạng đơn là 'Đồng ý' và giá cuối cùng > 30000
select MaDH, TenKH from DonHang dh join KhachHang kh
On dh.MaKH = kh.MaKH
where TinhTrang = N'Đồng ý' and GiaCuoiCung > 30000

CREATE INDEX DH_TT_GIA
ON DonHang (TinhTrang, GiaCuoiCung)
INCLUDE (MaKH)

DROP INDEX DH_TT_GIA on DonHang

-- tìm kiếm tên loại sản phẩm
select * from LoaiSanPham
where TenLoai = 'Ampcessryt'

CREATE INDEX LSP_TEN
ON LoaiSanPham (TenLoai)

DROP INDEX LSP_TEN on LoaiSanPham