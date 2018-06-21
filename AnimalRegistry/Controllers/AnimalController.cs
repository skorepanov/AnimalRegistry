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

        public async Task<IActionResult> List(AnimalSortState sortOrder = AnimalSortState.ClassAsc)
        {
            IQueryable<Animal> animals = null;

            // сохранить сортировку чтобы при повторном клике менялось направление сортировки
            ViewBag.ClassSort = sortOrder == AnimalSortState.ClassAsc ? AnimalSortState.ClassDesc : AnimalSortState.ClassAsc;
            ViewBag.GenderSort = sortOrder == AnimalSortState.GenderAsc ? AnimalSortState.GenderDesc : AnimalSortState.GenderAsc;
            ViewBag.NameSort = sortOrder == AnimalSortState.NameAsc ? AnimalSortState.NameDesc : AnimalSortState.NameAsc;
            ViewBag.LocationSort = sortOrder == AnimalSortState.LocationAsc ? AnimalSortState.LocationDesc : AnimalSortState.LocationAsc;
            ViewBag.WeightSort = sortOrder == AnimalSortState.WeightAsc ? AnimalSortState.WeightDesc : AnimalSortState.WeightAsc;
            ViewBag.DateOfWeighingSort =
                sortOrder == AnimalSortState.DateOfWeighingAsc ? AnimalSortState.DateOfWeighingDesc : AnimalSortState.DateOfWeighingAsc;

            switch (sortOrder)
            {
                case AnimalSortState.ClassDesc:
                    animals = db.Animals.OrderByDescending(a => a.Class);
                    break;
                case AnimalSortState.GenderAsc:
                    animals = db.Animals.OrderBy(a => a.Gender);
                    break;
                case AnimalSortState.GenderDesc:
                    animals = db.Animals.OrderByDescending(a => a.Gender);
                    break;
                case AnimalSortState.NameAsc:
                    animals = db.Animals.OrderBy(a => a.Name);
                    break;
                case AnimalSortState.NameDesc:
                    animals = db.Animals.OrderByDescending(a => a.Name);
                    break;
                case AnimalSortState.LocationAsc:
                    animals = db.Animals.OrderBy(a => a.Location);
                    break;
                case AnimalSortState.LocationDesc:
                    animals = db.Animals.OrderByDescending(a => a.Location);
                    break;
                case AnimalSortState.WeightAsc:
                    animals = db.Animals.OrderBy(a => a.Weight);
                    break;
                case AnimalSortState.WeightDesc:
                    animals = db.Animals.OrderByDescending(a => a.Weight);
                    break;
                case AnimalSortState.DateOfWeighingAsc:
                    animals = db.Animals.OrderBy(a => a.DateOfWeighing);
                    break;
                case AnimalSortState.DateOfWeighingDesc:
                    animals = db.Animals.OrderByDescending(a => a.DateOfWeighing);
                    break;
                default:
                    animals = db.Animals.OrderBy(a => a.Class);
                    break;
            }

            return View(await animals.AsNoTracking().ToListAsync());
        }

        #region Создание
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
        #endregion Создание

        #region Редактирование
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
        #endregion Редактирование

        #region Удаление
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Animal animal = new Animal { Id = id.Value };
                db.Entry(animal).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("List");
            }

            return NotFound();
        }
        #endregion Удаление
    }
}
