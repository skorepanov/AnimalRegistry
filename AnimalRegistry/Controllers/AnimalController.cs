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

        [HttpPost]
        public async Task<IActionResult> Create(Animal animal)
        {
            db.Animals.Add(animal);
            await db.SaveChangesAsync();
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Animal animal = await db.Animals.FirstOrDefaultAsync(a => a.Id == id);
                if (animal != null)
                    return View(animal);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Animal animal)
        {
            db.Animals.Update(animal);
            await db.SaveChangesAsync();
            return RedirectToAction("List");
        }
    }
}
