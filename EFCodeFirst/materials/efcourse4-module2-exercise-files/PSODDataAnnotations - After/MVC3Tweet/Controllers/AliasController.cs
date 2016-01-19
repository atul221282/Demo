using System.Data;
using System.Linq;
using System.Web.Mvc;
using DomainClasses;
using DataLayer;

namespace MVC3Tweet.Controllers
{ 
    public class AliasController : Controller
    {
        private TwitterContext db = new TwitterContext();

        //
        // GET: /Alias/

        public ViewResult Index()
        {
            return View(db.Aliases.ToList());
        }

        //
        // GET: /Alias/Details/5

        public ViewResult Details(int id)
        {
            Alias alias = db.Aliases.Find(id);
            return View(alias);
        }

        //
        // GET: /Alias/Create

        public ActionResult Create()
        {
            var alias = new Alias {Email = "info@juliel.me", CreateDate = System.DateTime.Now};
            return View(alias);
        } 

        //
        // POST: /Alias/Create

        [HttpPost]
        public ActionResult Create(Alias alias)
        {
            if (ModelState.IsValid)
            {
                db.Aliases.Add(alias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alias);
        }
        
        //
        // GET: /Alias/Edit/5
 
        public ActionResult Edit(int id)
        {
            Alias alias = db.Aliases.Find(id);
            return View(alias);
        }

        //
        // POST: /Alias/Edit/5

        [HttpPost]
        public ActionResult Edit(Alias alias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alias);
        }

        //
        // GET: /Alias/Delete/5
 
        public ActionResult Delete(int id)
        {
            Alias alias = db.Aliases.Find(id);
            return View(alias);
        }

        //
        // POST: /Alias/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Alias alias = db.Aliases.Find(id);
            db.Aliases.Remove(alias);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}