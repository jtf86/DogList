using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DogList.Objects;

namespace DogList.Controllers
{
    public class HomeController : Controller
    {

// HOME AND VIEW ALL ROUTES

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("/dogs")]
        public ActionResult Dogs()
        {
          List<Dog> allDogs = Dog.GetAll();
          return View(allDogs);
        }

// CREATE ROUTE

        [HttpPost("/dogs")]
        public ActionResult NewDog()
        {
          Dictionary<string, object> model = new Dictionary<string, object> ();
          Dog newDog = new Dog(Request.Form["dogname"]);
          newDog.Save();
          List<Dog> allDogs = Dog.GetAll();
          model.Add("newDog", newDog);
          model.Add("allDogs", allDogs);
          return RedirectToAction("Dogs");
        }

// READ/DETAILS ROUTE

        [HttpGet("/dogs/{id}")]
        public ActionResult DogDetails(int id)
        {
          Dog thisDog = Dog.Find(id);
          return View(thisDog);
        }

// EDIT ROUTES

        [HttpGet("/dogs/edit/{id}")]
        public ActionResult DogEdit(int id)
        {
          Dog thisDog = Dog.Find(id);
          return View(thisDog);
        }

        // [Route()]
        [HttpPost("/dogs/edit/{id}")]
        public ActionResult DogEdited(int id)
        {
          Dog thisDog = Dog.Find(id);
          thisDog.Update(Request.Form["newname"]);
          return RedirectToAction("Dogs");
        }

// DELETE ROUTES

        [HttpGet("/dogs/delete/{id}")]
        public ActionResult DogDelete(int id)
        {
          Dog thisDog = Dog.Find(id);
          return View(thisDog);
        }

        [HttpPost("/dogs/deleted/{id}")]
        public ActionResult DogDeleted(int id)
        {
          Dog thisDog = Dog.Find(id);
          string model = thisDog.GetName();
          thisDog.Delete();
          return RedirectToAction("Dogs");
        }

    }
}
