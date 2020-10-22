using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BasementHoofersQuiz.Models;


namespace BasementHoofersQuiz.Controllers
{
    [Authorize]
    public class AttemptController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Attempt
        public ActionResult Index()
        {   
            //This ViewBag will show the name of the Quiz         
            //ViewBag.WhatQuiz = "";
            //var quizTitle = "";
            //using (var ctx = new ApplicationDbContext())
            //{
            //    //var quizTitle = ctx.Database.SqlQuery<string>("SELECT quizTitle FROM QuizModels INNER JOIN AttemptModels ON AttemptModels.quizId = QuizModels.quizId").FirstOrDefault<string>();
            //    int quizID = ctx.Database.SqlQuery<int>("SELECT AttemptModels.quizId FROM AttemptModels").FirstOrDefault<int>();               
            //    quizTitle = ctx.Database.SqlQuery<string>("SELECT quizTitle FROM QuizModels WHERE QuizModels.quizId = "+quizID).FirstOrDefault<string>();                
            //}

            //ViewBag.WhatQuiz = quizTitle;
            var current = User.Identity.GetUserId();
            var attempts = db.AttemptModels.Where(s => s.UserId == current).OrderByDescending(d =>d.attemptDateTime);
            return View(attempts.ToList());            
        }

        // GET: Attempt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttemptModel attemptModel = db.AttemptModels.Find(id);
            if (attemptModel == null)
            {
                return HttpNotFound();
            }
            return View(attemptModel);
        }

        // GET: Attempt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Attempt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AttemptModel attemptModel, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                //int quizID = Int32.Parse(collection["quizId"]);
                //attemptModel.quizId = quizID;
                attemptModel.attemptDateTime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                db.AttemptModels.Add(attemptModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attemptModel);
        }

        //Create Attemp on Tech Quiz
        // GET: Attempt/Create
        public ActionResult CreateTech()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTech(AttemptModel attemptModel)
        {
            if (ModelState.IsValid)
            {
                attemptModel.attemptDateTime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                attemptModel.quizId = 1;
                db.AttemptModels.Add(attemptModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attemptModel);
        }
        
        //Create Attemp on PSY Quiz
        // GET: Attempt/Create
        public ActionResult CreatePsy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePsy(AttemptModel attemptModel)
        {
            if (ModelState.IsValid)
            {
                attemptModel.attemptDateTime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                attemptModel.quizId = 2;
                db.AttemptModels.Add(attemptModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attemptModel);
        }

        //Create Attemp on PSY Quiz
        // GET: Attempt/Create
        public ActionResult CreateBreaks()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBreaks(AttemptModel attemptModel)
        {
            if (ModelState.IsValid)
            {
                attemptModel.attemptDateTime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                attemptModel.quizId = 3;
                db.AttemptModels.Add(attemptModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attemptModel);
        }

        // GET: Attempt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttemptModel attemptModel = db.AttemptModels.Find(id);
            if (attemptModel == null)
            {
                return HttpNotFound();
            }
            return View(attemptModel);
        }

        // POST: Attempt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "attemptId,quizId,UserId,quizResult")] AttemptModel attemptModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attemptModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attemptModel);
        }

        // GET: Attempt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttemptModel attemptModel = db.AttemptModels.Find(id);
            if (attemptModel == null)
            {
                return HttpNotFound();
            }
            return View(attemptModel);
        }

        // POST: Attempt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttemptModel attemptModel = db.AttemptModels.Find(id);
            db.AttemptModels.Remove(attemptModel);
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
