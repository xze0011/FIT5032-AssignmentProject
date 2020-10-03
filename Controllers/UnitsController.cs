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
    public class UnitsController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: Units
        public ActionResult Index()
        {

                var unitSet = db.UnitSet.Include(u => u.Module).Include(u => u.Tutor).Include(u => u.ClassRoom);
                return View(unitSet.ToList());
        }

        // GET: Units/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.UnitSet.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Units/Create
        public ActionResult Create()
        {
            ViewBag.ModuleId = new SelectList(db.ModuleSet, "Id", "ModuleName");
            ViewBag.TutorId = new SelectList(db.TutorSet, "Id", "TutorName");
            ViewBag.ClassRoomId = new SelectList(db.ClassRoomSet, "Id", "ClassRoomName");
            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "Id,UnitName,Description,PriceAud,ModuleId,TutorId,ClassRoomId")] Unit unit)
        {
            unit.UserId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(unit);
            if (ModelState.IsValid)
            {
                db.UnitSet.Add(unit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModuleId = new SelectList(db.ModuleSet, "Id", "ModuleName", unit.ModuleId);
            ViewBag.TutorId = new SelectList(db.TutorSet, "Id", "TutorName", unit.TutorId);
            ViewBag.ClassRoomId = new SelectList(db.ClassRoomSet, "Id", "ClassRoomName", unit.ClassRoomId);
            return View(unit);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Units/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.UnitSet.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModuleId = new SelectList(db.ModuleSet, "Id", "ModuleName", unit.ModuleId);
            ViewBag.TutorId = new SelectList(db.TutorSet, "Id", "TutorName", unit.TutorId);
            ViewBag.ClassRoomId = new SelectList(db.ClassRoomSet, "Id", "ClassRoomName", unit.ClassRoomId);
            return View(unit);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "Id,UnitName,Description,PriceAud,UserId,ModuleId,TutorId,ClassRoomId")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModuleId = new SelectList(db.ModuleSet, "Id", "ModuleName", unit.ModuleId);
            ViewBag.TutorId = new SelectList(db.TutorSet, "Id", "TutorName", unit.TutorId);
            ViewBag.ClassRoomId = new SelectList(db.ClassRoomSet, "Id", "ClassRoomName", unit.ClassRoomId);
            return View(unit);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Units/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.UnitSet.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit unit = db.UnitSet.Find(id);
            db.UnitSet.Remove(unit);
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
