using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inspinia_MVC5.Models;

namespace Inspinia_MVC5.Controllers
{
    public class QAController : Controller
    {
        private Copy_IMR_TestEntities6 db = new Copy_IMR_TestEntities6();

        // GET: /QA/
        public ActionResult Index()
        {
            List<QA> currentUserQAs = new List<QA>();
            List<int> currentUserApplicationIds = new List<int>();
            foreach (var application in ((List<Application>)Session["ApplicationList"]))
            {
                currentUserApplicationIds.Add(application.Application_Id);
            }

            foreach(var qas in db.QAs)
            {
                if(currentUserApplicationIds.Contains(qas.Application_Id))
                {
                    currentUserQAs.Add(qas);
                }
            }

            ViewData["qas"] = currentUserQAs;
            return View();
        }

        // GET: /QA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QA qa = db.QAs.Find(id);
            if (qa == null)
            {
                return HttpNotFound();
            }
            return View(qa);
        }

        // GET: /QA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /QA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QAId,Title,Subtitle,Question,Answer,Type_Id,Application_Id,Geo_Id,DownloadTime")] QA qa)
        {
            if (ModelState.IsValid)
            {
                db.QAs.Add(qa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qa);
        }

        // GET: /QA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QA qa = db.QAs.Find(id);
            if (qa == null)
            {
                return HttpNotFound();
            }
            return View(qa);
        }

        // POST: /QA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QAId,Title,Subtitle,Question,Answer,Type_Id,Application_Id,Geo_Id,DownloadTime")] QA qa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qa);
        }


        // POST: /QA/Reorder
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Reorder(List<JSON_Helper> list)
        {
            if (list != null)
            {
                int index = 0;

                foreach (var item in list)
                {
                    QA qa = db.QAs.Find(item.id);
                    qa.Sequence_Num = index;
                    db.SaveChanges();
                    index++;
                }

                return Json("success");
            }
            else
            {
                return Json("not here");
            }
        }


        // GET: /QA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QA qa = db.QAs.Find(id);
            if (qa == null)
            {
                return HttpNotFound();
            }
            return View(qa);
        }

        // POST: /QA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QA qa = db.QAs.Find(id);
            db.QAs.Remove(qa);
            db.SaveChanges();
            return RedirectToAction("Index");
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
