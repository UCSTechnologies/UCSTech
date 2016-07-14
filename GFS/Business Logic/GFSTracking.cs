using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GFS.Models;
using GFS.Models.Tracking;

namespace GFS.Business_Logic
{
    public class GFSTracking
    {
        GFSContext db = new GFSContext();

        public void login(string userid)
        {
            User d = db.Users.ToList().Find(p => p.userid == userid);
            Activities t = new Activities();
            t.userid = userid;
            t.firstname = d.firstname;
            t.lastname = d.lastname;
            t.activity = "Logged in";
            t.time = DateTime.Now;
            db.Activities.Add(t);
            db.SaveChanges();
        }

        public void logout(string userid)
        {
            User d = db.Users.ToList().Find(p => p.userid == userid);
            Activities t = new Activities();
            t.userid = userid;
            t.firstname = d.firstname;
            t.lastname = d.lastname;
            t.activity = "Logged out";
            t.time = DateTime.Now;
            db.Activities.Add(t);
            db.SaveChanges();
        }

        public void sellPolicy(string userid, string polno, string membername)
        {
            User d = db.Users.ToList().Find(p => p.userid == userid);
            Activities t = new Activities();
            t.userid = userid;
            t.firstname = d.firstname;
            t.lastname = d.lastname;
            t.policyNo = polno;
            t.memname = membername;
            t.activity = "Sold policy";
            t.time = DateTime.Now;
            db.Activities.Add(t);
            db.SaveChanges();
        }

        public void makePayment(string userid, string firstname, string lastname)
        {
            //Actities t = new Actities();
            //t.userid = userid;
            //t.firstname = firstname;
            //t.lastname = lastname;
            //t.time = DateTime.Now;
            //db.Logouts.Add(t);
            db.SaveChanges();
        }

        public void changesMade(string userid, string firstname, string lastname)
        {
            //Actities t = new Actities();
            //t.userid = userid;
            //t.firstname = firstname;
            //t.lastname = lastname;
            //t.time = DateTime.Now;
            //db.Logouts.Add(t);
            db.SaveChanges();
        }
    }
}