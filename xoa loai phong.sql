delete from ChiTietHoaDon where IDHoaDon = (select HoaDon.IDHoaDon from HoaDon where IDDatPhong = ( select DatPhong.IDDatPhong from DatPhong where IDLoaiPhong = 15  )  )
update ThongTinHoaDonDV set IDHoaDon = null where IDHoaDon = ( select HoaDon.IDHoaDon from HoaDon where HoaDon.IDDatPhong = ( select DatPhong.IDDatPhong from DatPhong where IDLoaiPhong =15 ) ) 
delete from HoaDon where IDDatPhong = (select DatPhong.IDDatPhong from DatPhong where IDLoaiPhong = 15) 
delete from DatPhong where IDLoaiPhong = 15
delete from Phong where IDLoaiPhong = 15
delete from LoaiPhong where IDLoaiPhong = 15