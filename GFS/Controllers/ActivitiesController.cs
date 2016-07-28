using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GFS.Models;
using GFS.Models.Tracking;

namespace GFS.Controllers
{
    public class ActivitiesController : Controller
    {
        private GFSContext db = new GFSContext();

        // GET: Activities
        public ActionResult Index()
        {
            var acts = db.Activities.ToList().Where(p => p.time.Day == DateTime.Now.Day);
            return View(/*db.Activities.ToList()*/ acts);
        }
        
    }
}
