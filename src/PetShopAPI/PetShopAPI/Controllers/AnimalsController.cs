using Microsoft.AspNetCore.Mvc;
using PetShopAPI.Models;

namespace PetShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AnimalsController : ControllerBase
    {
        private static List<Animal> _animals = new List<Animal>
        {
            new Animal { Id = 1, Name = "Барсик", Species = "Кошка", Breed = "Британская", Age = 2, Price = 15000, IsAvailable = true },
            new Animal { Id = 2, Name = "Шарик", Species = "Собака", Breed = "Лабрадор", Age = 1, Price = 25000, IsAvailable = true }
        };

        
        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(_animals);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id)
        {
            var animal = _animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return NotFound();
            return Ok(animal);
        }

        
        [HttpPost]
        public IActionResult CreateAnimal(Animal animal)
        {
            animal.Id = _animals.Max(a => a.Id) + 1;
            _animals.Add(animal);
            return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
        }
    }
}
