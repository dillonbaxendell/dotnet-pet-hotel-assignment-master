using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace pet_hotel
{
    public class PetOwner
    { // database Table called PetOwner

        // fields
        public int id { get; set; }

        [Required] // <-- Attribute, will Error if missing
        public string name { get; set; }

        [Required]
        [EmailAddress]
        public string emailAddress { get; set; }

        // Will have to update when pet count goes up
        [NotMapped]
        [JsonIgnore]
        public List<Pet> pets { get; set; }

        [NotMapped]
        public int petCount { 
            get{
                return (pets == null ? 0: pets.Count);
        
            }
        }
    }
}
