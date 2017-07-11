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
        public ActionResult Index()
        {
            return View();
        }

        [Route("/dogs")]
        public ActionResult Dogs()
        {
          // Dictionary<string, object> model = new Dictionary<string, object> ();
          // List<Dog> allDogs = Dog.GetAll();
          // model.Add("allDogs", allDogs);
          // return View(model);
          return View();
        }

        [Route("/newdog")]
        [HttpPost]
        public ActionResult NewDog()
        {
          // Dictionary<string, object> model = new Dictionary<string, object> ();
          // Dog newDog = new Dog(Request.Form["name"]);
          // newDog.Save();
          // List<Dog> allDogs = Dog.GetAll();
          // model.Add("Recentdog", newDog);
          // model.Add("allDogs", allDogs);
          // return View(model);
          return View();
        }

    }
}
