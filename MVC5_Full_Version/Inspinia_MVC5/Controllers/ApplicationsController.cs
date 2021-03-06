﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inspinia_MVC5.Models;
using System.Diagnostics;

namespace Inspinia_MVC5.Controllers
{
    public class ApplicationsController : Controller
    {
        private Copy_IMR_TestEntities6 db = new Copy_IMR_TestEntities6();

        // GET: /Applications/
        public ActionResult Index()
        {
            List<Application> listOfApplicationsForTheCurrentUser = new List<Application>();
            int currentUserId = ((Supporter)Session["Supporter"]).Supporter_Id;

            foreach (Application_Supporters x in db.Application_Supporters)
            {
                int temp = x.Supporter_Id;
                if (temp.Equals(currentUserId))
                {
                    Application currentApp = db.Applications.Find(x.Application_Id);
                    listOfApplicationsForTheCurrentUser.Add(currentApp);
                }
            }

            ViewData["applications"] = listOfApplicationsForTheCurrentUser;

            return View(); //db.Applications.ToList());
        }

        // GET: /Applications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }

            //Finds all the users with same company id as the application. 
            IEnumerable<SelectListItem> users = from user in db.Supporters.ToList()
                                                where user.Company_Id.Equals(application.Company_Id)
                                                select new SelectListItem
                                                {
                                                    Text = user.FirstName + " " + user.LastName,
                                                    Value = user.Supporter_Id.ToString()
                                                };
            ViewData["Supporter_Id"] = users;

            return View(application);
        }

        // GET: /Applications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Application_Id,Name,Description,Company_Id,ApplicationToken")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Applications.Add(application);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(application);
        }

        // GET: /Applications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: /Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Application_Id,Name,Description,Company_Id,ApplicationToken")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(application);
        }

        // GET: /Applications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: /Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Application application = db.Applications.Find(id);
            db.Applications.Remove(application);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignUser([Bind(Include = "Application_Id,Supporter_Id")] Application_Supporters model)
        {
            //TODO show error message for trying to add someone who is already there or only display people who aren't already there.
            //Supporter currentSupporter = db.Supporters.Find(WebSecurity.CurrentUserId);

            //if (application.Company_Id == currentSupporter.Company_Id || currentSupporter.Role_Id == 1)
            //{
            db.Application_Supporters.Add(model);

            //application.Supporters.Add(db.Supporters.Find(model.Supporter_Id));
            db.SaveChanges();
            return RedirectToAction("Details", new { id = model.Application_Id });
            /*
            }
            else
            {
                //TODO error page
                return View();
            } */
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveUser([Bind(Include = "Application_Id, Supporter_Id")] Application_Supporters model)
        {
            //TODO display error message for trying to remove someone who isn't there or only display people that can be removed.
            Application_Supporters entry = db.Application_Supporters.Find(model.Application_Id, model.Supporter_Id);
            db.Application_Supporters.Remove(entry);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = model.Application_Id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
