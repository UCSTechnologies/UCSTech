using GFS.Models;
using GFS.Models.Tracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GFS.Controllers
{
    public class AuditController : Controller
    {
        private GFSContext db = new GFSContext();
        // GET: Audit
        //public ActionResult ViewAuditRecords(string searchBy, string search)
        //{
        //    var user = from d in db.Audits.ToList()
        //              select d;
        //    if (searchBy == "UserName")
        //    {
        //        user = (db.Audits.Where(x => x.UserName == search).ToList());
        //    }

        //    return View(user);

        //}
        public ActionResult ViewAuditRecords(Activities t)
        {

            var audits = from d in db.Audits.ToList()
                         select d;
            if (t != null)
            {
                audits = (db.Audits.Where(x => x.UserName == t.userid && x.DateAccessed.Day == t.time.Day));
            }
            return View(audits);
        }
    }
}