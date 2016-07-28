using GFS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GFS
{
    public class AuditAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;

            Audit audit = new Audit()
            {

                AuditID = Guid.NewGuid(),

                UserName = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",

                IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,

                AreaAccessed = request.RawUrl,

                DateAccessed = DateTime.UtcNow
            };

            // Stores the Audit in the Database
            GFSContext context = new GFSContext();
            context.Audits.Add(audit);
            context.SaveChanges();

            base.OnActionExecuting(filterContext);
        }

    }
}