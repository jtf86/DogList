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
        [Route("/")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("/dogs")]
        public ActionResult Dogs()
        {
          List<Dog> allDogs = Dog.GetAll();
          return View(allDogs);
        }

        [Route("/dogs/{id}")]
        public ActionResult DogDetails(int id)
        {
          Dog thisDog = Dog.Find(id);
          Console.WriteLine(thisDog);
          return View(thisDog);
        }


        [Route("/newdog")]
        [HttpPost]
        public ActionResult NewDog()
        {
          Dictionary<string, object> model = new Dictionary<string, object> ();
          Dog newDog = new Dog(Request.Form["dogname"]);
          newDog.Save();
          List<Dog> allDogs = Dog.GetAll();
          model.Add("newDog", newDog);
          model.Add("allDogs", allDogs);
          return View(model);
        }

    }
}
