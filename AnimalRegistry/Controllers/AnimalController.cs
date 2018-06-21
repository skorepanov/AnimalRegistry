using AnimalRegistry.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalRegistry.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var animals = AnimalContextSeed.GetAnimals();
            return View(animals);
        }

        public IActionResult Edit(int id)
        {
            Animal animal = AnimalContextSeed.GetAnimals()
                .Where(a => a.Id == id)
                .FirstOrDefault();
            return View(animal);
        }
    }
}
