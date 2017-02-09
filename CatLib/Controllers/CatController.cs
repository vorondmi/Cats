using System.Collections.Generic;
using System.Web.Mvc;
using CatLib.Models;

namespace CatLib.Controllers
{
    public class CatController : Controller
    {
        private CatDbContext db = new CatDbContext();
        public List<Cat> catList = new List<Cat>
            {
                new Cat { id = 1, names = "Sally", ages = 2 },
                new Cat { id = 2, names = "Dolly", ages = 4 },
                new Cat { id = 3, names = "Molly", ages = 5 }
            };

        public ActionResult Index()
        {
            //var allCats = from m in db.cats select m;

            return View(catList);
        }

        // GET: Cat
        public ActionResult Create()
        {
            return View(new Cat());
        }

        [HttpPost]
        public ActionResult Create(Cat input)
        {
            if (ModelState.IsValid)
            {
                //db.cats.Add(input);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(input);
        }

        public ActionResult Details(int id)
        {
            return View(catList[id-1]);
        }

        public ActionResult Update(int id)
        {
            return View(catList[id - 1]);
        }

        [HttpPost]
        public ActionResult Update(Cat updatedCat)
        {
            catList[updatedCat.id - 1] = updatedCat;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            catList.RemoveAt(id-1);
            return RedirectToAction("Index");
        }

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Cat catToDelete = db.cats.Find(id);
        //    db.cats.Remove(catToDelete);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}