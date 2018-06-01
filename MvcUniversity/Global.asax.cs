using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UniversityData;

namespace MvcUniversity
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Database.SetInitializer<SchoolContext>(null);  // Leave the db alone
            // Database.SetInitializer<SchoolContext>(new DropCreateDatabaseIfModelChanges<SchoolContext>());  // Recreate if model changes 
            Database.SetInitializer(new SchoolInitializer());  // Recreate if model changes and Seed the db

            using (var context = new SchoolContext())
            {
                context.Database.Initialize(true);
            }


        }
    }
}
