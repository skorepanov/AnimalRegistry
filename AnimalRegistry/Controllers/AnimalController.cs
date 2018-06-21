using AnimalRegistry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalRegistry.Controllers
{
    public class AnimalController : Controller
    {
        private AnimalContext db;

        public AnimalController(AnimalContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            return View(await db.Animals.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Animal animal = db.Animals
                .Where(a => a.Id == id)
                .FirstOrDefault();
            return View(animal);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Animal animal)
        {
            db.Animals.Add(animal);
            await db.SaveChangesAsync();
            return RedirectToAction("List");
        }
    }
}
