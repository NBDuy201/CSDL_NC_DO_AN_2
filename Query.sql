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

