using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectManagment;

namespace ProjectManagment.Controllers
{
    public class ProjectWorkersController : Controller
    {
        private ProjectManagmentModel db = new ProjectManagmentModel();

        // GET: ProjectWorkers
        public ActionResult Index()
        {
            var projectWorkers = db.ProjectWorkers.Include(p => p.Employee).Include(p => p.Project);
            return View(projectWorkers.ToList());
        }

        // GET: ProjectWorkers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectWorker projectWorker = db.ProjectWorkers.Find(id);
            if (projectWorker == null)
            {
                return HttpNotFound();
            }
            return View(projectWorker);
        }

        // GET: ProjectWorkers/Create
        public ActionResult Create()
        {
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "FirstName");
            ViewBag.Project_Id = new SelectList(db.Projects, "Id", "Name");
            return View();
        }

        // POST: ProjectWorkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Project_Id,Employee_Id")] ProjectWorker projectWorker)
        {
            if (ModelState.IsValid)
            {
                db.ProjectWorkers.Add(projectWorker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "FirstName", projectWorker.Employee_Id);
            ViewBag.Project_Id = new SelectList(db.Projects, "Id", "Name", projectWorker.Project_Id);
            return View(projectWorker);
        }

        // GET: ProjectWorkers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectWorker projectWorker = db.ProjectWorkers.Find(id);
            if (projectWorker == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "FirstName", projectWorker.Employee_Id);
            ViewBag.Project_Id = new SelectList(db.Projects, "Id", "Name", projectWorker.Project_Id);
            return View(projectWorker);
        }

        // POST: ProjectWorkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Project_Id,Employee_Id")] ProjectWorker projectWorker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectWorker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "FirstName", projectWorker.Employee_Id);
            ViewBag.Project_Id = new SelectList(db.Projects, "Id", "Name", projectWorker.Project_Id);
            return View(projectWorker);
        }

        // GET: ProjectWorkers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectWorker projectWorker = db.ProjectWorkers.Find(id);
            if (projectWorker == null)
            {
                return HttpNotFound();
            }
            return View(projectWorker);
        }

        // POST: ProjectWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectWorker projectWorker = db.ProjectWorkers.Find(id);
            db.ProjectWorkers.Remove(projectWorker);
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
