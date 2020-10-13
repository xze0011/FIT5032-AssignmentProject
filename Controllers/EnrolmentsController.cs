using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_AssignmentProject.Models;
using Microsoft.AspNet.Identity;

namespace FIT5032_AssignmentProject.Controllers
{

    [Authorize]
    public class EnrolmentsController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: Enrolments
        public ActionResult Index()
        {
            if (User.IsInRole("Administrator"))
            {
                var enrolmentSet = db.EnrolmentSet.Include(e => e.Student).Include(e => e.Unit);
                return View(enrolmentSet.ToList());
            }
            else
            {
                var userId = User.Identity.GetUserId();
                var Enrolments = db.EnrolmentSet.Where(s => s.UserId == userId).ToList();
                return View(Enrolments);
            }

        }

        // GET: Enrolments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrolment enrolment = db.EnrolmentSet.Find(id);
            if (enrolment == null)
            {
                return HttpNotFound();
            }
            return View(enrolment);
        }

        // GET: Enrolments/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.StudentSet, "Id", "FirstName");
            ViewBag.UnitId = new SelectList(db.UnitSet, "Id", "UnitName");
            return View();
        }

        // POST: Enrolments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "Id,EnrolmentDate,Grade,StudentId,UnitId")] Enrolment enrolment)
        {
            enrolment.UserId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(enrolment);
            if (ModelState.IsValid)
            {
                db.EnrolmentSet.Add(enrolment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.StudentSet, "Id", "FirstName", enrolment.StudentId);
            ViewBag.UnitId = new SelectList(db.UnitSet, "Id", "UnitName", enrolment.UnitId);
            return View(enrolment);
        }

        // GET: Enrolments/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrolment enrolment = db.EnrolmentSet.Find(id);
            if (enrolment == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.StudentSet, "Id", "FirstName", enrolment.StudentId);
            ViewBag.UnitId = new SelectList(db.UnitSet, "Id", "UnitName", enrolment.UnitId);
            return View(enrolment);
        }

        // POST: Enrolments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "Id,EnrolmentDate,Grade,UserId,StudentId,UnitId")] Enrolment enrolment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrolment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.StudentSet, "Id", "FirstName", enrolment.StudentId);
            ViewBag.UnitId = new SelectList(db.UnitSet, "Id", "UnitName", enrolment.UnitId);
            return View(enrolment);
        }

        // GET: Enrolments/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrolment enrolment = db.EnrolmentSet.Find(id);
            if (enrolment == null)
            {
                return HttpNotFound();
            }
            return View(enrolment);
        }

        // POST: Enrolments/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrolment enrolment = db.EnrolmentSet.Find(id);
            db.EnrolmentSet.Remove(enrolment);
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
