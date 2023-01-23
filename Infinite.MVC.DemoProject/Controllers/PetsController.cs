using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infinite.MVC.DemoProject.Models;
using System.Data.Entity;


namespace Infinite.MVC.DemoProject.Controllers
{
    public class PetsController : Controller
    {
        private readonly AppDbContext _appDb = null;

        public PetsController()
        {
            _appDb = new AppDbContext();
        }
        // GET: Pets
        public ActionResult Index()
        {
            var pets = _appDb.Pets.ToList();
            return View(pets);
        }

        public ActionResult Details(int id)
        {
            var pet = _appDb.Pets.Include(p => p.Breeds).FirstOrDefault(x => x.Id == id);
            if (pet != null)
            {
                return View(pet);
            }
            return HttpNotFound();

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pet = _appDb.Pets.FirstOrDefault(p => p.Id == id);
            if (pet != null)
            {
                var breeds = _appDb.Breeds.ToList();
                ViewBag.Breeds = breeds;
                return View(pet);
            }
            return HttpNotFound("Pet Id does not Exists");
        }
        [HttpPost]
        public ActionResult Edit(Pets pets)
        {
            if (pets != null)
            {
                var petInDb = _appDb.Pets.Find(pets.Id);
                if (petInDb != null)
                {
                    petInDb.Height = pets.Height;
                    petInDb.BreedsId = pets.BreedsId;
                    petInDb.Age = pets.Age;
                    petInDb.Weight = pets.Weight;
                    petInDb.Description = pets.Description;
                    petInDb.PetName = pets.PetName;
                    _appDb.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            var breeds = _appDb.Breeds.ToList();
            ViewBag.Breeds = breeds;
            return View(pets);
        }
        public ActionResult Delete(int id)
        {
            var petInDb = _appDb.Pets.FirstOrDefault(p => p.Id == id);
            if (petInDb != null)
            {
                _appDb.Pets.Remove(petInDb);
                _appDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }




    }
}