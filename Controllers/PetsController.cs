using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetPets() {
            return _context.PetHotel
            .Include(pet => pet.petOwner)
            .OrderBy(pet => pet.name)
            .ToList();
        }

        //It's getting to our DB, but it's not passing the test...
        [HttpPost]
        public IActionResult Post([FromBody] Pet pet) {

            _context.Add(pet);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPets), pet);
        }

        //This is working
        [HttpDelete("{id}")]
        public IActionResult DeletePet(int id) {
            Pet petToDelete = _context.PetHotel.Find(id);

            if (petToDelete == null) return NotFound();

            _context.PetHotel.Remove(petToDelete);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}/checkin")]
        public IActionResult CheckInPet(int id) {
             Pet petToCheckIn = _context.PetHotel.Find(id);
            
            if (petToCheckIn == null) return NotFound();

            petToCheckIn.checkedInAt = DateTime.UtcNow;
            // petToCheckIn.checkIn();
            _context.Update(petToCheckIn);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}/checkout")]
        public IActionResult CheckOutPet(int id) {
             Pet petToCheckIn = _context.PetHotel.Find(id);
            
            if (petToCheckIn == null) return NotFound();

            petToCheckIn.checkedInAt = null;
            // petToCheckIn.checkOut();
            _context.Update(petToCheckIn);
            _context.SaveChanges();

            return Ok();
        }



        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }
    }
}
