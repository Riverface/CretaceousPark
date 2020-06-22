using CretaceousPark.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CretaceousPark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private CretaceousParkContext _db;

        public AnimalsController(CretaceousParkContext db)
        {
            _db = db;
        }

        // GET api/animals
        [HttpGet]
        public ActionResult<IEnumerable<Animal>> Get(string species, string gender, string name, int minimumAge, int id)
        {
            var query = _db.Animals.AsQueryable();
            // field for Species
            if (species != null)
            {
                query = query.Where(entry => entry.Species == species);
            }
            // field for Gender
            if (gender != null)
            {
                query = query.Where(entry => entry.Gender == gender);
            }
            // field for Name
            if (name != null)
            {
                query = query.Where(entry => entry.Name == name);
            }
            // field for Id
            if (id > 0)
            {
                query = query.Where(entry => entry.AnimalId == id);
            }
            // field for minimum age
            if (minimumAge > 0)
            {
                //Where = Returns everything where lambda object Age is g= in dataset
                query = query.Where(animal => animal.Age >= minimumAge);
            }
            return query.ToList();
        }

        // GET api/animals/{id}
        [HttpGet("{id}")]
        public ActionResult<Animal> Get(int id)
        {
            return _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
        }

        // POST api/animals
        [HttpPost /*, ActionName("PostSingle") */ ]
        public void Post([FromBody] Animal animal)
        {
            _db.Animals.Add(animal);
            _db.SaveChanges();
        }

        // [HttpPost, ActionName("PostArray")]
        // public void Post([FromBody] Animal[] animals)
        // {
        //     foreach (Animal animal in animals)
        //     {
        //         _db.Animals.Add(animal);
        //     }
        //     _db.SaveChanges();
        // }

        //PUT api/animals/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Animal animal)
        {
            animal.AnimalId = id;
            _db.Entry(animal).State = EntityState.Modified;
            _db.SaveChanges();
        }

        //DELETE api/animals/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var animalToDelete = _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
            _db.Animals.Remove(animalToDelete);
            _db.SaveChanges();
        }
    }
}