using System;
using UIT.iDeal.Infrastructure.Bootstrapper;

namespace UIT.iDeal.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            /*AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);*/

            ApplicationConfigurator.BuildContainer();
            ApplicationConfigurator.Start();
        }

        protected void Application_End(Object sender, EventArgs e)
        {
            ApplicationConfigurator.End();
        }
    }
}