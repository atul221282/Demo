using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainClasses;
using DataLayer;

namespace MVC3Tweet.Controllers
{ 
    public class TweetController : Controller
    {
        private TwitterContext db = new TwitterContext();

        //
        // GET: /Tweet/

        public ViewResult Index(int authorId)
        {
            ViewBag.AuthorId = authorId;
            return View(db.Tweets.Where(t => t.Author.Id == authorId).ToList());
        }

    
        public ActionResult Create(int authorId)
        {
            return View();
        } 

        //
        // POST: /Tweet/Create

        [HttpPost]
        public ActionResult Create(Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                db.Tweets.Add(tweet);
                db.SaveChanges();
                return RedirectToAction("Index", new { authorId = Request.Form["AuthorId"] });
            }

            return View(tweet);
        }
        
    //
        // GET: /Tweet/Delete/5
 
        public ActionResult Delete(int id)
        {
            Tweet tweet = db.Tweets.Find(id);
            return View(tweet);
        }

        //
        // POST: /Tweet/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Tweet tweet = db.Tweets.Find(id);
            db.Tweets.Remove(tweet);
            db.SaveChanges();
            return RedirectToAction("Index", new { authorId = Request.Form["AuthorId"] });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}