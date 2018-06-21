using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalRegistry.Models
{
    public class AnimalContextSeed
    {
        public static async Task SeedAsync(AnimalContext animalContext)
        {
            if (!animalContext.Animals.Any())
            {
                animalContext.Animals.AddRange(
                    GetAnimals());

                await animalContext.SaveChangesAsync();
            }
        }

        static IEnumerable<Animal> GetAnimals()
        {
            return new List<Animal>()
            {
                new Animal { Id = 1, Class="Кот", Gender="Муж.", Name="Васька", Location="Клетка №5" },
                new Animal { Id = 2, Class="Собака", Gender="Жен.", Name="Полли", Location="Клетка №3", Weight = 5, DateOfWeighing = new DateTime(2018, 6, 2) },
                new Animal { Id = 3, Class="Попугай", Gender="Муж.", Name="Гаврош", Location="Клетка для попугаев", Weight = 0.03m }
            };
        }
    }
}
