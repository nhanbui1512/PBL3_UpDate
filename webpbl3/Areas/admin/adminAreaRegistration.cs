using System.Web.Mvc;

namespace webpbl3.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",
                new { controller = "DatPhong", action = "DanhSachDatPhong", id = UrlParameter.Optional }

            );
        }
    }
}