using System.Web.Mvc;

namespace CSRT.Areas.Finances_Procurement_Admin
{
    public class Finances_Procurement_AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Finances_Procurement_Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Finances_Procurement_Admin_default",
                "Finances_Procurement_Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}