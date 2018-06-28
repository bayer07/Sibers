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
    public class ProjectExecutorsController : Controller
    {
        private ProjectManagmentModel db = new ProjectManagmentModel();

        // GET: ProjectExecutors
        public ActionResult Index()
        {
            var projectExecutors = db.ProjectExecutors.Include(p => p.Employee).Include(p => p.Project);
            return View(projectExecutors.ToList());
        }

        // GET: ProjectExecutors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectExecutor projectExecutor = db.ProjectExecutors.Find(id);
            if (projectExecutor == null)
            {
                return HttpNotFound();
            }
            return View(projectExecutor);
        }

        // GET: ProjectExecutors/Create
        public ActionResult Create()
        {
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "FirstName");
            ViewBag.Project_Id = new SelectList(db.Projects, "Id", "Name");
            return View();
        }

        // POST: ProjectExecutors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Project_Id,Employee_Id")] ProjectExecutor projectExecutor)
        {
            if (ModelState.IsValid)
            {
                db.ProjectExecutors.Add(projectExecutor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "FirstName", projectExecutor.Employee_Id);
            ViewBag.Project_Id = new SelectList(db.Projects, "Id", "Name", projectExecutor.Project_Id);
            return View(projectExecutor);
        }

        // GET: ProjectExecutors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectExecutor projectExecutor = db.ProjectExecutors.Find(id);
            if (projectExecutor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "FirstName", projectExecutor.Employee_Id);
            ViewBag.Project_Id = new SelectList(db.Projects, "Id", "Name", projectExecutor.Project_Id);
            return View(projectExecutor);
        }

        // POST: ProjectExecutors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Project_Id,Employee_Id")] ProjectExecutor projectExecutor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectExecutor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "FirstName", projectExecutor.Employee_Id);
            ViewBag.Project_Id = new SelectList(db.Projects, "Id", "Name", projectExecutor.Project_Id);
            return View(projectExecutor);
        }

        // GET: ProjectExecutors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectExecutor projectExecutor = db.ProjectExecutors.Find(id);
            if (projectExecutor == null)
            {
                return HttpNotFound();
            }
            return View(projectExecutor);
        }

        // POST: ProjectExecutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectExecutor projectExecutor = db.ProjectExecutors.Find(id);
            db.ProjectExecutors.Remove(projectExecutor);
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
