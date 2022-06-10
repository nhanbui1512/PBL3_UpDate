delete from ChiTietHoaDon where IDHoaDon = ( select HoaDon.IDHoaDon from HoaDon where IDDatPhong = (select DatPhong.IDDatPhong from DatPhong where DatPhong.IDTK = 6) ) 
update ThongTinHoaDonDV set IDHoaDon = null where IDHoaDon = ( select HoaDon.IDHoaDon from HoaDon where IDDatPhong = (select DatPhong.IDDatPhong from DatPhong where DatPhong.IDTK = 6) )
delete from HoaDon where HoaDon.IDDatPhong =  (select DatPhong.IDDatPhong from DatPhong where DatPhong.IDTK = 6 )
delete from DatPhong where DatPhong.IDTK = 6
delete from ThongTinTK where IDTaiKhoan = 6
delete from TaiKhoan where IDTK = 6 