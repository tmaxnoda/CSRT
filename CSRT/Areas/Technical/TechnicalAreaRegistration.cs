using System.Web.Mvc;

namespace CSRT.Areas.Technical
{
    public class TechnicalAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Technical";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Technical_default",
                "Technical/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}