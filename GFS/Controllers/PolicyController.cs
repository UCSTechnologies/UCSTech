using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GFS.Models.Policies;
using GFS.Models;

namespace GFS.Controllers
{
    public class PolicyController : Controller
    {
        public GFSContext db = new GFSContext();
        // GET: Policy
        [Audit]
        public ActionResult template(string pol)
        {
            TempData["Main"] = db.NewMembers.ToList().Find(p => p.policyNo == pol);
            TempData["Deps"] = (from e in db.Dependants.ToList()
                               where e.policyNo == pol
                               select e).ToList();
            TempData["Ppayers"] = db.Payers.ToList().Find(l => l.policyNo == pol);
            TempData["Benss"] = (from e in db.Beneficiaries.ToList()
                                 where e.policyNo == pol
                                 select e).ToList();
            return View((NewMember)TempData["Main"]);
        }
    }
}