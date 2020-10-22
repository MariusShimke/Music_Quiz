using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BasementHoofersQuiz.Models;

namespace BasementHoofersQuiz.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Quiz
        public ActionResult Index()
        {
            return View(db.QuizModels.ToList());
        }

        // GET: Quiz/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizModel quizModel = db.QuizModels.Find(id);
            if (quizModel == null)
            {
                return HttpNotFound();
            }
            return View(quizModel);
        }

        // GET: Quiz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quiz/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "quizId,quizTitle,quizDescription")] QuizModel quizModel)
        {
            if (ModelState.IsValid)
            {
                db.QuizModels.Add(quizModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quizModel);
        }

        // GET: Quiz/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizModel quizModel = db.QuizModels.Find(id);
            if (quizModel == null)
            {
                return HttpNotFound();
            }
            return View(quizModel);
        }

        // POST: Quiz/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "quizId,quizTitle,quizDescription")] QuizModel quizModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quizModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quizModel);
        }

        // GET: Quiz/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizModel quizModel = db.QuizModels.Find(id);
            if (quizModel == null)
            {
                return HttpNotFound();
            }
            return View(quizModel);
        }

        // POST: Quiz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuizModel quizModel = db.QuizModels.Find(id);
            db.QuizModels.Remove(quizModel);
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
