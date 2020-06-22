using CretaceousPark.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
    public ActionResult<IEnumerable<Animal>> Get()
    {
      return _db.Animals.ToList();
    }

    // GET api/animals/{id}
    [HttpGet("{id}")]
    public ActionResult<Animal> Get(int id)
    {
      return _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
    }

    // POST api/animals
    [HttpPost /*, ActionName("PostSingle") */]
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