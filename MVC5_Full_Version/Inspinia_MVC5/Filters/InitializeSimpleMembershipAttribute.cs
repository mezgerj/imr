using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using Inspinia_MVC5.Models;
using System.Web.Security;

namespace IMR_WebApp.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<UsersContext>(null);

                try
                {
                    /*
                    using (var context = new UsersContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    } */
                    //changed DefaultConnection to Copy_IMR_TestEntities4 && Supporter to Supporters
                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "Supporter", "Supporter_Id", "UserName", autoCreateTables: true);
                    AddRole();
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }

            private static void AddRole()
            {
                if (!Roles.RoleExists("SuperAdmin"))
                {
                    Roles.CreateRole("SuperAdmin");
                }

                if (!Roles.RoleExists("Admin"))
                {
                    Roles.CreateRole("Admin");
                }

                if (!Roles.RoleExists("Manager"))
                {
                    Roles.CreateRole("Manager");
                }

                if (!Roles.RoleExists("Supporter"))
                {
                    Roles.CreateRole("Supporter");
                }

            }
        }
    }
}
