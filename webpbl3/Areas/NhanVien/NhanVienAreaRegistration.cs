using System.Web.Mvc;

namespace webpbl3.Areas.NhanVien
{
    public class NhanVienAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "NhanVien";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "NhanVien_default",
                "NhanVien/{controller}/{action}/{id}",
                new { controller = "DatPhong", action = "DanhSachDatPhong", id = UrlParameter.Optional }
            );
        }
    }
}