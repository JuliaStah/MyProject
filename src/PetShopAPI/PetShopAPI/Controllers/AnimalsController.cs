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
            if (animal == null)
            {
                return BadRequest("Животное с таким ID не найдено!");
            }

            return Ok(animal);
        }


        [HttpPost]
        public IActionResult CreateAnimal(string name, string species, string breed, int age, decimal price, bool isAvailable)
        {
            var animal = new Animal
            {
                Id = _animals.Max(a => a.Id) + 1,
                Name = name,
                Species = species,
                Breed = breed,
                Age = age,
                Price = price,
                IsAvailable = isAvailable
            };

            _animals.Add(animal);
            return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
        }

        [HttpPut]
        public IActionResult UpdateAnimal(int id, string name, string species, string breed, int age, decimal price, bool isAvailable)
        {
            var animal = _animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return BadRequest("Животное с таким ID не найдено!");
            }

            animal.Name = name;
            animal.Species = species;
            animal.Breed = breed;
            animal.Age = age;
            animal.Price = price;
            animal.IsAvailable = isAvailable;

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteAnimal(int id)
        {
            var animal = _animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return BadRequest("Животное с таким ID не найдено!");
            }

            _animals.Remove(animal);
            return Ok();
        }
    }
}
